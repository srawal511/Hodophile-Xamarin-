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
    [Activity(Label = "ADD_Employee")]
    public class ADD_Employee : Activity
    {
        String user_type;
        EditText EName, Password, CName, Contact, Email;
        Button btn;
        RegistrationClass RC1;
        RegistratoinModel RM1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ADD_Employee);


            EName = (EditText)FindViewById(Resource.Id.Ename);
            CName = (EditText)FindViewById(Resource.Id.Cname);

            user_type = "Company";
            Email = (EditText)FindViewById(Resource.Id.Email);
            Password = (EditText)FindViewById(Resource.Id.Pwd);
            Contact = (EditText)FindViewById(Resource.Id.Contact);


            btn = (Button)FindViewById(Resource.Id.AddEmp);
            btn.Click += btnclick;




        }
        public void btnclick(object sender, EventArgs e)
        {
            try
            {


                RC1 = new RegistrationClass();

                RM1 = new RegistratoinModel();
                RM1.FullName = EName.Text;
                RM1.CompanyName = CName.Text;
                RM1.UserType = user_type;
                RM1.Email = Email.Text;
                RM1.Password = Password.Text;
                RM1.Contact = Contact.Text;
                RC1.CreateDatabase();

                bool b = RC1.InsertItem(RM1);
                if (b)
                {
                    var intent = new Intent(this, typeof(Welcome));
                    intent.PutExtra("username", EName.Text);
                    intent.PutExtra("Message", "Please Login First");


                    StartActivity(intent);



                }
            }
            catch (Exception u)
            {
                Console.Write(u.Message);

            }

        }

    }
}
