using System.Runtime.Serialization;

namespace Raptor.PCL.WebAPI.Transports.LevelCreationBrowser {
    [DataContract]
    public class LevelCreationBrowserResponseItem {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int NumberDownloads { get; set; }
    }
}