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
        public Train(string name)
        {
            Name = name;
            TrainCurrentLocation = 0;
            Holding = new Package[TrainCapacity];
            
        }

        //fields
        public string Name;
        public int TrainCurrentLocation;
        public int TrainCapacity = 10;
        private Station TrainDepartureStation;
        private Station TrainDestinationStation;
        private Package[] Holding;

        //methods
    }
}
