using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_nisim_rachum.TransportationApp
{
    //מחלקה שמייצגת נהג, עם מאפיינים כמו שם פרטי, שם משפחה, מספר זהות וסוג הנהג.
    public class Driver
    {
        private string lastName;
        private string firstName;
        private string idNumber;
        private CargoType type;

        public Driver(string lastName, string firstName, string idNumber, CargoType type)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.idNumber = idNumber;
            this.type = type;
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string IDNumber
        {
            get { return idNumber; }
            set { idNumber = value; }
        }

        public CargoType Type
        {
            get { return type; }
            set { type = value; }
        }

        public bool Approve(CargoVehicle vehicle)
        {
            // Approval logic
            return true;
        }
    }
}
