using System.Runtime.Serialization;

namespace Raptor.Library.WebAPI.Transports.HighScore {
    [DataContract]
    public class HighScoreListResponseItem {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public int HighScore { get; set; }
    }
}