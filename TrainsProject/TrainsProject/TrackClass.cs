using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainsProject
{
    class Track : Database
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
        public static HomePage homepage;
        private static Station selectedStationForSource;
        //methods
        public static string buyTrack(string state)
        {
            if (state == "BuyTrack")
            {
                if (currentStations.Count < 2)
                {
                    homepage.ConsoleTextBox.Text = "Sorry! You can't buy a track until you have 2 stations!";
                    return null;
                }
                if (Bank.currentMoney - Bank.costOfTrack < 0)
                {
                    homepage.ConsoleTextBox.Text = "Sorry! You can't do that! You don't have enough money!";
                    return null;
                }
                homepage.ConsoleTextBox.Text = "You clicked yes! We purchased an Track for you, where would you like to start it?";
                Bank.currentMoney -= Bank.costOfTrack;
                Bank.updateMoneyBox();
                return "startTrack";
            }
            if (state != null)
            {
                homepage.ConsoleTextBox.Text += "Finish this transaction first!";
                return state;
            }
            homepage.ConsoleTextBox.Text = "Do you want to buy a track for $" + Bank.costOfTrack + "?";
            return "BuyTrack";
        }
        public static string buildTrack(string state)
        {
            if (state == "startTrack")
            {
                selectedStationForSource = currentStations.Find(i => i.Name == homepage.namingTextBox.Text.Trim());
                if (string.IsNullOrEmpty(homepage.namingTextBox.Text.Trim()))
                {
                    homepage.ConsoleTextBox.Text = "Sorry! You have to pick a Station";
                    return state;
                }
                if (selectedStationForSource == null)
                {
                    homepage.ConsoleTextBox.Text = "We couldn't find a Station named " + homepage.namingTextBox.Text.Trim();
                    return state;
                }
                
                homepage.ConsoleTextBox.Text = "Alright, we have set the start of the track to " + homepage.namingTextBox.Text.Trim() + " now, where do you want it to end?";
                homepage.namingTextBox.Text = null;
                return "endTrack";
            }
            if (state == "endTrack")
            {
                homepage.ConsoleTextBox.Text = "we made it to endTrack";
                if (string.IsNullOrEmpty(homepage.namingTextBox.Text.Trim()))
                {
                    homepage.ConsoleTextBox.Text = "Sorry! You have to pick a Station";
                    return state;
                }
                var selectedStationforDestination = currentStations.Find(i => i.Name == homepage.namingTextBox.Text.Trim());
                if (selectedStationforDestination == null)
                {
                    homepage.ConsoleTextBox.Text = "We couldn't find a Station named " + homepage.namingTextBox.Text.Trim();
                    return state;
                }
                homepage.ConsoleTextBox.Text = "You picked Station " + selectedStationforDestination.Name;
                homepage.namingTextBox.Text = null;
                homepage.ConsoleTextBox.Text = "Alright, we have set the track for you!";
                currentTracks.Add(new Track(selectedStationForSource,selectedStationforDestination));
                state = null;
                Train.updateTrainInfoBox();
                Station.updateStationInfoBox();
            }
            return state;
        }

    }
}
