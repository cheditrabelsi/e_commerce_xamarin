using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using e_commerce.Models;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace e_commerce
{
     public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath){
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Models.Produit>();
            db.CreateTableAsync<Models.Categorie>();
            db.CreateTableAsync<Models.User>();
            db.CreateTableAsync<Models.LigneCommande>();
            db.CreateTableAsync<Models.Commande>();
        }
        public Task<int> CreateProduit(Produit produit)
        {
            return db.InsertAsync(produit);
        }
        public Task<int> CreateCommande(Commande c)
        {
            return db.InsertAsync(c);
        }
        public Task<int> AjouteLigneCommande(LigneCommande l)
        {
            return db.InsertAsync(l);
        }
        
        public Task<List<Commande>> readAllCommande()
        {
            return db.Table<Commande>().ToListAsync();
        }
        public Task<List<Produit>> readAllProduct()
        {
            return db.Table<Produit>().ToListAsync();
        }
        public Task<int> DeleteLigneCommandeByProductId(int productId)
        {
            return db.Table<LigneCommande>().DeleteAsync(lc => lc.IdProduit == productId);
        }
        public Task<int> updateProduct(Produit pr)
        {
            return db.UpdateAsync(pr);
        }
        public Task<int> deleteProduct(Produit pr)
        {
            return db.DeleteAsync(pr);
        }
        public async Task DeleteAllCommandeAsync()
        {
            await db.DeleteAllAsync<Commande>();
        }

        public Task<int> CreateCategorie(Categorie categorie)
        {
            return db.InsertAsync(categorie);
        }
        public Task<List<Categorie>> readAllCategorie()
        {
            return db.Table<Categorie>().ToListAsync();
        }
         public Task<int> updateCategorie(Categorie categorie)
         {
             return db.UpdateAsync(categorie);
         }
        public Task<int> deleteCategorie(Categorie categorie)
        {
            return db.DeleteAsync(categorie);
        }
        public Task<int> CreateUser(User user)
        {
            return db.InsertAsync(user);
        }
        public async Task<User> getUser(string username, string password)
        {
            return await db.Table<User>().FirstOrDefaultAsync(u => u.Nom == username && u.password == password);
        }
        public async Task<User> getuser(int id)
        {
            return await db.Table<User>().FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<Produit> getProduct(int id)
        {
            return await db.Table<Produit>().FirstOrDefaultAsync(u => u.Id==id);
        }
        public async Task<List<Produit>> getAllProduct(List<int> l)
        {
            return await db.Table<Produit>().Where(p => l.Contains(p.Id)).ToListAsync();
        }
        public async Task<List<LigneCommande>> GetAllLigneCommandeForCommande(int id)
        {
            return await db.Table<LigneCommande>().Where(lc => lc.UserId == id).ToListAsync();
        }



    }

}
