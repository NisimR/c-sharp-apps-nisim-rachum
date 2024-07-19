using System;

namespace c_sharp_apps_nisim_rachum.TransportationApp
{
    public class PassengersAirplain : PublicVehicle
    {
        private int enginesNum;
        private int wingLength;
        private int rows;
        private int columns;

        public PassengersAirplain() { }

        public PassengersAirplain(int line, int id, int enginesNum, int wingLength, int rows, int columns)
            : base(line, id)
        {
            this.enginesNum = enginesNum;
            this.wingLength = wingLength;
            this.rows = rows;
            this.columns = columns;

            Seats = rows * columns - 7;
        }

        public override int MaxSpeed
        {
            get => maxSpeed;

            set
            {
                if (value <= 1000)
                {
                    maxSpeed = value;
                }
            }
        }

        public override bool CalculateHasRoom(int passengers)
        {
            
            int seatsForPassengers = Seats;

            if (seatsForPassengers - CurrentPassengers < passengers)
            {
                return false; // אין מקום
            }

            return true; // יש מקום
        }

        public override void UploadPassengers(int passengers)
        {
            // מספר המושבים לנוסעים הוא המושבים במטוס פחות 7 ישיבות פנויות לצוות ולחירום
            int seatsForPassengers = Seats;

            if (CalculateHasRoom(passengers))
            {
                CurrentPassengers += passengers;
            }
            else
            {
                RejecetedPassengers = passengers - (seatsForPassengers - CurrentPassengers);
                CurrentPassengers = seatsForPassengers; // נכנסים כל כך הרבה נוסעים כמה שניתן
                HasRoom = false; // אין יותר מקום
            }
        }
    }
}
