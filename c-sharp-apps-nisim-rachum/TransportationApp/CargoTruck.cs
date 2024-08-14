using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_nisim_rachum.TransportationApp
{
    public class CargoTruck : CargoVehicle
    {
        //private List<Container> containers;

        CargoType cargoType = CargoType.CargoTruck;

        public CargoTruck(Driver driver, double maxWeight, double maxVolume, Port currentPort, Port nextPort, int distanceToNextPort)
        {
            Driver = driver;
            MaxWeight = maxWeight;
            MaxVolume = maxVolume;

            CurrentPort = currentPort;
            NextPort = nextPort;
            DistanceToNextPort = distanceToNextPort;

            ItemsToLoad = new List<IPortable>();

            //containers = new List<Container>();
            //containers.Add(new Container());

        }

        public override bool Load(IPortable item)
        {
            if (item.GetWeight() <= MaxWeight - GetCurrentWeight() && item.GetVolume() <= MaxVolume - GetCurrentVolume())
            {
                ItemsToLoad.Add(item);
                item.SetLocation(CurrentPort);
                return true;
            }
            return false;

        }


        public override bool Load(List<IPortable> items)
        {
            double itemsWeight = 0;
            double itemsVolume = 0;

            foreach (IPortable item in items)
            {
                itemsWeight += item.GetWeight();
                itemsVolume += item.GetVolume();
            }

            if (itemsWeight <= MaxWeight - GetCurrentWeight() && itemsVolume <= MaxVolume - GetCurrentVolume())
            {

                ItemsToLoad.AddRange(items);
                return true;
            }
            return false;
        }

        public override bool UnLoad()
        {
            ItemsToLoad.Clear();
            return true;
        }

        public override bool UnLoad(IPortable item)
        {
            for (int i = 0; i < ItemsToLoad.Count; i++)
            {
                if (ItemsToLoad[i] == item)
                {
                    ItemsToLoad.Remove(ItemsToLoad[i]);
                    return true;
                    break;
                }
            }

            Console.WriteLine("Items list not found!");
            return false;
        }

        public override bool UnLoad(List<IPortable> items)
        {
            for (int i = 0; i < ItemsToLoad.Count && i < items.Count; i++)
            {
                if (ItemsToLoad[i] == items[i])
                {
                    ItemsToLoad.Remove(ItemsToLoad[i]);
                    return true;
                }
            }

            Console.WriteLine("Items list not found!");
            return false;
        }

        public override bool IsHaveRoom()
        {
            return GetCurrentVolume() < GetMaxVolume();
        }

        public override bool IsOverload()
        {
            return GetCurrentWeight() > GetMaxWeight();
        }

        public override double GetMaxVolume()
        {
            return MaxVolume;
        }

        public override double GetMaxWeight()
        {
            return MaxWeight;
        }

        public override double GetCurrentVolume()
        {
            double volume = 0;
            for (int i = 0; i < ItemsToLoad.Count; i++)
            {
                volume += ItemsToLoad[i].GetVolume();
            }

            return volume;
        }

        public override double GetCurrentWeight()
        {
            double weight = 0;
            for (int i = 0; i < ItemsToLoad.Count; i++)
            {
                weight = +ItemsToLoad[i].GetWeight();
            }
            return weight;
        }
    }
}
