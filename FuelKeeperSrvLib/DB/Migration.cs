using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace be.subport.app.FuelKeeper.SrvLib.DB
{
    static class Migration
    {

        public static void InitialMigration(SQLiteConnection conn)
        {
            //conn.
        }

        public static void Migrate(Main db)
        {
            
        }

        public static bool doesTableExists(SQLiteConnection conn, String tableName)
        {
            if (tableName == null || conn == null)
            {
                return false;
            }
            var cmd = new SQLiteCommand(string.Format(@"SELECT COUNT(*) FROM sqlite_master WHERE type = ""{0}"" AND name = ""{1}""", "table", tableName), conn);
            var cmdReader = cmd.ExecuteReader();
            if (cmdReader.Read())
                return (cmdReader.GetInt32(0) > 0);
            else
                return false;           
        }
    }
}
