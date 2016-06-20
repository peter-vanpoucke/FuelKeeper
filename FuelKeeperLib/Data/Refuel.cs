using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be.subport.app.FuelKeeper.Lib.Data
{

    [Serializable()]
    public class Refuel
    {

        public object _dbid;

        public DateTime time;

        public float amount;

        public float mileage;
    }
}
