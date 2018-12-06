using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using XamarinHodophile.Models;

namespace XamarinHodophile
{
    [Activity(Label = "Login")]
    public class Login : Activity
    {
TextView TV;
        Button btn;
        EditText Email,pwd,usrtype;

        RegistrationClass rc;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Login);
          
            Email = (EditText)FindViewById(Resource.Id.Uname);
            usrtype = (EditText)FindViewById(Resource.Id.Usertype);
            pwd = (EditText)FindViewById(Resource.Id.Pwd);
            

            btn = (Button)FindViewById(Resource.Id.Login);
            btn.Click += btnclick;



        }

        private void btnclick(object sender, EventArgs e)
        {
            rc = new RegistrationClass();
            string un = Email.ToString();


           List<RegistratoinModel> result =  rc.SelectTable(un,pwd.ToString()) ;

            if (result != null)
            {

                try {
                    if (usrtype.Text == "Company")
                    {
                        var intent = new Intent(this, typeof(Welcome));
                        intent.PutExtra("username", Email.Text);
                        intent.PutExtra("Usertype", usrtype.Text);
                        intent.PutExtra("pwd", pwd.Text);


                        StartActivity(intent);
                    }
                    else if (usrtype.Text == "Customer")
                    {

                        var intent = new Intent(this, typeof(WCCustomer));
                        intent.PutExtra("username", Email.Text);
                        intent.PutExtra("Usertype", usrtype.Text);
                        intent.PutExtra("pwd", pwd.Text);

                        StartActivity(intent);

                    }
                }
                catch (Exception q)
                {
                    Console.Write(q.Message);

                }

            }
           
            else
            {
                var intent = new Intent(this, typeof(MainActivity)).SetFlags(ActivityFlags.ClearTask);

                     var intent1 = new Intent(this, typeof(MainActivity));
                intent1.PutExtra("Message", "Register Here");
                StartActivity(intent);
                

            }
        }
    }
}