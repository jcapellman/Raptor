using System.Runtime.Serialization;

namespace Raptor.PCL.WebAPI.Transports.Levels {
    public class LevelCreationRequestItem {
        [DataMember]
        public string LevelData { get; set; }

        [DataMember]
        public string LevelName { get; set; }

        [DataMember]
        public int LevelNumbr { get; set; }
    }
}