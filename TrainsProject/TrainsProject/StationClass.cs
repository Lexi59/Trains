using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainsProject
{
    class Station
    {
        //constructor
        public Station(string name)
        {
            StationLocation = randomnumber.Next(0, mapSize+1);
            while (usedLocation.Contains(StationLocation))
            {
                StationLocation = new Random().Next(0, mapSize + 1);
            }
            usedLocation.Add(StationLocation); 
            Name = name;
        }
        //fields
        public string Name;
        const int mapSize = 100;
        static List<int> usedLocation = new List<int>();
        private readonly Random randomnumber = new Random();
        public int StationLocation;
        public List<Package> PackagesWaiting = new List<Package>();
        static int StationCapacity = 20;

        //methods
        public void addPackage(Station destination)
        {
            if( PackagesWaiting.Count < StationCapacity)
            {
                Random random = new Random();
                if(Name != destination.Name)
                {
                    PackagesWaiting.Add(new Package(random, destination));
                }
            }
        }
    }
}
