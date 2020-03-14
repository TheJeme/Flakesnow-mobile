using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flakesnow.Model
{
    public class Post
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Title { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [MaxLength(250)]
        public string Time { get; set; }

        [MaxLength(250)]
        public string Date { get; set; }

        public bool IsCounter { get; set; }
    }
}
