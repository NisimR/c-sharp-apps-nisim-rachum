using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_nisim_rachum.TransportationApp
{
    //מחלקה שיורשת מ-StorageStructure ומייצגת נמל.
    public class Port : StorageStructure
    {
        private List<IPortable> items;
        private double maxVolume;
        private double maxWeight;

         

        public Port(string street, string city, string country, double maxVolume, double maxWeight)
        {
            Street = street;
            City = city;
            Country = country;

            this.maxVolume = maxVolume;
            this.maxWeight = maxWeight;


            this.items = new List<IPortable>();
        }

        public override bool Load(IPortable item)
        {
            if (IsHaveRoom(item))
            {
                items.Add(item);
                return true;
            }
            return false;
        }

        public override bool Load(List<IPortable> items)
        {
            foreach (var item in items)
            {
                if (!Load(item))
                {
                    return false;
                }
            }
            return true;
        }

        public override bool UnLoad()
        {
            items.Clear();
            return true;
        }

        public override bool UnLoad(IPortable item)
        {
            return items.Remove(item);
        }

        public override bool UnLoad(List<IPortable> items)
        {
            for(int i=0;i<items.Count;i++)
            {
                if (!UnLoad(items[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override bool IsHaveRoom()
        {
            return GetCurrentVolume() < maxVolume && GetCurrentWeight() < maxWeight;
        }

        private bool IsHaveRoom(IPortable item)
        {
            return GetCurrentVolume() + item.GetVolume() <= maxVolume &&
                   GetCurrentWeight() + item.GetWeight() <= maxWeight;
        }

        public override bool IsOverload()
        {
            return GetCurrentVolume() > maxVolume || GetCurrentWeight() > maxWeight;
        }

        public override double GetMaxVolume()
        {
            return maxVolume;
        }

        public override double GetMaxWeight()
        {
            return maxWeight;
        }

        public override double GetCurrentVolume()
        {
            double currentVolume = 0;
            for(int i=0; i<items.Count; i++)
            {
                currentVolume += items[i].GetVolume();
            }
            return currentVolume;
        }

        public override double GetCurrentWeight()
        {
            double currentWeight = 0;
            for (int i = 0; i < items.Count; i++)
            {
                currentWeight += items[i].GetWeight();
            }
            return currentWeight;
        }
    }

}
