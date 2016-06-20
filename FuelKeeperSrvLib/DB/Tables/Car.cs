using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace be.subport.app.FuelKeeper.SrvLib.DB.Tables
{
    
    [Table("car")]
    public class Car
    {
        [PrimaryKey, AutoIncrement]
        public int id
        {
            get;
            set;
        }

        [NotNull]
        public string name
        {
            get;
            set;
        }

        [NotNull]
        public bool enabled
        {
            get;
            set;
        }

        [OneToMany]
        public List<Refuel> refuels
        {
            get;
            set;
        }
    }
}

