using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.SQLite.Linq;
//using System.Data.SQLite.EF6;
//using System.Data.Entity.Core;
using SQLite.Net.Attributes;

namespace be.subport.app.FuelKeeper.SrvLib.DB.Tables
{
    [Table("migrate")]
    class Migrate
    {
        [PrimaryKey, AutoIncrement]
        public int id
        {
            get;
            set;
        }

        [NotNull]
        public int step
        {
            get;
            set;
        }

        [NotNull]
        public DateTime applied
        {
            get;
            set;
        }
    }
}
