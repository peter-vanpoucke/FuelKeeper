using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using System.Data.SQLite;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
//using SQLite.Net.Platform;

namespace be.subport.app.FuelKeeper.SrvLib.DB
{
    public class Main
    {
        private readonly SQLiteConnection conn; 
        public const string DBFILENAME = "FuelKeeper.db";
        public Main(Platform platform) : this(platform, GetDefaultDBFile(true))
        {

        }

        private static FileInfo CreateFile (DirectoryInfo dataDir, string fileName)
        {
            var dbFilePath = Path.Combine(dataDir.FullName, fileName);
            //SQLiteConnection.CreateFile(dbFilePath);            
            return new FileInfo(dbFilePath);
        }

        public static FileInfo GetDefaultDBFile(bool createIfNonExistant)
        {
            var dataDir = Helper.GetMainDir().GetDirectories("Data").First();
            var dbFile = dataDir.GetFiles(DBFILENAME).FirstOrDefault();
            if (createIfNonExistant && dbFile == null)
                dbFile = CreateFile(dataDir, DBFILENAME);
            return dbFile;
        }

        public Main(Platform platform, FileInfo databaseFile)
        {            
            this.conn = 
                //new SQLiteConnection(string.Format("Data Source={0};Version=3;", databaseFile.FullName));
                new SQLiteConnection(platform.GetPlatform(), databaseFile.FullName);            

            Migration.Migrate(this);
        }


        public SQLiteConnection Connection
        {
            get { return this.conn; }
        }

        public IEnumerable<Tables.Car> GetData()
        {
            return this.Connection.GetAllWithChildren<Tables.Car>();
        }

        public void SetData(IEnumerable<Tables.Car> cars)
        {
            //foreach(var r in cars)
            //this.Connection.InsertAllWithChildren(cars, true);
            foreach (var r in cars)
                this.Connection.UpdateWithChildren(r);
        }
    }
}
