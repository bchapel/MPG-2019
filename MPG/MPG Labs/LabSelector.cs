using System;
using System.Collections.Generic;
using System.Text;

namespace MPG_Labs
{
    class LabSelector
    {
        static void Main()
        {
            Console.WriteLine("Please Choose a Lab");
            Console.WriteLine();
            Console.WriteLine("(1) Vector Class");
            Console.WriteLine("(2) Linear Accelerated Motion");
            Console.WriteLine("(3) Vector Angles");
            Console.WriteLine("(4) Force & Motion");
            Console.WriteLine("(5) Work & Energy");
            Console.WriteLine("(6) Scaling and Matrices");
            Console.WriteLine("(7) Closest Points");
            Console.WriteLine("(8) Collision Detection");
            Console.WriteLine("(9) Collisions & Momentum -- Not working"); 
            Console.WriteLine("(10) Rotations");
            Console.WriteLine("(11) Quaternion Rotation");
            //Console.WriteLine("(12) Rotational Dynamics");


            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Lab_01 lab1 = new Lab_01();
                    break;
                case 2:
                    Lab_02 lab2 = new Lab_02();
                    break;
                case 3:
                    Lab03 lab3 = new Lab03();
                    break;
                case 4:
                    Lab04 lab4 = new Lab04();
                    break;
                case 5:
                    Lab05 lab5 = new Lab05();
                    break;
                case 6:
                    Lab06 lab6 = new Lab06();
                    break;
                case 7:
                    Lab07 lab7 = new Lab07();
                    break;
                case 8:
                    Lab08 lab8 = new Lab08();
                    break;
                case 9:
                    //Lab09 lab9 = new Lab09();
                    break;
                case 10:
                    Lab10 lab10 = new Lab10();
                    break;
                case 11:
                    Lab11 lab11 = new Lab11();
                    break;
                case 12:
                    //Lab12 lab12 = new Lab12();
                    break;

                case 13:
                    //Lab13 lab13 = new Lab13();
                    break;
            }
        }
    }
}
