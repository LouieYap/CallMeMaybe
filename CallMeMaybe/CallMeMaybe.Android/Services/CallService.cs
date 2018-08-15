using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CallMeMaybe.Droid.Services;
using CallMeMaybe.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(CallService))]
namespace CallMeMaybe.Droid.Services
{
    public class CallService : ICallService
    {
  
        public void MakePhoneCall(string number)
        {
            var uri = Android.Net.Uri.Parse("tel:" + number);
            Intent intent = new Intent(Intent.ActionCall, uri);
            intent.AddFlags(ActivityFlags.NewTask);
            Android.App.Application.Context.StartActivity(intent);
        }
    }
}