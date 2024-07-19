using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_nisim_rachum.TransportationApp
{
    public class Bus : PublicVehicle
    {
        private readonly int doors;
        private bool bellStop = false;

        public Bus(){}
        public Bus(int line, int id, int maxSpeed, int seats, int doors)
            : base(line, id, maxSpeed, seats)
        {
            this.doors = doors;
        }
        public override int MaxSpeed
        {
            get => maxSpeed;

            set
            {
                if (value <= 120)
                {
                    maxSpeed = value;
                }
            }
        }

        public override bool CalculateHasRoom(int passengers)
        {
            return (Math.Round(Seats*1.1) - CurrentPassengers) >= passengers;
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
                RejecetedPassengers = passengers - (int)(Math.Round(Seats * 1.1) - CurrentPassengers);
                CurrentPassengers = (int)Math.Round(Seats * 1.1);
                HasRoom = false;
            }
        }
    }



}