using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace mba_ODataService.mbaf
{

    public partial class RolePermissions
    {
        public RolePermissions(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
