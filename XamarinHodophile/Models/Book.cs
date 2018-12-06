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
   public class Book
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string C_id { get; set; }
        public string D_id { get; set; }
        public string Address { get; set; }
        public string Message { get; set; }

    }
}