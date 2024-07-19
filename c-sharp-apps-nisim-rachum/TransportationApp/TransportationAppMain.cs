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
            MonitorTransportation m = new MonitorTransportation();
            m.Test1();
        
        }
    }
}
