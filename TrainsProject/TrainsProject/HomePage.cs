﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;

namespace TrainsProject
{
    public partial class HomePage : Form
    {
        //variables
        private int currentMoney = 500;
        private string state = null;
        private int costOfStation = 100;
        private int costoftrain = 50;
        private int costOfTrainUpgrade = 50;
        private int costOfTrack = 25;
        private int capacityUpgradeAmount = 5;
        private Station newTrackSource;
        private Train trainForMove;
        List<Station> currentStations = new List<Station>();
        List<Train> currentTrains = new List<Train>();
        List<Control> stationMapGrid = new List<Control>();
        List<Track> currentTracks = new List<Track>();

        public HomePage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateMoneyBox();
            for (int x = 1; x<101; x++)
            {
                var textboxName = string.Format("textBox{0}", x);
                var foundTextboxes = Controls.Find(textboxName, true);
                if(foundTextboxes[0] != null)
                {
                    stationMapGrid.Add(foundTextboxes[0]);
                }
            } 
        }

        //functions
        private void updateMoneyBox()
        {
            CurrentMoneyTextBox.Text = "Current Money: $" + currentMoney;
        }

        private void createNewStation(string name)
        {
            Station newStation = new Station(name);
            currentStations.Add(newStation);
            stationMapGrid[newStation.StationLocation].Visible = true;
            stationMapGrid[newStation.StationLocation].Text = newStation.Name;
            ConsoleTextBox.Text = "Awesome! We named your new station: " + namingTextBox.Text.Trim();
        }
        private void spawningPackages()
        {
            if (currentStations.Count > 1)
            {
                Random random = new Random();
                int randomNumOfPackages = random.Next(0, 5);
                for (int i = 0; i < randomNumOfPackages; i++)
                {
                    int randomStation = random.Next(0, currentStations.Count);
                    currentStations[randomStation].addPackage(currentStations[random.Next(0,currentStations.Count)]);
                }
            }
        }
        private void updateTrainandStationInfoBoxes()
        {
            StationInfoBox.Items.Clear();
            trainInfoBox.Items.Clear();
            foreach(Station stationItem in currentStations)
            {
                StationInfoBox.Items.Add("Name: " + stationItem.Name);
                StationInfoBox.Items.Add("  Destinations:");
                foreach(Track tracks in currentTracks)
                {
                    if(tracks.sourceStation.Name == stationItem.Name)
                    {
                        StationInfoBox.Items.Add("      " + tracks.destinationStation.Name);
                    }
                }
                StationInfoBox.Items.Add("  Packages:");
                foreach(Package packageItem in stationItem.PackagesWaiting)
                {
                    StationInfoBox.Items.Add("      " + packageItem.PackageType + "-" + packageItem.PackageValue + "  " + packageItem.PackageDestinationStation.Name);
                }
            }
            foreach (Train trainItem in currentTrains)
            {
                trainInfoBox.Items.Add(trainItem.Name + "-" + trainItem.TrainCurrentLocation.Name);
                trainInfoBox.Items.Add("    Packages:");
                foreach(Package packageItem in trainItem.Holding)
                {
                    trainInfoBox.Items.Add("      " + packageItem.PackageType + "-" + packageItem.PackageValue + "  " + packageItem.PackageDestinationStation.Name);
                }
            }
            spawningPackages();
        }

        //events
        private void buyStationButton_Click(object sender, EventArgs e)
        {
            if(state != null)
            {
                ConsoleTextBox.Text += "Finish this transaction first!";
                return;
            }
            ConsoleTextBox.Text = "Do you want to buy a Station for $" + costOfStation + "?";
            state = "BuyStation";
        }

        private void buyTrainsButton_Click(object sender, EventArgs e)
        {
            if (state != null)
            {
                ConsoleTextBox.Text += "Finish this transaction first!";
                return;
            }
            ConsoleTextBox.Text = "Do you want to buy a train for $" + costoftrain + "?";
            state = "BuyTrain";
        }

