﻿using System.Runtime.Serialization;

namespace Raptor.PCL.WebAPI.Transports.Levels {
    [DataContract]
    public class LevelCreationUpdateRequestItem {
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