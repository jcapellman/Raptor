﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raptor.WebAPI.DataLayer.Entities.Objects.Tables {
    [Table("Content")]
    public class Content {
        [Key]
        public int ID { get; set; }

        public DateTimeOffset Modified { get; set; }

        public DateTimeOffset Created { get; set; }

        public bool Active { get; set; }

        public int ContentTypeID { get; set; }

        public string Filename { get; set; }

        public int Fileversion { get; set; }

        public string JSONData { get; set; }
    }
}