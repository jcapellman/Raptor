using System;
using Raptor.Library.Enums;

namespace Raptor.Library.WebAPI.Common {
    public class HandlerWrapperItem {
        public Guid? UserID { get; set; }

        public PLATFORMS PlatformType { get; set; }
    }
}