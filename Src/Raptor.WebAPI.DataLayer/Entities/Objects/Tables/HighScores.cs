﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raptor.WebAPI.DataLayer.Entities.Objects.Tables {
    [Table("HighScores")]
    public class HighScores {
        [Key]
        public int ID { get; set; }

        public DateTimeOffset Modified { get; set; }

        public DateTimeOffset Created { get; set; }

        public bool Active { get; set; }

        public string Username { get; set; }

        public int HighScore { get; set; }

        public int LevelID { get; set; }
    }
}