using System;
using System.Collections.Generic;
using System.Text;

namespace MPG_Labs
{
    class Lab07
    {

        static void Main()
        {

            Vector3D ship = new Vector3D(282, 791, 456);
            Vector3D meteroird = new Vector3D(151, 366, 965);
            Vector3D metDir = new Vector3D(12, 31, -46);

            Vector3D lun1 = new Vector3D(377, 912, 598);
            Vector3D lun2 = new Vector3D(385, 920, 593);
            Vector3D lun3 = new Vector3D(388, 914, 604);
            Console.WriteLine("Use default scenario? Y/N?");
            string key = Console.ReadLine();
            if (key != "Y")
            {
                Console.WriteLine("Please provide an X value for the ship");
                float tempX = float.Parse(Console.ReadLine());
                Console.WriteLine("Please provide an Y value for the ship");
                float tempY = float.Parse(Console.ReadLine());
                Console.WriteLine("Please provide an Z value for the ship");
                float tempZ = float.Parse(Console.ReadLine());

                ship.SetRectGivenRect(tempX, tempY, tempZ);

                Console.WriteLine("Please provide an X value for the meteroid");
                tempX = float.Parse(Console.ReadLine());
                Console.WriteLine("Please provide an Y value for the meteroid");
                tempY = float.Parse(Console.ReadLine());
                Console.WriteLine("Please provide an Z value for the meteroid");
                tempZ = float.Parse(Console.ReadLine());

                meteroird.SetRectGivenRect(tempX, tempY, tempZ);

                Console.WriteLine("Please provide an X value for the meteroid direction");
                tempX = float.Parse(Console.ReadLine());
                Console.WriteLine("Please provide an Y value for the meteroid direction");
                tempY = float.Parse(Console.ReadLine());
                Console.WriteLine("Please provide an Z value for the meteroid direction");
                tempZ = float.Parse(Console.ReadLine());

                metDir.SetRectGivenRect(tempX, tempY, tempZ);


                Console.WriteLine("Please provide an X value for the Luna 1");
                tempX = float.Parse(Console.ReadLine());
                Console.WriteLine("Please provide an Y value for the Luna 1");
                tempY = float.Parse(Console.ReadLine());
                Console.WriteLine("Please provide an Z value for the Luna 1");
                tempZ = float.Parse(Console.ReadLine());

                lun1.SetRectGivenRect(tempX, tempY, tempZ);

                Console.WriteLine("Please provide an X value for the Luna 2");
                tempX = float.Parse(Console.ReadLine());
                Console.WriteLine("Please provide an Y value for the Luna 2");
                tempY = float.Parse(Console.ReadLine());
                Console.WriteLine("Please provide an X value for the Luna 2");
                tempZ = float.Parse(Console.ReadLine());

                lun2.SetRectGivenRect(tempX, tempY, tempZ);

                Console.WriteLine("Please provide an X value for the Luna 3");
                tempX = float.Parse(Console.ReadLine());
                Console.WriteLine("Please provide an Y value for the Luna 3");
                tempY = float.Parse(Console.ReadLine());
                Console.WriteLine("Please provide an z value for the Luna 3");
                tempZ = float.Parse(Console.ReadLine());

                lun3.SetRectGivenRect(tempX, tempY, tempZ);
            }

            Vector3D closeLine = ship.ClosestPointLine(meteroird, ship, metDir);
            Vector3D distanceLine = ship - closeLine;
            Console.WriteLine("Closest Point on Meteor Path");
            closeLine.PrintRect();
            Console.WriteLine("Closest Distance from Asteroid to Ship: " + distanceLine.GetMag());



            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Ship Position:");
            ship.PrintRect();


            Vector3D lunN = lun1.PlaneEquation(lun1, lun2, lun3);
            Console.WriteLine("Normal of Lunar Surface:");
            lunN.PrintRect();
            Vector3D closePlane = ship.ClosestPointsPlane(lun1, ship, lunN);
            Vector3D distance = ship - closePlane;

            Console.WriteLine("Closest Point on Lunar surface to ship");
            closePlane.PrintRect();
            Console.WriteLine("Ship Altitude: " + distance.GetMag());
            Console.ReadLine();


            Vector3D test1 = new Vector3D(3, 5, -2);
            Vector3D test2 = new Vector3D(4, 0, 1);
            Vector3D testReturn = test1.ParaProjection(test1, test2);
            testReturn.PrintRect();
            Console.ReadLine();

        }
    }
}
