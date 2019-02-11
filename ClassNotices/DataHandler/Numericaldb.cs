using System.Collections.Generic;
using System.Linq;
using ClassNotices.Model;
using SQLite;

namespace ClassNotices.DataHandler
{
    class Numericaldb
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool CreateDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Numerical.db")))
                {
                    connection.CreateTable<Contact>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Android.Util.Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        public bool Insert(Contact contact)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Numerical.db")))
                {
                    connection.Insert(contact);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Android.Util.Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        public List<Contact> selectTable()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Numerical.db")))
                {
                    return connection.Table<Contact>().ToList();

                }
            }
            catch (SQLiteException ex)
            {
                Android.Util.Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }
        public bool Update(Contact contact)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Numerical.db")))
                {
                    connection.Query<Contact>("UPDATE Contact set Number=?", contact.Number);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Android.Util.Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        public bool Delete(Contact contact)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Numerical.db")))
                {
                    connection.Delete(contact);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Android.Util.Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        public bool SelectQueryTable(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Numerical.db")))
                {
                    connection.Query<Contact>("SELECT * FROM Person Where Id=? ", Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Android.Util.Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
    }
}