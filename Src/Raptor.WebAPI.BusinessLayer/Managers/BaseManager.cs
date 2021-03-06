﻿using System;
using Raptor.WebAPI.BusinessLayer.Settings;

namespace Raptor.WebAPI.BusinessLayer.Managers {
    public class BaseManager {
        private readonly GlobalSettings _gSettings;

        protected Guid CurrentUserGUID;

        protected string DatabaseConnection => _gSettings.DatabaseConnection;

        public BaseManager(GlobalSettings gSettings) {
            _gSettings = gSettings;
            CurrentUserGUID = Guid.NewGuid();
        }
    }
}