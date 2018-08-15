
using CallMeMaybe.ViewModel;
using CallMeMaybe.Views;
using Contacts.Model;
using Contacts.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contacts.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoaderPage : ContentPage
	{
        ApiService api;
        ContactsViewModel vm;
        List<Contact> _contacts;

        public LoaderPage ()
		{
            api = new ApiService();
			InitializeComponent ();
            RetrieveContactsAsync();
		}


        public async void RetrieveContactsAsync()
        {
            message.Text = "Downloading Contacts...";
            _contacts = await api.sendRequest<String>();
            await Task.Delay(2000);
            if (_contacts != null && _contacts.Count > 0)
            {
                proceed.IsVisible = false;
                //Save Model
                var page = new ContactListPage(_contacts);
                await Navigation.PushModalAsync(page);
            } else
            {
                message.Text = "An error occurred" + Environment.NewLine + "while downloading your contacts";
                proceed.IsVisible = true;

            }
        }

        private async void OnProceed(object sender, EventArgs e)
        {
            var page = new ContactListPage(new List<Contact>());
            await Navigation.PushModalAsync(page);
        }
	}
}