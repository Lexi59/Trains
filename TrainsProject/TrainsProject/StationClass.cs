using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainsProject
{
    class Station
    {
        //constructor
        public Station(string name)
        {
            StationLocation = randomnumber.Next(0, mapSize + 1);    //TODO: deal with overlapping stations
            Name = name;
            PackagesWaiting = new Package[StationCapacity];

        }
        //fields
        public string Name;
        static int mapSize = 100;
        private readonly Random randomnumber = new Random();
        public int StationLocation;
        public Package[] PackagesWaiting;
        static int StationCapacity = 20;

        //methods
    }
}
