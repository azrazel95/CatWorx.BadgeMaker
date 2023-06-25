using System;
using System.Collections.Generic;
using System.Threading.Tasks;
//project itself
namespace CatWorx.BadgeMaker
{
    //program!
    class Program
    {
        //main is the entry point.
        async static Task Main(string[] args) {
            //greeting
            Console.WriteLine("Hello and welcome to CatWorx Badgemaker!\n ");
            //the list contains a template(Employee) which has a name assigned to it, employees.
            //awaits an apicall through peoplefetchers getfromapi method.
            List<Employee> employees = await PeopleFetcher.GetFromApi();
            //employs util's printemployees method, taking an arg of employees
            Util.PrintEmployees(employees);
            //employs utils makecsv method, taking an arg of employees
            Util.MakeCSV(employees);
            //employs utils makebadges method, taking an arg of employees.
            await Util.MakeBadges(employees);
        }

    }
}