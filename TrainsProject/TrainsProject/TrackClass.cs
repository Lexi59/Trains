using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainsProject
{
    class Track
    {
        //constructor
        public Track(Station source, Station destination)
        {
            sourceStation = source;
            destinationStation = destination;
            length = Math.Abs(source.StationLocation % 10 - destination.StationLocation % 10) + (source.StationLocation / destination.StationLocation);
        }

        //fields
        public Station sourceStation;
        public Station destinationStation;
        public int length;
        //methods

    }
}
