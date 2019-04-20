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
        public Bank() { }

        public readonly static int costOfStation = 100;
        public readonly static int costoftrain = 50;
        public readonly static int costOfTrainUpgrade = 50;
        public readonly static int costOfTrack = 25;

        public static int CurrentMoney { get; set; } = 500;
        public static HomePage Homepage { get; set; }

        //methods
        public static void updateMoneyBox()
        {
            Homepage.CurrentMoneyTextBox.Text = "Current Money: $" + CurrentMoney;
        }

    }
}
