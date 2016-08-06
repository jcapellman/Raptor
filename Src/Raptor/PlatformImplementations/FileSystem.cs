using System.IO;

using Newtonsoft.Json;

using Raptor.PCL.Common;
using Raptor.PCL.FileSystem;

using Environment = System.Environment;

namespace Raptor.Android.PlatformImplementations {
    public class FileSystem : BaseFileSystem {
        public override void WriteFile<T>(int fileID, T obj) {
            File.WriteAllText(GetFullPath(fileID), JsonConvert.SerializeObject(obj));
        }

        public override bool DeleteFile(int fileID) {
            if (!File.Exists(GetFullPath(fileID))) {
                return false;
            }

            File.Delete(GetFullPath(fileID));

            return true;
        }

        public override ReturnSet<T> OpenFile<T>(int fileID) {
            if (!File.Exists(GetFullPath(fileID))) {
                return new ReturnSet<T>($"{GetFullPath(fileID)} does not exist");
            }

            var json = File.ReadAllText(GetFullPath(fileID));
            
            return new ReturnSet<T>(JsonConvert.DeserializeObject<T>(json));
        }

        public override string GetBasePath() => Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        public override string GetFullPath(int fileID) => Path.Combine(GetBasePath(), fileID.ToString());
    }
}