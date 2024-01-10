using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace e_commerce.Models
{
    public class Categorie
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Nom { get; set; }
    }
}
