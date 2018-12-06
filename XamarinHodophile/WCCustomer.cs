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
    [Activity(Label = "WCCustomer")]
    public class WCCustomer : Activity
    { 
        Button FindRide, PlaceFeedback, ViewRide,ViewResult, BookIt,Logout;
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.WCCustomer);
            FindRide = (Button)FindViewById(Resource.Id.FindRide);
            FindRide.Click += FindRideclick;

            PlaceFeedback = (Button)FindViewById(Resource.Id.PlaceFeedback);
            PlaceFeedback.Click += PlaceFeedbackclick;

            ViewRide = (Button)FindViewById(Resource.Id.ViewRide);
            ViewRide.Click += ViewRideclick;

            ViewResult = (Button)FindViewById(Resource.Id.ViewResult);
            ViewResult.Click += ViewResultclick;


            BookIt = (Button)FindViewById(Resource.Id.BookIt);
            BookIt.Click += BookItclick;


            Logout = (Button)FindViewById(Resource.Id.Logout);
            Logout.Click += Logoutclick;

        }

        private void BookItclick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(BookRide));

            String Username = intent.GetStringExtra("username");
            intent.PutExtra("username", Username);
            StartActivity(intent);
            //BookRide
        }

        private void Logoutclick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(Login));

            String Username = intent.GetStringExtra("username");
            intent.PutExtra("username", Username);
            StartActivity(intent);
        }

        private void ViewResultclick(object sender, EventArgs e)
        {

            var intent = new Intent(this, typeof(Results));
            String Username = intent.GetStringExtra("username");
            intent.PutExtra("username", Username);
            StartActivity(intent);

        }

        private void FindRideclick(object sender, EventArgs e)
        {

            var intent = new Intent(this, typeof(Activity2));

            String Username = intent.GetStringExtra("username");
            intent.PutExtra("username", Username);
            StartActivity(intent);
        }

        private void PlaceFeedbackclick(object sender, EventArgs e)
        {

            var intent = new Intent(this, typeof(AddFeedback));

            String Username = intent.GetStringExtra("username");
            intent.PutExtra("username", Username);
            StartActivity(intent);

        }

        private void ViewRideclick(object sender, EventArgs e)
        {


            var intent = new Intent(this, typeof(CustomerRideshow));
            String Username = intent.GetStringExtra("username");
            intent.PutExtra("username", Username);
            StartActivity(intent);


        }
    }
}