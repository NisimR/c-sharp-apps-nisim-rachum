using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_nisim_rachum.TransportationApp
{
    //מחלקה אבסטרקטית שמייצגת מבנה איחסון כמו נמל או מחסן, ומממשת את IContainable.
    public abstract class StorageStructure : IContainable
    {

        private string country;
        private string city;
        private string street;
        private int number;



        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string Street
        {
            get { return street; }
            set { street = value; }
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        // Implement IContainable methods
        public abstract  bool Load(IPortable item);
        public abstract bool Load(List<IPortable> items);
        public abstract bool UnLoad();
        public abstract bool UnLoad(IPortable item);
        public abstract bool UnLoad(List<IPortable> items);
        public abstract bool IsHaveRoom();
        public abstract bool IsOverload();
        public abstract double GetMaxVolume();
        public abstract double GetMaxWeight();
        public abstract double GetCurrentVolume();
        public abstract double GetCurrentWeight();
    }
}
