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
using Java.Lang;
using XamarinHodophile.Models;

namespace XamarinHodophile
{
    public class ViewHolder : Java.Lang.Object
    {

        public TextView TXtView { get; set; }

    }
    public class ListViewAdapter:BaseAdapter
    {
        private Activity activity;
        private List<RegistratoinModel> Listreg;
        private MainActivity mainActivity;
        private List<RegistratoinModel> lstSource;

        public ListViewAdapter(MainActivity mainActivity, List<RegistratoinModel> lstSource)
        {
            this.mainActivity = mainActivity;
            this.lstSource = lstSource;
        }

        public void listadapter(Activity activity, List<RegistratoinModel> Listreg)
        {
            this.activity = activity;
            this.Listreg = Listreg;

        }

        public override int Count
        {
            get
            {
                return Listreg.Count;
            }
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return Listreg[position].Id;

        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.activity_main, parent, false);

            var textName = view.FindViewById<TextView>(Resource.Id.FullName);
            textName.Text = Listreg[position].FullName;
            return view;

        }


    }
}