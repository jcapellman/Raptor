﻿using System.Runtime.Serialization;

namespace Raptor.PCL.WebAPI.Transports.LevelCreationBrowser {
    [DataContract]
    public class LevelCreationBrowserResponseItem {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int NumberDownloads { get; set; }
    }
}