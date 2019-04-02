using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainsProject
{
    class Package
    {
        //constructor
        public Package()
        {
            string[] packageTypeArray = { "Toys", "Gifts", "Electronics", "Clothes", "Food" };
            Random randomNumber = new Random();
            int randomNumberForPackageType = randomNumber.Next(0, packageTypeArray.Length);
            PackageType = packageTypeArray[randomNumberForPackageType];
            PackageValue = randomNumber.Next(0, 300);
        }
        //fields
        public string PackageType;
        public int PackageValue;
        public Station PackageDestinationStation;

        //methods
    }
}
