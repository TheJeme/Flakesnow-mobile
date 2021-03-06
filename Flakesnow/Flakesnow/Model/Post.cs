﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flakesnow.Model
{
    public class Post
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Time { get; set; }

        public string Date { get; set; }

        public string Days { get; set; }

        public string Hours { get; set; }

        public string Minutes { get; set; }

        public bool IsCounter { get; set; }
    }
}
