using System;
using System.Collections.Generic;
using System.Text;

namespace MPG_Labs
{
    class Lab04
    {
        public static void Main()
        {
            float newBoxSpeed = 0;
            float boxSpeed = 0;
            float boxAccel = 0;
            float oldBoxAccel = 0;
            float boxPos = 0;
            float oldPos = 0;
            float boxTime = 0;
            float boxTimeStep = 0.1f;

            Console.WriteLine("A box is sliding on a surface. Please input an initial velocity? (M/S)");
            boxSpeed = float.Parse(Console.ReadLine());
            Console.WriteLine("What is the friction coefficient of the surface?");
            float fCoefficient = float.Parse(Console.ReadLine());
            //Concept: Fnet = Mass * Acceleration.  
            //friction force = u * |N|
            //Normal Force = angle of surface && mass * gravity.
            //Surface is flat so Normal = mg
            //If mass is part of both equations we can divide it out.
            if (fCoefficient <= 0 || fCoefficient > 1)
            {
                Console.WriteLine("Invalid Input: Friction coefficient.  Please restart the program with proper parameters");
                Console.ReadLine();
            }
            else
            {
                while (boxSpeed > 0)
                {
                    boxPos = oldPos + boxSpeed * boxTimeStep + (0.5f * oldBoxAccel) * (boxTimeStep * boxTimeStep);
                    boxAccel = -fCoefficient * 9.8f;
                    newBoxSpeed = boxSpeed + (boxAccel + oldBoxAccel) * 0.5f * boxTimeStep;

                    //Housekeeping:
                    oldBoxAccel = boxAccel;
                    oldPos = boxPos;
                    boxSpeed = newBoxSpeed;
                    boxTime += boxTimeStep;
                }

                Console.WriteLine("Box Final Position: " + boxPos + " meters.");
                Console.WriteLine("Time until Box's halt: " + boxTime);
                Console.ReadLine();
            }

            //Velocity Verlet /w air resistance
            //R→new = R→old + V→old Δt + ½ a→old Δt^2
            //a→new =  -9.8 - V→old * 0.1
            //V→new = V→old + (a→new + a→old) * 0.5 * Δt
            //a→old = a→new
            //
            //Defining and setting initial values
            float timeStep = 0.1f; //seconds
            float elapsedTime = 0;
            float thrustTime = 1.0f; //seconds

            //Acceleration of Gravity. 
            float gravity = 9.8f;   //M/s^2

            //Mass of Ship
            float mass = 0.0742f;   //Kilograms

            //Air resistance coefficient
            float airResistance = 0.02f;
            //Mass Coefficient - to avoid unnecessary division.
            float massCoefficient = 1 / mass;
            //Rocket thrust is a heading of 23 degrees and a pitch of 62 degrees.
            //F⃗ net=∑1nF⃗ n=F⃗ 1+F⃗ 1+...+F⃗ n

            //a⃗ =F⃗ netm.



            //Process for Creation of Vectors.
            //Create Vectors for Old Position, New Position, old Velocity, Velocity, old acceleration, and acceleration, and wind force.
            //Rocket thrust is a heading of 23 degrees and a pitch of 62 degrees.
            //F⃗ net=∑1nF⃗ n=F⃗ 1+F⃗ 1+...+F⃗ n
            //fwind = airResistance* Velocity;

            //a⃗ =F⃗ netm.
            Vector3D acceleration = new Vector3D();
            Vector3D newAcceleration = new Vector3D();

            Vector3D position = new Vector3D(0, 0.2f, 0);   //Meters
            Vector3D newPosition = new Vector3D();          //Meters
            Vector3D velocity = new Vector3D();             //Meters per Second
            Vector3D newVelocity = new Vector3D();          //Meters per Second
            Vector3D weight = new Vector3D();               //kg * force of gravity
            Vector3D windSpeed = new Vector3D();            //Velocity of Wind, in meters per second

            //Create Vector for Thrust? 
            Vector3D thruster = new Vector3D();

            weight.SetRectGivenRect(0, -gravity * mass, 0);
            thruster.SetRectGivenMagHeadPitch(10, thruster.DegreeToRad(23), thruster.DegreeToRad(62));

            Vector3D windForce = (velocity - windSpeed) * -airResistance;

            while (newPosition.GetY() > 0 || elapsedTime < thrustTime)
            {
                //R→new = R→old + V→old Δt + ½ a→old Δt^2
                newPosition = position + (velocity * timeStep) + ((acceleration * 0.5f) * (timeStep * timeStep));
                //A→new = Fnet / mass
                if (elapsedTime < thrustTime)
                {
                    newAcceleration = (thruster + windForce + weight) * massCoefficient;
                    Vector3D Tw = thruster - windForce;
                    Console.WriteLine("Thrust - Windorce: ");
                    Tw.PrintRect();
                }
                else
                {
                    newAcceleration = (windForce + weight) * massCoefficient;
                }

                //V→new = V→old + (a→new + a→old) * 0.5 * Δt
                newVelocity = velocity + (acceleration + newAcceleration) * 0.5f * timeStep;

                //a→old = a→new
                acceleration = newAcceleration;
                position = newPosition;
                elapsedTime += timeStep;
                
            }
            Console.WriteLine("Rocket has crashed. Kaboom");
            Console.WriteLine("Time Elapsed: " + elapsedTime);
            Console.WriteLine("Final position of rocket");
            newPosition.PrintRect();
            Console.ReadLine();


        }

    }
}
