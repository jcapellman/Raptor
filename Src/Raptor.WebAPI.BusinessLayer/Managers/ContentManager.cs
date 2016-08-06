using System.Collections.Generic;
using System.Linq;

using Raptor.PCL.Enums;
using Raptor.PCL.WebAPI.Transports.Content;
using Raptor.WebAPI.DataLayer.Entities;

namespace Raptor.WebAPI.BusinessLayer.Managers {
    public class ContentManager : BaseManager {
        public IEnumerable<ContentSyncServerResponseItem> GetServerContentListing() {
            using (var eFactory = new EntityFactory()) {
                return eFactory.Content.Where(a => a.Active).ToList().Select(a => new ContentSyncServerResponseItem {
                    FileID = a.ID,
                    FileVersion = a.Fileversion
                }).ToList();
            }
        }

        public IEnumerable<ContentSyncFileResponseItem> GetFiles(List<int> files) {
            using (var eFactory = new EntityFactory()) {
                return
                    eFactory.Content.Where(a => files.Contains(a.ID))
                        .ToList()
                        .Select(b => new ContentSyncFileResponseItem  {
                            FileVersion = b.Fileversion,
                            FileID = b.ID,
                            ContentType = (CONTENT_TYPES) b.ContentTypeID,
                            JsonData = b.JSONData
                        }).ToList();
            }
        }
    }
}