using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace e_commerce.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Nom { get; set; }
        [NotNull]
        public string password { get; set; }
        public string role { get; set; }
    }
}
