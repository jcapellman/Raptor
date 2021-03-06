﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Raptor.WebAPI.DataLayer.Entities.Objects.Tables {
    public class WebAPIRequests {
        [Key]
        public int ID { get; set; }

        public DateTimeOffset Modified { get; set; }

        public DateTimeOffset Created { get; set; }

        public bool Active { get; set; }

        public string Description { get; set; }
    }
}