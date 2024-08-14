using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_nisim_rachum.TransportationApp
{
    public abstract class Furniture : IPortable
    {
        private double width;

        private double length;

        private double height;

        private double weight;

        private bool fragile;

        private bool packaged;

        private StorageStructure location;

        private CargoType cargoType;

        int itemId;

        private string description;


        public Furniture(int id, string description, double width, double length, double height, double weight, bool fragile, CargoType cargoType)
        {
            this.itemId = id;
            this.description = description;
            Width = width;
            Length = length;
            Height = height;
            Weight = weight;
            Fragile = fragile;
            packaged = false;
            this.cargoType = cargoType;
        }

        protected Furniture(double width, double length, double height, double weight, CargoType cargoType)
        {
            this.width = width;
            this.length = length;
            this.height = height;
            this.weight = weight;
            this.cargoType = cargoType;
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public double Width
        {
            get { return width; }
            set { width = value; }
        }
        public double Length
        {
            get { return length; }
            set { length = value; }
        }

        public double Height
        {
            get { return height; }
            set { height = value; }
        }
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public bool Fragile
        {
            get { return fragile; }
            set { fragile = value; }
        }

        public double GetArea()
        { return Width * Length; }
        public double[] GetSize()
        { return new double[] { (int)Width, (int)Length, (int)Height }; }
        public double GetVolume()
        { return Width * Length * Height; }
        public double GetWeight()
        { return Weight; }
        public void PackageItem()
        { packaged = true; }
        public bool IsPackaged()
        { return packaged; }

        public void UnPackage()
        { packaged = false; }

        public bool IsFragile()
        { return Fragile; }
        public StorageStructure GetLocation()
        { return location; }
        public bool IsLoaded()
        { return location != null; }
        public void SetLocation(StorageStructure loc)
        { location = loc; }

        public CargoType GetCargoType()
        {
            return cargoType;
        }

        public void SetCargoType(CargoType cargoType)
        {
            this.cargoType = cargoType;
        }

        public int GetID()
        {
            return this.itemId;
        }
    }
}
