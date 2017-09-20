using System.Runtime.Serialization;

namespace Raptor.Library.WebAPI.Transports.Levels {
    [DataContract]
    public class LevelResponseItem {
        [DataMember]
        public int LevelID { get; set; }

        [DataMember]
        public string LevelData { get; set; }

        [DataMember]
        public string LevelName { get; set; }

        [DataMember]
        public string LevelDescription { get; set; }
    }
}