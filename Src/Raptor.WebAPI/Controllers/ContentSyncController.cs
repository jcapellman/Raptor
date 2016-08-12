using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

using Raptor.PCL.Common;
using Raptor.PCL.Enums;
using Raptor.PCL.WebAPI.Transports.Content;

using Raptor.WebAPI.BusinessLayer.Managers;
using Raptor.WebAPI.BusinessLayer.Settings;

namespace Raptor.WebAPI.Controllers {
    public class ContentSyncController : BaseController {
        public ContentSyncController(IOptions<GlobalSettings> globalSettings, IMemoryCache memoryCache) : base(globalSettings.Value, memoryCache) { }

        [HttpGet]
        public ReturnSet<List<ContentSyncServerResponseItem>> Get() => ReturnHandler(new ContentManager(MANAGER_CONTAINER.GSetings).GetServerContentListing(), WebAPIRequests.SERVERCONTENT_GET);

        [HttpGet("{files}")]
        public ReturnSet<List<ContentSyncFileResponseItem>> Get(string files) => ReturnHandler(new ContentManager(MANAGER_CONTAINER.GSetings).GetFiles(files.Split(',').Select(a => Convert.ToInt32(a)).ToList()), WebAPIRequests.SERVERCONTENT_PULLDOWN);
    }
}