using System;

using Raptor.Library.Enums;

using Raptor.WebAPI.BusinessLayer.Settings;
using Raptor.WebAPI.DataLayer.Entities;
using Raptor.WebAPI.DataLayer.Entities.Objects.Tables;

namespace Raptor.WebAPI.BusinessLayer.Managers {
    public class RequestManager : BaseManager {
        public RequestManager(GlobalSettings gSettings) : base(gSettings) { }

        public async void RecordRequest(WEBAPI_REQUESTS requestEnum, Guid? userGUID) {
            using (var eFactory = new EntityFactory(DatabaseConnection)) {
                var requestItem = new WebAPIRequestLog {
                    WebAPIRequestID = (int) requestEnum,
                    UserGUID = userGUID
                };
                
                eFactory.WebAPIRequestLog.Add(requestItem);

                await eFactory.SaveChangesAsync();
            }
        }
    }
}