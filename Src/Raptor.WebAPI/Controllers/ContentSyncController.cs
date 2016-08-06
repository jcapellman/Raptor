using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using Raptor.PCL.WebAPI.Transports.Content;
using Raptor.WebAPI.BusinessLayer.Managers;

namespace Raptor.WebAPI.Controllers {
    public class ContentSyncController : BaseController {
        [HttpGet]
        public IEnumerable<ContentSyncServerResponseItem> Get() => new ContentManager().GetServerContentListing();

        [HttpGet]
        public IEnumerable<ContentSyncFileResponseItem> Get(List<int> files) => new ContentManager().GetFiles(files);
    }
}