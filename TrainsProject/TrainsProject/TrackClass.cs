using System;

namespace TrainsProject
{
    public class Track : Database
    {
        //constructor
        public Track(Station source, Station destination)
        {
            sourceStation = source;
            destinationStation = destination;
        }

        //fields
        public Station sourceStation;
        public Station destinationStation;
        private static Station selectedStationForSource;

        public static HomePage Homepage { get; set; }

        //methods
        public static string buyTrack(string state)
        {
            if (state == "BuyTrack")
            {
                if (CurrentStations.Count < 2)
                {
                    Homepage.ConsoleTextBox.Text = "Sorry! You can't buy a track until you have 2 stations!";
                    return null;
                }
                if (Bank.CurrentMoney - Bank.costOfTrack < 0)
                {
                    Homepage.ConsoleTextBox.Text = "Sorry! You can't do that! You don't have enough money!";
                    return null;
                }
                Homepage.ConsoleTextBox.Text = "You clicked yes! We purchased an Track for you, where would you like to start it?";
                Bank.CurrentMoney -= Bank.costOfTrack;
                Bank.updateMoneyBox();
                return "startTrack";
            }
            if (state != null)
            {
                Homepage.ConsoleTextBox.Text += "Finish this transaction first!";
                return state;
            }
            Homepage.ConsoleTextBox.Text = "Do you want to buy a track for $" + Bank.costOfTrack + "?";
            return "BuyTrack";
        }
        public static string buildTrack(string state)
        {
            if (state == "startTrack")
            {
                selectedStationForSource = CurrentStations.Find(i => i.Name == Homepage.namingTextBox.Text.Trim());
                if (string.IsNullOrEmpty(Homepage.namingTextBox.Text.Trim()))
                {
                    Homepage.ConsoleTextBox.Text = "Sorry! You have to pick a Station";
                    return state;
                }
                if (selectedStationForSource == null)
                {
                    Homepage.ConsoleTextBox.Text = "We couldn't find a Station named " + Homepage.namingTextBox.Text.Trim();
                    return state;
                }
                
                Homepage.ConsoleTextBox.Text = "Alright, we have set the start of the track to " + Homepage.namingTextBox.Text.Trim() + " now, where do you want it to end?";
                Homepage.namingTextBox.Text = null;
                return "endTrack";
            }
            if (state == "endTrack")
            {
                Homepage.ConsoleTextBox.Text = "we made it to endTrack";
                if (string.IsNullOrEmpty(Homepage.namingTextBox.Text.Trim()))
                {
                    Homepage.ConsoleTextBox.Text = "Sorry! You have to pick a Station";
                    return state;
                }
                var selectedStationforDestination = CurrentStations.Find(i => i.Name == Homepage.namingTextBox.Text.Trim());
                if (selectedStationforDestination == null)
                {
                    Homepage.ConsoleTextBox.Text = "We couldn't find a Station named " + Homepage.namingTextBox.Text.Trim();
                    return state;
                }
                Homepage.ConsoleTextBox.Text = "You picked Station " + selectedStationforDestination.Name;
                Homepage.namingTextBox.Text = null;
                if(selectedStationforDestination == selectedStationForSource)
                {
                    Homepage.ConsoleTextBox.Text = "Sorry, you can't make a looped track. Transaction cancelled.";
                    Bank.CurrentMoney += Bank.costOfTrack;
                    Bank.updateMoneyBox();
                    return null;
                }
                Homepage.ConsoleTextBox.Text = "Alright, we have set the track for you!";
                CurrentTracks.Add(new Track(selectedStationForSource,selectedStationforDestination));
                state = null;
                Train.updateTrainInfoBox();
                Station.updateStationInfoBox();
            }
            return state;
        }

    }
}
