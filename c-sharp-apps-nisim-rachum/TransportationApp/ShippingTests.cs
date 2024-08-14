using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_nisim_rachum.TransportationApp
{
    public class ShippingTest
    {
        public static void TestMain()
        {
            TestLoadSingleItemToCargoShip();
            TestLoadMultipleItemsToCargoAirPlane();
            TestCargoTrainReadyToTravel();
            TestOverloadingCargoShip();
            TestCalculateShippingCostForCargoShip();
            TestUnloadingCargoTrain();
            TestPartialLoadingCargoAirplane();
            TestCargoShipTravelToNextPort();
            TestEmptyingCargoPlane();
            TestApprovalWithoutLoadingCargoTrain();
            TestUnloadingSpecificItemsFromCargoShip();
            TestTravelingWithoutApprovalCargoPlane();
            TestCalculateShippingCostForCargoTrain();
            TestOverloadCargoPlane();
            //TestReadyToTravelAfterPartialLoadingCargoTrain();
        }

        public static void PrintList (List<IPortable> items)
        {
            for(int i=0; i < items.Count;i++)
            {
                Console.WriteLine(items[i].GetID());
            }
        }
        public static void TestLoadSingleItemToCargoShip()
        {
            Console.WriteLine("NO #1");
            Port portA = new Port("Montifioty St.", "Haifa", "Israel", 5000, 10000);
            Port portB = new Port("Victoria Harbor", "Hong Kong", "China", 8000, 15000);
            Driver driver1 = new Driver("John", "Doe", "123456789", CargoType.CargoShip);
            CargoShip cargoShip = new CargoShip(driver1, 1000000000000, 2000000000000, portA, portB, 50000);
            ElectricalItem tv = new ElectricalItem(78797, "tv 43in Samsung",100, 50, 10, 20, true, CargoType.CargoShip);

            bool result = cargoShip.Load(tv);
            Console.WriteLine($"TestLoadSingleItemToCargoShip: {result} - TV loaded: {tv.IsLoaded()}");
        }

        public static void TestLoadMultipleItemsToCargoAirPlane()
        {
            Console.WriteLine("NO #2");
            Port portB = new Port("Pier 39", "San Francisco", "USA", 6000, 12000);
            Port portC = new Port("Sydney Cove", "Sydney", "Australia", 7500, 13500);
            Driver driver2 = new Driver("Jane", "Smith", "987654321", CargoType.CargoAirplane);
            CargoAirplane cargoPlane = new CargoAirplane (driver2, 5000000000, 10000000000, portB, portC, 1500);
            ElectricalItem tv = new ElectricalItem(78797,"Screen 43in Samsung", 100, 50, 10, 20, true, CargoType.CargoShip);
            GeneralItem box = new GeneralItem(78797, " browm box", 50, 50, 50, 30, false, CargoType.CargoAirplane);
            Chair chair = new Chair(78797, "Chair 343 Model", 40, 40, 90, 15, false, CargoType.CargoAirplane);

            List<IPortable> items = new List<IPortable> { tv, box, chair };
            bool result = cargoPlane.Load(items);

            ShippingPriceCalculator shippingPriceCalculator = new ShippingPriceCalculator();
            Console.WriteLine($"TestLoadMultipleItemsToCargoPlane: {result} - Items loaded price: {shippingPriceCalculator.CalculatePrice(items,7000)}");
        }

        public static void TestCargoTrainReadyToTravel()
        {
            Console.WriteLine("NO #3");
            Port portA = new Port("Le Havre", "Paris", "France", 5500, 11000);
            Port portC = new Port("Port of Hamburg", "Hamburg", "Germany", 7000, 14000);
            Driver driver3 = new Driver("Mike", "Johnson", "111213141", CargoType.CargoTrain);
            CargoTrain cargoTrain = new CargoTrain(driver3, 8000, 15000, portC, portA, 3000);
            ElectricalItem tv = new ElectricalItem(78797, "Screen 43in Samsung", 100, 50, 10, 20, true, CargoType.CargoTrain);
            GeneralItem box = new GeneralItem(78797, " browm box", 50, 50, 50, 30, false, CargoType.CargoTrain);
            Chair chair = new Chair(78797, "Chair 343 Model", 40, 40, 90, 15, false, CargoType.CargoTrain);

            List<IPortable> items = new List<IPortable> { tv, box, chair };
            cargoTrain.Load(items);
            cargoTrain.ApproveTravel();
            Console.WriteLine($"TestCargoTrainReadyToTravel: {cargoTrain.CanTravel}");
        }

        public static void TestOverloadingCargoShip()
        {
            Console.WriteLine("NO #4");
            Port portA = new Port("Port of Antwerp", "Antwerp", "Belgium", 6500, 13000);
            Port portB = new Port("Port of Rotterdam", "Rotterdam", "Netherlands", 8000, 16000);
            Driver driver1 = new Driver("John", "Doe", "123456789", CargoType.CargoShip);
            CargoShip cargoShip = new CargoShip(driver1, 10000, 20000, portA, portB, 5000);

            List<IPortable> items = new List<IPortable>();
            for (int i = 0; i < 1000; i++)
            {
                items.Add(new GeneralItem(78797, " browm box {i} ", 50, 50, 50, 30, false, CargoType.CargoShip));
            }
            bool result = cargoShip.Load(items);
            Console.WriteLine($"TestOverloadingCargoShip: {result} - Is Overload: {cargoShip.IsOverload()}");
        }

        public static void TestCalculateShippingCostForCargoShip()
        {
            Console.WriteLine("NO #5");
            Port portA = new Port("Port of Vancouver", "Vancouver", "Canada", 6200, 12500);

            Port portB = new Port("Port of Yokohama", "Yokohama", "Japan", 6800, 13800);

            Driver driver1 = new Driver("John", "Doe", "123456789", CargoType.CargoShip);

            CargoShip cargoShip = new CargoShip(driver1, 10000000000, 200000000000, portA, portB,1200);
            ElectricalItem tv = new ElectricalItem(78797, "Screen 43in Samsung", 100, 50, 10, 20, true, CargoType.CargoShip);
            GeneralItem box = new GeneralItem(78797, " browm box", 50, 50, 50, 30, false, CargoType.CargoShip);

            cargoShip.Load(tv);
            cargoShip.Load(box);
            cargoShip.ApproveTravel();

            ShippingPriceCalculator shippingPriceCalculator = new ShippingPriceCalculator();
            
            double cost = shippingPriceCalculator.CalculatePrice(cargoShip.ItemsToLoad,1200);
            Console.WriteLine($"TestCalculateShippingCostForCargoShip: {cost}");
        }

        public static void TestUnloadingCargoTrain()
        {
            Console.WriteLine("NO #6");
            Port portA = new Port("Port of Busan", "Busan", "South Korea", 7000, 14500);
            Port portC = new Port("Port of Singapore", "Singapore", "Singapore", 7800, 15500);
            Driver driver3 = new Driver("Mike", "Johnson", "111213141", CargoType.CargoTrain);
            CargoTrain cargoTrain = new CargoTrain(driver3, 800000000, 150000000000, portC, portA, 1000);
            ElectricalItem tv = new ElectricalItem(78797, "Screen 43in Samsung", 100, 50, 10, 20, true, CargoType.CargoTrain);
            GeneralItem box = new GeneralItem(787971, " browm box", 50, 50, 50, 30, false, CargoType.CargoTrain);
            Chair chair = new Chair(787972, "Chair 343 Model", 40, 40, 90, 15, false, CargoType.CargoTrain);

            List<IPortable> items = new List<IPortable> { tv, box, chair };
            cargoTrain.Load(items);
            //PrintList(items);
            cargoTrain.UnLoad(tv); // don
            //PrintList(items);

            Console.WriteLine($"TestUnloadingCargoTrain: TV loaded: {tv.IsLoaded()} - Items count: {cargoTrain.ItemsToLoad.Count}");
        }

        public static void TestPartialLoadingCargoAirplane()
        {
            Console.WriteLine("NO #7");
            Port portB = new Port("Port of Shanghai", "Shanghai", "China", 8500, 17000);
            Port portC = new Port("Port of Mumbai", "Mumbai", "India", 6400, 12800);
            Driver driver2 = new Driver("Jane", "Smith", "987654321", CargoType.CargoAirplane);
            CargoAirplane cargoAirplane = new CargoAirplane(driver2, 50000000, 100000000000, portB, portC, 17000-12800);
            ElectricalItem tv = new ElectricalItem(78797, "Screen 43in Samsung", 100, 50, 10, 20, true, CargoType.CargoAirplane);
            GeneralItem box = new GeneralItem(78797, " browm box", 50, 50, 50, 30, false, CargoType.CargoAirplane);
            Chair chair = new Chair(78797, "Chair 343 Model", 40, 40, 90, 15, false, CargoType.CargoAirplane);

            List<IPortable> items = new List<IPortable> { tv, box, chair };
            bool result = cargoAirplane.Load(items);
            Console.WriteLine($"TestPartialLoadingCargoPlane: {result} - Items loaded count: {cargoAirplane.ItemsToLoad.Count}");
            bool partialLoad = cargoAirplane.Load(new GeneralItem(78797, " browm box", 50, 50, 50, 30, false, CargoType.CargoAirplane));
            Console.WriteLine($"TestPartialLoadingCargoPlane: Partial Load: {partialLoad}");
        }

        public static void TestCargoShipTravelToNextPort()
        {
            Console.WriteLine("NO #8");
            Port portA = new Port("Port of Santos", "Santos", "Brazil", 6600, 13200);
            Port portB = new Port("Port of Buenos Aires", "Buenos Aires", "Argentina", 6700, 13500);
            Driver driver1 = new Driver("John", "Doe", "123456789", CargoType.CargoShip);
            CargoShip cargoShip = new CargoShip(driver1, 10000000, 20000000000, portA, portB, 300);
            ElectricalItem tv = new ElectricalItem(78797, "Screen 43in Samsung", 100, 50, 10, 20, true, CargoType.CargoShip);

            cargoShip.Load(tv);
            cargoShip.ApproveTravel();
            bool travelResult = cargoShip.CanTravel;
            cargoShip.TravelToNextPort();
            Console.WriteLine($"TestCargoShipTravelToNextPort: {travelResult} - Current Port: {cargoShip.CurrentPort.City}");
        }

        public static void TestEmptyingCargoPlane()
        {
            Console.WriteLine("NO #9");
            Port portB = new Port("Port of Durban", "Durban", "South Africa", 6900, 14000);
            Port portC = new Port("Port of Lagos", "Lagos", "Nigeria", 7100, 14500);
            Driver driver2 = new Driver("Jane", "Smith", "987654321", CargoType.CargoAirplane);
            CargoAirplane cargoAirplane = new CargoAirplane(driver2, 50000000, 1000000000000, portB, portC, 500);
            ElectricalItem tv = new ElectricalItem(78797, "Screen 43in Samsung", 100, 50, 10, 20, true, CargoType.CargoAirplane);
            GeneralItem box = new GeneralItem(787971, " browm box", 50, 50, 50, 30, false, CargoType.CargoAirplane);
            Chair chair = new Chair(787972, "Chair 343 Model", 40, 40, 90, 15, false, CargoType.CargoAirplane);

            List<IPortable> items = new List<IPortable> { tv, box, chair };
            cargoAirplane.Load(items);
            //Console.WriteLine(cargoAirplane.ItemsToLoad.Count);
            cargoAirplane.UnLoad();
            Console.WriteLine($"TestEmptyingCargoPlane: Items loaded count: {cargoAirplane.ItemsToLoad.Count}");
        }

        public static void TestApprovalWithoutLoadingCargoTrain()
        {
            Console.WriteLine("NO #10");
            Port portA = new Port("Port of Alexandria", "Alexandria", "Egypt", 7200, 14800);
            Port portC = new Port("Port of Jebel Ali", "Dubai", "UAE", 7800, 16000);
            Driver driver3 = new Driver("Mike", "Johnson", "111213141", CargoType.CargoTrain);
            CargoTrain cargoTrain = new CargoTrain(driver3, 8000, 15000, portC, portA, 3000);

            cargoTrain.ApproveTravel();
            Console.WriteLine($"TestApprovalWithoutLoadingCargoTrain: Ready to travel: {cargoTrain.CanTravel}");
        }

        public static void TestUnloadingSpecificItemsFromCargoShip()
        {
            Console.WriteLine("NO #11");
            Port portA = new Port("Port of Doha", "Doha", "Qatar", 7300, 15000);
            Port portB = new Port("Port of Aqaba", "Aqaba", "Jordan", 7400, 15200);
            Driver driver1 = new Driver("John", "Doe", "123456789", CargoType.CargoShip);
            CargoShip cargoShip = new CargoShip(driver1, 100000000000, 200000000000, portA, portB, 200);
            ElectricalItem tv = new ElectricalItem(78797, "Screen 43in Samsung", 100, 50, 10, 20, true, CargoType.CargoShip);
            GeneralItem box = new GeneralItem(78797, " browm box", 50, 50, 50, 30, false, CargoType.CargoShip);
            Chair chair = new Chair(78797, "Chair 343 Model", 40, 40, 90, 15, false, CargoType.CargoAirplane);

            List<IPortable> items = new List<IPortable> { tv, box, chair };
            cargoShip.Load(items);
            cargoShip.UnLoad(new List<IPortable> { tv, chair });
            Console.WriteLine($"TestUnloadingSpecificItemsFromCargoShip: TV loaded: {tv.IsLoaded()} - Chair loaded: {chair.IsLoaded()} - Box loaded: {box.IsLoaded()}");
        }

        public static void TestTravelingWithoutApprovalCargoPlane()
        {
            Console.WriteLine("NO #12");
            Port portB = new Port("Port of Karachi", "Karachi", "Pakistan", 7500, 15500);
            Port portC = new Port("Port of Colombo", "Colombo", "Sri Lanka", 7600, 15700);
            Driver driver2 = new Driver("Jane", "Smith", "987654321", CargoType.CargoAirplane);
            CargoAirplane cargoAirplane = new CargoAirplane(driver2, 5000, 10000, portB, portC, 7000);
            ElectricalItem tv = new ElectricalItem(78797, "Screen 43in Samsung", 100, 50, 10, 20, true, CargoType.CargoAirplane);

            cargoAirplane.Load(tv);
            bool travelResult = cargoAirplane.CanTravel;
            Console.WriteLine($"TestTravelingWithoutApprovalCargoPlane: {travelResult}");
        }

        public static void TestCalculateShippingCostForCargoTrain()
        {
            Console.WriteLine("NO #13");
            Port portA = new Port("Port of Manila", "Manila", "Philippines", 7700, 15800);
            Port portC = new Port("Port of Jakarta", "Jakarta", "Indonesia", 7900, 16200);
            Driver driver3 = new Driver("Mike", "Johnson", "111213141", CargoType.CargoTrain);
            CargoTrain cargoTrain = new CargoTrain(driver3, 8000000000, 1500000000000, portC, portA, 3000);
            ElectricalItem tv = new ElectricalItem(78797, "Screen 43in Samsung", 100, 50, 10, 20, true, CargoType.CargoTrain);

            cargoTrain.Load(tv);
            cargoTrain.ApproveTravel();

            ShippingPriceCalculator shippingPriceCalculator = new ShippingPriceCalculator();

            double cost = shippingPriceCalculator.CalculatePrice(cargoTrain.ItemsToLoad, 3000);
            Console.WriteLine($"TestCalculateShippingCostForCargoTrain: {cost}");
        }

        public static void TestOverloadCargoPlane()
        {
            Console.WriteLine("NO #14");
            Port portB = new Port("Port of Ho Chi Minh", "Ho Chi Minh City", "Vietnam", 8000, 16500);
            Port portC = new Port("Port of Bangkok", "Bangkok", "Thailand", 8200, 16800);
            Driver driver2 = new Driver("Jane", "Smith", "987654321", CargoType.CargoAirplane);
            CargoAirplane cargoAirplane = new CargoAirplane(driver2, 500, 1000, portB, portC, 7000);

            List<IPortable> items = new List<IPortable>();
            for (int i = 0; i < 100; i++)
            {
                items.Add(new GeneralItem(78797, " browm box", 50, 50, 50, 30, false, CargoType.CargoShip));
            }
            bool result = cargoAirplane.Load(items);
            Console.WriteLine($"TestOverloadCargoPlane: {result} ");
        }

        public static void TestReadyToTravelAfterPartialLoadingCargoTrain()
        {
            Console.WriteLine("NO #15");
            Port portA = new Port("Port of Athens", "Athens", "Greece", 6700, 13400);
            Port portC = new Port("Port of Lisbon", "Lisbon", "Portugal", 6600, 13200);
            Driver driver3 = new Driver("Mike", "Johnson", "111213141", CargoType.CargoTrain);
            CargoTrain cargoTrain = new CargoTrain(driver3, 8000, 15000, portC, portA, 3000);
            ElectricalItem tv = new ElectricalItem(78797, "Screen 43in Samsung", 100, 50, 10, 20, true, CargoType.CargoTrain);
            GeneralItem box = new GeneralItem(78797, " browm box", 50, 50, 50, 30, false, CargoType.CargoTrain);
            Chair chair = new Chair(78797, "Chair 343 Model", 40, 40, 90, 15, false, CargoType.CargoTrain);

            List<IPortable> items = new List<IPortable> { tv, box, chair };
            cargoTrain.Load(items);
            cargoTrain.ApproveTravel();
            cargoTrain.Load(new GeneralItem(78797, "Sofa 777 Model", 100, 3000, 90, 15, false, CargoType.CargoTrain)); // Attempt to partially load after approval
            Console.WriteLine($"TestReadyToTravelAfterPartialLoadingCargoTrain: {cargoTrain.CanTravel}");
        }
    }
}
