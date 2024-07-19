using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_nisim_rachum.TransportationApp
{
    public class PublicVehicle
    {

        private int line = 0;
        private int id = 0;
        protected int maxSpeed = 0;
        private int currentPassengers = 0;
        private int seats = 0;
        private bool hasRoom = true;
        private int rejecetedPassengers = 0;

        public PublicVehicle()
        {

        }
        public PublicVehicle(int line, int id, int maxSpeed, int seats)
        {
            this.line = line;
            this.id = id;
            this.MaxSpeed = maxSpeed;
            this.seats = seats;
        }

        public PublicVehicle(int line, int id)
        {
            this.line = line;
            this.id = id;
        }

        public int Line { get => line; set => line = value; }
        public int Id { get => id; set => id = value; }

        public virtual int MaxSpeed
        {
            get => maxSpeed;

            set
            {
                if (value <= 40)
                {
                    maxSpeed = value;
                }
            }
        }
        public int CurrentPassengers { get => currentPassengers; set => currentPassengers = value; }
        public int Seats { get => seats; set => seats = value; }
        public bool HasRoom { get => hasRoom; set => hasRoom = value; }
        public int RejecetedPassengers { get => rejecetedPassengers; set => rejecetedPassengers = value; }

        public virtual bool CalculateHasRoom(int passengers)
        {
            return (Seats - CurrentPassengers) >= passengers;
        }

        public virtual void UploadPassengers(int passengers)
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
                CurrentPassengers = Seats;
                HasRoom = false;
            }

        }
    }
}