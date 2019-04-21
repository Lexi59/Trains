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
        [Test()]
        public void trainUpbeforeTrain()
        {
            HomePage homepage = new HomePage();
            homepage.Show();

            homepage.upgradeTrainButton.PerformClick();
            homepage.YesButton.PerformClick();
            Assert.AreEqual("You can't purchase a train upgrade before having a train!", homepage.ConsoleTextBox.Text);
        }
        [Test()]
        public void moveTrainbeforeTrain()
        {
            HomePage homepage = new HomePage();
            homepage.Show();

            homepage.moveTrainButton.PerformClick();
            Assert.AreEqual("Sorry! You can't move a train until you have a train", homepage.ConsoleTextBox.Text);
        }
        [Test()]
        public void moveTrainbeforeTracks()
        {
            HomePage homepage = new HomePage();
            homepage.Show();

            homepage.buyStationButton.PerformClick();
            homepage.YesButton.PerformClick();
            homepage.namingTextBox.Text = "test";
            homepage.namingSubmit.PerformClick();

            homepage.buyTrainsButton.PerformClick();
            homepage.YesButton.PerformClick();
            homepage.namingTextBox.Text = "hi";
            homepage.namingSubmit.PerformClick();

            homepage.moveTrainButton.PerformClick();
            Assert.AreEqual("Sorry! You can't move a train until you have tracks!", homepage.ConsoleTextBox.Text);
            Train.CurrentTrains.Clear();
            Train.CurrentStations.Clear();
        }
        [Test()]
        public void moveTrainWithoutTrack()
        {
            HomePage homepage = new HomePage();
            homepage.Show();
            Bank.CurrentMoney = 500;

            homepage.buyStationButton.PerformClick();
            homepage.YesButton.PerformClick();
            homepage.namingTextBox.Text = "test";
            homepage.namingSubmit.PerformClick();

            homepage.buyStationButton.PerformClick();
            homepage.YesButton.PerformClick();
            homepage.namingTextBox.Text = "test2";
            homepage.namingSubmit.PerformClick();

            homepage.buyTrainsButton.PerformClick();
            homepage.YesButton.PerformClick();
            homepage.namingTextBox.Text = "1";
            homepage.namingSubmit.PerformClick();

            homepage.buildTrackButton.PerformClick();
            homepage.YesButton.PerformClick();
            homepage.namingTextBox.Text = "test";
            homepage.namingSubmit.PerformClick();
            homepage.namingTextBox.Text = "test2";
            homepage.namingSubmit.PerformClick();

            homepage.moveTrainButton.PerformClick();
            homepage.namingTextBox.Text = "1";
            homepage.namingSubmit.PerformClick();
            homepage.YesButton.PerformClick();
            homepage.namingTextBox.Text = "test";
            homepage.namingSubmit.PerformClick();
            Assert.AreEqual("Sorry, there is no track there. Transaction cancelled.", homepage.ConsoleTextBox.Text);
            Train.CurrentStations.Clear();
            Train.CurrentTracks.Clear();
            Train.CurrentTrains.Clear();
        }
        [Test()]
        public void upgradingTrainthatdoesntexist()
        {
            HomePage homepage = new HomePage();
            homepage.Show();

            homepage.buyStationButton.PerformClick();
            homepage.YesButton.PerformClick();
            homepage.namingTextBox.Text = "hi";
            homepage.namingSubmit.PerformClick();

            homepage.buyTrainsButton.PerformClick();
            homepage.YesButton.PerformClick();
            homepage.namingTextBox.Text = "1";
            homepage.namingSubmit.PerformClick();

            homepage.upgradeTrainButton.PerformClick();
            homepage.YesButton.PerformClick();
            homepage.namingTextBox.Text = "2";
            homepage.namingSubmit.PerformClick();

            Assert.AreEqual("We couldn't find a train named 2", homepage.ConsoleTextBox.Text);
        }
    }
}