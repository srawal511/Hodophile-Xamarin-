using Android.App;
using System.Collections.Generic;
using XamarinHodophile.Models;
using System;

using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
namespace XamarinHodophile
{
    class CustomerRideAdaptor : BaseAdapter<CLocation>
    {

        private CustomerRideshow results;
        private List<CLocation> listdata;
        private Activity context;
        public CustomerRideAdaptor(CustomerRideshow results, List<CLocation> listdata)
        {
            this.context = results;
            this.listdata = listdata;
        }
        public override CLocation this[int position]
        {
            get
            {

                return listdata[position];

            }

        }

        public override int Count
        {

            get
            {

                return listdata.Count;
            }

        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            if (convertView == null)
            {

                view = context.LayoutInflater.Inflate(Resource.Layout.RideAdaptor, null, false);

            }
            CLocation item = this[position];
            view.FindViewById<TextView>(Resource.Id.textView1).Text = item.Email;
            view.FindViewById<TextView>(Resource.Id.textView2).Text = item.address;
            view.FindViewById<TextView>(Resource.Id.textView3).Text = item.Message;

            return view;
        }
    }
}
