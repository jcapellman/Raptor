using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Raptor.PCL.WebAPI.Transports.LevelCreationBrowser {
    public class LevelCreationBrowserDetailResponseItem {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int NumDownloads { get; set; }

        [DataMember]
        public int Likes { get; set; }

        [DataMember]
        public int Dislikes { get; set; }

        [DataMember]
        public List<string> Reviews { get; set; }

        [DataMember]
        public string LongDescription { get; set; }
    }
}