using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_nisim_rachum.TransportationApp
{
    public class Crone
    {
        private int rows;
        private int columns;

        public Crone(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
        }

        public Crone(Crone crone)
        {
            this.rows = crone.rows;
            this.columns = crone.columns;
        }

        public int GetSeats()
        {
            return rows*columns;
        }

        public int GetExtras()
        {
            return rows*2;
        }
    }

}