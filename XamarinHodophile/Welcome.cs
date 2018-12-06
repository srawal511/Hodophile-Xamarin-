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

namespace XamarinHodophile
{
    [Activity(Label = "Welcome")]
    public class Welcome : Activity
    {
        Button AddEmp, Results,Ride, Location,logout;
        TextView TV;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
           SetContentView(Resource.Layout.WCEmployee);
          
            AddEmp = (Button)FindViewById(Resource.Id.AddEmp);
            AddEmp.Click += AddEmpclick;

            Results = (Button)FindViewById(Resource.Id.Results);
            Results.Click += Resultsclick;

            Ride = (Button)FindViewById(Resource.Id.Ride);
            Ride.Click += Rideclick;


            Location = (Button)FindViewById(Resource.Id.Location);
            Location.Click += Locationclick;

            logout = (Button)FindViewById(Resource.Id.LOGOUT);
            logout.Click += logoutclick;

        }

        private void logoutclick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(Login));

            String Username = intent.GetStringExtra("username");
            String Usertype = intent.GetStringExtra("Usertype");
            StartActivity(intent);
        }

        private void Locationclick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(Activity2));

            String Username = intent.GetStringExtra("username");
            String Usertype = intent.GetStringExtra("Usertype");
            intent.PutExtra("Usertype", Usertype);

            intent.PutExtra("username", Username);
            StartActivity(intent); 


        }

        private void Rideclick(object sender, EventArgs e)
        {

       var intent = new Intent(this, typeof(View_Ride));

            String Username = intent.GetStringExtra("username");
            intent.PutExtra("username", Username);
            StartActivity(intent);
        }

        private void Resultsclick(object sender, EventArgs e)
        {
           
            var intent = new Intent(this, typeof(Results));

            String Username = intent.GetStringExtra("username");
            intent.PutExtra("username", Username);
            StartActivity(intent);
           
        }

        private void AddEmpclick(object sender, EventArgs e)
        {

            var intent = new Intent(this, typeof(ADD_Employee));

            String Username = intent.GetStringExtra("username");
            intent.PutExtra("username", Username);
            StartActivity(intent);

        }
    }
}