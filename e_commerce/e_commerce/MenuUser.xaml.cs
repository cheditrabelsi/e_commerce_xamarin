using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace e_commerce
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuUser : FlyoutPage
    {
        public MenuUser()
        {
            InitializeComponent();
            flyoutUser.listviewUser.ItemSelected += OnSelectedItem;
        }

        private void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlayoutPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetPage));
                flyoutUser.listviewUser.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}