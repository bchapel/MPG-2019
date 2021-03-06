﻿using System;

namespace MPG_Labs
{
    class Lab_01
    {
        /* Lab 01 Test Program
    Author: Bowen Walker Chapel
    Version: 1.0
    Date: August 26 2019.
    Summary: Following Lab Procedures based on: http://jccc-mpg.wikidot.com/the-vector-class

     */

        public Lab_01()
        {
            //Temporary float values used to store user input and create two vectors.
            float tempX1;
            float tempY1;
            float tempZ1;

            float tempX2;
            float tempY2;
            float tempZ2;

            //Grab user input and parse as temporary float values for Vector 1.
            Console.WriteLine("Please Input an X Coordinate for Vector 1");
            tempX1 = float.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Please Input an Y Coordinate for Vector 1");
            tempY1 = float.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Please Input an Z Coordinate for Vector 1");
            tempZ1 = float.Parse(Console.ReadLine());
            Console.WriteLine("");

            //Define new Vector using temporary float values.
            Vector3D Vector1 = new Vector3D(tempX1, tempY1, tempZ1);
            Console.WriteLine("");
            Console.WriteLine("");

            //Grab user input and parse as temporary float values for Vector 2.
            Console.WriteLine("Please Input an X Coordinate for Vector 2");
            tempX2 = float.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Please Input an Y Coordinate for Vector 2");
            tempY2 = float.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Please Input an Z Coordinate for Vector 2");
            tempZ2 = float.Parse(Console.ReadLine());
            Console.WriteLine("");

            Vector3D Vector2 = new Vector3D(tempX2, tempY2, tempZ2);

            Console.Clear();
            Console.WriteLine("Vector 1:");
            Console.WriteLine("Rect:");
            Vector1.PrintRect();
            Vector1.PrintMag();
            Console.WriteLine("");

            Console.WriteLine("Vector 2:");
            Console.WriteLine("Rect:");
            Vector2.PrintRect();
            Vector2.PrintMag();

            Console.WriteLine("");
            Console.ReadLine();

            Vector3D sumVector = Vector1 + Vector2;
            Console.WriteLine("Sum of Vector 1 and 2");
            Console.WriteLine("Rect:");
            sumVector.PrintRect();
            sumVector.PrintMag();

            Console.ReadLine();
            Console.WriteLine();

            Vector3D subVector = Vector1 - Vector2;
            Console.WriteLine("Difference of Vector 1 and 2");
            Console.WriteLine("Rect:");
            subVector.PrintRect();
            subVector.PrintMag();

            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Please input a number to multiply the vector by.");
            float temp = float.Parse(Console.ReadLine());
            Vector3D scaleRect = Vector1 * temp;

            Console.ReadLine();
            Console.WriteLine("Original Value:");
            Vector1.PrintRect();
            Vector1.PrintMag();

            Console.WriteLine("Scaled Value:");
            scaleRect.PrintRect();
            scaleRect.PrintMag();

            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Vector 1 expressed as the product of it's magnitude and unit direction");

            if (Vector1.GetMag() != 0)
                Vector1.SetRectGivenRect(Vector1.GetX() / Vector1.GetMag(), Vector1.GetY() / Vector1.GetMag(), Vector1.GetZ() / Vector1.GetMag());
            else
            {
                Console.WriteLine("ERROR: Can not complete operation.  Magnitude is zero");
            }


            Vector1.PrintRect();

            Console.WriteLine();
            Console.WriteLine("End of Program. Press Enter to close");
            Console.ReadLine();
        }
    }
}