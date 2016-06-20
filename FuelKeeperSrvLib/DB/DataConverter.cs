using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be.subport.app.FuelKeeper.SrvLib.DB
{
    public class DataConverter
    {
        
        public static Lib.Data.Car ConvertCarToData(Tables.Car car, bool convertRecursive)
        {
            var d = new Lib.Data.Car();
            d._dbid = car.id;
            d.name = car.name;
            d.enabled = car.enabled;

            if (convertRecursive)            
                d.refuels = new List<Lib.Data.Refuel>(car.refuels.ConvertAll< Lib.Data.Refuel>(new Converter<Tables.Refuel, Lib.Data.Refuel>(ConvertRefuelToData)));

            return d;
        }

        public static Lib.Data.Refuel ConvertRefuelToData(Tables.Refuel refuel)
        {
            var d = new Lib.Data.Refuel();
            d._dbid = refuel.id;
            d.time = refuel.time;
            d.amount = refuel.amount;
            d.mileage = refuel.mileage;
            return d;
        }        
    }
}
