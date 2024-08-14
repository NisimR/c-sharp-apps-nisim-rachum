using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_nisim_rachum.TransportationApp
{
    public class Chair : Furniture
    {
        public Chair(int id, string description, double width, double length, double height, double weight, bool fragile, CargoType cargoType)
            : base(id,description, width, length, height, weight, fragile,cargoType)
        {
        }
    }

    public class Table : Furniture
    {
        public Table(int id, string description, double width, double length, double height, double weight, bool fragile, CargoType cargoType)
            : base(id,description, width, length, height, weight, fragile, cargoType)
        {
        }
    }

    public class Sofa : Furniture
    {
        public Sofa(int id, string description, double width, double length, double height, double weight, bool fragile, CargoType cargoType)
            : base(id, description, width, length, height, weight, fragile, cargoType)
        {
        }
    }

}
