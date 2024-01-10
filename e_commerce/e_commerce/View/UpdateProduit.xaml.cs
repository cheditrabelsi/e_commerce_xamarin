using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class UpdateProduit : ContentPage
    {
        private Produit selectedProduct;
        private string imageUrl;

        public  UpdateProduit(Produit selectedProduit)
        {
            InitializeComponent();
            this.selectedProduct = selectedProduit;
            nomEntry.Text = this.selectedProduct.Nom;
            DescriptionEntry.Text= selectedProduit.Description;
            prixEntry.Text = selectedProduct.Prix.ToString();
            getAllCategorie();
        }
        public async void getAllCategorie()
        {
            var categories = await App.Mydatabase.readAllCategorie(); 
            var categoryNames = categories.Select(c => c.Nom).ToList(); 

            categoryPicker.ItemsSource = categoryNames;

        }
        private async void Button_Clicked(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(nomEntry.Text))
            {
                await DisplayAlert("invalid", "sdsd", "ok");
            }
            else
            {
                updateproduit();
            }

        }
        async void updateproduit()
        {
            await App.Mydatabase.updateProduct(new Models.Produit
            {
                Id = selectedProduct.Id,
                Nom = nomEntry.Text,
                Description = DescriptionEntry.Text,
                IdCategorie = categoryPicker.SelectedIndex,
                UrlImage = imageUrl,
                Prix = Decimal.Parse(prixEntry.Text)
            }); 

            await Navigation.PushAsync(new homePage());
        }
private async void OnImageButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var pickResult = await MediaPicker.PickPhotoAsync();
                if (pickResult != null)
                {
                    selectedImage.Source = ImageSource.FromStream(() => pickResult.OpenReadAsync().Result);
                    imageUrl = pickResult.FullPath;

                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erreur : {ex.Message}");
            }
        }
    }
}