using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_nisim_rachum.TransportationApp
{
    public class TransportationAppMain
    {
        public static void MainEntry()
        { 
            Console.WriteLine("TransportationApp");
            //MonitorTransportation m = new MonitorTransportation();
            //m.Test1();

            Console.WriteLine("Shipping Test: ");

            //ElectricalItem tv = new ElectricalItem("tv 43in Samsung", 100, 50, 10, 20, true, CargoType.CargoShip);

            //ShippingPriceCalculator shippingPriceCalculator = new ShippingPriceCalculator();

            //Console.WriteLine(shippingPriceCalculator.CalculatePrice(tv,1));

            ShippingTest.TestMain();



        }
    }
}
