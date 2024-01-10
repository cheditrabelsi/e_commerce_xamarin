using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using e_commerce.Models;
using System.Diagnostics;
using System.Windows.Input;

namespace e_commerce.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ligneCommande : ContentPage
    {
        Decimal somme = 0;
        public ligneCommande()
        {
            InitializeComponent();

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                int id = Preferences.Get("id", 0);
                if (Preferences.Get("IsLoggedIn", false))
                {
                    List<LigneCommande> lignesCommande = await App.Mydatabase.GetAllLigneCommandeForCommande(id);
                    List<ProduitAvecQuantiteViewModel> produitsAvecQuantite = new List<ProduitAvecQuantiteViewModel>();

                    foreach (var ligneCommande in lignesCommande)
                    {
                        Produit produit = await App.Mydatabase.getProduct(ligneCommande.IdProduit);

                        if (produit != null)
                        {
                            somme = somme + produit.Prix;
                            ProduitAvecQuantiteViewModel produitAvecQuantite = new ProduitAvecQuantiteViewModel
                            {
                                Nom = produit.Nom,
                                Prix = produit.Prix,
                                UrlImage = produit.UrlImage,
                                Quantite = ligneCommande.Quantite,
                                Id = ligneCommande.IdProduit
                            };

                            produitsAvecQuantite.Add(produitAvecQuantite);
                        }
                    }
                    total.Text = somme.ToString();
                    collectionView.ItemsSource = produitsAvecQuantite;
                }
                else
                {
                    DisplayAlert("info", "you don't have nothing", "ok");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
            }
        }






        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MenuUser());
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("info", "your command is valid", "ok");
            Commande c = new Commande();
            int id = Preferences.Get("id", 0);
            User u = await App.Mydatabase.getuser(id);
            List<LigneCommande> lignesCommande = await App.Mydatabase.GetAllLigneCommandeForCommande(id);
            c.NomClient = u.Nom;
            c.LignesCommande = lignesCommande;
            await App.Mydatabase.CreateCommande(c);




        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            if (sender is ImageButton button)
            {
                if (button.CommandParameter != null)
                {
                    if (button.CommandParameter is int productId)
                    {
                        await DisplayAlert("Alert", $"Supprimer le produit avec l'ID : {productId}", "OK");
                        
                        await App.Mydatabase.DeleteLigneCommandeByProductId(productId);
                        OnAppearing();
                    }
                    else
                    {
                        await DisplayAlert("Alert", $"CommandParameter is not int. Type: {button.CommandParameter.GetType().FullName}", "OK");
                    }
                }
                else
                {
                  await DisplayAlert("Alert", "CommandParameter is null", "OK");
                }
            }
            else
            {
                await DisplayAlert("Alert", "sender is not ImageButton", "OK");
            }
        }

        private void plus(object sender, EventArgs e)
        {
            
        }
        private void moins(object sender, EventArgs e)
        {

        }
    }

    }
