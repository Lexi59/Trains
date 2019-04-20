using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainsProject
{
    class Train : Database
    {
        //constructor
        public Train(string name, Station startingStation)
        {
            Name = name;
            TrainCurrentLocation = null;
            Holding = new List<Package>();
            TrainCurrentLocation = startingStation;
        }

        //fields
        public string Name;
        public Station TrainCurrentLocation;
        public int TrainCapacity = 10;
        public List<Package> Holding;
        public int capacityUpgradeAmount = 5;

        public static HomePage Homepage { get; set; }
        internal static Train TrainForMove { get; set; }

        //methods
        public static void updateTrainInfoBox()
        {
            Homepage.trainInfoBox.Items.Clear();
            foreach (Train trainItem in CurrentTrains)
            {
                Homepage.trainInfoBox.Items.Add(trainItem.Name + "-" + trainItem.TrainCurrentLocation.Name);
                Homepage.trainInfoBox.Items.Add("    Packages:");
                foreach (Package packageItem in trainItem.Holding)
                {
                    Homepage.trainInfoBox.Items.Add("      " + packageItem.PackageType + "-" + packageItem.PackageValue + "  " + packageItem.PackageDestinationStation.Name);
                }
            }
            Package.spawningPackages();
        }
        public static string buyTrain(string state)
        {
            if (state == "BuyTrain")
            {
                if (CurrentStations.Count < 1)
                {
                    Homepage.ConsoleTextBox.Text = "Sorry! You can't buy a train until you have a station!";
                    return null;
                }
                if (Bank.CurrentMoney - Bank.costoftrain < 0)
                {
                    Homepage.ConsoleTextBox.Text = "Sorry! You can't do that! You don't have enough money!";
                    return null;
                }
                Homepage.ConsoleTextBox.Text = "You clicked yes! We bought you a Train. Please enter a name for it:";
                Bank.CurrentMoney -= Bank.costoftrain;
                Bank.updateMoneyBox();
                return "nameTrain";
            }
            if (state != null)
            {
                Homepage.ConsoleTextBox.Text += "Finish this transaction first!";
                return state;
            }
            Homepage.ConsoleTextBox.Text = "Do you want to buy a train for $" + Bank.costoftrain + "?";
            return"BuyTrain";
        }
        public static string upgradeTrain(string state)
        {
            if (state == "UpgradeTrain")
            {
                if (Bank.CurrentMoney - Bank.costOfTrainUpgrade < 0)
                {
                    Homepage.ConsoleTextBox.Text = "Sorry! You can't do that! You don't have enough money!";
                    return null;
                }
                Homepage.ConsoleTextBox.Text = "You clicked yes! We purchased an upgrade for you, which train would you like to use it on?";
                Bank.CurrentMoney -= Bank.costOfTrainUpgrade;
                Bank.updateMoneyBox();
                return "UpgradeWhichTrain";
            }
            if (CurrentTrains.Count < 1)
            {
                Homepage.ConsoleTextBox.Text = "You can't purchase a train upgrade before having a train!";
                state = null;
                return state;
            }
            if (state != null)
            {
                Homepage.ConsoleTextBox.Text += "Finish this transaction first!";
                return state;
            }
            Homepage.ConsoleTextBox.Text = "Do you want to upgrade a Train for $" + Bank.costOfTrainUpgrade + "?";
            return "UpgradeTrain";
        }
        public static string moveTrainPrep(string state)
        {
            if (state != null)
            {
                Homepage.ConsoleTextBox.Text += "Finish this transaction first!";
                return state;
            }
            if (CurrentTrains.Count < 1)
            {
                Homepage.ConsoleTextBox.Text = "Sorry! You can't move a train until you have a train";
                return state;
            }
            if (CurrentTracks.Count < 1)
            {
                Homepage.ConsoleTextBox.Text = "Sorry! You can't move a train until you have tracks!";
                return state;
            }
            Homepage.ConsoleTextBox.Text = "Alright, let's move a train. Which Train would you like to move?";
            return "MoveTrain";
        }
        public static string nameTrain(string state)
        {
            if (state == "nameTrain")
            {
                if (string.IsNullOrEmpty(Homepage.namingTextBox.Text.Trim()))
                {
                    Homepage.ConsoleTextBox.Text = "Sorry! You have to give it a name!";
                    return state;
                }
                Random random = new Random();
                CurrentTrains.Add(new Train(Homepage.namingTextBox.Text.Trim(), CurrentStations[random.Next(0, CurrentStations.Count)]));
                Homepage.ConsoleTextBox.Text = "Awesome! We named your new Train: " + Homepage.namingTextBox.Text.Trim();
                Train.updateTrainInfoBox();
                Station.updateStationInfoBox();
                Homepage.namingTextBox.Text = null;
                return null;
            }
            return state;
        }
        public static string upgradeWhichTrain(string state)
        {
            if (state == "UpgradeWhichTrain")
            {
                if (string.IsNullOrEmpty(Homepage.namingTextBox.Text.Trim()))
                {
                    Homepage.ConsoleTextBox.Text = "Sorry! You have to pick a train!";
                    return state;
                }
                var selectedTrainforUpgrade = CurrentTrains.Find(i => i.Name == Homepage.namingTextBox.Text.Trim());
                if (selectedTrainforUpgrade == null)
                {
                    Homepage.ConsoleTextBox.Text = "We couldn't find a train named " + Homepage.namingTextBox.Text.Trim();
                    return state;
                }
                selectedTrainforUpgrade.TrainCapacity += selectedTrainforUpgrade.capacityUpgradeAmount;
                Homepage.ConsoleTextBox.Text = "Awesome! We have upgraded the train named " + Homepage.namingTextBox.Text.Trim() + " to a capacity of " + selectedTrainforUpgrade.TrainCapacity;
                Homepage.namingTextBox.Text = null;
                return null;
            }
            return state;
        }
        public static string moveTrain(string state)
        {
            if (state == "MoveTrain")
            {
                if (string.IsNullOrEmpty(Homepage.namingTextBox.Text.Trim()))
                {
                    Homepage.ConsoleTextBox.Text = "Sorry! You have to pick a Train";
                    return state;
                }
                TrainForMove = CurrentTrains.Find(i => i.Name == Homepage.namingTextBox.Text.Trim());
                if (TrainForMove == null)
                {
                    Homepage.ConsoleTextBox.Text = "We couldn't find a train named " + Homepage.namingTextBox.Text.Trim();
                    return null;
                }
                Homepage.namingTextBox.Text = null;
                Homepage.ConsoleTextBox.Text = "Alright, we found your Train! It is at station " + TrainForMove.TrainCurrentLocation.Name + " .Go ahead and add any packages or press 'Yes' to continue.";
                state = "PackageManagement";
                foreach (Package i in TrainForMove.TrainCurrentLocation.PackagesWaiting)
                {
                    Homepage.packageSelectionDropDown.Items.Add(i.PackageType + "-" + i.PackageValue + "," + i.PackageDestinationStation.Name);
                }
                return state;
            }
            else if (state == "MoveTrainDestination")
            {
                if (string.IsNullOrEmpty(Homepage.namingTextBox.Text.Trim()))
                {
                    Homepage.ConsoleTextBox.Text += "Sorry! You have to pick a Station";
                    return state;
                }
                var selectedStationForMoving = CurrentStations.Find(i => i.Name == Homepage.namingTextBox.Text.Trim());
                if (selectedStationForMoving == null)
                {
                    Homepage.ConsoleTextBox.Text = "We couldn't find a Station named " + Homepage.namingTextBox.Text.Trim();
                    return state;
                }
                var trackExists = CurrentTracks.Find(i => i.sourceStation == TrainForMove.TrainCurrentLocation && i.destinationStation == selectedStationForMoving);
                if (trackExists == null)
                {
                    Homepage.ConsoleTextBox.Text = "Sorry, there is no track there. Transaction cancelled.";
                    Homepage.namingTextBox.Text = null;
                    return null;
                }
                TrainForMove.TrainCurrentLocation = selectedStationForMoving;
                Homepage.ConsoleTextBox.Text = "You have moved!";
                Homepage.namingTextBox.Text = null;
                Train.updateTrainInfoBox();
                Station.updateStationInfoBox();
                Homepage.packageSelectionDropDown.Items.Clear();
                Homepage.packageSelectionDropDown.SelectedItem = null;
                foreach (Package i in TrainForMove.Holding)
                {
                    if (i.PackageDestinationStation == TrainForMove.TrainCurrentLocation)
                    {
                        Bank.CurrentMoney += i.PackageValue;
                        Homepage.ConsoleTextBox.Text = "Awesome! Packages have been successfully delivered!";
                    }
                }
                TrainForMove.Holding.RemoveAll(i => i.PackageDestinationStation == TrainForMove.TrainCurrentLocation);
                Bank.updateMoneyBox();
                Train.updateTrainInfoBox();
                Station.updateStationInfoBox();
                state = null;
            }
            return state;
        }
    }
}
