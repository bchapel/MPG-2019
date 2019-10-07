using System;
using System.Collections.Generic;
using System.Text;

namespace MPG_Labs
{
    class Lab05
    {
        static void Main()
        {
            Lab05 test = new Lab05();
            test.OneDMotion();
            test.TwoDMotion();

        }

        public void OneDMotion()
        {
            float boxMass = 0.05f; //kg
            float boxVelocity = 0f; //m/s
            float boxY = 10; //m
            float boxKElossStep = 0; //Percentage
            float boxElapsedTime = 0; //Seconds
            float boxTimeStep = 0.05f;//Seconds
            float boxKE = 0f;
            float newKE = 0f;
            float boxPE = 0f;
            float boxGravity = 9.8f;

            Console.WriteLine("Please Input an initial velocity. (M/S)");
            boxVelocity = float.Parse(Console.ReadLine());

            Console.WriteLine("Please input what percentage of Kinetic Energy is lost per time step (" + boxTimeStep + " seconds)");
            boxKElossStep = float.Parse(Console.ReadLine());

            boxKE = 0.5f * boxMass * boxVelocity * boxVelocity;
            Console.WriteLine("Initial Box KE: " + boxKE);


            while (boxY > 0)
            {
                boxKE = (0.5f * boxMass * boxVelocity * boxVelocity) * (1 - (boxKElossStep * 0.01f));
                boxPE = boxMass * boxGravity * boxY;
                boxVelocity = (float)Math.Sqrt(boxKE / 0.5f * boxMass);

                boxY = -0.32219f * boxElapsedTime + 10;
                boxElapsedTime += boxTimeStep;

                Console.WriteLine("Current KE: " + boxKE);
                Console.WriteLine("Current PE: " + boxPE);
                Console.WriteLine("Total E: " + (boxKE + boxPE));

                Console.WriteLine();
            }

            Console.WriteLine("Box hit floor");
            Console.WriteLine("Time: " + boxElapsedTime);

        }

        public void TwoDMotion()
        {

        }
    }
}
