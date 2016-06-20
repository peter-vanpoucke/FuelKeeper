using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using be.subport.app.FuelKeeper.SrvLib.DB;
using be.subport.app.FuelKeeper.Lib.Data;
using be.subport.app.FuelKeeper.Lib.Remoting;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace be.subport.app.FuelKeeper.Test.Server
{
    public class DataProviderRunner
    {
        Main db;
        //DataProvider dp;

        public DataProviderRunner()
        {
            db = new Main(new WindowsPlatform());

            //this.dp = new DataProvider();
            Cache.DataRetrievalHandler += this.ConvertData;

        }
        public void Run()
        { 
            /*
            var cars = db.GetData();
            foreach (var aCar in cars)
            {
                Console.WriteLine("Car: {0} ({1})", aCar.name, aCar.enabled);
                foreach(var aRefuel in aCar.refuels)
                    Console.WriteLine(" * @ {0} / amount {1} l / on {2} km", aRefuel.time, aRefuel.amount, aRefuel.mileage);


                aCar.refuels.Add(new SrvLib.DB.Tables.Refuel
                {
                    amount = 52.3f,
                    mileage = 133400,
                    time = DateTime.Now,
                    //car_id = aCar.id
                });

            }
            //db.SetData(cars);
            */


            //************************************* TCP *************************************//
            // using TCP protocol
            TcpChannel channel = new TcpChannel(8080);
            ChannelServices.RegisterChannel(channel,true);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(DataProvider), "FuelKeeperSrv", WellKnownObjectMode.Singleton);
            //************************************* TCP *************************************//
            

            /*
            Console.WriteLine("Press a key to continue...");
            Console.ReadKey();
            */
        }

        public string Test()
        {
            return string.Format("# cars: {0}", (new DataProvider()).RetrieveData().Count());
        }
       

        public IEnumerable<Car> ConvertData()
        {
            foreach (var r in this.db.GetData())
                yield return DataConverter.ConvertCarToData(r, true);
        }
    }
}
