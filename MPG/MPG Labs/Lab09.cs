using System;
using System.Collections.Generic;
using System.Text;

namespace MPG_Labs
{
    class Lab09
    {
        /* Name: Momentum & Collision Lab
         * Author: Bowen Chapel
         * Version: 1.1
         * Date: January 2020
         * Summary: This lab is used to test the effects of collision on an object and it's momentum through two scenarios.
         * Scenario one is an object reflecting off of a wall, while scenario two is two objects hitting one another.
         * Changes: Fixing Reflection portion to use the Normalized normal vector of the plane rather than just the normal vector of the plane.
        */
        public Lab09()
        {
            //Prompts User to let them choose which scenario to run.
            Console.WriteLine("Press 1. to enter Scenario one: Reflection, or anything else for Scenario Two: Two Objects");
            if (Console.ReadLine() == "1")
            {
                float rest = 0.83f;     //Coefficient of restitution
                Vector3D final = new Vector3D();    //Final Velocity of Object
                Vector3D initial = new Vector3D(13.2f, 126.0f, -25.3f); //Initial Velocity of Object.
                Console.WriteLine("Initial speed of the Projectile (m/s)");
                initial.PrintMag(); //Display 

                Vector3D normal = new Vector3D();       //Normal Vector of the plane.

                //Defining the points of the plane.
                Vector3D p1 = new Vector3D(7.24f, 0.12f, -0.67f);
                Vector3D p2 = new Vector3D(-0.3f, 0.21f, 0.17f);
                Vector3D p3 = new Vector3D(-0.45f, 8.34f, 6.71f);

                normal = normal.PlaneEquation(p1, p2, p3);   //Calculating Normal Vector from Points
                normal = !normal;
                final = initial - (1 + rest) * ((initial ^ normal) * normal);   //Final Velocity Vector

                Console.WriteLine("Final Vector velocty (m/s)");
                final.PrintRect();
                Console.WriteLine("Final speed (m/s)");
                final.PrintMag();
                Console.ReadLine();
            }

            // Scenario Two
            else
            {
                //Mass, inititial velocity, and final velocity values of objects.
                float massObj1 = 0f;        //KG
                float iVelocityObj1 = 0f;   //m/s
                float fVelocityObj1 = 0f;   //m/s

                float iVelocityObj2 = 0f;   //m/s
                float fVelocityObj2 = 0f;   //M/s
                float massObj2 = 0f;        //KG

                float E = 0f;               //Coefficient of Restitution

                //Prompts user for Scenario Data and parses it.
                Console.WriteLine("What is the Mass of Object One?  (KG)");
                massObj1 = float.Parse(Console.ReadLine());
                Console.WriteLine("What is the Velocity of Object One? (M/S)");
                iVelocityObj1 = float.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("What is the Mass of Object Two? (KG)");
                massObj2 = float.Parse(Console.ReadLine());
                Console.WriteLine("What is the Velocity of Object Two? (M/S)");
                iVelocityObj2 = float.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("What is the coefficient of Restitution, E?");
                E = float.Parse(Console.ReadLine());

                //Calculates the veloicty of Object One the hard way
                //Once Object One's velocity is calculated, it is used to calculate Object two's much easier.
                fVelocityObj1 = ((massObj1 - (E * massObj2)) * iVelocityObj1 + (1 + E) * massObj2 * iVelocityObj2) / (massObj1 + massObj2);
                fVelocityObj2 = fVelocityObj1 + (E * (iVelocityObj1 - iVelocityObj2));

                Console.WriteLine();
                //Prints out Final Velocity of the Objects.
                Console.WriteLine("Velocity of Object One: " + fVelocityObj1 + " m/s");
                Console.WriteLine("Velocity of Object Two: " + fVelocityObj2 + " m/s");
            }

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
