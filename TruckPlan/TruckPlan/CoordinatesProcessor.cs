using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TruckPlan
{
    class CoordinatesProcessor
    {
        public object AitS1TiU24JdFwI8r1kqZ_H4JNxU5eUFlta0MFUIAFUFf6onvfAD6KeTdhWa7yZV { get; private set; }
        
        public async Task<LocationModel> GetCountry(Tuple<double, double> coordinates)
        {
            double latitude = coordinates.Item1;
            double longtitude = coordinates.Item2;

            string url = "";
            string country = "";
            

            if (latitude != null && longtitude != null)
            {
                url = $"http://dev.virtualearth.net/REST/v1/Locations/{ coordinates }?includeEntityTypes=countryRegion&o=0&key={AitS1TiU24JdFwI8r1kqZ_H4JNxU5eUFlta0MFUIAFUFf6onvfAD6KeTdhWa7yZV}";
            }
            
            using (HttpResponseMessage response = await ApiHelper.client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                   LocationModel location = await response.Content.ReadAsAsync<LocationModel>();
                   return location;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        
    }
}
