using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_nisim_rachum.TransportationApp
{
    //מחלקה אבסטרקטית שמייצגת רכב משא, ומממשת את StorageStructure ו-IContainable, עם מאפיינים כמו נהג, משקל מקסימלי, נפח מקסימלי, וכו'.
    public abstract class CargoVehicle : StorageStructure, IContainable
    {
        private Driver driver;
        private double maxWeight;
        private double maxVolume;
        private bool canTravel;
        private bool isOverloaded;
        private Port nextPort;
        private Port currentPort;
        private int currentTripID;
        private List<IPortable> itemsToLoad;
        private double expectedPayment;
        private IShippingPriceCalculator priceCalculator;
        private int distanceToNextPort;
        private Dictionary<int, double> paymentHistory;

        public Driver Driver
        {
            get { return driver; }
            set { driver = value; }
        }

        public double MaxWeight
        {
            get { return maxWeight; }
            set { maxWeight = value; }
        }

        public double MaxVolume
        {
            get { return maxVolume; }
            set { maxVolume = value; }
        }

        public bool CanTravel
        {
            get { return canTravel; }
            set { canTravel = value; }
        }

        public bool IsOverloaded
        {
            get { return isOverloaded; }
            set { isOverloaded = value; }
        }

        public Port NextPort
        {
            get { return nextPort; }
            set { nextPort = value; }
        }

        public Port CurrentPort
        {
            get { return currentPort; }
            set { currentPort = value; }
        }

        public int CurrentTripID
        {
            get { return currentTripID; }
            set { currentTripID = value; }
        }

        public List<IPortable> ItemsToLoad
        {
            get { return itemsToLoad; }
            set { itemsToLoad = value; }
        }

        public double ExpectedPayment
        {
            get { return expectedPayment; }
            set { expectedPayment = value; }
        }

        public IShippingPriceCalculator PriceCalculator
        {
            get { return priceCalculator; }
            set { priceCalculator = value; }
        }

        public int DistanceToNextPort
        {
            get { return distanceToNextPort; }
            set { distanceToNextPort = value; }
        }

        public Dictionary<int, double> PaymentHistory
        {
            get { return paymentHistory; }
            set { paymentHistory = value; }
        }

        // Implement IContainable methods
        public abstract override bool Load(IPortable item);
        public abstract override bool Load(List<IPortable> items);
        public abstract override bool UnLoad();
        public abstract override bool UnLoad(IPortable item);
        public abstract override bool UnLoad(List<IPortable> items);
        public abstract override bool IsHaveRoom();
        public abstract override bool IsOverload();
        public abstract override double GetMaxVolume();
        public abstract override double GetMaxWeight();
        public abstract override double GetCurrentVolume();
        public abstract override double GetCurrentWeight();

        // Additional methods
        public virtual string GetPricingList()
        {
            // Implementation for returning pricing details
            return "Pricing details...";
        }

        public void ApproveTravel()
        {
            if (!canTravel)
            {
                canTravel = driver.Approve(this);
            }
        }

        public void TravelToNextPort()
        {
            if (canTravel && nextPort != null)
            {
                
                currentPort = nextPort;
                
            }
        }
    }
}
