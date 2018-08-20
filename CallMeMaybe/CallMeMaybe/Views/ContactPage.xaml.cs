using CallMeMaybe.ViewModel;
using Contacts.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CallMeMaybe.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactPage : ContentPage
	{
		public ContactPage (Contact contact, ObservableCollection<Contact>cs, String title)
		{
            int index = cs.IndexOf(contact);
            ContactViewModel cvm = new ContactViewModel(contact, cs, title, index);
            BindingContext = cvm;
            cvm.Navigation = Navigation;
            InitializeComponent();
           
        }
	}
}