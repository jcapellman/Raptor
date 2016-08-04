using System;
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;

using Raptor.PCL.Helpers;
using Raptor.PCL.WebAPI.Transports.Content;

using Environment = System.Environment;

namespace Raptor.Android.PlatformImplementations {
    public class FileSystem : BaseFileSystem {
        public override void WriteFile<T>(string name, T obj) {
            File.WriteAllText(GetFullPath(name), JsonConvert.SerializeObject(obj));
        }

        public override bool DeleteFile(string name) {
            if (!File.Exists(GetFullPath(name))) {
                return false;
            }

            File.Delete(GetFullPath(name));

            return true;
        }

        public override T OpenFile<T>(string name) {
            var json = File.ReadAllText(GetFullPath(name));

            return JsonConvert.DeserializeObject<T>(json);
        }

        public override string GetBasePath() => Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        public override string GetFullPath(string fileName) => Path.Combine(GetBasePath(), fileName);
    }
}