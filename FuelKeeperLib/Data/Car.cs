using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace be.subport.app.FuelKeeper.Lib.Data
{

    [Serializable()]
    public class Car
    {
        public object _dbid;

        public string name;

        public bool enabled;
        
        public List<Refuel> refuels
        {
            get;
            set;
        }
    }
}

