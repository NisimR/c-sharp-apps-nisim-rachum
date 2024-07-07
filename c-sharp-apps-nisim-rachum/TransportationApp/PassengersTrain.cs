using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_nisim_rachum.TransportationApp
{
    public class PassengersTrain : PublicVehicle
    {
        private Crone[] crones = null;
        private int cronesAmount = 0;

        public PassengersTrain()
        {
        }

        public PassengersTrain(int line, int id, int maxSpeed, int seats, Crone crone, int cronesAmount)
            : base(line, id, maxSpeed, seats)
        {
            this.CronesAmount = cronesAmount;

            this.Crones = new Crone[cronesAmount];

            for (int i = 0; i < Crones.Length; i++)
            {
                this.Crones[i] = new Crone(crone);
            }
            Seats = seats * cronesAmount;
        }
        public override int MaxSpeed
        {
            get => maxSpeed;
            set
            {
                if (value <= 300)
                {
                    maxSpeed = value;
                }
                
            }
        }

        public Crone[] Crones { get => crones; set => crones = value; }
        public int CronesAmount { get => cronesAmount; set => cronesAmount = value; }

        public override bool CalculateHasRoom(int passengers)
        {
            int totalExtraSeats = 0;
            int totalSeats = 0;

            for (int i = 0; i < Crones.Length; i++)
            {
                totalExtraSeats += Crones[i].GetExtras();
            }

            for(int i = 0;i<=Crones.Length-1;i++)
            {
                totalSeats += Crones[i].GetSeats();
            }

            Seats= totalSeats+totalExtraSeats;

            return (Seats - CurrentPassengers) >= passengers;
        }

        public override void UploadPassengers(int passengers)
        {
            

            if (CalculateHasRoom(passengers))
            {
                CurrentPassengers += passengers;
                HasRoom = true;
                RejecetedPassengers = 0;
            }
            else
            {
                RejecetedPassengers = passengers - (Seats - CurrentPassengers);
                CurrentPassengers += passengers - RejecetedPassengers;
                HasRoom = false;
            }
        }
    }
}