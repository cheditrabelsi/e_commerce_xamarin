using SQLite;
using System;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;
using System.Text;

namespace e_commerce.Models
{
    public class LigneCommande
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Produit))]
        public int IdProduit { get; set; }
        [ForeignKey(typeof(Commande))]
        public int Quantite { get; set; }
        [ForeignKey(typeof(User))]
        public int UserId { get; set; }
    }
}
