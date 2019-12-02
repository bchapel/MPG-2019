using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MPG_Labs
{
    class Lab12
    {

        /* Name: Rotational Dynamics Lab
         * Author: Bowen Chapel
         * Summary: Simulate how center of mass affects movement & rotational acceleration.
         * 
         * 
         */
         //Masses of Each objects         float massOne;
        float massTwo;          //Linear Motion Parts.         Vector3D centerMassPos = new Vector3D(0, 0, 0);
        Vector3D linVel = new Vector3D();
        Vector3D linVelOld = new Vector3D();
        Vector3D linAccel = new Vector3D();
        Vector3D linAccelOld = new Vector3D();
        Vector3D centerMassOld = new Vector3D();
        Vector3D linForce = new Vector3D();

        //Rotational Motion Parts
        Vector3D r1 = new Vector3D();
        Vector3D r2 = new Vector3D();

        Vector3D torqueForce = new Vector3D();         float forceTime;        //How long force should last
        float time = 0f;        //Overall simulation time         float timeStep = 0.02f; //Time Step.

        float barLength = 0f;   //Distance between both bars.

        float massCo = 0f;      //Mass Coefficient for cheaper division.
        float torque = 0f;
        float force = 0f;
        float forceAngle = 0f;

        //Values for Angular Velocity Verlet.
        float theta = 0f;       //Rads
        
        float olTheta = 0f;     //Rads
        float angVel = 0f;      //Rads per Second         float olVel = 0f;       //Rads per Second
        float angAccel = 0f;    //Rads Per Second Squared
        float olAccel;          //Rads Per Second Squared

        float inertia = 0f;



       public Lab12()
        {
            //REPLAN
            /* -- = done
             * --Mass One.
             * --Mass Two
             * --Vector radius1 & 2
             *  Note: R1 points from CoM to M1, R2 same but for M2.
             * 
             * 
             * --float force = N
             * --float theta = rads (input degrees convert to rads)
             * --Float Torque = radius * force * Sin(theta)
             * TWO velocity Verlet running in parallel
             * --One for linear motion of Center of Mass
             * --One for Rotational Motion of parts.
             * 
             * --FORCE is always acting at the tip of R1.  
             * --magnitude of R1 will never change, but it's orientation will.
             * 
             * 
             * Known Center, known radius.
             * Cm * (m1 + m2) = M1 * r1.mag + m2 * r2mag
             * 
             */


            //Get Obj1 & 2 Mass
            Console.WriteLine("Please Input a Mass for Mass 1 (kg)");
            massOne = float.Parse(Console.ReadLine());
            Console.WriteLine("Please Input a Mass for Mass 2 (kg)");
            massTwo = float.Parse(Console.ReadLine());

            //How far apart should the two masses be?
            Console.WriteLine("Distance between both objects");
            barLength = float.Parse(Console.ReadLine());

            //Get Force Data.
            Console.WriteLine("Please Input an angle of Force (Degrees)");
            forceAngle = r1.DegreeToRad(float.Parse(Console.ReadLine()));

            Console.WriteLine("Please Put the strength of Force (N)");
            force = float.Parse(Console.ReadLine());

            //Get Time for simulation run
            Console.WriteLine("Please Input a Time (seconds) to run");
            forceTime = float.Parse(Console.ReadLine());



            r1.SetRectGivenPolar(massTwo * barLength / (massOne + massTwo), theta + (float)Math.PI);
            r2.SetRectGivenPolar(barLength - r1.GetMag(), theta);

            massCo = 1 / (massOne + massTwo);   //Calculating Mass Coefficient.
            inertia = massOne * r1.GetMagSq() + massTwo * r2.GetMagSq();
            linForce.SetRectGivenPolar(force, forceAngle);
                
            while (time < forceTime)    //While elapsed Time is less than simulation time limit.
            {
                //Linear Velocity Verlet
                centerMassPos = centerMassOld + linVelOld * timeStep + 0.5f * linAccelOld * timeStep * timeStep;
                linAccel = linForce * massCo;
                linVel = linVelOld + 0.5f * (linAccel + linAccelOld) * timeStep;

                //Angular Velocity Verlet
                torque = (r1.GetX() * linForce.GetY() - r1.GetY() * linForce.GetX());
                theta = olTheta + olVel * timeStep + 0.5f * olAccel * timeStep * timeStep;  
                angAccel = torque / inertia;
                angVel = olVel + 0.5f * (angAccel + olAccel) * timeStep;

                //Update Radius Positions.
                r1.SetRectGivenPolar(r1.GetMag(), theta + (float)Math.PI);
                r2.SetRectGivenPolar(r2.GetMag(), theta);

                //Update Old Linear Variables.
                centerMassOld = centerMassPos;
                linVelOld = linVel;
                linAccelOld = linAccel;

                //Update old Angular Values variables
                olAccel = angAccel;
                olVel = angVel;
                olTheta = theta;

                Console.WriteLine("Center of Mass Position: ");
                centerMassPos.PrintRect();

                Console.WriteLine("Angular Acceleration: " + angAccel + "rad/s square");
                Console.WriteLine("Angular Velocity: " + angVel + "rad/s");
                Console.WriteLine("Angular Position: " + theta + "rad");
                WriteFile("Rotational Dynamics", time, olAccel, olVel, olTheta);        //Writing to .CSV document.
                time += timeStep;   //Updating Time.
            }
            Console.WriteLine();
            Console.WriteLine("End of Simulation");
        }


        private static void WriteFile(string filename, float time, float acceleration, float velocity, float position)
        {
            using (StreamWriter stream = new StreamWriter(Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory) + "\\MathPhysics Output\\" + filename + ".csv", true))
            {
                string output = time.ToString() + "," + acceleration.ToString() + "," + velocity.ToString() + "," + position.ToString();
                stream.WriteLine(output);
            }
        }
    }
}
