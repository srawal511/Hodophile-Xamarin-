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
    [Activity(Label = "View_Ride")]
    public class View_Ride : Activity
    {
        TextView Cust_id,Address,Message;
        Book B;
        RegistrationClass Rc;
        Button btn;
        EditText Et;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.View_Ride);

            Et = (EditText)FindViewById(Resource.Id.editText1);
            
            btn = (Button)FindViewById(Resource.Id.button1);
            btn.Click += btnclick;

            //FindViewById<TextView>(Resource.Id.textView1).Text = "Booked Successfully ! Enjoy Your Ride";


        }

        private void btnclick(object sender, EventArgs e)
        {

            B = new Book();
            Rc = new RegistrationClass();
            String t = Et.ToString();
            List<Book> res =  Rc.SelectTableBook(t);

            if (res != null) {
                int y = res.Count;
                Book temp = res.Last();
                FindViewById<TextView>(Resource.Id.textView1).Text = temp.C_id;
                FindViewById<TextView>(Resource.Id.textView2).Text = temp.Address;
                FindViewById<TextView>(Resource.Id.textView3).Text = temp.Message;
            }

        }
    }
}