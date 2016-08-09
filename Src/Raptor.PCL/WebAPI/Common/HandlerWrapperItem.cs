using System;

using Raptor.PCL.Enums;

namespace Raptor.PCL.WebAPI.Common {
    public class HandlerWrapperItem {
        public Guid? UserID { get; set; }

        public PLATFORMS PlatformType { get; set; }
    }
}