using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using be.subport.app.FuelKeeper.Lib.Data;
using be.subport.app.FuelKeeper.Lib.Remoting;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;


namespace FuelKeeperTestClient1
{
    class Program
    {
        static void Main(string[] args)
        {
            //************************************* TCP *************************************//
            // using TCP protocol
            // running both client and server on same machines
            TcpChannel chan = new TcpChannel();
            ChannelServices.RegisterChannel(chan, true);
            // Create an instance of the remote object
            var dp = (DataProvider)Activator.GetObject(typeof(DataProvider), "tcp://localhost:8080/FuelKeeperSrv");
            // if remote object is on another machine the name of the machine should be used instead of localhost.
            //************************************* TCP *************************************//

            var cars = dp.RetrieveData();
            foreach (var aCar in cars)
            {
                Console.WriteLine("Car: {0} ({1})", aCar.name, aCar.enabled);
                foreach (var aRefuel in aCar.refuels)
                    Console.WriteLine(" * @ {0} / amount {1} l / on {2} km", aRefuel.time, aRefuel.amount, aRefuel.mileage);
            }

            Console.WriteLine("Press a key to continue...");
            Console.ReadKey();
        }
    }
}
