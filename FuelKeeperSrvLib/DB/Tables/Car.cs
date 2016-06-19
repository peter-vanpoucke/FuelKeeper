using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace be.subport.app.FuelKeeper.SrvLib.DB.Tables
{
    [Table("car")]
    public class Car
    {
        public int id
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }

        public bool enabled
        {
            get;
            set;
        }
    }
}
