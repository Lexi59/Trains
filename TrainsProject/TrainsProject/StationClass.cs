using System;
using System.Collections.Generic;


namespace TrainsProject
{
    public class Station : Database
    {
        //constructor
        public Station(string name)
        {
            StationLocation = randomnumber.Next(0, mapSize+1);
            if(usedLocation.Count < StationMapGrid.Count)
            {
                while (usedLocation.Contains(StationLocation))
                {
                    StationLocation = new Random().Next(0, mapSize + 1);
                }
                    usedLocation.Add(StationLocation);
            }
            else
            {
                Homepage.ConsoleTextBox.Text = "Sorry! You are out of room. You can only move trains now.";
                Homepage.buyStationButton.Enabled = false;
            }
             
            Name = name;
        }

        const int mapSize = 100;
        private static List<int> usedLocation = new List<int>();
        private readonly Random randomnumber = new Random();
        private static int StationCapacity = 20;

        public static HomePage Homepage { get; set; }
        public string Name { get; set; }
        public int StationLocation { get; set; }
        public List<Package> PackagesWaiting { get; set; } = new List<Package>();

        //methods
        public void addPackage(Station destination)
        {
            if( PackagesWaiting.Count < StationCapacity)
            {
                Random random = new Random();
                if(Name != destination.Name)
                {
                    PackagesWaiting.Add(new Package(random, destination));
                }
            }
        }
        public static void createNewStation(Station newStation)
        {
            CurrentStations.Add(newStation);
            StationMapGrid[newStation.StationLocation].Visible = true;
            StationMapGrid[newStation.StationLocation].Text = newStation.Name;
            Homepage.ConsoleTextBox.Text = "Awesome! We named your new station: " + Homepage.namingTextBox.Text.Trim();
        }
        public static void updateStationInfoBox()
        {
            Homepage.StationInfoBox.Items.Clear();
            foreach (Station stationItem in CurrentStations)
            {
                Homepage.StationInfoBox.Items.Add("Name: " + stationItem.Name);
                Homepage.StationInfoBox.Items.Add("  Destinations:");
                foreach (Track tracks in CurrentTracks)
                {
                    if (tracks.sourceStation.Name == stationItem.Name)
                    {
                        Homepage.StationInfoBox.Items.Add("      " + tracks.destinationStation.Name);
                    }
                }
                Homepage.StationInfoBox.Items.Add("  Packages:");
                foreach (Package packageItem in stationItem.PackagesWaiting)
                {
                    Homepage.StationInfoBox.Items.Add("      " + packageItem.PackageType + "-" + packageItem.PackageValue + "  " + packageItem.PackageDestinationStation.Name);
                }
            }
            Package.spawningPackages();
        }
        public static string buyStation(String state)
        {
            if (state == "BuyStation")
            {
                if (Bank.CurrentMoney - Bank.costOfStation < 0)
                {
                    Homepage.ConsoleTextBox.Text = "Sorry! You can't do that! You don't have enough money!";
                    return null;
                }
                Homepage.ConsoleTextBox.Text = "You clicked yes! We bought you a station. Please enter a name for it:";
                Bank.CurrentMoney -= Bank.costOfStation;
                Bank.updateMoneyBox();
                return "nameStation";
            }
            if (state != null)
            {
                Homepage.ConsoleTextBox.Text += "Finish this transaction first!";
                return state;
            }
            Homepage.ConsoleTextBox.Text = "Do you want to buy a Station for $" + Bank.costOfStation + "?";
            return "BuyStation";

        }
        public static string nameStation(string state)
        {
            if (state == "nameStation")
            {
                if (string.IsNullOrEmpty(Homepage.namingTextBox.Text.Trim()))
                {
                    Homepage.ConsoleTextBox.Text = "Sorry! You have to give it a name!";
                    return state;
                }
                Station.createNewStation(new Station(Homepage.namingTextBox.Text.Trim()));
                Train.updateTrainInfoBox();
                Station.updateStationInfoBox();
                Homepage.namingTextBox.Text = null;
                return null;
            }
            return state;
        }
    }
}
