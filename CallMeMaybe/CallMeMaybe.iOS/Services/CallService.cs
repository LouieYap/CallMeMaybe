using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CallMeMaybe.iOS.Services;
using CallMeMaybe.Services;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(CallService))]
namespace CallMeMaybe.iOS.Services
{
    public class CallService : ICallService
    {
        public void MakePhoneCall(string number)
        {
            var url = new NSUrl(@"tel://{0}", number);
            UIApplication.SharedApplication.OpenUrl(url);
        }
    }
}