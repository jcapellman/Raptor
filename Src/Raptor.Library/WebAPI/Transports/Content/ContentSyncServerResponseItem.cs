using System.Runtime.Serialization;

namespace Raptor.Library.WebAPI.Transports.Content {
    [DataContract]
    public class ContentSyncServerResponseItem : BaseTransport {
        [DataMember]
        public int FileID { get; set; }

        [DataMember]
        public int FileVersion { get; set; }
    }
}