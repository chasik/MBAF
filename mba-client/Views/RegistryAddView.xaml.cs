using System.Windows.Controls;
using mba_client.components;

namespace mba_client.Views
{
    public partial class RegistryAddView : UserControl
    {
        internal TreeListFileExplorer fileExplorer;
        public RegistryAddView()
        {
            InitializeComponent();

            fileExplorer = new TreeListFileExplorer(FileExplorerView);
        }
    }
}
