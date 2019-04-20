using System.Collections.Generic;
using System.Windows.Forms;

namespace TrainsProject
{
    abstract class Database
    {
        //constructor
        protected Database() { }

        internal static List<Station> CurrentStations { get; set; } = new List<Station>();
        internal static List<Train> CurrentTrains { get; set; } = new List<Train>();
        public static List<Control> StationMapGrid { get; set; } = new List<Control>();
        internal static List<Track> CurrentTracks { get; set; } = new List<Track>();

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
        }
    }
}
