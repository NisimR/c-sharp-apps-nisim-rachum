using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_nisim_rachum.TransportationApp
{
    public class ShippingPriceCalculator : IShippingPriceCalculator
    {
        private const double TrainRatePerKm = 5;
        private const double ShipRatePerKm = 20;
        private const double PlaneRatePerKm = 50;


        public double CalculatePrice(IPortable item, int travelDistance)
        {
            int units = CalculateUnits(item);
            double ratePerKm = GetRatePerKm(item);
            return units * travelDistance * ratePerKm;
        }

        public double CalculatePrice(List<IPortable> items, int travelDistance)
        {
            int totalUnits = 0;

            for (int i = 0; i < items.Count ; i++)
                totalUnits += CalculateUnits(items[0]);

            double ratePerKm = items.Count > 0 ? GetRatePerKm(items[0]) : 0;

            return totalUnits * travelDistance * ratePerKm;
        }

        private int CalculateUnits(IPortable item)//חישוב כמות יחידות 
        {
            int units = 0;
            units += (int)(item.GetVolume() / 100);
            units += (int)item.GetWeight();

            if (item.IsFragile())
            {
                units *= 2;
            }

            return units;
        }

        private double GetRatePerKm(IPortable item)
        {
            switch (item.GetCargoType())
            {
                case CargoType.CargoTrain:
                    return TrainRatePerKm;
                case CargoType.CargoShip:
                    return ShipRatePerKm;
                case CargoType.CargoAirplane:
                    return PlaneRatePerKm;
                default:
                    return -1;
            }
        }
    }

}