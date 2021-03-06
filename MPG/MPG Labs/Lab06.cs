﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

/*/
Author: Bowen Chapel - October 29th, 2018.
Lab 06 - Translations and scaling - example lab to demonstrate translating, raw scaling, and center scaling of an Object.


Changelog.  1.1 - October 15th - 2019. Modified to use Vector class, also improved UI.
*/
namespace MPG_Labs
{
    //Program Class Purpose: To test translation, scaling, and center-scaling functions added to the Vector3D class.
    class Lab06
    {
        Vector3D vector1 = new Vector3D();
        Vector3D vector2 = new Vector3D();
        Vector3D vector3 = new Vector3D();
        Vector3D vector4 = new Vector3D();

        Vector3D centerVector = new Vector3D();
        Vector3D scaleVector = new Vector3D();
        Vector3D translateVector = new Vector3D();
        float avgX;
        float avgY;
        float avgZ;


        public Lab06()
        {

            Vector3D[] vectors = new Vector3D[4];

            vectors[0] = vector1;
            vectors[1] = vector2;
            vectors[2] = vector3;
            vectors[3] = vector4;

            //This value is used for the while loop below, to ensure every Vector from the array above is cycled through.
            int number = 0;


            //Temp variables used to store a user input from a console.readline().
            float tempX;
            float tempY;
            float tempZ;


            //This loop uses the Vector Array created above so that the User may specify the X, Y, Z values of all of every Vector.
            while (number < 4)
            {
                Console.WriteLine("Please Provide an X value for Vector " + (number + 1));
                tempX = float.Parse(Console.ReadLine());
                Console.WriteLine("Please Provide an Y value for Vector " + (number + 1));
                tempY = float.Parse(Console.ReadLine());
                Console.WriteLine("Please Provide an Z value for Vector " + (number + 1));
                tempZ = float.Parse(Console.ReadLine());

                Console.WriteLine();

                //Each Vector correspondingly has it's X,Y,Z components assigned.
                vectors[number].SetRectGivenRect(tempX, tempY, tempZ);

                Console.WriteLine();
                number++;
            }
            //After the While loop is finished, it asks the user for a center point.
            Console.WriteLine();
            Console.WriteLine("Please Provide an X value for the Center Vector");
            tempX = float.Parse(Console.ReadLine());
            Console.WriteLine("Please Provide an Y value for the Center Vector");
            tempY = float.Parse(Console.ReadLine());
            Console.WriteLine("Please Provide an Z value for the Center Vector");
            tempZ = float.Parse(Console.ReadLine());

            //These coordinates are then assigned to the centerVector's X,Y,Z components.
            centerVector.SetRectGivenRect(tempX, tempY, tempZ);

            Console.ReadLine();
            Console.Clear();
            CallSwitch(0);
            Console.ReadLine();
        }

