using System.Runtime.Serialization;

namespace mba_model
{
    [DataContract]
    public class ImportType
    {
        [DataMember]
        public byte Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
