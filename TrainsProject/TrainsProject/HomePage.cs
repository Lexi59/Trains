using System;
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
        private string YesorNoResponse;
        public HomePage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CurrentMoneyTextBox.Text = "Current Money: $" + currentMoney;
        }

        private void buyStationButton_Click(object sender, EventArgs e)
        {
            ConsoleTextBox.Text += "Do you want to buy a Station for $100?";
            
        }
    }

}
