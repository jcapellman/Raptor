using System;
using System.Runtime.Serialization;

namespace Raptor.PCL.WebAPI.Transports.Users {
    public class UserResponseItem {
        [DataMember]
        public Guid UserGUID { get; set; }

        [DataMember]
        public string DisplayName { get; set; }
    }
}