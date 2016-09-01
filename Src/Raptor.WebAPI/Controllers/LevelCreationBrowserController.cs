using System.Collections.Generic;

using Microsoft.Extensions.Caching.Memory;

using Raptor.PCL.Common;
using Raptor.PCL.Enums;
using Raptor.PCL.WebAPI.Transports.LevelCreationBrowser;

using Raptor.WebAPI.BusinessLayer.Managers;
using Raptor.WebAPI.BusinessLayer.Settings;

namespace Raptor.WebAPI.Controllers {
    public class LevelCreationBrowserController : BaseController {
        public LevelCreationBrowserController(GlobalSettings globalSettings, IMemoryCache memoryCache) : base(globalSettings, memoryCache) { }

        public ReturnSet<List<LevelCreationBrowserResponseItem>> GET()
            =>
                ReturnHandler(new LevelCreationBrowserManager(_globalSettings).GetLevelsListing(),
                    WEBAPI_REQUESTS.LEVELCREATION_BROWSER_GET_LISTING);
    }
}