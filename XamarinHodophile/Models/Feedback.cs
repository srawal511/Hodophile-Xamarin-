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
using SQLite;

namespace XamarinHodophile.Models
{
   public class Feedback
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Yname { get; set; }

        public string Cname { get; set; }

        public string Dname { get; set; }

        public string Message { get; set; }
        public string Rank { get; set; }

    }
}