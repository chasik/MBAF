using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.LayoutControl;

namespace mba_application.MBAComponents.MBABehaviors
{
    public class ColumnHeadersFlowPanelBehavior : Behavior<FlowLayoutControl>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseEnter += AssociatedObject_MouseEnter;
            AssociatedObject.PreviewMouseLeftButtonDown += AssociatedObject_PreviewMouseLeftButtonDown;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.MouseEnter -= AssociatedObject_MouseEnter;
            AssociatedObject.PreviewMouseLeftButtonDown -= AssociatedObject_PreviewMouseLeftButtonDown;
            base.OnDetaching();
        }

        private static void AssociatedObject_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private static void AssociatedObject_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }
    }
}
