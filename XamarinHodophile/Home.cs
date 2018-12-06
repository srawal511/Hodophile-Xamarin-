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
    [Activity(Label = "Home")]
    public class Home : Activity
    {
        TextView TV;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Home);
            TV = FindViewById<TextView>(Resource.Id.Home);
            TV.Text = "Welcome Home";

        }
    }
}