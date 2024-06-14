using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_nisim_rachum.SportApp
{
    public class Team
    {
        private string name = "";
        private string city = "";
        private string currentLeague = "";

        private int totalGames = 0;
        private int currentGames = 0;
        private int wins = 0;
        private int losses = 0;
        private int evens = 0;
        private int points = 0;

        private int goalsFor = 0;
        private int goalAgainst = 0;

        public Team(string name,string city) 
        {
        this.name = name;
        this.city = city;
        }

        public string GetName()
            { return name; }


    }
}
