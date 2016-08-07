using System.Runtime.Serialization;

namespace Raptor.PCL.WebAPI.Transports.HighScore {
    [DataContract]
    public class HighScoreRequestItem : BaseTransport {
        [DataMember]
        public int LevelID { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public int HighScore { get; set; }
    }
}