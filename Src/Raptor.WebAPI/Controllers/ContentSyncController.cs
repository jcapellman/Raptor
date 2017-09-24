using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

using Raptor.Library.Common;
using Raptor.Library.Enums;
using Raptor.Library.WebAPI.Transports.Content;

using Raptor.WebAPI.BusinessLayer.Managers;
using Raptor.WebAPI.BusinessLayer.Settings;
using Raptor.WebAPI.CustomAttributes;

namespace Raptor.WebAPI.Controllers {
    public class ContentSyncController : BaseController {
        public ContentSyncController(IOptions<GlobalSettings> globalSettings, IMemoryCache memoryCache) : base(globalSettings.Value, memoryCache) { }

        [HttpGet]
        [TypeFilter(typeof(Cachable), Arguments = new object[] { WEBAPI_REQUESTS.SERVERCONTENT_GET })]
        public ReturnSet<List<ContentSyncServerResponseItem>> Get() => ReturnHandler(new ContentManager(MANAGER_CONTAINER.GSetings).GetServerContentListing(), WEBAPI_REQUESTS.SERVERCONTENT_GET);

        [HttpGet("{files}")]
        public ReturnSet<List<ContentSyncFileResponseItem>> Get(string files) => ReturnHandler(new ContentManager(MANAGER_CONTAINER.GSetings).GetFiles(files.Split(',').Select(a => Convert.ToInt32(a)).ToList()), WEBAPI_REQUESTS.SERVERCONTENT_PULLDOWN);
    }
}