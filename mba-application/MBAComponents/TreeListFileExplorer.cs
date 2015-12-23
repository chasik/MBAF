using DevExpress.Utils;
using DevExpress.Xpf.Grid;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace mba_application.MBAComponents
{
    public class TreeListFileExplorer
    {
        public TreeListFileExplorer(TreeListView treeListView)
        {
            treeListView.NodeExpanding += treeListView_NodeExpanding;

            Helper = new FileSystemHelper();
            InitDrives(treeListView);
        }

        private void treeListView_NodeExpanding(object sender, DevExpress.Xpf.Grid.TreeList.TreeListNodeAllowEventArgs e)
        {
            var node = e.Node;
            if (node.Tag != null && (bool) node.Tag)
                return;

            InitFolder(node);
            node.Tag = true;
        }

        public FileSystemDataProvider Helper { get; set; }

        public void InitDrives(TreeListView treeListView)
        {
            try
            {
                var root = Helper.GetLogicalDrives();

                foreach (var s in root)
                {
                    var node = new TreeListNode() {
                        Content = new FileSystemItem(s, "Drive", "<Drive>", s),
                        Image = FileSystemImages.DiskImage,
                        IsExpandButtonVisible = DefaultBoolean.True,
                        Tag = false
                    };
                    treeListView.Nodes.Add(node);
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(e.Message);
            }
        }
        private void InitFolder(TreeListNode treeListNode)
        {
            InitFolders(treeListNode);
            InitFiles(treeListNode);
        }

        private void InitFiles(TreeListNode treeListNode)
        {
            var item = treeListNode.Content as FileSystemItem;
            if (item == null) return;

            try
            {
                var root = Helper.GetFiles(item.FullName);
                foreach (var s in root)
                {
                    
                    TreeListNode node;
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
            catch (Exception)
            {
                //MessageBox.Show(e.Message);
            }
        }

        private void InitFolders(TreeListNode treeListNode)
        {
            var item = treeListNode.Content as FileSystemItem;
            if (item == null) return;

            try
            {
                var root = Helper.GetDirectories(item.FullName);
                foreach (var s in root)
                {
                    var node = new TreeListNode()
                    {
                        Content = new FileSystemItem(Helper.GetDirectoryName(s), "Folder", "<Folder>", s),
                        Image = FileSystemImages.ClosedFolderImage
                    };
                    treeListNode.Nodes.Add(node);

                    node.IsExpandButtonVisible = HasFiles(s) ? DefaultBoolean.True : DefaultBoolean.False;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(e.Message);
            }
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
        static BitmapImage _fileImage;
        public static BitmapImage FileImage => _fileImage ?? (_fileImage = LoadImage("file-simple"));

        static BitmapImage _diskImage;
        public static BitmapImage DiskImage => _diskImage ?? (_diskImage = LoadImage("disk-orange"));

        static BitmapImage _fileExcelImage;
        public static BitmapImage FileExcelImage => _fileExcelImage ?? (_fileExcelImage = LoadImage("file-excel-orange"));

        static BitmapImage _fileExcel2Image;
        public static BitmapImage FileExcel2Image => _fileExcel2Image ?? (_fileExcel2Image = LoadImage("file-excel2-orange"));

        static BitmapImage _closedFolderImage;
        public static BitmapImage ClosedFolderImage => _closedFolderImage ?? (_closedFolderImage = LoadImage("folder-closed"));

        static BitmapImage _openedFolderImage;
        public static BitmapImage OpenedFolderImage => _openedFolderImage ?? (_openedFolderImage = LoadImage("folder-opened"));

        public static BitmapImage LoadImage(string imageName)
        {
            return new BitmapImage(new Uri("pack://application:,,,/mba-application;component/Resources/Images/FileSystem/" + imageName + ".png"));
        }
    }
}
