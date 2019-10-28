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
            Console.WriteLine("(1) Lab");
            Console.WriteLine("(2) Lab");
            Console.WriteLine("(3) Lab");
            Console.WriteLine("(4) Lab");
            Console.WriteLine("(5) Lab");
            Console.WriteLine("(6) Scaling and Matrices");
            Console.WriteLine("(7) Closest Points");
            Console.WriteLine("(8) Computing Distances");


            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    Lab08 lab = new Lab08();
                    break;

            }
        }
    }
}
