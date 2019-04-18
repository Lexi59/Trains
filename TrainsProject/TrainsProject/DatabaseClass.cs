using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainsProject
{
    class Database
    {
        //constructor
        public Database()
        {
            currentStations = new List<Station>();
            currentTrains = new List<Train>();
            stationMapGrid = new List<Control>();
            currentTracks = new List<Track>();
        }
        //fields
        public List<Station> currentStations;
        public List<Train> currentTrains;
        public List<Control> stationMapGrid;
        public List<Track> currentTracks;
        //methods
    }
}
