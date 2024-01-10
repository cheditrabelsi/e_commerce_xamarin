using e_commerce.Models;
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
    public partial class UpdateCategorie : ContentPage
    {
        private Categorie selectedCategorie;
        public UpdateCategorie(Categorie selectedCategorie)
        {
            InitializeComponent();
            this.selectedCategorie = selectedCategorie;
            nomEntry.Text = selectedCategorie.Nom;
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nomEntry.Text))
            {
                await DisplayAlert("invalid", "sdsd", "ok");
            }
            else
            {
                updateCategorie();
            }

        }
        async void updateCategorie()
        {
            await App.Mydatabase.updateCategorie(new Models.Categorie
            {
                Id=selectedCategorie.Id,
                Nom = nomEntry.Text
              
            });
            
            await Navigation.PushAsync(new homePage());
        }
    }
}