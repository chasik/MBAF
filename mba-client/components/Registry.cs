using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.Layout.Core;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Spreadsheet;
using DevExpress.Spreadsheet;

namespace mba_client.components
{
    class Registry
    {
        private static Registry instance;
        public TreeListFileExplorer fileExplorer;
        private SpreadsheetControl excelControl;
        public Registry (DockLayoutManager layoutManager)
        {
            LayoutGroup layoutGroupRoot = layoutManager.DockController.AddDocumentGroup(DockType.Top);

            LayoutPanel panelExplorer = new LayoutPanel { Caption = "Файловая система" };
            panelExplorer.SetValue(BaseLayoutItem.ItemWidthProperty, new GridLength(280));
            fileExplorer = new TreeListFileExplorer();
            fileExplorer.SelectExcelFile += FileExplorer_SelectExcelFile;
            panelExplorer.SetValue(ContentItem.ContentProperty, fileExplorer.treeListControl);

            layoutManager.DockController.Dock(panelExplorer, layoutGroupRoot, DockType.Left);
            layoutManager.DockController.Dock(new LayoutPanel { Caption = "Результаты" }, layoutGroupRoot, DockType.Top);

            excelControl = new SpreadsheetControl();

            LayoutPanel panelExcel = new LayoutPanel { Caption = "Excel" };
            panelExcel.SetValue(ContentItem.ContentProperty, excelControl);

            layoutManager.DockController.Dock(panelExcel, layoutGroupRoot, DockType.Fill);
        }

        private void FileExplorer_SelectExcelFile(object sender, string fullFileName)
        {
            excelControl.LoadDocument(fullFileName);
            RegistryParser regParser = new RegistryParser { WorkBook = excelControl.Document };

            regParser.Analysis();

        }

        public static Registry GetInstance(DockLayoutManager layoutManager)
        {
            instance = instance ?? new Registry(layoutManager);
            return instance;
        }

        internal void Show()
        {

        }
    }
}
