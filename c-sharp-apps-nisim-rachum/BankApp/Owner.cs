using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_nisim_rachum.BankApp
{
    public class Owner
    {
        private string firstName;
        private string lastName;

        public Owner (string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string GetFirstName()
        {
            return this.firstName;
        }
        public string GetLastName()
        {
            return this.lastName;
        }

        public void SetFirstName(string firstName)
        { this.firstName = firstName; }

        public void SetLastName(string lastName)
            { this.lastName = lastName; }

    }
}
