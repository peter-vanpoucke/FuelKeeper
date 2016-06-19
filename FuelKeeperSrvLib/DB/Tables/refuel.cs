using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be.subport.app.FuelKeeper.SrvLib.DB.Tables
{
    //[Table("refuel")]
    public class Refuel
    {
        public int id
        {
            get;
            set;
        }

        public Car car
        {
            get;
            set;
        }

        public DateTime time
        {
            get;
            set;
        }

        public float amount
        {
            get;
            set;
        }

        public float mileage
        {
            get;
            set;
        }
    }
}
