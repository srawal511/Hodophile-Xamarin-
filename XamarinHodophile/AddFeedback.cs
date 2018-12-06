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
    [Activity(Label = "AddFeedback")]
    public class AddFeedback : Activity
    {
        Feedback RM;
        RegistrationClass RC;
        Button btn;
        EditText Yname, Cname, Ename, Message, rank;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddFeedback);

            Yname = (EditText)FindViewById(Resource.Id.YName);
            Cname = (EditText)FindViewById(Resource.Id.Cname);
            Ename = (EditText)FindViewById(Resource.Id.Ename);
            Message = (EditText)FindViewById(Resource.Id.Message);
            rank = (EditText)FindViewById(Resource.Id.Rank);


            btn = (Button)FindViewById(Resource.Id.Submit);
            btn.Click += btnclick;

        }

        private void btnclick(object sender, EventArgs e)
        {
            // Intent kfsjk = new Intent();
            //              var intent = new Intent();

            RC = new RegistrationClass();

            RM = new Feedback();
            RM.Yname = Yname.Text;
            RM.Cname = Cname.Text;
            RM.Dname = Ename.Text;
            RM.Message = Message.Text;
            RM.Rank = rank.Text;
           
            RC.CreateDatabaseFeedback();

            bool b = RC.InsertFeedback(RM);
            //intent.PutExtra("succesfull!",FullName.Text)
            if (b)
            {
                var intent = new Intent(this, typeof(WCCustomer));
               
                StartActivity(intent);



            }

        }
    }
}