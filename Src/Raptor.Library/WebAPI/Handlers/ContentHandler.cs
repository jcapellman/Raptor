using System.Collections.Generic;
using System.Threading.Tasks;
using Raptor.Library.Common;
using Raptor.Library.WebAPI.Common;
using Raptor.Library.WebAPI.Transports.Content;

namespace Raptor.Library.WebAPI.Handlers {
    public class ContentHandler : BaseHandler {
        protected override string BaseControllerName() => "ContentSync";

        public async Task<ReturnSet<List<ContentSyncServerResponseItem>>> GetServerContent()
            => await GetAsync<ReturnSet<List<ContentSyncServerResponseItem>>>();

        public async Task<ReturnSet<List<ContentSyncFileResponseItem>>> GetFiles(List<int> files)
            => await GetAsync<List<int>, ReturnSet<List<ContentSyncFileResponseItem>>>(files);

        public ContentHandler(HandlerWrapperItem wrapperItem) : base(wrapperItem) { }
    }
}