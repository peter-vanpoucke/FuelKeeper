using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.SQLite;
using System.Reflection;
using SQLite;

namespace be.subport.app.FuelKeeper.SrvLib.DB
{
    static class Migration
    {

        public static void InitialMigration(SQLiteConnection conn)
        {
            /*
            var initQry = @"
";
            conn
            */

            var types = new Type[] { typeof(Tables.Car), typeof(Tables.Migrate), typeof(Tables.Refuel) };
            /*
            List<TableClass> tables = new List<TableClass>();
            // Get Types in the assembly.
            foreach (Type t in types)
            {
                TableClass tc = new TableClass(t);
                tables.Add(tc);
            }

            // Create SQL for each table
            foreach (TableClass table in tables)
            {
                Console.WriteLine(table.CreateTableScript());
                Console.WriteLine();
            }
            */
            foreach (Type t in types)
            {
                conn.CreateTable(t);
            }

        }

        public static void Migrate(Main db)
        {
            var conn = db.Connection;
            if (!doesTableExists(conn, "migrate"))
            {
                InitialMigration(conn);
            }
        }

        public static bool doesTableExists(SQLiteConnection conn, String tableName)
        {
            if (tableName == null || conn == null)
            {
                return false;
            }
            var qry = string.Format(@"SELECT COUNT(*) FROM sqlite_master WHERE type = ""{0}"" AND name = ""{1}""", "table", tableName);
            /*var cmd = new SQLiteCommand (qry, conn);
            var cmdReader = cmd.ExecuteReader();
            if (cmdReader.Read())
                return (cmdReader.GetInt32(0) > 0);
            else
                return false;           
                */
            var cmd = conn.CreateCommand(qry);
            var list = cmd.ExecuteQuery<int>();
            return (list.Count() > 0 && list.First() > 0);
                
        }
    }
}
