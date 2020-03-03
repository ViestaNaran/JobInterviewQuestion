using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TruckPlan
{
    // Extends person
    class Driver : Person
    {
       public string driversLicense { get; set; }
       public string driverID { get; set; }
       
      
       public Driver(string name, int age, string driverID, string driversLicense) : base(name, age)
       {
            this.driverID = driverID;
            this.driversLicense = driversLicense;
       }
    }
}
