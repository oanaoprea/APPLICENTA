﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class Workout
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string CaloriesBurnt { get; set; }
    }
}
