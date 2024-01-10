using e_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace e_commerce.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        public login()
        {
            InitializeComponent();
        }
        async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nomEntry.Text)||string.IsNullOrWhiteSpace(PassEntry.Text))
            {
                await DisplayAlert("invalid", "verifier les champs", "ok");
            }
            else
            {
                getuser();
            }
        }
        async void getuser()
        {
            string nom = nomEntry.Text;
            string pass = PassEntry.Text;
            User user = await App.Mydatabase.getUser(nom, pass);
            if (user != null)
            {
                
                Preferences.Set("IsLoggedIn", true);
                Preferences.Set("nom",nom);
                Preferences.Set("id", user.Id);
                
                if (user.role == "admin")
                {
                    
                    await Navigation.PushModalAsync(new MainPage());
                }
                else
                {
                    await Navigation.PushAsync(new MenuUser());
                }
            }
            else
            {
                
                await DisplayAlert("Erreur", "Nom d'utilisateur ou mot de passe incorrect", "OK");
                
            }
        }

    }
}