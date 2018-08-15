using Android.Telecom;
using CallMeMaybe.Services;
using Contacts.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CallMeMaybe.ViewModel
{
    public class ContactsViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<Contact> _contacts;
        public ObservableCollection<Contact> Contacts
        {
            get { return _contacts; }
            set
            {
                _contacts = value;
                OnPropertyChanged("Contacts");
            }
        }

        private ObservableCollection<Contact> OriginalContacts;
        private string _contactImage;
        private string _favoriteImage;
        private string _phoneImage;
        private string _deleteMenu;
        private string _searchBar;
        private string _contactsSize;

        public ICommand DeleteCommand => new Command(OnDelete);
        public ICommand SearchBarCommand => new Command(OnSearch);
        public ICommand TapCommand => new Command(OnTapped);
        public ICommand CallCommand => new Command(OnCall);
        public string ContactImage
        {
            get => _contactImage; set
            {
                _contactImage = value;
                OnPropertyChanged("ContactImage");
            }
        }

        public string FavoriteImage
        {
            get => _favoriteImage; set
            {
                _favoriteImage = value;
                OnPropertyChanged("FavoriteImage");
            }
        }

        public string PhoneImage
        {
            get => _phoneImage; set
            {
                _phoneImage = value;
                OnPropertyChanged("PhoneImage");
            }
        }

        public ContactsViewModel(List<Contact> contactsParam)
        {
            OriginalContacts = new ObservableCollection<Contact>(contactsParam);
            Contacts = Utility.ArrangeContacts(new ObservableCollection<Contact>(contactsParam));      
            updateContactsSize();
            ContactImage = "baseline_account_circle_black_24.png";
            FavoriteImage = "baseline_favorite_border_black_24.png";
            PhoneImage = "baseline_phone_black_24.png";
        }

        public string DeleteMenu
        {
            get => _deleteMenu; set
            {
                _deleteMenu = value;
                OnPropertyChanged("DeleteMenu");
            }
        }

        public string SearchBar
        {
            get => _searchBar; set
            {
                _searchBar = value;
                OnPropertyChanged("SearchBar");
                SearchBarCommand.Execute(null);
            }
        }

        public string ContactsSize
        {
            get => _contactsSize; set
            {
                _contactsSize = value;
                OnPropertyChanged("ContactsSize");
            }
        }



        private void OnSearch()
        { 
            string keyword = _searchBar;
            _contacts.Clear();
            if (!String.IsNullOrWhiteSpace(keyword)) {       
                foreach (Contact c in OriginalContacts)
                {
                    if (c.FullName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        _contacts.Add(c);
                    }
                }
            
            } else
            {
                foreach (Contact c in OriginalContacts)
                {
                      _contacts.Add(c);                    
                }
            }
            updateContactsSize();
        }

        private void OnDelete(object s)
        {
            foreach (Contact c in Contacts)
            {
                if (c.FullName.Equals(s))
                {
                    Contacts.Remove(c);
                    break;
                }
            }
            Contacts = Utility.ArrangeContacts(Contacts);
            updateContactsSize();
        }

        private void OnTapped(object s)
        {
           foreach (Contact c in Contacts)
            {
                if(c.FullName.Equals(s))
                {
                     c.Favorite = c.Favorite? false:true;
                     break;
                }             
            }
            Contacts = Utility.ArrangeContacts(Contacts);
        }

        private void OnCall(object s)
        {
            DependencyService.Get<ICallService>().MakePhoneCall(Convert.ToString(s));
        }

        private void updateContactsSize()
        {
            ContactsSize = Convert.ToString(_contacts.Count);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
