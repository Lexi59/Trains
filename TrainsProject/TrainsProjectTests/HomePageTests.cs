using NUnit.Framework;
using TrainsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainsProject.Tests
{
    [TestFixture()]
    public class HomePageTests
    {
        [Test()]
        public void TrainBeforeStation()
        {
            HomePage homepage = new HomePage();
            homepage.Show();
            homepage.buyTrainsButton.PerformClick();
            homepage.YesButton.PerformClick();
            string actual = homepage.ConsoleTextBox.Text;
            Assert.AreEqual("Sorry! You have to buy a station first!", actual);
        }
        [Test()]
        public void TrackBefore2Station()
        {
            HomePage homepage = new HomePage();
            homepage.Show();
            homepage.buildTrackButton.PerformClick();
            homepage.YesButton.PerformClick();
            Assert.AreEqual("Sorry! You can't buy a track until you have 2 stations!", homepage.ConsoleTextBox.Text);
            homepage.buyStationButton.PerformClick();
            homepage.YesButton.PerformClick();
            homepage.namingTextBox.Text = "Test";
            homepage.namingSubmit.PerformClick();
            homepage.buildTrackButton.PerformClick();
            homepage.YesButton.PerformClick();
            Assert.AreEqual("Sorry! You can't buy a track until you have 2 stations!", homepage.ConsoleTextBox.Text);
            Train.CurrentStations.Clear();
        }
        [Test()]
        public void noNameForTrain()
        {
            HomePage homepage = new HomePage();
            homepage.Show();
            homepage.buyStationButton.PerformClick();
            homepage.YesButton.PerformClick();
            homepage.namingTextBox.Text = "Test";
            homepage.namingSubmit.PerformClick();
            homepage.buyTrainsButton.PerformClick();
            homepage.YesButton.PerformClick();
            homepage.namingSubmit.PerformClick();
            Assert.AreEqual("Sorry! You have to give it a name!", homepage.ConsoleTextBox.Text);
            Train.CurrentStations.Clear();
        }
        [Test()]
        public void noNameForStation()
        {
            HomePage homepage = new HomePage();
            homepage.Show();
            homepage.buyStationButton.PerformClick();
            homepage.YesButton.PerformClick();
            homepage.namingSubmit.PerformClick();
            Assert.AreEqual("Sorry! You have to give it a name!", homepage.ConsoleTextBox.Text);

        }
        [Test()]
        public void sameSourceandDestinationForTrack()
        {
            HomePage homepage = new HomePage();
            homepage.Show();
            Bank.CurrentMoney = 500;

            homepage.buyStationButton.PerformClick();
            homepage.YesButton.PerformClick();
            homepage.namingTextBox.Text = "Test";
            homepage.namingSubmit.PerformClick();
            Assert.AreEqual("Awesome! We named your new station: Test",homepage.ConsoleTextBox.Text);

            homepage.buyStationButton.PerformClick();
            homepage.YesButton.PerformClick();
            homepage.namingTextBox.Text = "Test";
            homepage.namingSubmit.PerformClick();

            homepage.buildTrackButton.PerformClick();
            homepage.YesButton.PerformClick();
            homepage.namingTextBox.Text = "Test";
            homepage.namingSubmit.PerformClick();
            homepage.namingTextBox.Text = "Test";
            homepage.namingSubmit.PerformClick();

            Assert.AreEqual("Sorry, you can't make a looped track. Transaction cancelled.", homepage.ConsoleTextBox.Text);
            Train.CurrentStations.Clear();
        }
        [Test()]
        public void overSpending()
        {
            HomePage homepage = new HomePage();
            homepage.Show();
            for(int i = 0;i < 5; i++)
            {
                homepage.buyStationButton.PerformClick();
                homepage.YesButton.PerformClick();
                homepage.namingTextBox.Text = "Test";
                homepage.namingSubmit.PerformClick();
            }
            Assert.AreEqual("Sorry! You can't do that! You don't have enough money!", homepage.ConsoleTextBox.Text);
            Train.CurrentStations.Clear();
        }
        [Test()]
        public void interruptingTransaction()
        {
            HomePage homepage = new HomePage();
            homepage.Show();
            homepage.buyStationButton.PerformClick();
            homepage.YesButton.PerformClick();
            homepage.buyTrainsButton.PerformClick();
            Assert.AreEqual("You clicked yes! We bought you a station. Please enter a name for it:Finish this transaction first!", homepage.ConsoleTextBox.Text);

        }
        [Test()]
        public void spacesinTrainName()
        {
            HomePage homepage = new HomePage();
            homepage.Show();
            homepage.buyStationButton.PerformClick();
            homepage.YesButton.PerformClick();
            homepage.namingTextBox.Text = "Test";
            homepage.namingSubmit.PerformClick();

            homepage.buyTrainsButton.PerformClick();
            homepage.YesButton.PerformClick();
            homepage.namingTextBox.Text = "      Hi     ";
            homepage.namingSubmit.PerformClick();

            homepage.upgradeTrainButton.PerformClick();
            homepage.YesButton.PerformClick();
            homepage.namingTextBox.Text = "      Hi     ";
            homepage.namingSubmit.PerformClick();
            Assert.AreEqual("Awesome! We have upgraded the train named Hi to a capacity of 15", homepage.ConsoleTextBox.Text);

            
            homepage.upgradeTrainButton.PerformClick();
            homepage.YesButton.PerformClick();
            homepage.namingTextBox.Text = "Hi";
            homepage.namingSubmit.PerformClick();
            Assert.AreEqual("Awesome! We have upgraded the train named Hi to a capacity of 20", homepage.ConsoleTextBox.Text);
            Train.CurrentStations.Clear();
            Train.CurrentTrains.Clear();
            Bank.CurrentMoney = 500;
        }
    }
}