using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;

namespace be.subport.app.FuelKeeper.SrvLib.DB
{
    public class Main
    {
        private readonly SQLiteConnection conn; 
        public const string DBFILENAME = "FuelKeeper.db";
        public Main() : this(GetDefaultDBFile(true))
        {

        }

        public static FileInfo CreateDBFile (DirectoryInfo dataDir, string fileName)
        {
            var dbFilePath = Path.Combine(dataDir.FullName, fileName);
            SQLiteConnection.CreateFile(dbFilePath);
            return new FileInfo(dbFilePath);
        }

        public static FileInfo GetDefaultDBFile(bool createIfNonExistant)
        {
            var dataDir = Helper.GetMainDir().GetDirectories("Data").First();
            var dbFile = dataDir.GetFiles(DBFILENAME).FirstOrDefault();
            if (createIfNonExistant && dbFile == null)
                dbFile = CreateDBFile(dataDir, DBFILENAME);
            return dbFile;
        }

        public Main(FileInfo databaseFile)
        {            
            this.conn = new SQLiteConnection(string.Format("Data Source={0};Version=3;", databaseFile.FullName));

            Migration.Migrate(this);
        }

        public SQLiteConnection Connection
        {
            get { return this.conn; }
        }
    }
}
