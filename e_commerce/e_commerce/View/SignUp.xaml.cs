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
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();
        }
        async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nomEntry.Text) || string.IsNullOrWhiteSpace(passEntry.Text)) 
            {
                await DisplayAlert("invalid", "verifier las champs", "ok");
            }
            else
            {
                AddUser();
            }

        }
        async void AddUser()
        {
            await App.Mydatabase.CreateUser(new Models.User
            {
                Nom = nomEntry.Text,
                password=passEntry.Text,
                role="user"
            });
            await Navigation.PushAsync(new login());
        }
    }
}