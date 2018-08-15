using CallMeMaybe.Services;
using Contacts.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Contacts.Services
{
    public class ApiService
    {

        private readonly string END_POINT = "http://10.155.64.167:8080/contacts";
        public async Task<List<Contact>> sendRequest<T>()
        {
            List<Contact> contacts = null;
            HttpClient hTTPClient = new HttpClient();
            hTTPClient.Timeout = new TimeSpan(20000000);

            try
            {
                HttpResponseMessage response = await hTTPClient.GetAsync(new Uri(END_POINT));
                if (response != null && response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                 
                    contacts = JsonConvert.DeserializeObject<List<Contact>>(responseString);
                    contacts = Utility.Sanitize(contacts);
                }
            } catch(Exception)
            {
                System.Diagnostics.Debug.WriteLine("Error occurred retrieving the list of contacts.");
            }
           
            return contacts;    
        }


    }
}
