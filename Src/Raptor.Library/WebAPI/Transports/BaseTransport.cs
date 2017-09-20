using Newtonsoft.Json;

namespace Raptor.Library.WebAPI.Transports {
    public class BaseTransport {
        public string ToJSON() => JsonConvert.SerializeObject(this);

        public static T FromJSON<T>(string json) => JsonConvert.DeserializeObject<T>(json);
    }
}