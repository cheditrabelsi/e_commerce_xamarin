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
    public partial class HomeUser : ContentPage
    {
        public HomeUser()
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
        private async void GoToProduct(object sender, EventArgs e)
        {
            if (sender is ImageButton imageButton && imageButton.CommandParameter is int id)
            {
                await Navigation.PushModalAsync(new NavigationPage(new Product(id)));
            }
        }
        private async void GoToLigneDeCommande(object sender, EventArgs e)
        {
            if (sender is ImageButton imageButton)
            {
                await Navigation.PushModalAsync(new NavigationPage(new ligneCommande()));
            }
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Preferences.Clear();
            DisplayAlert("info", "you are disconnect", "ok");
        }
    }
}