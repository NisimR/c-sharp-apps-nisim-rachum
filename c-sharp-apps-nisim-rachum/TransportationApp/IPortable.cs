using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_nisim_rachum.TransportationApp
{
    // ממשק שמגדיר פריט שניתן להעמסה, עם מאפיינים כמו שטח, נפח, משקל וכדומה.
    public interface IPortable
    {
        int GetID();
        double GetArea();
        double[] GetSize(); // Width, Length, Height
        double GetVolume();
        double GetWeight();
        void PackageItem();
        bool IsPackaged();
        void UnPackage();
        bool IsFragile();
        StorageStructure GetLocation();

        void SetLocation(StorageStructure loc);
        bool IsLoaded();
        CargoType GetCargoType();
        void SetCargoType(CargoType cargoType);
    }
}
