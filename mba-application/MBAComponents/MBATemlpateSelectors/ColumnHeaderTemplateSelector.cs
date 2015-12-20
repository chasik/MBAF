using mba_application.ViewModels.Import;
using System.Windows;
using System.Windows.Controls;

namespace mba_application.MBAComponents.MBATemlpateSelectors
{
    class ColumnHeaderTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ColumnHeaderDefaultTemplate { get; set; }
        public DataTemplate ColumnHeaderWithRelationTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            ColumnHeaderValue columnHeader = item as ColumnHeaderValue;

            if (columnHeader.RelatedColumnHeader != null)
                return ColumnHeaderWithRelationTemplate;
            else
                return ColumnHeaderDefaultTemplate;
        }
    }
}
