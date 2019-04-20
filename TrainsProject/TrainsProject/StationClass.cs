using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainsProject
{
    class Station : Database
    {
        //constructor
        public Station(string name)
        {
            StationLocation = randomnumber.Next(0, mapSize+1);
            while (usedLocation.Contains(StationLocation))
            {
                StationLocation = new Random().Next(0, mapSize + 1);
            }
            usedLocation.Add(StationLocation); 
            Name = name;
        }
        //fields
        public string Name;
        const int mapSize = 100;
        private static List<int> usedLocation = new List<int>();
        private readonly Random randomnumber = new Random();
        public int StationLocation;
        public List<Package> PackagesWaiting = new List<Package>();
        private static int StationCapacity = 20;
        public static HomePage homepage;

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
            currentStations.Add(newStation);
            homepage.ConsoleTextBox.Text = "The length of station map grid is: " + stationMapGrid.Count;
            stationMapGrid[newStation.StationLocation].Visible = true;
            stationMapGrid[newStation.StationLocation].Text = newStation.Name;
            homepage.ConsoleTextBox.Text = "Awesome! We named your new station: " + homepage.namingTextBox.Text.Trim();
        }
        public static void updateStationInfoBox()
        {
            homepage.StationInfoBox.Items.Clear();
            foreach (Station stationItem in currentStations)
            {
                homepage.StationInfoBox.Items.Add("Name: " + stationItem.Name);
                homepage.StationInfoBox.Items.Add("  Destinations:");
                foreach (Track tracks in currentTracks)
                {
                    if (tracks.sourceStation.Name == stationItem.Name)
                    {
                        homepage.StationInfoBox.Items.Add("      " + tracks.destinationStation.Name);
                    }
                }
                homepage.StationInfoBox.Items.Add("  Packages:");
                foreach (Package packageItem in stationItem.PackagesWaiting)
                {
                    homepage.StationInfoBox.Items.Add("      " + packageItem.PackageType + "-" + packageItem.PackageValue + "  " + packageItem.PackageDestinationStation.Name);
                }
            }
            Package.spawningPackages();
        }
        public static string buyStation(String state)
        {
            if (state == "BuyStation")
            {
                if (Bank.currentMoney - Bank.costOfStation < 0)
                {
                    homepage.ConsoleTextBox.Text = "Sorry! You can't do that! You don't have enough money!";
                    return null;
                }
                homepage.ConsoleTextBox.Text = "You clicked yes! We bought you a station. Please enter a name for it:";
                Bank.currentMoney -= Bank.costOfStation;
                Bank.updateMoneyBox();
                return "nameStation";
            }
            if (state != null)
            {
                homepage.ConsoleTextBox.Text += "Finish this transaction first!";
                return state;
            }
            homepage.ConsoleTextBox.Text = "Do you want to buy a Station for $" + Bank.costOfStation + "?";
            return "BuyStation";

        }
        public static string nameStation(string state)
        {
            if (state == "nameStation")
            {
                if (string.IsNullOrEmpty(homepage.namingTextBox.Text.Trim()))
                {
                    homepage.ConsoleTextBox.Text = "Sorry! You have to give it a name!";
                    return state;
                }
                Station.createNewStation(new Station(homepage.namingTextBox.Text.Trim()));
                Train.updateTrainInfoBox();
                Station.updateStationInfoBox();
                homepage.namingTextBox.Text = null;
                return null;
            }
            return state;
        }
    }
}
