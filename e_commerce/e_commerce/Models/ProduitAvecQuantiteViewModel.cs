using System;
using System.Collections.Generic;
using System.Text;

namespace e_commerce.Models
{
    class ProduitAvecQuantiteViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public decimal Prix { get; set; }
        public string UrlImage { get; set; }
        public int Quantite { get; set; }
    }
}
