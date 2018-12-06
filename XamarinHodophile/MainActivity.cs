using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using SQLite;
using XamarinHodophile.Models;

namespace XamarinHodophile
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
      
        RegistrationClass RC;      
        EditText FullName,Company_Name,user_type,Email,Password;
        Button reg,log;
        RegistratoinModel RM;
       
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
          

            FullName = (EditText)FindViewById(Resource.Id.FullName);
            Company_Name = (EditText)FindViewById(Resource.Id.Company_Name);
            user_type = (EditText)FindViewById(Resource.Id.Usertype);
            Email = (EditText)FindViewById(Resource.Id.Email);
            Password = (EditText)FindViewById(Resource.Id.Password);

           
            reg = (Button)FindViewById(Resource.Id.Register);
            reg.Click += Registerclick;

            log = (Button)FindViewById(Resource.Id.Login1);
            log.Click += Login1click;



        }

        private void Login1click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(Login));
            intent.PutExtra("username", user_type.Text);
            intent.PutExtra("Message", "Please Login First");


            StartActivity(intent);

        }

        public void Registerclick(object sender, EventArgs e)
        {
            try
            {

                RC = new RegistrationClass();

                RM = new RegistratoinModel();
                RM.FullName = FullName.Text;
                RM.CompanyName = Company_Name.Text;
                RM.UserType = user_type.Text;
                RM.Email = Email.Text;
                RM.Password = Password.Text;
                RC.CreateDatabase();

                bool b =    RC.InsertItem(RM);
                if (b)
                {
                    var intent = new Intent(this, typeof(Login));
                    intent.PutExtra("username", user_type.Text);
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
