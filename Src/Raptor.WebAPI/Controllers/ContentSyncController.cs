using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Raptor.PCL.Common;
using Raptor.PCL.WebAPI.Transports.Content;

using Raptor.WebAPI.BusinessLayer.Managers;
using Raptor.WebAPI.BusinessLayer.Settings;

namespace Raptor.WebAPI.Controllers {
    public class ContentSyncController : BaseController {
        public ContentSyncController(IOptions<GlobalSettings> globalSettings) : base(globalSettings.Value) { }

        [HttpGet]
        public ReturnSet<List<ContentSyncServerResponseItem>> Get() => ReturnHandler(new ContentManager(MANAGER_CONTAINER.GSetings).GetServerContentListing());

        [HttpGet("{files}")]
        public ReturnSet<List<ContentSyncFileResponseItem>> Get(string files) => ReturnHandler(new ContentManager(MANAGER_CONTAINER.GSetings).GetFiles(files.Split(',').Select(a => Convert.ToInt32(a)).ToList()));
    }
}