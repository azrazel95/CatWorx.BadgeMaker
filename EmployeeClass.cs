using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatWorx.BadgeMaker
{
    //establishes the employee class
    class Employee
    {
        //attributes
        public string FirstName;
        public string LastName;
        public int Id;
        public string PhotoUrl;
        //callbacks
        public Employee(string firstName, string lastName, int id, string photoUrl) {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            PhotoUrl = photoUrl;
        }
        //returns the company name(its always catworx for this guy)
        public string GetCompanyName()
        {
            return "Cat Worx";
        }
        //cheeky getfullname method
        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
        //returns id(of course)
        public int GetId()
        {
            return Id;
        }
        //this may surprise you, but this returns the photourl
        public string GetPhotoUrl()
        {
            return PhotoUrl;
        }
    }
}
