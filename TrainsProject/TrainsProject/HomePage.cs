using System;
using System.Windows.Forms;

namespace TrainsProject
{
    public partial class HomePage : Form 
    {
        //variables
        private string state = null;
        private Bank bank;

        public static HomePage ReferenceToHomePage { get; set; }

        //constructor
        public HomePage()
        {
            InitializeComponent();
            bank = new Bank();
            Database.InitializeMap(this);
            ReferenceToHomePage = this;
            Bank.Homepage = this;
            Track.Homepage = this;
            Package.Homepage = this;
            Station.Homepage = this;
            Train.Homepage = this;
        }

        //events
        private void Form1_Load(object sender, EventArgs e)
        {
            Bank.updateMoneyBox();
        }

        private void buyStationButton_Click(object sender, EventArgs e)
        {
            state = Station.buyStation(state);
        }

        private void buyTrainsButton_Click(object sender, EventArgs e)
        {
            state = Train.buyTrain(state);
        }

        private void upgradeTrainButton_Click(object sender, EventArgs e)
        {
            state = Train.upgradeTrain(state);
        }

        private void buildTrackButton_Click(object sender, EventArgs e)
        {
            state = Track.buyTrack(state);
        }
        private void moveTrainButton_Click(object sender, EventArgs e)
        {
            state = Train.moveTrainPrep(state);
        }
        private void YesButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(state))
            {
                if (state == "BuyStation")
                {
                    state = Station.buyStation(state);
                }
                else if (state == "BuyTrain")
                {
                    state = Train.buyTrain(state);
                }
                else if (state == "UpgradeTrain")
                {
                    state = Train.upgradeTrain(state);
                }
                else if (state == "BuyTrack")
                {
                    state = Track.buyTrack(state);
                }
                else if (state == "PackageManagement")
                {
                    state = Package.packageManagement("PackageManagementComplete");
                }
            }
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
                state = Station.nameStation(state);
            }
            else if (state == "nameTrain")
            {
                state = Train.nameTrain(state);
            }
            else if (state == "UpgradeWhichTrain")
            {
                state = Train.upgradeWhichTrain(state);
            }
            else if (state == "startTrack")
            {
                state = Track.buildTrack(state);
            }
            else if (state == "endTrack")
            {
                state = Track.buildTrack(state);
            }
            else if (state == "MoveTrain")
            {
                state = Train.moveTrain(state);
            }
            else if (state == "MoveTrainDestination")
            {
                state = Train.moveTrain(state);
            }
        }

        private void packageSelectButton_Click(object sender, EventArgs e)
        {
            if (state == "PackageManagement")
            {
                state = Package.packageManagement(state, Train.TrainForMove);
            }
        }
    }
}
