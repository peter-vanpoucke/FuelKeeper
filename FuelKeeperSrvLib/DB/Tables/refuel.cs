using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace be.subport.app.FuelKeeper.SrvLib.DB.Tables
{
    [Table("refuel")]
    public class Refuel
    {
        [PrimaryKey, AutoIncrement]
        public int id
        {
            get;
            set;
        }

        [NotNull, ForeignKey(typeof(Car))]
        public int car_id
        {
            get;
            set;
        }

        [ManyToOne]
        public Car car
        {
            get;
            set;
        }

        [NotNull]
        public DateTime time
        {
            get;
            set;
        }

        [NotNull]
        public float amount
        {
            get;
            set;
        }

        [NotNull]
        public float mileage
        {
            get;
            set;
        }
    }
}
