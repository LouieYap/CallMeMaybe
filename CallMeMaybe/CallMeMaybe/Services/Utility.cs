using Contacts.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CallMeMaybe.Services
{
    public class Utility
    {

        public static List<Contact> Sanitize(List<Contact> contacts)
        {
            foreach (Contact c in contacts)
            {
                if ((String.IsNullOrEmpty(c.FirstName) && String.IsNullOrEmpty(c.LastName)) || String.IsNullOrEmpty(c.ContactNumber))
                {
                    contacts.Remove(c);
                    break;
                }
            }

            return contacts;
        }

        public static ObservableCollection<Contact> ArrangeContacts(ObservableCollection<Contact> contacts)
        {
            return new ObservableCollection<Contact>(contacts.OrderBy(c => c.FullName).OrderByDescending(c => c.Favorite));
        }



      

    }
}
