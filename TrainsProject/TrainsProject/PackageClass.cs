using System;

namespace TrainsProject
{
    public class Package : Database
    {
        //constructor
        public Package(Random RandomNumber, Station destination)
        {
            string[] packageTypeArray = { "Toys", "Gifts", "Electronics", "Clothes", "Food" };
            int randomNumberForPackageType = RandomNumber.Next(0, packageTypeArray.Length);
            PackageType = packageTypeArray[randomNumberForPackageType];
            PackageValue = RandomNumber.Next(0, 300);
            PackageDestinationStation = destination;
        }
        //fields
        public string PackageType;
        public int PackageValue;
        public Station PackageDestinationStation;

        public static HomePage Homepage { get; set; }

        //methods
        public static void spawningPackages()
        {
            if (Database.CurrentStations.Count > 1)
            {
                Random random = new Random();
                int randomNumOfPackages = random.Next(0, 5);
                for (int i = 0; i < randomNumOfPackages; i++)
                {
                    int randomStation = random.Next(0, CurrentStations.Count);
                    CurrentStations[randomStation].addPackage(CurrentStations[random.Next(0, CurrentStations.Count)]);
                }
            }
        }
        public static string packageManagement(string state)
        {
            if (state == "PackageManagementComplete")
            {
                Homepage.ConsoleTextBox.Text = "Alright, all done adding packages. Where do you want to go?";
                return "MoveTrainDestination";
            }
            return state;
        }
        public static string packageManagement(string state, Train trainForMove)
        {
            if (state == "PackageManagement" && Homepage.packageSelectionDropDown.SelectedItem != null && trainForMove != null)
            {
                if (trainForMove.Holding.Count + 1 < trainForMove.TrainCapacity && !trainForMove.Holding.Contains(trainForMove.TrainCurrentLocation.PackagesWaiting[Homepage.packageSelectionDropDown.SelectedIndex]))
                {
                    trainForMove.Holding.Add(trainForMove.TrainCurrentLocation.PackagesWaiting[Homepage.packageSelectionDropDown.SelectedIndex]);
                    Homepage.ConsoleTextBox.Text = "Alright, we have added the package for you. Are you done?";
                    Train.updateTrainInfoBox();
                    Station.updateStationInfoBox();
                }
                else if (trainForMove.Holding.Contains(trainForMove.TrainCurrentLocation.PackagesWaiting[Homepage.packageSelectionDropDown.SelectedIndex]))
                {
                    trainForMove.Holding.Remove(trainForMove.TrainCurrentLocation.PackagesWaiting[Homepage.packageSelectionDropDown.SelectedIndex]);
                    Homepage.ConsoleTextBox.Text = "We have removed the package for you!";
                }
                else
                {
                    Homepage.ConsoleTextBox.Text = "Sorry! You don't have room!";
                }
            }
            return state;
        }
    }
}
