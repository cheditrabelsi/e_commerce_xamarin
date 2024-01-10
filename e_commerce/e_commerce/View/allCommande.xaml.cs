using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using e_commerce.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace e_commerce.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class allCommande : ContentPage
    {
        public allCommande()
        {
            InitializeComponent();

            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            

            try
            {
               
                commandeview.ItemsSource = await App.Mydatabase.readAllCommande();
              
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
            }
        }
    }
}