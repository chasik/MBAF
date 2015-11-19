using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace mba_model
{
    public class ColumnHeader
    {
        public int Id { get; set; }
        public string ScreenName { get; set; }

        public int GoodColumnId { get; set; }

        public virtual GoodColumn GoodColumn { get; set; }
    }
}
