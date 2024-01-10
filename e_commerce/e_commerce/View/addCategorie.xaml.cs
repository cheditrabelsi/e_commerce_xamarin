using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace e_commerce.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class addCategorie : ContentPage
    {
        public addCategorie()
        {
            InitializeComponent();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nomEntry.Text))
            {
                await DisplayAlert("invalid", "sdsd", "ok");
            }
            else
            {
                AddCategorie();
            }

        }
        async void AddCategorie()
        {
            await App.Mydatabase.CreateCategorie(new Models.Categorie
            {
                Nom = nomEntry.Text
            });
            await Navigation.PushAsync(new homePage());
        }
    }
}