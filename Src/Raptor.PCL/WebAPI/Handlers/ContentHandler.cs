using System.Collections.Generic;
using System.Threading.Tasks;

using Raptor.PCL.Common;
using Raptor.PCL.WebAPI.Transports.Content;

namespace Raptor.PCL.WebAPI.Handlers {
    public class ContentHandler : BaseHandler {
        protected override string BaseControllerName() => "ContentSync";

        public async Task<ReturnSet<List<ContentSyncServerResponseItem>>> GetServerContent()
            => await GetAsync<ReturnSet<List<ContentSyncServerResponseItem>>>();

        public async Task<ReturnSet<List<ContentSyncFileResponseItem>>> GetFiles(List<int> files)
            => await GetAsync<List<int>, ReturnSet<List<ContentSyncFileResponseItem>>>(files);
    }
}