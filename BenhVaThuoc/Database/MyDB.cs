using BenhVaThuoc.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;

namespace BenhVaThuoc.Database
{
    public class MyDB
    {
        private static MyDB _instance;
        public static MyDB Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MyDB();
                return _instance;
            }
        }
        private SQLiteConnection conn;

        private MyDB()
        {
            Debug.WriteLine("MyDB()");
            conn = new SQLiteConnection(FILE_NAME);
        }


        public List<NhomBenh> GetListNhomBenh()
        {
            List<NhomBenh> list = conn.Query<NhomBenh>("select * from benh_category");
           
            return list;
        }

        #region Cấu hình đặc biệt
        public static event Action DBFileIsReady;
        public static bool DBIsReady = false;
        public const string FILE_NAME = "data.db";

        public static async Task<bool> CheckDBExitsAsync()
        {
            try
            {
                var file = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(FILE_NAME);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static async Task<bool> CreateDB()
        {
            try
            {
                if (await CheckDBExitsAsync() == false)
                {
                    //Copy ra ngoài
                    StorageFile file = await Package.Current.InstalledLocation.GetFileAsync(FILE_NAME);
                    Debug.WriteLine("Copying...");
                    await file.CopyAsync(ApplicationData.Current.LocalFolder);

                    Debug.WriteLine("Copied!");
                }

                DBIsReady = true;

                if (DBFileIsReady != null)
                    DBFileIsReady();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        #endregion
    }
}
