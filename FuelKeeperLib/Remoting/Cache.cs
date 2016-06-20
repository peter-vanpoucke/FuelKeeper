using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be.subport.app.FuelKeeper.Lib.Remoting
{
    public static class Cache
    {
        public static Func<IEnumerable<Data.Car>> DataRetrievalHandler;
    }
}
