using System.Runtime.Serialization;

namespace Raptor.PCL.WebAPI.Transports.HighScore {
    [DataContract]
    public class HighScoreListResponseItem {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public int HighScore { get; set; }
    }
}