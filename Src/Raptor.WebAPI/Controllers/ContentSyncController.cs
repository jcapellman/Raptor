using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using Raptor.PCL.Common;
using Raptor.PCL.WebAPI.Transports.Content;

using Raptor.WebAPI.BusinessLayer.Managers;

namespace Raptor.WebAPI.Controllers {
    public class ContentSyncController : BaseController {
        [HttpGet]
        public ReturnSet<List<ContentSyncServerResponseItem>> Get() => new ContentManager().GetServerContentListing();

        [HttpGet]
        public ReturnSet<List<ContentSyncFileResponseItem>> Get([FromQuery]List<int> files) => new ContentManager().GetFiles(files);
    }
}