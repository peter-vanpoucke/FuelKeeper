using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.SQLite.Linq;
//using System.Data.SQLite.EF6;
//using System.Data.Entity.Core;

namespace be.subport.app.FuelKeeper.SrvLib.DB.Tables
{
    //[Table("migrate")]
    class Migrate
    {
        public int step
        {
            get;
            set;
        }

        public DateTime applied
        {
            get;
            set;
        }
    }
}
