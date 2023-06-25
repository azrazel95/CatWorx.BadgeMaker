using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace CatWorx.BadgeMaker
{
    //establishes peoplefetcher as a class
    internal class PeopleFetcher
    {
        //apicall function
        async public static Task<List<Employee>> GetFromApi()
        {
            //establishes list
            List<Employee> employees = new List<Employee>();
            //using httpclient, severs connection once finished
            using (HttpClient client = new HttpClient())
            {
                //cheeky get function
                string response = await client.GetStringAsync("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
                //how to deal with json objects; a thread. 
                //using jobject to get the json in c#
                JObject json = JObject.Parse(response);
                //looping over the data
                foreach (JToken token in json.SelectToken("results")!)
                {
                    // declaring the emp
                    Employee emp = new Employee
                    (
                        //taking apart the attributes from the api call's json, tostring()
                      token.SelectToken("name.first")!.ToString(),
                      token.SelectToken("name.last")!.ToString(),
                      //dont forget your integers!
                      Int32.Parse(token.SelectToken("id.value")!.ToString().Replace("-", "")),
                      token.SelectToken("picture.large")!.ToString()
                    );
                    //add to employees list
                    employees.Add(emp);
                }
                //returns now filled list
                return employees;

            }

        }
    }
}
