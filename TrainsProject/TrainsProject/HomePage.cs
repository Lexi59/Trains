﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainsProject
{
    public partial class HomePage : Form
    {
        private int currentMoney = 500;
        private string state = null;
        private int costOfStation = 100;
        private int costoftrain = 25;
        List<Station> currentStations = new List<Station>();
        List<Train> currentTrains = new List<Train>();

        public HomePage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateMoneyBox();
            stationMapGrid.Rows.Add(10);
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
                currentStations.Add(new Station(namingTextBox.Text.Trim()));
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
        }


    }

}
