using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinHodophile.Models;

namespace XamarinHodophile
{
    [Activity(Label = "CustomerRideshow")]
    public class CustomerRideshow : Activity
    {
        ListView mylist;
        ProgressBar progressBar;
        CustomerRideAdaptor myadapter;

        RegistrationClass RC;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CustomerRideOption);


            RC = new RegistrationClass();
            List<CLocation> V = RC.SelectTableLocation();
            mylist = FindViewById<ListView>(Resource.Id.listView1);
            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);
            showData();

           
        }

        private void showData()
        {
            progressBar.Visibility = ViewStates.Visible;
            // List<listItem> mylist = db.abc();

            progressBar.Visibility = ViewStates.Gone;
            myadapter = new CustomerRideAdaptor(this, RC.SelectTableLocation());
            mylist.Adapter = myadapter;

        }
    }
}