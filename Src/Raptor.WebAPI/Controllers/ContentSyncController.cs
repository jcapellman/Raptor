using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Raptor.PCL.Common;
using Raptor.PCL.WebAPI.Transports.Content;

using Raptor.WebAPI.BusinessLayer.Managers;
using Raptor.WebAPI.Settings;

namespace Raptor.WebAPI.Controllers {
    public class ContentSyncController : BaseController {
        public ContentSyncController(IOptions<GlobalSettings> globalSettings) : base(globalSettings.Value) { }

        [HttpGet]
        public ReturnSet<List<ContentSyncServerResponseItem>> Get() => new ContentManager(MANAGER_CONTAINER.GSetings.DatabaseConnection).GetServerContentListing();

        [HttpGet]
        public ReturnSet<List<ContentSyncFileResponseItem>> Get([FromQuery]List<int> files) => new ContentManager(MANAGER_CONTAINER.GSetings.DatabaseConnection).GetFiles(files);
    }
}