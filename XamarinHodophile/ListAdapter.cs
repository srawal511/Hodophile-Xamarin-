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
     class ListAdapter : BaseAdapter<Feedback>
    {
        private Results results;
        private List<Feedback> listdata;
        private Activity context;
        public ListAdapter(Results results, List<Feedback> listdata)
        {
            this.context = results;
            this.listdata = listdata;
        }
        public override Feedback this[int position]
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

                view = context.LayoutInflater.Inflate(Resource.Layout.AdaptorResult, null, false);

            }
            Feedback item = this[position];
            view.FindViewById<TextView>(Resource.Id.textView3).Text = item.Rank;
            view.FindViewById<TextView>(Resource.Id.textView2).Text = item.Dname;
            view.FindViewById<TextView>(Resource.Id.textView1).Text = item.Cname;

        
            return view;
        }
    }
}