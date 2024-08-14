using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_nisim_rachum.TransportationApp
{
    //ממשק שמגדיר מתודות לחישוב עלות משלוח לפי פריט ומרחק.
    public interface IShippingPriceCalculator
    {
        double CalculatePrice(IPortable item, int travelDistance);
        double CalculatePrice(List<IPortable> items, int travelDistance);
    }

}
