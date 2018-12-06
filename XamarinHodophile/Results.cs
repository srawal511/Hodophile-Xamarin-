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
using Android.Util;
namespace XamarinHodophile
{
    [Activity(Label = "Results")]
    public class Results : Activity
    {
        ListView mylist;
        ProgressBar progressBar;
        ListAdapter myadapter;
      
        RegistrationClass RC;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Results);
            RC = new RegistrationClass();
            List<Feedback> V = RC.SelectTableResult();
           mylist = FindViewById<ListView>(Resource.Id.listView1);
            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);
            showData();


        }

        private void showData()
        {
            progressBar.Visibility = ViewStates.Visible;
            // List<listItem> mylist = db.abc();
           
            progressBar.Visibility = ViewStates.Gone;
            myadapter = new ListAdapter(this, RC.SelectTableResult());
            mylist.Adapter = myadapter;

        }
    }
}