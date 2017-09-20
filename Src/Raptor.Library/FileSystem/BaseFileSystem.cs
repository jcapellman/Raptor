using System.Collections.Generic;
using System.Linq;
using Raptor.Library.Common;
using Raptor.Library.WebAPI.Transports.Content;

namespace Raptor.Library.FileSystem {
    public abstract class BaseFileSystem {
        private readonly List<ContentSyncServerResponseItem> _fileDB;

        public List<ContentSyncServerResponseItem> GetFileDB() => _fileDB;

        protected BaseFileSystem() {
            var result = OpenFile<List<ContentSyncServerResponseItem>>(Constants.FILEDB_ID);

            _fileDB = result.HasError ? new List<ContentSyncServerResponseItem>() : result.ReturnValue;
        }

        public ReturnSet<ContentSyncServerResponseItem> GetFile(int fileID) {
            var file = GetFileDB().FirstOrDefault(a => a.FileID == fileID);

            return file == null ? new ReturnSet<ContentSyncServerResponseItem>($"Could not obtain {fileID} from DB") : new ReturnSet<ContentSyncServerResponseItem>(file);
        }

        public abstract void WriteFile<T>(int fileID, T obj);

        public abstract bool DeleteFile(int fileID);

        public abstract ReturnSet<T> OpenFile<T>(int fileID);

        public abstract string GetBasePath();

        public abstract string GetFullPath(int fileID);

        public List<int> GetHigherVersionFilesList(List<ContentSyncServerResponseItem> serverSideFiles) {
            // If the database is empty - just download everything without wasting cycles
            if (!GetFileDB().Any()) {
                return serverSideFiles.Select(a => a.FileID).ToList();
            }

            // Delete any files on the client that aren't on the server
            foreach (var item in GetFileDB().Where(a => serverSideFiles.Any(b => b.FileID == a.FileID))) {
                DeleteFile(item.FileID);
            }

            // Figure out any files that are on the server or have a higher version on the server
            return (from file in serverSideFiles let clientSideFile = GetFileDB().FirstOrDefault(a => a.FileID == file.FileID) where clientSideFile == null ||
                    clientSideFile.FileVersion < file.FileVersion select file.FileID).ToList();
        }

        public void AddFiles(List<ContentSyncFileResponseItem> updatedFiles) {
            foreach (var file in updatedFiles) {
                WriteFile(file.FileID, file.JsonData);

                _fileDB.Add(new ContentSyncServerResponseItem {
                    FileID = file.FileID,
                    FileVersion = file.FileVersion
                });
            }
        }
    }
}