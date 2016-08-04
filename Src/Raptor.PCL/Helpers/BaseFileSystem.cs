using System;
using System.Linq;

using System.Collections.Generic;

using Raptor.PCL.Common;
using Raptor.PCL.WebAPI.Transports.Content;

namespace Raptor.PCL.Helpers {
    public abstract class BaseFileSystem {
        private List<ContentSyncServerResponseItem> _fileDB;

        public List<ContentSyncServerResponseItem> GetFileDB() => _fileDB;

        protected BaseFileSystem() {
            _fileDB = OpenFile<List<ContentSyncServerResponseItem>>(Constants.FILEDB_FILENAME);
        }

        public abstract void WriteFile<T>(string name, T obj);

        public abstract bool DeleteFile(string name);

        public abstract T OpenFile<T>(string name);

        public abstract string GetBasePath();

        public abstract string GetFullPath(string fileName);

        public List<Guid> GetHigherVersionFilesList(List<ContentSyncServerResponseItem> serverSideFiles) {
            // Delete any files on the client that aren't on the server
            foreach (var item in GetFileDB().Where(a => serverSideFiles.Any(b => b.FileGUID == a.FileGUID))) {
                DeleteFile(item.FileGUID.ToString());
            }

            // Figure out any files that are on the server or have a higher version on the server
            return (from file in serverSideFiles let clientSideFile = GetFileDB().FirstOrDefault(a => a.FileGUID == file.FileGUID) where clientSideFile == null || 
                    clientSideFile.FileVersion < file.FileVersion select file.FileGUID).ToList();
        }
    }
}