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

            List<Contact> _contacts = contacts.OrderBy(c => c.FullName).OrderByDescending(c => c.Favorite).ToList();
            contacts.Clear();
            foreach (Contact c in _contacts)
            {
                contacts.Add(c);
            }

            return contacts;
        }



      

    }
}
