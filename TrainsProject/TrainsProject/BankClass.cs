using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TrainsProject
{
    class Bank : Database
    {
        //constructor
        public Bank()
        {
        }
        //fields
        public static int currentMoney = 500;
        public readonly static int costOfStation = 100;
        public readonly static int costoftrain = 50;
        public readonly static int costOfTrainUpgrade = 50;
        public readonly static int costOfTrack = 25;
        public static HomePage homepage;
        //methods
        public static void updateMoneyBox()
        {
            homepage.CurrentMoneyTextBox.Text = "Current Money: $" + currentMoney;
        }

    }
}
