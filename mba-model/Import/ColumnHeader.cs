using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace mba_model
{
    [DataContract]
    public class ColumnHeader
    {
        [DataMember]
        public int Id { get; set; }
<<<<<<< HEAD

        [DataMember]
        public string Name { get; set; }
=======
        public string ScreenName { get; set; }
>>>>>>> 6ffeacc5dd44d3de79ee0143d8c9452c1a7cc2bb

        [DataMember]
        public int GoodColumnId { get; set; }

<<<<<<< HEAD
        [DataMember]
=======
>>>>>>> 6ffeacc5dd44d3de79ee0143d8c9452c1a7cc2bb
        public virtual GoodColumn GoodColumn { get; set; }
    }
}
