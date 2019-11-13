using System;
using System.Collections.Generic;
using System.Text;

namespace MPG_Labs
{
    class Lab05
    {

        //http://jccc-mpg.wikidot.com/work-and-energy
        public Lab05()
        {
            Lab05 test = new Lab05();
            //test.OneDMotion();
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
            Vector3D velocty = new Vector3D();
            Vector3D position = new Vector3D(0, 6778000, 0);
            Vector3D acceleration = new Vector3D();


            Vector3D Earth = new Vector3D();
            Vector3D gravity = new Vector3D();

            float radius = 6378000;
            float earthMass = 5.98e24f; //kg
            float shipMass = 225; //kg
            float shipElapsedTime = 0;
            float shipTimeStep = 10; //seconds
            float bigG = 6.67e-11f;

            float shipKE = 0f;
            float shipPE = 0f;
            float shipSpeed = 0f;
            float massCoefficient = 1 / shipMass;

            Console.WriteLine("Please input an initial speed");
            float tempX = float.Parse(Console.ReadLine());
            velocty.SetRectGivenRect(tempX, 0);

            //Make a function for this in Vector3D class.
            float distance = (float)Math.Sqrt( ((position.GetX() - Earth.GetX()) * position.GetX() - Earth.GetX())
                + ((position.GetY() - Earth.GetY()) * position.GetY() - Earth.GetY()) + ((position.GetZ() - Earth.GetZ()) * position.GetZ() - Earth.GetZ()));
            Console.WriteLine("Initial Altitude: " + (distance - radius));


            while (distance > radius + 100 || shipElapsedTime < 36000)
            {
                /// THIS COMMENT IS FROM AN EXAMPLE IN CLASS
                //Force = Delta PE/DeltaX X^  - DeltaPE/deltaY Y^
                //THEN USE an epsX + and - left and right of
                //5000m works as a good epsilon.
                //force.X = -(PE(r+epsX) - PE (r-epsX))/(zEps)


                //position
                Vector3D newPosition = position + velocty * shipTimeStep + (acceleration * 0.5f);
                gravity = Gravitycalc(Earth, newPosition, earthMass, shipMass);
                //acceleration
                Vector3D newAcceleration = gravity * massCoefficient;
                Console.WriteLine("Acceleration: ");
                newAcceleration.PrintRect();

                Vector3D newVelocity = velocty + (newAcceleration + acceleration) * 0.5f * shipTimeStep;

                shipPE = -bigG * (shipMass * earthMass) / distance;
                shipKE = 0.5f * shipMass * newVelocity.GetMagSq();
                shipSpeed = (float)Math.Sqrt(shipKE / 0.5f * shipMass);


                acceleration = newAcceleration;
                position = newPosition;
                velocty = newVelocity;
                shipElapsedTime += shipTimeStep;

                distance = (float)Math.Sqrt(((position.GetX() - Earth.GetX()) * position.GetX() - Earth.GetX())
                + ((position.GetY() - Earth.GetY()) * position.GetY() - Earth.GetY()) + ((position.GetZ() - Earth.GetZ()) * position.GetZ() - Earth.GetZ()));

                Console.WriteLine("KE: " + shipKE);
                Console.WriteLine("PE: " + shipPE);
                Console.WriteLine("Total E: " + (shipKE + shipPE));
                Console.WriteLine("Position");
                newPosition.PrintRect();

                Console.WriteLine("Ship Speed: " + shipSpeed);                
                Console.WriteLine("Altitude: " + (distance - radius) * 0.001 + " km");

                Console.WriteLine();
                   
            }

            if (distance <= radius + 100000)
            {
                Console.WriteLine("Ship Crashed: Altitude Too Low");
            }
            else if (shipElapsedTime > 36000)
            {
                Console.WriteLine("Time Limit Elapsed: Orbit Stableish?");
            }
        }

        Vector3D Gravitycalc(Vector3D obj1, Vector3D obj2, float mass1, float mass2)
        {
            Vector3D obj12 = obj2 - obj1;
            float invobj12Mag = 1.0f / obj12.GetMag();
            Vector3D Fgrav = !obj12 * ((6.67300e-11f) * mass1 * mass2) * invobj12Mag * invobj12Mag;

            return Fgrav;
        }

        float PE (Vector3D r)
        {
            return 2f;
        }
    }


}


//newPosition = oldPositon + oldVelocity* timeStep + 1 / 2 * oldAcceleration * (timeStep* timeStep);
//                newAcceleration = -9.8f - (0.1f * newVelocity);
//                newVelocity = oldVelocity + (newAcceleration + oldAcceleration) * 0.5f * timeStep;

////Housekeeping.
//elapsedTime += timeStep;            //Updating elapsedTime with change in time
//                oldAcceleration = newAcceleration; //Updating old acceleration to new acceleration
//                oldPositon = newPosition;           //updating old position to new position
//                oldVelocity = newVelocity;          //updating old velocity to new velocity.