using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpf.Docking;

namespace mba_client.components
{
    class Registry
    {
        private static Registry instance;
        public Registry (DockLayoutManager layoutManager)
        {
                 //       < dxdo:LayoutGroup >
                 //< dxdo:DocumentGroup >
                 //     < dxdo:DocumentPanel Caption = "Document" >
                 //          < Grid />
                 //      </ dxdo:DocumentPanel >
                 //       < dxdo:DocumentPanel Caption = "Document" >
                 //            < Grid />
                 //        </ dxdo:DocumentPanel >
                 //     </ dxdo:DocumentGroup >
                 //  </ dxdo:LayoutGroup >
        }

        public static Registry GetInstance(DockLayoutManager layoutManager)
        {
            instance = instance ?? new Registry(layoutManager);
            return instance;
        }

        internal void Show()
        {
            throw new NotImplementedException();
        }
    }
}
