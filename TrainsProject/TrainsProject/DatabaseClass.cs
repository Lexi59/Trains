using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainsProject
{
    abstract class Database
    {
        //constructor
        protected Database()
        {
        }
        //fields
        public static List<Station> currentStations = new List<Station>();
        public static List<Train> currentTrains = new List<Train>();
        public static List<Control> stationMapGrid = new List<Control>();
        public static List<Track> currentTracks = new List<Track>();
        //methods
        public static void InitializeMap(HomePage homepage)
        {
            for (int x = 1; x < 101; x++)
            {
                var textboxName = string.Format("textBox{0}", x);
                var foundTextboxes = homepage.Controls.Find(textboxName, true);
                if (foundTextboxes[0] != null)
                {
                    stationMapGrid.Add(foundTextboxes[0]);
                }
            }
        }
    }
}
