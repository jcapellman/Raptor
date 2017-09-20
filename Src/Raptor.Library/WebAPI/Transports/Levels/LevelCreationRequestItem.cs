using System.Runtime.Serialization;

namespace Raptor.Library.WebAPI.Transports.Levels {
    public class LevelCreationRequestItem {
        [DataMember]
        public string LevelData { get; set; }

        [DataMember]
        public string LevelName { get; set; }

        [DataMember]
        public string LevelDescription { get; set; }
    }
}