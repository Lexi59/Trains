using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainsProject
{
    class Train
    {
        //constructor
        public Train(string name, Station startingStation)
        {
            Name = name;
            TrainCurrentLocation = null;
            Holding = new List<Package>();
            TrainCurrentLocation = startingStation;
        }

        //fields
        public string Name;
        public Station TrainCurrentLocation;
        public int TrainCapacity = 10;
        private Station TrainDepartureStation;
        private Station TrainDestinationStation;
        public List<Package> Holding;
        public int capacityUpgradeAmount = 5;

        //methods
    }
}
