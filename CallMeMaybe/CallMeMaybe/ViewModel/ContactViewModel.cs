using CallMeMaybe.Services;
using CallMeMaybe.Views;
using Contacts.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CallMeMaybe.ViewModel
{



    public class ContactViewModel : INotifyPropertyChanged
    {

        public INavigation Navigation { get; internal set; }
        private ObservableCollection<Contact> _contacts;
        private Contact _contact;
        private string _title;
        private string _buttonText;
        private int _index;

        public ICommand SaveCommand => new Command(OnSave);

        public Contact Contact
        {
            get => _contact; set
            {
                _contact = value;
                OnPropertyChanged("Contact");
            }
        }

        public string Title
        {
            get => _title; set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public string ButtonText
        {
            get => _buttonText; set
            {
                _buttonText = value;
                OnPropertyChanged("ButtonText");
            }
        }


        public ContactViewModel(Contact c, ObservableCollection<Contact> Contacts, String title, int index)
        {

            Contact = c;
            Title = title;
            _contacts = Contacts;
            _index = index;
            _buttonText = title == "Add Contact" ? "Save" : "Update";

        }

        public async void OnSave()
        {
            if (String.IsNullOrWhiteSpace(_contact.FirstName) || String.IsNullOrWhiteSpace(_contact.LastName) || String.IsNullOrWhiteSpace(_contact.ContactNumber))
            {
                await App.Current.MainPage.DisplayAlert("Validation Error", "Please complete the contact details form", "OK");
            } else
            {
                if (_index >= 0)
                {
                    Contact c = _contacts[_index];
                    c.FirstName = _contact.FirstName;
                    c.LastName = _contact.LastName;
                    c.ContactNumber = _contact.ContactNumber;
                }
                else
                {
                    _contacts.Add(_contact);
                }
                _contacts = Utility.ArrangeContacts(_contacts);
                await Navigation.PopAsync();
            }


        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
