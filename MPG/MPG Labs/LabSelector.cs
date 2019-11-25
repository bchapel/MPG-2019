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
            Console.WriteLine("(12) Rotational Dynamics");


            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Lab_01 lab1 = new Lab_01();
                    break;
                case 2:
                    Console.Clear();
                    Lab_02 lab2 = new Lab_02();
                    break;
                case 3:
                    Console.Clear();
                    Lab03 lab3 = new Lab03();
                    break;
                case 4:
                    Console.Clear();
                    Lab04 lab4 = new Lab04();
                    break;
                case 5:
                    Console.Clear();
                    Lab05 lab5 = new Lab05();
                    break;
                case 6:
                    Console.Clear();
                    Lab06 lab6 = new Lab06();
                    break;
                case 7:
                    Console.Clear();
                    Lab07 lab7 = new Lab07();
                    break;
                case 8:
                    Console.Clear();
                    Lab08 lab8 = new Lab08();
                    break;
                case 9:
                    Console.Clear();
                    Lab09 lab9 = new Lab09();
                    break;
                case 10:
                    Console.Clear();
                    Lab10 lab10 = new Lab10();
                    break;
                case 11:
                    Console.Clear();
                    Lab11 lab11 = new Lab11();
                    break;
                case 12:
                    Console.Clear();
                    Lab12 lab12 = new Lab12();
                    break;
            }
        }
    }
}
