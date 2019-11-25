using System;
using System.Collections.Generic;
using System.Text;

namespace MPG_Labs
{
    class Lab11
    {
        /* Name: Lab 11 - Quaternions.
         * Author: Bowen W Chapel
         * Version: 1.0f
         * Summary: This lab demonstrates the functions of the newly Constructed Quaternion class
         * go read that class to see how these functions work, this is only calling them.
         */

        //Two Quaternions as defined by the lab instructions.
        Quaternion P = new Quaternion(1, new Vector3D(0,2,-3));
        Quaternion Q = new Quaternion(2, new Vector3D(4, -1, 1));

        public Lab11()
        {
            //Gives user the Initila values so they know what they are.
            Console.WriteLine("Starting Quaternions)");
            P.PrintQuaternion();
            Q.PrintQuaternion();

            //Adding the Two Quatrnions and printing their sum.
            Console.WriteLine();
            Console.WriteLine("Addition");
            Quaternion T = P + Q;
            T.PrintQuaternion();

            //Subtracting the Two Quatrnions and printing their difference.
            Console.WriteLine();
            Console.WriteLine("Subtraction");
            T = P - Q;
            T.PrintQuaternion();

            //Scaling the Quaternion by a Float value and printing the result.
            Console.WriteLine();
            Console.WriteLine("Scalar Multiplication P");
            T = 5f * P;
            T.PrintQuaternion();
            Console.WriteLine("Scalar Multiplication Q");
            T = 5f * Q;
            T.PrintQuaternion();

            //Multiplying two Quaternions against one another and printing the result.
            Console.WriteLine("");
            Console.WriteLine("Quaternion Multiplication");
            T = P ^ Q;
            T.PrintQuaternion();

            //Printing the Magnitude of Quaternions P and Q.
            Console.WriteLine();
            Console.WriteLine("P Mag");
            P.PrintMagnitude();
            Console.WriteLine("Q Mag");
            Q.PrintMagnitude();

            //Calculating and Printing the Conjugate value for Quaternion P.
            Console.WriteLine("");
            Console.WriteLine("Conjugate P");

            T = ~P;
            T.PrintQuaternion();
            Console.WriteLine("Conjugate Q");
            T = ~Q;
            T.PrintQuaternion();

            //Calculating and Printing the Inverse value for Quaternion P.
            T = -P;
            Console.WriteLine("");
            Console.WriteLine("Inverse P");
            T.PrintQuaternion();

            Console.WriteLine("Inverse Q");
            T = -Q;
            T.PrintQuaternion();

            //Calculating the specified Rotation.
            Console.ReadLine();



        }
    }
}
