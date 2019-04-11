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

        //methods
    }
}
