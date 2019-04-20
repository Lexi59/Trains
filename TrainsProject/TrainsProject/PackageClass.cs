using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainsProject
{
    class Package : Database
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
        public static HomePage homepage;

        //methods
        public static void spawningPackages()
        {
            if (Database.currentStations.Count > 1)
            {
                Random random = new Random();
                int randomNumOfPackages = random.Next(0, 5);
                for (int i = 0; i < randomNumOfPackages; i++)
                {
                    int randomStation = random.Next(0, currentStations.Count);
                    currentStations[randomStation].addPackage(currentStations[random.Next(0, currentStations.Count)]);
                }
            }
        }
        public static string packageManagement(string state, Train trainForMove = null)
        {
            if (state == "PackageManagementComplete")
            {
                homepage.ConsoleTextBox.Text = "Alright, all done adding packages. Where do you want to go?";
                return "MoveTrainDestination";
            }
            if (state == "PackageManagement" && homepage.packageSelectionDropDown.SelectedItem != null && trainForMove != null)
            {
                if (trainForMove.Holding.Count + 1 < trainForMove.TrainCapacity && !trainForMove.Holding.Contains(trainForMove.TrainCurrentLocation.PackagesWaiting[homepage.packageSelectionDropDown.SelectedIndex]))
                {
                    trainForMove.Holding.Add(trainForMove.TrainCurrentLocation.PackagesWaiting[homepage.packageSelectionDropDown.SelectedIndex]);
                    homepage.ConsoleTextBox.Text = "Alright, we have added the package for you. Are you done?";
                    Train.updateTrainInfoBox();
                    Station.updateStationInfoBox();
                }
                else if (trainForMove.Holding.Contains(trainForMove.TrainCurrentLocation.PackagesWaiting[homepage.packageSelectionDropDown.SelectedIndex]))
                {
                    trainForMove.Holding.Remove(trainForMove.TrainCurrentLocation.PackagesWaiting[homepage.packageSelectionDropDown.SelectedIndex]);
                    homepage.ConsoleTextBox.Text = "We have removed the package for you!";
                }
                else
                {
                    homepage.ConsoleTextBox.Text = "Sorry! You don't have room!";
                }
            }
            return state;
        }
    }
}
