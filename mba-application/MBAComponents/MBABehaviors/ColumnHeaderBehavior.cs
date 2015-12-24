using System;
using System.Windows.Controls;
using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.LayoutControl;
using mba_application.ViewModels.Import;

namespace mba_application.MBAComponents.MBABehaviors
{
    public class ColumnHeaderBehavior : Behavior<StackPanel>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseEnter += AssociatedObject_MouseEnter;
            AssociatedObject.PreviewMouseLeftButtonDown += AssociatedObject_PreviewMouseLeftButtonDown;
            AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        private static void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var stackPanel = (StackPanel)sender;
            ((ColumnHeaderValue)stackPanel.DataContext).ParentFrameworkElement = stackPanel;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseEnter -= AssociatedObject_MouseEnter;
            AssociatedObject.PreviewMouseLeftButtonDown -= AssociatedObject_PreviewMouseLeftButtonDown;
            base.OnDetaching();
        }

        private static void AssociatedObject_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.Source is CheckEdit)
                return;
            var stackPanel = (StackPanel) sender;
            var flowLayout = (FlowLayoutControl) stackPanel.Parent;

            var sheetInfo = (SheetInfo) flowLayout.DataContext;
            var workSheet = sheetInfo.WorkSheet;

            var selectedColumn = sheetInfo.SelectedColumnHeaderValue = (ColumnHeaderValue)stackPanel.DataContext;
            var selectedColumnMatches = sheetInfo.SelectedColumnMatches;

            if (Math.Abs(workSheet.Selection.LeftColumnIndex - selectedColumn.RangeInWorksheet.Left) > 0)
                workSheet.ScrollTo(selectedColumn.HeaderTableRowIndex, (int) selectedColumn.RangeInWorksheet.Left);

            workSheet.Columns[(int) selectedColumn.RangeInWorksheet.Left].AutoFit();

            workSheet.Selection = workSheet.Range.FromLTRB(
                    (int) selectedColumn.RangeInWorksheet.Left,
                    (int) selectedColumn.RangeInWorksheet.Top,
                    (int) selectedColumn.RangeInWorksheet.Right,
                    (int) selectedColumn.RangeInWorksheet.Bottom
                );

            selectedColumnMatches.Clear();
            selectedColumn.GoodColumnWithPercentMatches.ForEach(gcwp => selectedColumnMatches.Add(gcwp));
        }

        private static void AssociatedObject_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            
        }
    }
}
