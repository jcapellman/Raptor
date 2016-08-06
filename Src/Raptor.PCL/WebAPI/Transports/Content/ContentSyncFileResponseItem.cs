﻿using System;
using System.Runtime.Serialization;

using Raptor.PCL.Enums;

namespace Raptor.PCL.WebAPI.Transports.Content {
    [DataContract]
    public class ContentSyncFileResponseItem : BaseTransport {
        [DataMember]
        public int FileID { get; set; }

        [DataMember]
        public int FileVersion { get; set; }

        [DataMember]
        public CONTENT_TYPES ContentType { get; set; }

        [DataMember]
        public string JsonData { get; set; }
    }
}