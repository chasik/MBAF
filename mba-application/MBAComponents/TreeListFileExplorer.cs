using DevExpress.Utils;
using DevExpress.Xpf.Grid;
using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace mba_application.MBAComponents
{
    class TreeListFileExplorer
    {
        public TreeListFileExplorer(TreeListView _treeListView)
        {
            _treeListView.NodeExpanding += treeListView_NodeExpanding;

            Helper = new FileSystemHelper();
            InitDrives(_treeListView);
        }

        private void treeListView_NodeExpanding(object sender, DevExpress.Xpf.Grid.TreeList.TreeListNodeAllowEventArgs e)
        {
            TreeListNode node = e.Node;
            if (node.Tag == null || (bool)node.Tag == false)
            {
                InitFolder(node);
                node.Tag = true;
            }
        }

        FileSystemDataProvider Helper { get; set; }

        public void InitDrives(TreeListView _treeListView)
        {
            try
            {
                string[] root = Helper.GetLogicalDrives();

                foreach (string s in root)
                {
                    TreeListNode node = new TreeListNode() {
                        Content = new FileSystemItem(s, "Drive", "<Drive>", s),
                        Image = FileSystemImages.DiskImage,
                        IsExpandButtonVisible = DefaultBoolean.True,
                        Tag = false
                    };
                    _treeListView.Nodes.Add(node);
                }
            }
            catch { }
        }
        private void InitFolder(TreeListNode treeListNode)
        {
            InitFolders(treeListNode);
            InitFiles(treeListNode);
        }

        private void InitFiles(TreeListNode treeListNode)
        {
            FileSystemItem item = treeListNode.Content as FileSystemItem;
            if (item == null) return;
            TreeListNode node;
            try
            {
                string[] root = Helper.GetFiles(item.FullName);
                foreach (string s in root)
                {
                    if (s.IndexOf(".xlsx", 0, StringComparison.InvariantCultureIgnoreCase) > -1)
                        node = new TreeListNode() { Content = new FileSystemItem(Helper.GetFileName(s), "File", Helper.GetFileSize(s).ToString(), s), Image = FileSystemImages.FileExcel2Image };
                    else if (s.IndexOf(".xls", 0, StringComparison.InvariantCultureIgnoreCase) > -1)
                        node = new TreeListNode() { Content = new FileSystemItem(Helper.GetFileName(s), "File", Helper.GetFileSize(s).ToString(), s), Image = FileSystemImages.FileExcelImage };
                    else
                        node = new TreeListNode() { Content = new FileSystemItem(Helper.GetFileName(s), "File", Helper.GetFileSize(s).ToString(), s), Image = FileSystemImages.FileImage };

                    node.IsExpandButtonVisible = DefaultBoolean.False;
                    treeListNode.Nodes.Add(node);
                }
            }
            catch { }
        }

        private void InitFolders(TreeListNode treeListNode)
        {
            FileSystemItem item = treeListNode.Content as FileSystemItem;
            if (item == null) return;

            try
            {
                string[] root = Helper.GetDirectories(item.FullName);
                foreach (string s in root)
                {
                    try
                    {
                        TreeListNode node = new TreeListNode() { Content = new FileSystemItem(Helper.GetDirectoryName(s), "Folder", "<Folder>", s), Image = FileSystemImages.ClosedFolderImage };
                        treeListNode.Nodes.Add(node);

                        node.IsExpandButtonVisible = HasFiles(s) ? DefaultBoolean.True : DefaultBoolean.False;
                    }
                    catch { }
                }
            }
            catch { }
        }

        private bool HasFiles(string path)
        {
            string[] root = Helper.GetFiles(path);
            if (root.Length > 0) return true;
            root = Helper.GetDirectories(path);
            if (root.Length > 0) return true;
            return false;
        }

        public abstract class FileSystemDataProvider
        {
            public abstract string[] GetLogicalDrives();
            public abstract string[] GetDirectories(string path);
            public abstract string[] GetFiles(string path);
            public abstract string GetDirectoryName(string path);
            public abstract string GetFileName(string path);
            public abstract long GetFileSize(string path);
        }

        public class FileSystemHelper : FileSystemDataProvider
        {
            public override string[] GetLogicalDrives()
            {
                return Directory.GetLogicalDrives();
            }
            public override string[] GetDirectories(string path)
            {
                return Directory.GetDirectories(path);
            }
            public override string[] GetFiles(string path)
            {
                return Directory.GetFiles(path);
            }
            public override string GetDirectoryName(string path)
            {
                return new DirectoryInfo(path).Name;
            }
            public override string GetFileName(string path)
            {
                return new FileInfo(path).Name;
            }
            public override long GetFileSize(string path)
            {
                return new FileInfo(path).Length;
            }
        }
    }
    public class FileSystemItem
    {
        public FileSystemItem(string name, string type, string size, string fullName)
        {
            Name = name;
            ItemType = type;
            Size = size;
            FullName = fullName;
        }
        public string Name { get; set; }
        public string ItemType { get; set; }
        public string Size { get; set; }
        public string FullName { get; set; }
    }

    public class FileSystemImages
    {
        static BitmapImage fileImage;
        public static BitmapImage FileImage
        {
            get
            {
                if (fileImage == null)
                    fileImage = LoadImage("file-simple");
                return fileImage;
            }
        }
        static BitmapImage diskImage;
        public static BitmapImage DiskImage
        {
            get
            {
                if (diskImage == null)
                    diskImage = LoadImage("disk-orange");
                return diskImage;
            }
        }
        static BitmapImage fileExcelImage;
        public static BitmapImage FileExcelImage
        {
            get
            {
                if (fileExcelImage == null)
                    fileExcelImage = LoadImage("file-excel-orange");
                return fileExcelImage;
            }
        }
        static BitmapImage fileExcel2Image;
        public static BitmapImage FileExcel2Image
        {
            get
            {
                if (fileExcel2Image == null)
                    fileExcel2Image = LoadImage("file-excel2-orange");
                return fileExcel2Image;
            }
        }
        static BitmapImage closedFolderImage;
        public static BitmapImage ClosedFolderImage
        {
            get
            {
                if (closedFolderImage == null)
                    closedFolderImage = LoadImage("folder-closed");
                return closedFolderImage;
            }
        }
        static BitmapImage openedFolderImage;
        public static BitmapImage OpenedFolderImage
        {
            get
            {
                if (openedFolderImage == null)
                    openedFolderImage = LoadImage("folder-opened");
                return openedFolderImage;
            }
        }
        static BitmapImage LoadImage(string imageName)
        {
            return new BitmapImage(new Uri("pack://application:,,,/mba-application;component/Resources/Images/FileSystem/" + imageName + ".png"));
        }
    }
}
