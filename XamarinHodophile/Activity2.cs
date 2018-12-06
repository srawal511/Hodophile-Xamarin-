using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.Geolocator;
using XamarinHodophile.Models;

namespace XamarinHodophile
{
    [Activity(Label = "Activity2")]
    public class Activity2 : Activity
    {

        CLocation RM;
        RegistrationClass RC;
        Button btn;
        TextView Usertype, Email, Message;
        TextView _addressText;
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Location);
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, savedInstanceState);

            _addressText = FindViewById<TextView>(Resource.Id.address_text);
          
            FindViewById<Button>(Resource.Id.Get_Location).Click += AddressButton1_OnClick;

        //    FindViewById<TextView>(Resource.Id.get_address_button).Click += AddressButton2_OnClickAsync;
        }
        private async void AddressButton1_OnClick(object sender, EventArgs e)
        {
            try
            {
                Usertype = FindViewById<TextView>(Resource.Id.Usertype);
                Email = FindViewById<TextView>(Resource.Id.Email);
                Message = FindViewById<TextView>(Resource.Id.Message);
                                var locator = CrossGeolocator.Current;
                                  locator.DesiredAccuracy = 50;
                    TimeSpan ts = TimeSpan.FromTicks(10000);
                    var position = await locator.GetPositionAsync(timeout: ts);

                Geocoder geocoder = new Geocoder(this);
                IList<Address> addressList =
                    await geocoder.GetFromLocationAsync(position.Latitude, position.Longitude, 10);

                Address address = addressList.FirstOrDefault();
                if (address != null)
                {
                    StringBuilder deviceAddress = new StringBuilder();
                    for (int i = 0; i <= address.MaxAddressLineIndex; i++)
                    {
                        deviceAddress.AppendLine(address.GetAddressLine(i));
                    }
                    _addressText.Text = deviceAddress.ToString();

                    RC = new RegistrationClass();
                     RM = new CLocation();
                    RM.Email = Email.Text;
                    RM.UserType = Usertype.Text;
                    RM.address = deviceAddress.ToString();
                    RM.Message = Message.Text;
                    RC.CreateDatabaseLocation();

                    bool b = RC.InsertCLocation(RM);


                    if (b)
                    {
                        FindViewById<TextView>(Resource.Id.Status).Text = "Location Saved!";


                    }

                }
                else
                {
                    _addressText.Text = "Unable to determine the address. Try again in a few minutes.";
                }

             




            }
            catch (Exception a) {
                Console.Write(a.Message);
            }
        }
        
    }
    }