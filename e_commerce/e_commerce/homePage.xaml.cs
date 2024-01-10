using e_commerce.Models;
using e_commerce.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace e_commerce
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class homePage : ContentPage
    {
       public homePage()
        {
            InitializeComponent();
        }
        
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing(); 
                 myCollectionView.ItemsSource = await App.Mydatabase.readAllProduct();
                 myCollectionViewca.ItemsSource = await App.Mydatabase.readAllCategorie();
            }
            catch { }
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Preferences.Clear();
            DisplayAlert("info", "you are disconnect", "ok");
            await Navigation.PushModalAsync(new MenuUser());

        }

        private async void deleteCategorie(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            if (button != null)
            {
                var selectedCategorie = button?.BindingContext as Categorie;

                if (selectedCategorie != null)
                {
                    bool answer = await DisplayAlert("Confirmation", "Voulez-vous vraiment supprimer cette catégorie ?", "Oui", "Non");

                    if (answer)
                    {
                        await App.Mydatabase.deleteCategorie(selectedCategorie);
                        await Navigation.PushAsync(new homePage());

                    }
                }
            }
        }


        async void UpdateCategorie(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            if (button != null)
            {
                var selectedCategorie = button?.BindingContext as Categorie;
               
                if (selectedCategorie != null)
                {
                    await Navigation.PushAsync(new UpdateCategorie(selectedCategorie));
                }
            }

        }

        private async void deleteProduit(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            if (button != null)
            {
                var selectedProduit = button?.BindingContext as Produit;

                if (selectedProduit != null)
                {
                    bool answer = await DisplayAlert("Confirmation", "Voulez-vous vraiment supprimer cette catégorie ?", "Oui", "Non");

                    if (answer)
                    {
                        await App.Mydatabase.deleteProduct(selectedProduit);
                        await Navigation.PushAsync(new homePage());

                    }
                }
            }
        }


        async void UpdateProduit(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            if (button != null)
            {
                var selectedProduct = button?.BindingContext as Produit;

                if (selectedProduct != null)
                {
                    await Navigation.PushAsync(new UpdateProduit(selectedProduct));
                }
            }

        }
    }
}