using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TruckPlan
{
    class GPS
    {
        // private bool destinationReached = false; -- Moved to TruckPlan to check there. 
        private double currentLatPosition;
        private double currentLongPosition;
        private Random r = new Random();
        private Tuple<double, double> currentCords { set; get; }
        private Tuple<double, double> destination { set; get; }
        private double DistanceDriven { get; }

        private string currentCountry { get; set; }

        private double updateTimer = 3000;
        Timer timer1;

        public CoordinatesProcessor countryGenerator = new CoordinatesProcessor();

        // The list holding the generated Coordinates, which will be passed on to the truck or the truckplan to calculate the total distance driven in each country. 
        private LinkedList<Tuple<double, double,string>> coordinatesList = new LinkedList<Tuple<double, double,string>>();

        
        // To make it more authentic with actual double numbers, it either needs to be cast to a double or we will simply add another r.NextDouble to the result
        public Tuple<double, double> GenerateCords()
        {
            currentLatPosition = r.Next(-90,90);
            currentLongPosition = r.Next(-180,180);

            currentCords = Tuple.Create(currentLatPosition,currentLongPosition);

            return currentCords;
        }

        // This method is used by the GPS to generate coordinates between the last given current position and the end destination of the truck. 
        public Tuple<double, double> GenerateCords1(Tuple<double, double> start, Tuple<double, double> end)
        {
            Console.WriteLine("GenerateCords With parameters called!");
            int startxI = (int)start.Item1;
            int endxI = (int)start.Item2;
            int startyI = (int)end.Item1;
            int endyI = (int)end.Item2;

            currentLatPosition = r.Next(startxI, endxI);
            currentLongPosition = r.Next(startyI, endyI);
            
            currentCords = Tuple.Create(currentLatPosition, currentLongPosition);
           // string countryHolder = updateCurrentCountry(currentCords);


            return Tuple.Create(currentLatPosition,currentLongPosition);
        }
  
        private void OnTimedEvent2(Object source, ElapsedEventArgs e)
        {
            if (currentCords != null && destination != null)
            {
                currentCords = GenerateCords1(currentCords, destination);
                Console.WriteLine("CurrentCords was not null, Currentcords: " + currentCords);
            }
            // If the destination is reached
            else if(currentCords == destination)
            {
                Console.WriteLine("CurrentCords and destination are the same. CurrentCords : " + currentCords + "Destination: " + destination);
                timer1.Stop();
            }
            // If no Coordinates are set.  
            else
            {
                Console.WriteLine("No Coordinates are set, called OnTimedEvent1 to generate random cords.");
                OnTimedEvent(source,e);
            }
        }



       
        public string GetCountryByCode(Tuple<double, double> cords)
        {
            // string countryHolder = updateCurrentCountry(cords);

           

            return currentCountry;
        }

      
        public async Task updateCurrentCountry(Tuple <double,double> location)
        {
            var countryLocator = await countryGenerator.GetCountry(location);

            if (countryLocator != null)
            {
                currentCountry = countryLocator.Name;
            }   
        }
        

        public void InitTimer()
        {
            timer1 = new Timer(updateTimer);
            timer1.Enabled = true;
            timer1.AutoReset = true;
            timer1.Elapsed += OnTimedEvent2;
        }
        
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("OnTimedEvent");
            Console.WriteLine(GenerateCords());
        }

        public LinkedList<Tuple<double, double, string>> GetCoordsList()
        {
            return coordinatesList;
        }

        // Uses pythagoras to calculate the straightline distance between 2 points
        public double DistanceBetweenPoints(Tuple<double, double> start, Tuple<double, double> end)
        {
            return Math.Sqrt(Math.Pow(start.Item1 - end.Item1, 2) + Math.Pow(start.Item2 - end.Item2, 2));
        }
    }
}
