using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatWorx.BadgeMaker
{
    class Employee
    {
        public string FirstName;
        public string LastName;
        public int Id;
        public string PhotoUrl;
        public Employee(string firstName, string lastName) {
            FirstName = firstName;
            LastName = lastName;
        }
        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
