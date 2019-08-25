using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using XamKvStorageInterface;

namespace XamKvStorage
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public IXamKvStorage xamKvStorage;

        public MainPage()
        {
            InitializeComponent();

            txtIntroText.Text = "This is a demo of XamKvStorage, a Xamarin.Forms analogue to " +
                "the localStorage feature in HTML5/JavaScript";

            xamKvStorage = DependencyService.Get<IXamKvStorage>();

        }

        private void btnSetValue_Clicked(object sender, EventArgs e)
        {
            bool success = xamKvStorage.SetValue("City", txtEntryValue.Text);
            if (success)
            {
                DisplayAlert("XamKvStorage", "SetValue completed, saved value of " + txtEntryValue.Text, "OK");
            }
            else
            {
                DisplayAlert("XamKvStorage", "SetValue completed, exception occurred", "OK");
            }
        }

        private void btnGetValue_Clicked(object sender, EventArgs e)
        {
            string dummy = xamKvStorage.GetValue("City");
            DisplayAlert("XamKvStorage", "GetValue returned: " + dummy, "OK");
        }
        private void btnDeleteValue_Clicked(object sender, EventArgs e)
        {
            xamKvStorage.DeleteValue("City");
            DisplayAlert("XamKvStorage", "DeleteValue successful for key.", "OK");
        }

    }

}
