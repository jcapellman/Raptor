using System.IO;

using Newtonsoft.Json;

using Raptor.PCL.Common;
using Raptor.PCL.FileSystem;

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

        public override bool DeleteFile(int fileID) {
            var file = GetFile(fileID);

            return !file.HasError && DeleteFile(file.ReturnValue.FileName);
        }

        public override ReturnSet<T> OpenFile<T>(string name) {
            if (!File.Exists(GetFullPath(name))) {
                return new ReturnSet<T>($"{GetFullPath(name)} does not exist");
            }

            var json = File.ReadAllText(GetFullPath(name));

            return new ReturnSet<T>(JsonConvert.DeserializeObject<T>(json));
        }

        public override string GetBasePath() => Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        public override string GetFullPath(string fileName) => Path.Combine(GetBasePath(), fileName);
    }
}