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
            PackagesWaiting = new Package[StationCapacity];
        }
        //fields
        public string Name;
        const int mapSize = 100;
        static List<int> usedLocation = new List<int>();
        private readonly Random randomnumber = new Random();
        public int StationLocation;
        public Package[] PackagesWaiting;
        static int StationCapacity = 20;

        //methods
    }
}
