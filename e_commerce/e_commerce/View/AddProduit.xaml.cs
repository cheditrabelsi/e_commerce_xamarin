using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace e_commerce.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProduit : ContentPage
    {
        
        private string imageUrl;
        private List<Models.Categorie> categoriesList;
        public AddProduit()
        {
            InitializeComponent();
            categoryPicker.Items.Add("Catégorie 1");
            categoryPicker.Items.Add("Catégorie 2");
            _ = LoadCategoriesAsync();
            
        }
        private async Task LoadCategoriesAsync()
        {
            categoriesList = await App.Mydatabase.readAllCategorie();
            foreach (var categorie in categoriesList)
            {
                categoryPicker.Items.Add(categorie.Nom);
            }
        }
        async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nomEntry.Text))
            {
                await DisplayAlert("invalid", "sdsd", "ok");
            }
            else
            {
                addProduit();
            }

        }
        async void addProduit()
        {
            var selectedCategory = categoriesList.FirstOrDefault(c => c.Nom == categoryPicker.SelectedItem.ToString());
            if (selectedCategory != null)
            {
                if (decimal.TryParse(prixEntry.Text, out decimal prix))
                {
                    await App.Mydatabase.CreateProduit(new Models.Produit
                    {
                        Nom = nomEntry.Text,
                        Description = DescriptionEntry.Text,
                        Prix = prix,
                        UrlImage = imageUrl,
                        IdCategorie = selectedCategory.Id
                    });

                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Erreur", "Le prix saisi est invalide.", "OK");
                }
            }
            else
            {
                await DisplayAlert("Erreur", "Veuillez sélectionner une catégorie.", "OK");
            }
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