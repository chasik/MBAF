using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;

namespace mba_application.ViewModels.Operator
{
    [POCOViewModel]
    public class OperatorWorkflowViewModel
    {
        protected OperatorWorkflowViewModel() { }

        public static OperatorWorkflowViewModel Create()
        {
            return ViewModelSource.Create(() => new OperatorWorkflowViewModel());
        }
    }
}