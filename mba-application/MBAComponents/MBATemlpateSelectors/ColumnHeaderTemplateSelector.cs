using mba_application.ViewModels.Import;
using System.Windows;
using System.Windows.Controls;

namespace mba_application.MBAComponents.MBATemlpateSelectors
{
    public class ColumnHeaderTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ColumnHeaderDefaultTemplate { get; set; }
        public DataTemplate ColumnHeaderWithRelationTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var columnHeader = (ColumnHeaderValue) item;

            return columnHeader?.RelatedColumnHeader != null ? ColumnHeaderWithRelationTemplate : ColumnHeaderDefaultTemplate;
        }
    }
}
