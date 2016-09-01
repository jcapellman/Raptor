using System;
using System.Collections.Generic;
using System.Linq;

using Raptor.PCL.Common;
using Raptor.PCL.WebAPI.Transports.LevelCreationBrowser;

using Raptor.WebAPI.BusinessLayer.Settings;
using Raptor.WebAPI.DataLayer.Entities;

namespace Raptor.WebAPI.BusinessLayer.Managers {
    public class LevelCreationBrowserManager : BaseManager {
        public LevelCreationBrowserManager(GlobalSettings gSettings) : base(gSettings) { }

        public ReturnSet<List<LevelCreationBrowserResponseItem>> GetLevelsListing() {
            try {
                using (var eFactory = new EntityFactory(DatabaseConnection)) {
                    var result = eFactory.Levels.Where(a => a.Active).ToList();

                    var response = result.Select(a => new LevelCreationBrowserResponseItem {
                        Name = a.LevelName,
                        NumberDownloads = 0
                    }).ToList();

                    return new ReturnSet<List<LevelCreationBrowserResponseItem>>(response);
                }
            } catch (Exception ex) {
                return new ReturnSet<List<LevelCreationBrowserResponseItem>>(ex);
            }
        }
    }
}