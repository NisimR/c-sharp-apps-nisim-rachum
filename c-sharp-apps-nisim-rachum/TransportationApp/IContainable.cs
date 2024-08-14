using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_nisim_rachum.TransportationApp
{
    //ממשק שמגדיר יכולת אחסון של פריט, עם מתודות לטעינה, פריקה, בדיקת מקום וכו'.
    public interface IContainable
    {
        bool Load(IPortable item);
        bool Load(List<IPortable> items);
        bool UnLoad();
        bool UnLoad(IPortable item);
        bool UnLoad(List<IPortable> items);
        bool IsHaveRoom();
        bool IsOverload();
        double GetMaxVolume();
        double GetMaxWeight();
        double GetCurrentVolume();
        double GetCurrentWeight();
    }
}
