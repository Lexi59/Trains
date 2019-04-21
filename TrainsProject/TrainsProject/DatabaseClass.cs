using System.Collections.Generic;
using System.Windows.Forms;

namespace TrainsProject
{
    public abstract class Database
    {
        //constructor
        protected Database() { }

        public static List<Station> CurrentStations { get; set; } = new List<Station>();
        public static List<Train> CurrentTrains { get; set; } = new List<Train>();
        public static List<Control> StationMapGrid { get; set; } = new List<Control>();
        public static List<Track> CurrentTracks { get; set; } = new List<Track>();
        public static HomePage Homepage;

        //methods
        public static void InitializeMap(HomePage homepage)
        {
            for (int x = 1; x < 101; x++)
            {
                var textboxName = string.Format("textBox{0}", x);
                var foundTextboxes = homepage.Controls.Find(textboxName, true);
                if (foundTextboxes[0] != null)
                {
                    StationMapGrid.Add(foundTextboxes[0]);
                }
            }
            Homepage = homepage;
        }
    }
}
