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
    [Activity(Label = "BookRide")]
    public class BookRide : Activity
    {
        string Mssage, Addrss;
        
        EditText D_id, C_id;
        Button btn;
      
        RegistrationClass Rc;
        Book RM;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.BookIt);
            D_id = (EditText)FindViewById(Resource.Id.Driver_Id);

            C_id = (EditText)FindViewById(Resource.Id.Cust_id);

            btn = (Button)FindViewById(Resource.Id.button1);
            btn.Click += btnclick;


        }

        private void btnclick(object sender, EventArgs e)
        {
            Rc = new RegistrationClass();
            Rc.CreateDatabaseBook();
            String t = C_id.ToString();
            List<CLocation> res= Rc.SelectBookedLocation(t);
            List<CLocation> k = Rc.SelectTableLocation();
            int o =k.Count;

            if (res != null)
            { int i= res.Count;

                CLocation Loc = res.Last();
                CLocation Loc1 = res[0];

                Mssage = Loc.Message;
                Addrss = Loc.address;
            }

            RM = new Book();
            RM.Message = Mssage;
            RM.C_id = C_id.Text;
            RM.D_id = D_id.Text;
            RM.Address = Addrss;
            bool r=Rc.InsertBook(RM);
            if (r)
            {
                FindViewById<TextView>(Resource.Id.textView1).Text = "Booked Successfully ! Enjoy Your Ride";

            }


        }
    }
}