        //This function contains the bulk of the program.  It was created as an easy way to restart the while loop it contains, in event of user inputting invalid data.
        public void CallSwitch(int startingTime)
        {
            //Temp variables for storing user input.
            float tempX;
            float tempY;
            float tempZ;

            int i = startingTime;  //Initially called at Zero, allows this function to be called with a higher initial I value, such as default case in While loop below.
            while (i < 4000)
            {
                //User is prompted to choose one of three operations on their Vectors.
                Console.WriteLine("Please Choose an Operation:");
                Console.WriteLine();
                Console.WriteLine("(1.) Translate the Object");
                Console.WriteLine("(2.) Scale the Object Raw");
                Console.WriteLine("(3.) Scale the Object around it's Center");
                Console.WriteLine("(4.) Rotate the Object around a specified Axis.");
                Console.WriteLine("(5.) Exit the Program");

                Console.WriteLine();

                int choice = Convert.ToInt32(Console.ReadLine());  //User's choice is stored and used in the switch.
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Translating Object");

                        //4D Vectors are created so the User can see a more Mathematical representation of the Vector changes.
                        Vector3D translate1 = new Vector3D(0, 0, 0, 0);
                        Vector3D translate2 = new Vector3D(0, 0, 0, 0);
                        Vector3D translate3 = new Vector3D(0, 0, 0, 0);
                        Vector3D translate4 = new Vector3D(0, 0, 0, 0);

                        //User is Prompted for X, Y, and Z changes, this data is then stored.
                        Console.WriteLine("How much do you want to translate the object's X value by?");
                        tempX = float.Parse(Console.ReadLine());
                        Console.WriteLine("How much do you want to translate the object's Y value by?");
                        tempY = float.Parse(Console.ReadLine());
                        Console.WriteLine("How much do you want to translate the object's Z value by?");
                        tempZ = float.Parse(Console.ReadLine());

                        //ScaleVector is a temporary vector used to store said variables.
                        scaleVector.SetRectGivenRect(tempX, tempY, tempZ);


                        //The temporary translate Vectors are given data, and printed.
                        translate1.SetRectGivenRect(1, 0, 0, vector1.GetX() + scaleVector.GetX());
                        translate2.SetRectGivenRect(0, 1, 0, vector1.GetY() + scaleVector.GetY());
                        translate3.SetRectGivenRect(0, 0, 1, vector1.GetZ() + scaleVector.GetZ());
                        translate4.SetRectGivenRect(0, 0, 0, 1);

                        Console.WriteLine();
                        translate1.PrintMatrix();
                        translate2.PrintMatrix();
                        translate3.PrintMatrix();
                        translate4.PrintMatrix();

                        Console.WriteLine();

                        Console.WriteLine("Old Vector 1:");
                        vector1.PrintRect();

                        Console.WriteLine();
                        //The first Vector is translated and printed.
                        Console.WriteLine("New Vector 1");
                        vector1.MatrixTranslation(scaleVector);
                        vector1.PrintRect();

                        Console.ReadLine();

                        //The temporary translate Vectors are given data, and printed.
                        translate1.SetRectGivenRect(1, 0, 0, vector2.GetX() + scaleVector.GetX());
                        translate2.SetRectGivenRect(0, 1, 0, vector2.GetY() + scaleVector.GetY());
                        translate3.SetRectGivenRect(0, 0, 1, vector2.GetZ() + scaleVector.GetZ());
                        translate4.SetRectGivenRect(0, 0, 0, 1);

                        Console.WriteLine();
                        translate1.PrintMatrix();
                        translate2.PrintMatrix();
                        translate3.PrintMatrix();
                        translate4.PrintMatrix();
                        Console.WriteLine();

                        Console.WriteLine("Old Vector 2:");
                        vector2.PrintRect();
                        Console.WriteLine();
                        //The Second Vector is translated and printed.
                        Console.WriteLine("New Vector 2");
                        vector2.MatrixTranslation(scaleVector);
                        Console.WriteLine();
                        vector2.PrintRect();

                        Console.ReadLine();

                        //And so on....

                        translate1.SetRectGivenRect(1, 0, 0, vector3.GetX() + scaleVector.GetX());
                        translate2.SetRectGivenRect(0, 1, 0, vector3.GetY() + scaleVector.GetY());
                        translate3.SetRectGivenRect(0, 0, 1, vector3.GetZ() + scaleVector.GetZ());
                        translate4.SetRectGivenRect(0, 0, 0, 1);

                        Console.WriteLine();
                        translate1.PrintMatrix();
                        translate2.PrintMatrix();
                        translate3.PrintMatrix();
                        translate4.PrintMatrix();
                        Console.WriteLine();

                        Console.WriteLine("Old Vector 3:");
                        vector3.PrintRect();
                        Console.WriteLine();
                        Console.WriteLine("New Vector 3");
                        vector3.MatrixTranslation(scaleVector);
                        Console.WriteLine();
                        vector3.PrintRect();

                        Console.ReadLine();

                        translate1.SetRectGivenRect(1, 0, 0, vector4.GetX() + scaleVector.GetX());
                        translate2.SetRectGivenRect(0, 1, 0, vector4.GetY() + scaleVector.GetY());
                        translate3.SetRectGivenRect(0, 0, 1, vector4.GetZ() + scaleVector.GetZ());
                        translate4.SetRectGivenRect(0, 0, 0, 1);

                        Console.WriteLine();
                        translate1.PrintMatrix();
                        translate2.PrintMatrix();
                        translate3.PrintMatrix();
                        translate4.PrintMatrix();
                        Console.WriteLine();

                        Console.WriteLine("Old Vector 4:");
                        vector4.PrintRect();
                        Console.WriteLine();
                        Console.WriteLine("New Vector 4");
                        vector4.MatrixTranslation(scaleVector);
                        Console.WriteLine();
                        vector4.PrintRect();

                        //Center Vector is Recalculated via averaging out each Vector's value.
                        avgX = (vector1.GetX() + vector2.GetX() + vector3.GetX() + vector4.GetX()) / 4;
                        avgY = (vector1.GetY() + vector2.GetY() + vector3.GetY() + vector4.GetY()) / 4;
                        avgZ = (vector1.GetZ() + vector2.GetZ() + vector3.GetZ() + vector4.GetZ()) / 4;
                        centerVector.SetRectGivenRect(avgX, avgY, avgZ);
                        Console.WriteLine(0);
                        Console.WriteLine("New Center Vector:");
                        centerVector.PrintRect();

                        Console.ReadLine();
                        Console.Clear();

                        i++;
                        break;

                    case 2: //User is prompted by how much they'd like to scale the X, Y, and Z components by.
                        Console.WriteLine("How much do you want to Raw Scale the object's X value by?");
                        Console.WriteLine("1.15% would be increasing by 15%, while 0.85 would be decreasing by 15%)");
                        tempX = float.Parse(Console.ReadLine());

                        Console.WriteLine("How much do you want to Raw Scale the object's Y value by?");
                        tempY = float.Parse(Console.ReadLine());

                        Console.WriteLine("How much do you want to Raw Scale the object's Z value by?");
                        tempZ = float.Parse(Console.ReadLine());

                        //ScaleVector tempVector is temporarily staffed by tempX, tempY, tempZ.
                        scaleVector.SetRectGivenRect(tempX, tempY, tempZ);
                        Console.WriteLine("Old Vectors:");
                        Console.WriteLine();
                        Console.WriteLine("Vector One:");
                        vector1.PrintRect();
                        Console.WriteLine();

                        Console.WriteLine("Vector Two:");
                        vector2.PrintRect();
                        Console.WriteLine();

                        Console.WriteLine("Vector Three:");
                        vector3.PrintRect();
                        Console.WriteLine();

                        Console.WriteLine("Vector Four:");
                        vector4.PrintRect();
                        Console.WriteLine();
                        Console.WriteLine("New Vectors:");

                        //The new Function MatrixRawScale is called on each Vector, with the scaleVector's X,Y,Z,W values called against it.
                        vector1.MatrixRawScale(scaleVector);
                        vector2.MatrixRawScale(scaleVector);
                        vector3.MatrixRawScale(scaleVector);
                        vector4.MatrixRawScale(scaleVector);

                        //Every Vector is then printed out with a label.
                        Console.WriteLine();
                        Console.WriteLine("Vector One:");
                        vector1.PrintRect();
                        Console.WriteLine();

                        Console.WriteLine("Vector Two:");
                        vector2.PrintRect();
                        Console.WriteLine();

                        Console.WriteLine("Vector Three:");
                        vector3.PrintRect();
                        Console.WriteLine();

                        Console.WriteLine("Vector Four:");
                        vector4.PrintRect();
                        Console.WriteLine();

                        //Recalculating the Center Vector.
                        avgX = (vector1.GetX() + vector2.GetX() + vector3.GetX() + vector4.GetX()) / 4;
                        avgY = (vector1.GetY() + vector2.GetY() + vector3.GetY() + vector4.GetY()) / 4;
                        avgZ = (vector1.GetZ() + vector2.GetZ() + vector3.GetZ() + vector4.GetZ()) / 4;
                        centerVector.SetRectGivenRect(avgX, avgY, avgZ);
                        Console.WriteLine(0);
                        Console.WriteLine("New Center Vector:");
                        centerVector.PrintRect();
                        Console.ReadLine();

                        i++;
                        break;

                    case 3: //User is prompted by how much they'd like to scale the X, Y, and Z components by.
                        Console.WriteLine("Scaling about the Center of the object.");

                        Console.WriteLine("How much do you want to Scale the object's X value by?");
                        Console.WriteLine("(IE: 1.15% would be increasing by 15, while 0.85 would be decreasing by 15%)");
                        tempX = float.Parse(Console.ReadLine());
                        Console.WriteLine("How much do you want to Scale the object's Y value by?");
                        tempY = float.Parse(Console.ReadLine());
                        Console.WriteLine("How much do you want to Scale the object's Z value by?");
                        tempZ = float.Parse(Console.ReadLine());

                        //ScaleVector temp Vector is temporarily staffed by tempX, tempY, tempZ.
                        scaleVector.SetRectGivenRect(tempX, tempY, tempZ);

                        //New Function MatrixCenterScale is called by every numbered Vector, using the XYZW of the scaleVector, and the XYZ of the previously defined centerVector.
                        vector1.MatrixCenterScale(scaleVector, centerVector);
                        vector2.MatrixCenterScale(scaleVector, centerVector);
                        vector3.MatrixCenterScale(scaleVector, centerVector);
                        vector4.MatrixCenterScale(scaleVector, centerVector);

                        //All Vectors are then printed and labeled.
                        Console.WriteLine();

                        Console.WriteLine("Vector One:");
                        vector1.PrintRect();

                        Console.WriteLine();
                        Console.WriteLine("Vector Two:");
                        vector2.PrintRect();

                        Console.WriteLine();
                        Console.WriteLine("Vector Three:");
                        vector3.PrintRect();

                        Console.WriteLine();
                        Console.WriteLine("Vector Four:");
                        vector4.PrintRect();

                        Console.WriteLine();
                        Console.ReadLine();

                        i++;
                        break;

                    case 4: //Rotations!

                        Vector3D[] vectors = new Vector3D[4];

                        vectors[0] = new Vector3D(vector1.GetX(), vector1.GetY(), vector1.GetZ());
                        vectors[1] = new Vector3D(vector2.GetX(), vector2.GetY(), vector2.GetZ());
                        vectors[2] = new Vector3D(vector3.GetX(), vector3.GetY(), vector3.GetZ());
                        vectors[3] = new Vector3D(vector4.GetX(), vector4.GetY(), vector4.GetZ());

                        Console.WriteLine("How large of an angle would you like to use ? (Degrees)");
                        float angleTheta = float.Parse(Console.ReadLine());

                        angleTheta = vector1.DegreeToRad(angleTheta);
                        Console.WriteLine("Converted to radians: " + angleTheta);


                        Console.WriteLine("What Axis would you like to rotate around?");
                        Console.WriteLine("(1.) X Axis");
                        Console.WriteLine("(2.) Y Axis");
                        Console.WriteLine("(3.) Z Axis");
                        int choice2 = Convert.ToInt32(Console.ReadLine()); //User's choice is stored and used in the switch.

                        switch (choice2)
                        {
                            case 1: // X Axis
                                int vectorNumber = 0;

                                while (vectorNumber < 4)
                                {
                                    tempX = vectors[vectorNumber].GetX();//1X + 0y + 0Z + 0 * 1

                                    //Get angle from axis to vectors, that’s theta

                                    //0X + y * CosTheta + z * -SinTheta + 0 *1
                                    tempY = (vectors[vectorNumber].GetY() * (float)Math.Cos(angleTheta)) + (vectors[vectorNumber].GetZ() * -(float)Math.Sin(angleTheta));
                                    //0x + y * SinTheta + Z * CosTheta + 0 *1
                                    tempZ = (vectors[vectorNumber].GetY() * (float)Math.Sin(angleTheta)) + (vectors[vectorNumber].GetZ() * (float)Math.Cos(angleTheta));

                                    vectors[vectorNumber].SetRectGivenRect(tempX, tempY, tempZ);
                                    vectorNumber++;
                                }

                                break;
                            case 2: //Y Axis
                                vectorNumber = 0;

                                while (vectorNumber < 4)
                                {
                                    //X * CosTheta + 0Y + Z * SinTheta + 0 * 1
                                    tempX = (vectors[vectorNumber].GetX() * ((float)Math.Cos(angleTheta)) + (vectors[vectorNumber].GetZ() * (float)Math.Sin(angleTheta)));
                                    //0X + 1Y + 0Z + 0 * 1
                                    tempY = vectors[vectorNumber].GetY();
                                    //X * -SinTheta + 0Y + Z * CosTheta + 0 * 1
                                    tempZ = (vectors[vectorNumber].GetX() * -(float)Math.Sin(angleTheta) + (vectors[vectorNumber].GetZ() * (float)Math.Cos(angleTheta)));

                                    vectors[vectorNumber].SetRectGivenRect(tempX, tempY, tempZ);
                                    vectorNumber++;
                                }
                                break;

                            case 3: //Z Axis
                                vectorNumber = 0;

                                while (vectorNumber < 4)
                                {
                                    //X * CosTheta + Y * -SinTheta + 0Z + 0 * 1
                                    tempX = (vectors[vectorNumber].GetX() * ((float)Math.Cos(angleTheta)) + (vectors[vectorNumber].GetY() * -(float)Math.Sin(angleTheta)));
                                    //X * SinTheta + Y * CosTheta + 0Z + 0 * 1
                                    tempY = (vectors[vectorNumber].GetX() * ((float)Math.Sin(angleTheta)) + (vectors[vectorNumber].GetY() * (float)Math.Cos(angleTheta)));
                                    //0X + 0Y + Z + 0 * 1
                                    tempZ = vectors[vectorNumber].GetZ();
                                    //Vectors[vectorNumber].GetZ() * (Sin( angleTheta) + Math.Cos( angleTheta));

                                    vectors[vectorNumber].SetRectGivenRect(tempX, tempY, tempZ);
                                    vectorNumber++;
                                }
                                break;


                            default:
                                Console.WriteLine("Invalid Input, action cancelled - returning to Matrix menu.");
                                CallSwitch(i);
                                break;
                        }


                        vector1.SetRectGivenRect(vectors[0].GetX(), vectors[0].GetY(), vectors[0].GetZ());
                        vector2.SetRectGivenRect(vectors[1].GetX(), vectors[1].GetY(), vectors[1].GetZ());
                        vector3.SetRectGivenRect(vectors[2].GetX(), vectors[2].GetY(), vectors[2].GetZ());
                        vector4.SetRectGivenRect(vectors[3].GetX(), vectors[3].GetY(), vectors[3].GetZ());
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Vector One:");
                        vector1.PrintRect();
                        Console.WriteLine();

                        Console.WriteLine("Vector Two:");
                        vector2.PrintRect();
                        Console.WriteLine();

                        Console.WriteLine("Vector Three:");
                        vector3.PrintRect();
                        Console.WriteLine();

                        Console.WriteLine("Vector Four:");
                        vector4.PrintRect();
                        Console.WriteLine();

                        Console.ReadLine();

                        i++;
                        break;

                    case 5: //Exit the program
                        Environment.Exit(0);
                        break;

                    default: //If user selects an invalid choice, it informs them of this and recalls the function without resetting the i value.
                        Console.WriteLine("Invalid Input, please try again.");
                        CallSwitch(i);
                        break;

                }
            }

            //At conclusion of loop, clears console and informs user, before printing out the final results of all the changes.
            Console.Clear();
            Console.WriteLine("Final Result of Operations");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Vector One:");
            vector1.PrintRect();

            Console.WriteLine();
            Console.WriteLine("Vector Two:");
            vector2.PrintRect();

            Console.WriteLine();
            Console.WriteLine("Vector Three:");
            vector3.PrintRect();

            Console.WriteLine();
            Console.WriteLine("Vector Four:");
            vector4.PrintRect();

            Console.WriteLine();
            Console.ReadLine();
        }
    }

}
