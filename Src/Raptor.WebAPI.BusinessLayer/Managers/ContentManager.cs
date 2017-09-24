using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using Raptor.Library.Common;
using Raptor.Library.Enums;
using Raptor.Library.WebAPI.Transports.Content;

using Raptor.WebAPI.BusinessLayer.Settings;
using Raptor.WebAPI.DataLayer.Entities;

namespace Raptor.WebAPI.BusinessLayer.Managers {
    public class ContentManager : BaseManager {
        public ReturnSet<List<ContentSyncServerResponseItem>> GetServerContentListing() {
            using (var eFactory = new EntityFactory(DatabaseConnection)) {
                var response = eFactory.Content.Where(a => a.Active).AsNoTracking().ToList().Select(a => new ContentSyncServerResponseItem {
                    FileID = a.ID,
                    FileVersion = a.Fileversion
                }).ToList();

                return new ReturnSet<List<ContentSyncServerResponseItem>>(response);
            }
        }

        public ReturnSet<List<ContentSyncFileResponseItem>> GetFiles(List<int> files) {
            using (var eFactory = new EntityFactory(DatabaseConnection)) {
                return new ReturnSet<List<ContentSyncFileResponseItem>>(
                    eFactory.Content.Where(a => files.Contains(a.ID) && a.Active).AsNoTracking()
                        .ToList()
                        .Select(b => new ContentSyncFileResponseItem {
                            FileVersion = b.Fileversion,
                            FileID = b.ID,
                            ContentType = (CONTENT_TYPES)b.ContentTypeID,
                            JsonData = b.JSONData
                        }).ToList());
            }
        }

        public ContentManager(GlobalSettings gSettings) : base(gSettings) { }
    }
}