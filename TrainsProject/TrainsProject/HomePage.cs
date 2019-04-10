using System;
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
        private int currentMoney = 500;
        private string state = null;
        private int costOfStation = 100;
        private int costoftrain = 25;
        private int costOfTrainUpgrade = 50;
        private int capacityUpgradeAmount = 5;
        List<Station> currentStations = new List<Station>();
        List<Train> currentTrains = new List<Train>();
        List<Control> stationMapGrid = new List<Control>();

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

        private void updateMoneyBox()
        {
            CurrentMoneyTextBox.Text = "Current Money: $" + currentMoney;
        }

        private void buyStationButton_Click(object sender, EventArgs e)
        {
            ConsoleTextBox.Text = "Do you want to buy a Station for $" + costOfStation + "?";
            state = "BuyStation";
        }

        private void buyTrainsButton_Click(object sender, EventArgs e)
        {
            ConsoleTextBox.Text = "Do you want to buy a train for $" + costoftrain + "?";
            state = "BuyTrain";
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(state))
            {
                if(state == "BuyStation")
                {
                    ConsoleTextBox.Text = "You clicked yes! We bought you a station. Please enter a name for it:";
                    currentMoney -= costOfStation;
                    updateMoneyBox();
                    state = "nameStation";
                }
                if (state == "BuyTrain")
                {
                    ConsoleTextBox.Text = "You clicked yes! We bought you a Train. Please enter a name for it:";
                    currentMoney -= costoftrain;
                    updateMoneyBox();
                    state = "nameTrain";
                }
                if (state == "UpgradeTrain")
                {
                    ConsoleTextBox.Text = "You clicked yes! We purchased an upgrade for you, which train would you like to use it on?";
                    currentMoney -= costOfTrainUpgrade;
                    updateMoneyBox();
                    state = "UpgradeWhichTrain";
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
                Station newStation = new Station(namingTextBox.Text.Trim());
                currentStations.Add(newStation);
                stationMapGrid[newStation.StationLocation].Visible = true;
                stationMapGrid[newStation.StationLocation].Text = newStation.Name;
                ConsoleTextBox.Text = "Awesome! We named your new station: " + namingTextBox.Text.Trim();
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
                currentTrains.Add(new Train(namingTextBox.Text.Trim()));
                ConsoleTextBox.Text = "Awesome! We named your new Train: " + namingTextBox.Text.Trim();
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
            }
        }

        private void upgradeTrainButton_Click(object sender, EventArgs e)
        {
            ConsoleTextBox.Text = "Do you want to upgrade a Train for $" + costOfTrainUpgrade + "?";
            state = "UpgradeTrain";
        }
    }

}
