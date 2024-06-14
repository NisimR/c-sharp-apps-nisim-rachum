using System;

namespace c_sharp_apps_nisim_rachum.SportApp
{
    public class Season
    {
        private int year = 9999;
        private string sportType = "";
        private string leagueName = "";

        private Round[] rounds = null; 
        
        private  Team[]  teams = null;
        private int numsTeams = 0;

        public Season(int year, string sportType, string leagueName, Team[] teams)
        {
            this.year = year;
            this.sportType=sportType;
            this.leagueName = leagueName;
            this.teams = teams;
        }

        public void DisplayTable() {

            for (int i = 0; i < teams.Length; i++)
            {
                Console.WriteLine((i + 1) + " - "+teams[i].GetName());


            }


        }






    }
}

