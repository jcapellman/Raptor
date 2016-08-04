using System;
using System.Collections.Generic;

using Raptor.PCL.WebAPI.Transports.Content;
using Raptor.WebAPI.DataLayer.Entities;

namespace Raptor.WebAPI.BusinessLayer.Managers {
    public class ContentManager : BaseManager {
        public IEnumerable<ContentSyncServerResponseItem> GetServerContentListing() {
            return new List<ContentSyncServerResponseItem>();
        }

        public IEnumerable<ContentSyncFileResponseItem> GetFiles(List<Guid> files) {
            using (var eFactory = new EntityFactory()) {


                return new List<ContentSyncFileResponseItem>();
            }
        }
    }
}