        private void upgradeTrainButton_Click(object sender, EventArgs e)
        {
            if (currentTrains.Count < 1)
            {
                ConsoleTextBox.Text = "You can't purchase a train upgrade before having a train!";
                state = null;
                return;
            }
            if (state != null)
            {
                ConsoleTextBox.Text += "Finish this transaction first!";
                return;
            }
            ConsoleTextBox.Text = "Do you want to upgrade a Train for $" + costOfTrainUpgrade + "?";
            state = "UpgradeTrain";
        }

        private void buildTrackButton_Click(object sender, EventArgs e)
        {
            if (state != null)
            {
                ConsoleTextBox.Text += "Finish this transaction first!";
                return;
            }
            ConsoleTextBox.Text = "Do you want to buy a track for $" + costOfTrack + "?";
            state = "BuyTrack";
        }
        private void moveTrainButton_Click(object sender, EventArgs e)
        {
            if (state != null)
            {
                ConsoleTextBox.Text += "Finish this transaction first!";
                return;
            }
            if (currentTrains.Count < 1)
            {
                ConsoleTextBox.Text = "Sorry! You can't move a train until you have a train";
                return;
            }
            if(currentTracks.Count < 1)
            {
                ConsoleTextBox.Text = "Sorry! You can't move a train until you have tracks!";
                return;
            }
            ConsoleTextBox.Text = "Alright, let's move a train. Which Train would you like to move?";
            state = "MoveTrain";
        }
        private void YesButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(state))
            {
                if(state == "BuyStation")
                {
                    if(currentMoney - costOfStation < 0)
                    {
                        ConsoleTextBox.Text = "Sorry! You can't do that! You don't have enough money!";
                        state = null;
                        return;
                    }
                    ConsoleTextBox.Text = "You clicked yes! We bought you a station. Please enter a name for it:";
                    currentMoney -= costOfStation;
                    updateMoneyBox();
                    state = "nameStation";
                }
                if (state == "BuyTrain")
                {
                    if(currentStations.Count < 1)
                    {
                        ConsoleTextBox.Text = "Sorry! You can't buy a train until you have a station!";
                        state = null;
                        return;
                    }
                    if (currentMoney - costoftrain < 0)
                    {
                        ConsoleTextBox.Text = "Sorry! You can't do that! You don't have enough money!";
                        state = null;
                        return;
                    }
                    ConsoleTextBox.Text = "You clicked yes! We bought you a Train. Please enter a name for it:";
                    currentMoney -= costoftrain;
                    updateMoneyBox();
                    state = "nameTrain";
                }
                if (state == "UpgradeTrain")
                {
                    if (currentMoney - costOfTrainUpgrade < 0)
                    {
                        ConsoleTextBox.Text = "Sorry! You can't do that! You don't have enough money!";
                        state = null;
                        return;
                    }
                    ConsoleTextBox.Text = "You clicked yes! We purchased an upgrade for you, which train would you like to use it on?";
                    currentMoney -= costOfTrainUpgrade;
                    updateMoneyBox();
                    state = "UpgradeWhichTrain";
                }
                if (state == "BuyTrack")
                {
                    if(currentStations.Count < 2)
                    {
                        ConsoleTextBox.Text = "Sorry! You can't buy a track until you have 2 stations!";
                        state = null;
                        return;
                    }
                    if(currentMoney - costOfTrack < 0)
                    {
                        ConsoleTextBox.Text = "Sorry! You can't do that! You don't have enough money!";
                        state = null;
                        return;
                    }
                    ConsoleTextBox.Text = "You clicked yes! We purchased an Track for you, where would you like to start it?";
                    currentMoney -= costOfTrack;
                    updateMoneyBox();
                    state = "startTrack";
                }
                if (state == "PackageManagement")
                {
                    ConsoleTextBox.Text = "Alright, all done adding packages. Where do you want to go?";
                    state = "MoveTrainDestination";
                }
            }
            spawningPackages();
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            if(state == "BuyStation")
            {
                ConsoleTextBox.Text = "Station purchase cancelled";
            }
            if (state == "BuyTrain")
            {
                ConsoleTextBox.Text = "Train purchase cancelled";
            }
            if (state == "UpgradeTrain")
            {
                ConsoleTextBox.Text = "Train Upgrade cancelled";
            }
            if (state == "BuyTrack")
            {
                ConsoleTextBox.Text = "Track purchase cancelled";
            }
            if (state == "PackageManagement")
            {
                ConsoleTextBox.Text = "Okay, keep adding items then";
                return;
            }
            state = null;
        }

        private void namingSubmit_Click(object sender, EventArgs e)
        {
            if (state == "nameStation")
            {
                if (string.IsNullOrEmpty(namingTextBox.Text.Trim()))
                {
                    ConsoleTextBox.Text = "Sorry! You have to give it a name!";
                    return;
                }
                createNewStation(namingTextBox.Text.Trim());
                updateTrainandStationInfoBoxes();
                namingTextBox.Text = null;
                state = null; 
            }
            if (state == "nameTrain")
            {
                if (string.IsNullOrEmpty(namingTextBox.Text.Trim()))
                {
                    ConsoleTextBox.Text = "Sorry! You have to give it a name!";
                    return;
                }
                Random random = new Random();
                currentTrains.Add(new Train(namingTextBox.Text.Trim(),currentStations[random.Next(0,currentStations.Count)]));
                ConsoleTextBox.Text = "Awesome! We named your new Train: " + namingTextBox.Text.Trim();
                updateTrainandStationInfoBoxes();
                namingTextBox.Text = null;
                state = null;
            }
            if (state == "UpgradeWhichTrain")
            {
                if (string.IsNullOrEmpty(namingTextBox.Text.Trim()))
                {
                    ConsoleTextBox.Text = "Sorry! You have to pick a train!";
                    return;
                }
                var selectedTrainforUpgrade = currentTrains.Find(i => i.Name == namingTextBox.Text.Trim());
                if(selectedTrainforUpgrade == null)
                {
                    ConsoleTextBox.Text = "We couldn't find a train named " + namingTextBox.Text.Trim();
                    return;
                }
                selectedTrainforUpgrade.TrainCapacity += capacityUpgradeAmount;
                ConsoleTextBox.Text = "Awesome! We have upgraded the train named " + namingTextBox.Text.Trim() + " to a capacity of " + selectedTrainforUpgrade.TrainCapacity;
                namingTextBox.Text = null;
                state = null;
            }
            if (state == "startTrack")
            {
                if (string.IsNullOrEmpty(namingTextBox.Text.Trim()))
                {
                    ConsoleTextBox.Text = "Sorry! You have to pick a Station";
                    return;
                }
                var selectedStationforSource = currentStations.Find(i => i.Name == namingTextBox.Text.Trim());
                if(selectedStationforSource == null)
                {
                    ConsoleTextBox.Text = "We couldn't find a Station named " + namingTextBox.Text.Trim();
                    return;
                }
                newTrackSource = selectedStationforSource;
                namingTextBox.Text = null;
                ConsoleTextBox.Text = "Alright, we have set the start of the track to " + namingTextBox.Text.Trim() + " now, where do you want it to end?";
                state = "endTrack";
                return;
            }
            if (state == "endTrack")
            {
                if (string.IsNullOrEmpty(namingTextBox.Text.Trim()))
                {
                    ConsoleTextBox.Text = "Sorry! You have to pick a Station";
                    return;
                }
                var selectedStationforDestination = currentStations.Find(i => i.Name == namingTextBox.Text.Trim());
                if (selectedStationforDestination == null)
                {
                    ConsoleTextBox.Text = "We couldn't find a Station named " + namingTextBox.Text.Trim();
                    return;
                }
                namingTextBox.Text = null;
                ConsoleTextBox.Text = "Alright, we have set the track for you!";
                currentTracks.Add(new Track(newTrackSource, selectedStationforDestination));
                state = null;
                updateTrainandStationInfoBoxes();
            }
            if (state == "MoveTrain")
            {
                if (string.IsNullOrEmpty(namingTextBox.Text.Trim()))
                {
                    ConsoleTextBox.Text = "Sorry! You have to pick a Train";
                    return;
                }
                var selectedTrainforMoving = currentTrains.Find(i => i.Name == namingTextBox.Text.Trim());
                if (selectedTrainforMoving == null)
                {
                    ConsoleTextBox.Text = "We couldn't find a train named " + namingTextBox.Text.Trim();
                    return;
                }
                namingTextBox.Text = null;
                ConsoleTextBox.Text = "Alright, we found your Train! It is at station " + selectedTrainforMoving.TrainCurrentLocation.Name + " .Go ahead and add any packages or press 'Yes' to continue.";
                trainForMove = selectedTrainforMoving;
                state = "PackageManagement";
                foreach (Package i in trainForMove.TrainCurrentLocation.PackagesWaiting)
                {
                    packageSelectionDropDown.Items.Add(i.PackageType + "-" + i.PackageValue + "," + i.PackageDestinationStation.Name);
                }
                return;
            }
            if (state == "MoveTrainDestination")
            {
                if (string.IsNullOrEmpty(namingTextBox.Text.Trim()))
                {
                    ConsoleTextBox.Text += "Sorry! You have to pick a Station";
                    return;
                }
                var selectedStationForMoving = currentStations.Find(i => i.Name == namingTextBox.Text.Trim());
                if (selectedStationForMoving == null)
                {
                    ConsoleTextBox.Text = "We couldn't find a Station named " + namingTextBox.Text.Trim();
                    return;
                }
                var trackExists = currentTracks.Find(i => i.sourceStation == trainForMove.TrainCurrentLocation && i.destinationStation == selectedStationForMoving);
                if(trackExists == null)
                {
                    ConsoleTextBox.Text = "Sorry, there is no track there. Transaction cancelled.";
                    namingTextBox.Text = null;
                    state = null;
                    return;
                }
                trainForMove.TrainCurrentLocation = selectedStationForMoving;
                ConsoleTextBox.Text = "You have moved!";
                namingTextBox.Text = null;
                updateTrainandStationInfoBoxes();
                packageSelectionDropDown.Items.Clear();
                packageSelectionDropDown.SelectedItem = null;
                foreach(Package i in trainForMove.Holding)
                {
                    if(i.PackageDestinationStation == trainForMove.TrainCurrentLocation)
                    {
                        currentMoney += i.PackageValue;
                        ConsoleTextBox.Text = "Awesome! Packages have been successfully delivered!";
                    }
                }
                trainForMove.Holding.RemoveAll(i => i.PackageDestinationStation == trainForMove.TrainCurrentLocation);
                updateMoneyBox();
                updateTrainandStationInfoBoxes();
                state = null;
            }
        }

        private void packageSelectButton_Click(object sender, EventArgs e)
        {
            if (state == "PackageManagement" && packageSelectionDropDown.SelectedItem != null)
            {
                if(trainForMove.Holding.Count + 1 < trainForMove.TrainCapacity && !trainForMove.Holding.Contains(trainForMove.TrainCurrentLocation.PackagesWaiting[packageSelectionDropDown.SelectedIndex]))
                {
                    trainForMove.Holding.Add(trainForMove.TrainCurrentLocation.PackagesWaiting[packageSelectionDropDown.SelectedIndex]);
                    ConsoleTextBox.Text = "Alright, we have added the package for you. Are you done?";
                    updateTrainandStationInfoBoxes();
                }
                else if (trainForMove.Holding.Contains(trainForMove.TrainCurrentLocation.PackagesWaiting[packageSelectionDropDown.SelectedIndex]))
                {
                    trainForMove.Holding.Remove(trainForMove.TrainCurrentLocation.PackagesWaiting[packageSelectionDropDown.SelectedIndex]);
                    ConsoleTextBox.Text = "We have removed the package for you!";
                }
                else
                {
                    ConsoleTextBox.Text = "Sorry! You don't have room!";
                }
            }
        }
    }
}
