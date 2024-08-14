using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_nisim_rachum.TransportationApp
{

    public class Container : StorageStructure
    {

        private List<IPortable> items;

        double maxWeight;
        double maxVolume;

        double currentVolume = 0;
        double currentWeight = 0;

        public Container() //: base (country, city, street, number)
        {

            List<IPortable> items = new List<IPortable>();
        }

        public override double GetCurrentVolume()
        {
            return currentVolume;
        }

        public override double GetCurrentWeight()
        {
            return currentWeight;
        }

        public override double GetMaxVolume()
        {
            return maxVolume;
        }

        public override double GetMaxWeight()
        {
            return maxWeight;
        }

        public override bool IsHaveRoom()
        {
            return currentVolume < maxVolume && currentWeight < maxWeight;
        }

        public override bool IsOverload()
        {
            return currentVolume > maxVolume && currentWeight > maxWeight;
        }

        public override bool Load(IPortable item)
        {
            if (item.GetVolume() < currentVolume && item.GetWeight() < currentWeight)
            {
                this.items.Add(item);
                return true;
            }

            return false;
        }

        public override bool Load(List<IPortable> items)
        {
            double itemsVolume = 0;
            double itemsWeight = 0;

            for (int i = 0; i < items.Count; i++)
            {

                itemsVolume += items[i].GetVolume();
                itemsWeight += items[i].GetWeight();

            }

            if (itemsVolume < currentVolume && itemsWeight < currentWeight)
            {

                items.AddRange(items);
                return true;
            }
            return false;

        }

        public override bool UnLoad()
        {
            items.Clear();
            return true;
        }

        public override bool UnLoad(IPortable item)
        {
           // IPortable itemToRemov

            items.Remove(item);
            return true;
        }

        public override bool UnLoad(List<IPortable> items)
        {
            {
                foreach (IPortable item in items)
                {
                    if (!UnLoad(item))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
