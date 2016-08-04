﻿using System;
using System.Runtime.Serialization;

namespace Raptor.PCL.WebAPI.Transports.Content {
    [DataContract]
    public class ContentSyncServerResponseItem : BaseTransport {
        [DataMember]
        public Guid FileGUID { get; set; }

        [DataMember]
        public int FileVersion { get; set; }
    }
}