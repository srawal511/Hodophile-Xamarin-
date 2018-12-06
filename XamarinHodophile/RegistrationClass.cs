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
using SQLite;
using XamarinHodophile.Models;

namespace XamarinHodophile
{
    public class RegistrationClass
    {

        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public bool CreateDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "RegistratoinModel.db")))
                {

                    connection.CreateTable<RegistratoinModel>();
                    return true;
                }
            }
            catch (SQLiteException e)
            {
                Log.Info("Message", e.Message);
                return false;
            }
        }
        public bool CreateDatabaseFeedback()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Feedback.db")))
                {

                    connection.CreateTable<Feedback>();
                    return true;
                }
            }
            catch (SQLiteException e)
            {
                Log.Info("Message", e.Message);
                return false;
            }
        }

        public bool InsertItem(RegistratoinModel item)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "RegistratoinModel.db")))
                {
                    connection.Insert(item);
                    return true;
                }
            }
            catch (SQLiteException e)
            {
                Log.Info("Message", e.Message);
                return false;
            }

        }
        public bool InsertFeedback(Feedback item)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Feedback.db")))
                {
                    connection.Insert(item);
                    return true;
                }
            }
            catch (SQLiteException e)
            {
                Log.Info("Message", e.Message);
                return false;
            }

        }
        public List<RegistratoinModel> SelectTable(String email,string pwd)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "RegistratoinModel.db")))
                {
                    List<RegistratoinModel> v = connection.Query<RegistratoinModel>("SELECT * FROM RegistratoinModel Where Email=? and  Password =?", email, pwd);
                  
                    return v;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                List<RegistratoinModel> v= new List<RegistratoinModel>();
                return v;
            }
        }
        public List<Feedback> SelectTableResult()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Feedback.db")))
                {
                    List<Feedback> v = connection.Query<Feedback>("SELECT *  FROM Feedback ");
                    return v;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                List<Feedback> v = new List<Feedback>();
                return v;
            }
        }
        public List<CLocation> SelectTableLocation()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "CLocation.db")))
                {
                    List<CLocation> v = connection.Query<CLocation>("SELECT *  FROM CLocation ");
                    return v;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                List<CLocation> v = new List<CLocation>();
                return v;
            }
        }
        public bool CreateDatabaseLocation()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "CLocation.db")))
                {

                    connection.CreateTable<CLocation>();
                    return true;
                }
            }
            catch (SQLiteException e)
            {
                Log.Info("Message", e.Message);
                return false;
            }
        }

        public bool InsertCLocation(CLocation item)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "CLocation.db")))
                {
                    connection.Insert(item);
                    return true;
                }
            }
            catch (SQLiteException e)
            {
                Log.Info("Message", e.Message);
                return false;
            }

        }
        public List<CLocation> SelectBookedLocation(string item)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "CLocation.db")))
                {

                    List<CLocation> v = connection.Query<CLocation>("SELECT * FROM CLocation");
                   
                    return v;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                List<CLocation> v = new List<CLocation>();
                return v;
            }
        }
        public List<Book> SelectTableBook( String item)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Book.db")))
                {// Where Email=?", emailEmail
                    List<Book> v = connection.Query<Book>("SELECT * FROM Book ", item);
                    return v;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                List<Book> v = new List<Book>();
                return v;
            }
        }
        public bool CreateDatabaseBook()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Book.db")))
                {

                    connection.CreateTable<Book>();
                    return true;
                }
            }
            catch (SQLiteException e)
            {
                Log.Info("Message", e.Message);
                return false;
            }
        }
        public bool InsertBook(Book item)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Book.db")))
                {
                    connection.Insert(item);
                    return true;
                }
            }
            catch (SQLiteException e)
            {
                Log.Info("Message", e.Message);
                return false;
            }

        }

    }
}


    