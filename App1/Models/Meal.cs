using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class Meal
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }

        public string Calories { get; set; }
        public bool ch = false;
        public bool Checked
        {
            get
            {
                return ch;
            }
            set
            {
                ch = value;
            }
        }

    }
}
