using CallMeMaybe.ViewModel;
using Contacts.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CallMeMaybe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactListPage : TabbedPage
    {
        public ContactsViewModel vm;
        public ContactListPage (List<Contact> _contacts)
        {
            vm = new ContactsViewModel(_contacts);
            vm.Navigation = Navigation;
            BindingContext = vm;
            InitializeComponent();
         

        }


    }
}