﻿using System;
using System.Threading.Tasks;
using Raptor.Library.FileSystem;
using Raptor.Library.WebAPI.Common;
using Raptor.Library.WebAPI.Handlers;

namespace Raptor.Library.Managers {
    public class ContentSyncManager : BaseManager {
        public ContentSyncManager() { }

        public async Task<bool> SymcServerFiles(BaseFileSystem fileSystem) {
            if (fileSystem == null) {
                throw new Exception("fileSystem is null");
            }

            var contentHandler = new ContentHandler(new HandlerWrapperItem());

            var serverFiles = await contentHandler.GetServerContent();

            if (serverFiles.HasError) {
                throw new Exception(serverFiles.ExceptionMessage);
            }

            var filesNeedingUpdates = fileSystem.GetHigherVersionFilesList(serverFiles.ReturnValue);

            var updatedFiles = await contentHandler.GetFiles(filesNeedingUpdates);

            if (updatedFiles.HasError) {
                throw new Exception(updatedFiles.ExceptionMessage);
            }

            fileSystem.AddFiles(updatedFiles.ReturnValue);

            return true;
        }
    }
}