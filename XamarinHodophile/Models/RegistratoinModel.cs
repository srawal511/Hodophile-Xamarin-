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
   public  class RegistratoinModel
    {
        [PrimaryKey,AutoIncrement]
public int Id { get; set; }
        public string FullName { get; set; }

        public string UserType { get; set; }

        public string CompanyName { get; set; }

        public string Email { get; set; }
        public string Contact { get; set; }

        public string Password { get; set; }
    }
}