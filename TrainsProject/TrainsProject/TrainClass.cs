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
        private Station TrainDepartureStation;
        private Station TrainDestinationStation;
        public List<Package> Holding;
        public static HomePage homepage;
        public int capacityUpgradeAmount = 5;
        public static Train trainForMove;

        //methods
        public static void updateTrainInfoBox()
        {
            homepage.trainInfoBox.Items.Clear();
            foreach (Train trainItem in currentTrains)
            {
                homepage.trainInfoBox.Items.Add(trainItem.Name + "-" + trainItem.TrainCurrentLocation.Name);
                homepage.trainInfoBox.Items.Add("    Packages:");
                foreach (Package packageItem in trainItem.Holding)
                {
                    homepage.trainInfoBox.Items.Add("      " + packageItem.PackageType + "-" + packageItem.PackageValue + "  " + packageItem.PackageDestinationStation.Name);
                }
            }
            Package.spawningPackages();
        }
        public static string buyTrain(string state)
        {
            if (state == "BuyTrain")
            {
                if (currentStations.Count < 1)
                {
                    homepage.ConsoleTextBox.Text = "Sorry! You can't buy a train until you have a station!";
                    return null;
                }
                if (Bank.currentMoney - Bank.costoftrain < 0)
                {
                    homepage.ConsoleTextBox.Text = "Sorry! You can't do that! You don't have enough money!";
                    return null;
                }
                homepage.ConsoleTextBox.Text = "You clicked yes! We bought you a Train. Please enter a name for it:";
                Bank.currentMoney -= Bank.costoftrain;
                Bank.updateMoneyBox();
                return "nameTrain";
            }
            if (state != null)
            {
                homepage.ConsoleTextBox.Text += "Finish this transaction first!";
                return state;
            }
            homepage.ConsoleTextBox.Text = "Do you want to buy a train for $" + Bank.costoftrain + "?";
            return"BuyTrain";
        }
        public static string upgradeTrain(string state)
        {
            if (state == "UpgradeTrain")
            {
                if (Bank.currentMoney - Bank.costOfTrainUpgrade < 0)
                {
                    homepage.ConsoleTextBox.Text = "Sorry! You can't do that! You don't have enough money!";
                    return null;
                }
                homepage.ConsoleTextBox.Text = "You clicked yes! We purchased an upgrade for you, which train would you like to use it on?";
                Bank.currentMoney -= Bank.costOfTrainUpgrade;
                Bank.updateMoneyBox();
                return "UpgradeWhichTrain";
            }
            if (currentTrains.Count < 1)
            {
                homepage.ConsoleTextBox.Text = "You can't purchase a train upgrade before having a train!";
                state = null;
                return state;
            }
            if (state != null)
            {
                homepage.ConsoleTextBox.Text += "Finish this transaction first!";
                return state;
            }
            homepage.ConsoleTextBox.Text = "Do you want to upgrade a Train for $" + Bank.costOfTrainUpgrade + "?";
            return "UpgradeTrain";
        }
        public static string moveTrainPrep(string state)
        {
            if (state != null)
            {
                homepage.ConsoleTextBox.Text += "Finish this transaction first!";
                return state;
            }
            if (currentTrains.Count < 1)
            {
                homepage.ConsoleTextBox.Text = "Sorry! You can't move a train until you have a train";
                return state;
            }
            if (currentTracks.Count < 1)
            {
                homepage.ConsoleTextBox.Text = "Sorry! You can't move a train until you have tracks!";
                return state;
            }
            homepage.ConsoleTextBox.Text = "Alright, let's move a train. Which Train would you like to move?";
            return "MoveTrain";
        }
        public static string nameTrain(string state)
        {
            if (state == "nameTrain")
            {
                if (string.IsNullOrEmpty(homepage.namingTextBox.Text.Trim()))
                {
                    homepage.ConsoleTextBox.Text = "Sorry! You have to give it a name!";
                    return state;
                }
                Random random = new Random();
                currentTrains.Add(new Train(homepage.namingTextBox.Text.Trim(), currentStations[random.Next(0, currentStations.Count)]));
                homepage.ConsoleTextBox.Text = "Awesome! We named your new Train: " + homepage.namingTextBox.Text.Trim();
                Train.updateTrainInfoBox();
                Station.updateStationInfoBox();
                homepage.namingTextBox.Text = null;
                return null;
            }
            return state;
        }
        public static string upgradeWhichTrain(string state)
        {
            if (state == "UpgradeWhichTrain")
            {
                if (string.IsNullOrEmpty(homepage.namingTextBox.Text.Trim()))
                {
                    homepage.ConsoleTextBox.Text = "Sorry! You have to pick a train!";
                    return state;
                }
                var selectedTrainforUpgrade = currentTrains.Find(i => i.Name == homepage.namingTextBox.Text.Trim());
                if (selectedTrainforUpgrade == null)
                {
                    homepage.ConsoleTextBox.Text = "We couldn't find a train named " + homepage.namingTextBox.Text.Trim();
                    return state;
                }
                selectedTrainforUpgrade.TrainCapacity += selectedTrainforUpgrade.capacityUpgradeAmount;
                homepage.ConsoleTextBox.Text = "Awesome! We have upgraded the train named " + homepage.namingTextBox.Text.Trim() + " to a capacity of " + selectedTrainforUpgrade.TrainCapacity;
                homepage.namingTextBox.Text = null;
                return null;
            }
            return state;
        }
        public static string moveTrain(string state)
        {
            if (state == "MoveTrain")
            {
                if (string.IsNullOrEmpty(homepage.namingTextBox.Text.Trim()))
                {
                    homepage.ConsoleTextBox.Text = "Sorry! You have to pick a Train";
                    return state;
                }
                trainForMove = currentTrains.Find(i => i.Name == homepage.namingTextBox.Text.Trim());
                if (trainForMove == null)
                {
                    homepage.ConsoleTextBox.Text = "We couldn't find a train named " + homepage.namingTextBox.Text.Trim();
                    return null;
                }
                homepage.namingTextBox.Text = null;
                homepage.ConsoleTextBox.Text = "Alright, we found your Train! It is at station " + trainForMove.TrainCurrentLocation.Name + " .Go ahead and add any packages or press 'Yes' to continue.";
                state = "PackageManagement";
                foreach (Package i in trainForMove.TrainCurrentLocation.PackagesWaiting)
                {
                    homepage.packageSelectionDropDown.Items.Add(i.PackageType + "-" + i.PackageValue + "," + i.PackageDestinationStation.Name);
                }
                return state;
            }
            else if (state == "MoveTrainDestination")
            {
                if (string.IsNullOrEmpty(homepage.namingTextBox.Text.Trim()))
                {
                    homepage.ConsoleTextBox.Text += "Sorry! You have to pick a Station";
                    return state;
                }
                var selectedStationForMoving = currentStations.Find(i => i.Name == homepage.namingTextBox.Text.Trim());
                if (selectedStationForMoving == null)
                {
                    homepage.ConsoleTextBox.Text = "We couldn't find a Station named " + homepage.namingTextBox.Text.Trim();
                    return state;
                }
                var trackExists = currentTracks.Find(i => i.sourceStation == trainForMove.TrainCurrentLocation && i.destinationStation == selectedStationForMoving);
                if (trackExists == null)
                {
                    homepage.ConsoleTextBox.Text = "Sorry, there is no track there. Transaction cancelled.";
                    homepage.namingTextBox.Text = null;
                    return null;
                }
                trainForMove.TrainCurrentLocation = selectedStationForMoving;
                homepage.ConsoleTextBox.Text = "You have moved!";
                homepage.namingTextBox.Text = null;
                Train.updateTrainInfoBox();
                Station.updateStationInfoBox();
                homepage.packageSelectionDropDown.Items.Clear();
                homepage.packageSelectionDropDown.SelectedItem = null;
                foreach (Package i in trainForMove.Holding)
                {
                    if (i.PackageDestinationStation == trainForMove.TrainCurrentLocation)
                    {
                        Bank.currentMoney += i.PackageValue;
                        homepage.ConsoleTextBox.Text = "Awesome! Packages have been successfully delivered!";
                    }
                }
                trainForMove.Holding.RemoveAll(i => i.PackageDestinationStation == trainForMove.TrainCurrentLocation);
                Bank.updateMoneyBox();
                Train.updateTrainInfoBox();
                Station.updateStationInfoBox();
                state = null;
            }
            return state;
        }
    }
}
