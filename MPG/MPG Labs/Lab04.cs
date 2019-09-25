using System;
using System.Collections.Generic;
using System.Text;

namespace MPG_Labs
{
    class Lab04
    {
        public static void Lab04Main()
        {
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

            Vector3D position = new Vector3D(0, 0, 0.2f);
            Vector3D newPosition = new Vector3D();
            Vector3D velocity = new Vector3D();
            Vector3D newVelocity = new Vector3D();
            Vector3D weight = new Vector3D();
            Vector3D windSpeed = new Vector3D();

            //Create Vector for Thrust? 
            Vector3D thruster = new Vector3D();

            weight.SetRectGivenRect(0, -gravity * mass, 0);
            thruster.SetRectGivenMagHeadPitch(10, thruster.DegreeToRad(23), thruster.DegreeToRad(62));

            Vector3D windForce = (velocity - windSpeed) * -airResistance;

            while (newPosition.GetY() > 0)
            {
                //R→new = R→old + V→old Δt + ½ a→old Δt^2
                newPosition = position + (velocity * timeStep) + ((acceleration * 0.5f) * (timeStep * timeStep));
                //position.X = newPosition.GetX() + velocity.X* time * 1 / 2 acceleration.X* time * time;
                //position.Y = newPosition.GetY() + velocity.Y* time * 1 / 2 acceleration.Y* time * time;
                //position.Z = newPosition.GetZ() + velocity.Z* time * 1 / 2 acceleration.Z* time * time;

                //A→new = Fnet / mass
                if (elapsedTime < thrustTime)
                {
                    newAcceleration = (thruster + windForce + weight) * massCoefficient;
                }
                else
                {
                    newAcceleration =  (windForce  + weight) * massCoefficient;
                }

                //newAcceleration.X = (thruster.X - windForce.X) / mass;
                //newAcceleration.Y = (thruster.Y - windForce.Y) / mass;
                //newAcceleration.Z = (thruster.Z -  9.8f*mass - windForce.Z) / mass;

                //V→new = V→old + (a→new + a→old) * 0.5 * Δt
                newVelocity = velocity + (acceleration + newAcceleration) * 0.5f * timeStep;
                //newVelocity.X = velocity.X + (acceleration.X + newAccleration.X) * 0.5 * time;
                //newVelocity.Y = velocity.Y + (acceleration.Y + newAccleration.Y) * 0.5 * time;
                //newVelocity.Z = velocity.Z + (acceleration.Z + newAccleration.Z) * 0.5 * time;

                //a→old = a→new
                acceleration = newAcceleration;
                //acceleration.X = newAcceleration.X;
                //acceleration.Y = newAcceleration.Y;
                //acceleration.Z = newAcceleration.Z;

                position = newPosition;
                elapsedTime += timeStep;
            }
            Console.WriteLine("Rocket has crashed. Kaboom");
            Console.WriteLine("Time Elapsed: " + elapsedTime);
            Console.WriteLine("Final position of rocket");
            newPosition.PrintRect();


        }

    }
}
