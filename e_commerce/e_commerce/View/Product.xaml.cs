using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using e_commerce.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace e_commerce.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Product : ContentPage
    {
        private int id;
        private int quantity = 1;
        public Product(int id)
        {
            InitializeComponent();
            this.id = id;
            getProduct();

        }
        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MenuUser());
        }
        async void getProduct()
        {

            Produit p = await App.Mydatabase.getProduct(id);
            if (p != null)
            {
                imageMain.Source = p.UrlImage;
                title.Text = p.Nom;
                detail.Text = p.Description;
                price.Text = p.Prix.ToString() + " dt";

            }
            else
            {

                await DisplayAlert("Erreur", "Nom d'utilisateur ou mot de passe incorrect", "OK");

            }
        }
        private void IncreaseQuantityClicked(object sender, EventArgs e)
        {
            quantity++;
            UpdateQuantityLabel();
        }
        private void DecreaseQuantityClicked(object sender, EventArgs e)
        {
            if (quantity > 1)
            {
                quantity--;
                UpdateQuantityLabel();
            }
        }

        private void UpdateQuantityLabel()
        {
            quantityLabel.Text = quantity.ToString();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            this.addCommande();
        }
        async void addCommande()
        {
            if (Preferences.Get("IsLoggedIn", false))
            {
                LigneCommande l = new LigneCommande
                {
                    IdProduit = this.id,
                    Quantite = this.quantity,

                    UserId = Preferences.Get("id", 0)
                };
                await App.Mydatabase.AjouteLigneCommande(l);
                await Navigation.PushAsync(new ligneCommande());
            }
            else
            {
                DisplayAlert("info", "you should connect", "ok");
                await Navigation.PushAsync(new login());
            }
        }
    }
}