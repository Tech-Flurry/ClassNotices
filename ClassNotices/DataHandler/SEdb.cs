using System.Collections.Generic;
using System.Linq;
using SQLite;
using ClassNotices.Model;

namespace ClassNotices.DataHandler
{
    class SEdb
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool CreateDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "SE.db")))
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
        public bool InsertIntoTablePerson(Contact contact)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "SE.db")))
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
        public List<Contact> selectTablePerson()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "SE.db")))
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
        public bool UpdateTablePerson(Contact contact)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "SE.db")))
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
        public bool DeleteTablePerson(Contact contact)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "SE.db")))
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
        public bool SelectQueryTablePerson(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "SE.db")))
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
