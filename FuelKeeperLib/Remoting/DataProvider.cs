using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be.subport.app.FuelKeeper.Lib.Remoting
{    
    public class DataProvider : MarshalByRefObject
    {
        //public event Func<IEnumerable<Data.Car>> DataRetrievalHandler;

        public List<Data.Car> RetrieveData()
        {
            return Cache.DataRetrievalHandler != null ? new List<Data.Car>(Cache.DataRetrievalHandler()) : new List<Data.Car>();
        }
    }
}
