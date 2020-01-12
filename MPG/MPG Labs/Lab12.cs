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
         *  A rigidbody object composed of two masses connected by a weightless, user-defined length, bar.
         *  A force on one of the masses will both push the object in a linear direction as well as cause the object to begin rotating.
         */
         //Masses of Each objects         float massOne;  //(kg
        float massTwo;  //(kg)          //Linear Motion Parts.         Vector3D centerMassPos = new Vector3D(0, 0, 0);     //Center of Mass position.  (m)
        Vector3D linVel = new Vector3D();                   //Center of Mass Velocity   (m/s)
        Vector3D linVelOld = new Vector3D();                //CoM old Velocity      (m/s)
        Vector3D linAccel = new Vector3D();                 //CoM acceleration      (m/s^2)
        Vector3D linAccelOld = new Vector3D();              //CoM old Acceleration  (m/s^2)
        Vector3D centerMassOld = new Vector3D();            //old center of mass position.  (m)
        Vector3D linForce = new Vector3D();                 //Force Vector, derived by user-supplied force later. (N)

        //Vectors from Center of Mass to each Mass object.
        Vector3D r1 = new Vector3D();
        Vector3D r2 = new Vector3D();

        Vector3D torqueForce = new Vector3D();         float forceTime;        //How long force should last
        float time = 0f;        //Overall simulation time         float timeStep = 0.02f; //Time Step.

        float barLength = 0f;   //Distance between both bars.

        float massCo = 0f;      //Mass Coefficient for cheaper division.
        float torque = 0f;      //Amount of Torque force
        float force = 0f;       //User-Defined force in Newtons.
        float forceAngle = 0f;  //User-defined direction of force. User inputs in degrees, program uses Radians.

        //Values for Angular Velocity Verlet.
        float theta = 0f;       //Rads
        
        float olTheta = 0f;     //Rads
        float angVel = 0f;      //Rads per Second         float olVel = 0f;       //Rads per Second
        float angAccel = 0f;    //Rads Per Second Squared
        float olAccel;          //Rads Per Second Squared

        float inertia = 0f;         //Used in angular rotation acceleration.
        float intertiaCoef = 0f;    //Used to save


       public Lab12()
        {

            Console.WriteLine("Please Input a Mass for Mass 1 (kg)");       //Get Obj1 & 2 Mass Inputs
            massOne = float.Parse(Console.ReadLine());
            Console.WriteLine("Please Input a Mass for Mass 2 (kg)");
            massTwo = float.Parse(Console.ReadLine());

            Console.WriteLine("Distance between both masses");              //Get the distance between mass one and two
            barLength = float.Parse(Console.ReadLine());

            Console.WriteLine("Please Input an angle of Force (Degrees)");  //Get Heading angle of applied Force
            forceAngle = r1.DegreeToRad(float.Parse(Console.ReadLine()));

            Console.WriteLine("Please Put the strength of Force (N)");      //Get strength of applied force.
            force = float.Parse(Console.ReadLine());

            Console.WriteLine("Please Input a Time (seconds) to run");      //Get input for how long the simulation should run.
            forceTime = float.Parse(Console.ReadLine());

            //Calculating Both radius Vectors based off of a reversal of center of mass Formula.
            r1.SetRectGivenPolar(massTwo * barLength / (massOne + massTwo), theta + (float)Math.PI);        
            r2.SetRectGivenPolar(barLength - r1.GetMag(), theta);

            massCo = 1 / (massOne + massTwo);                               //Calculating Mass Coefficient for easy division.
            inertia = massOne * r1.GetMagSq() + massTwo * r2.GetMagSq();    //Calculating inertia coefficient for angular acceleration.
            intertiaCoef = 1 / inertia;                               //Used to make calculation cheaper as it is called every frame.
            linForce.SetRectGivenPolar(force, forceAngle);                  //Setting linear Force Vector via user Force and angle.

            Console.WriteLine("R1 distance: " + r1.GetMag()); //Printing Lengths of Both R Vectors.
            Console.WriteLine("R2 distance: " + r2.GetMag());

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
                
            while (time < forceTime)    //While elapsed Time is less than simulation time limit.
            {
                //Linear Velocity Verlet
                centerMassPos = centerMassOld + linVelOld * timeStep + 0.5f * linAccelOld * timeStep * timeStep;
                linAccel = linForce * massCo;
                linVel = linVelOld + 0.5f * (linAccel + linAccelOld) * timeStep;

                //Angular Velocity Verlet
                torque = (r1.GetX() * linForce.GetY() - r1.GetY() * linForce.GetX());
                theta = olTheta + olVel * timeStep + 0.5f * olAccel * timeStep * timeStep;  
                angAccel = torque * intertiaCoef;
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

                //Printing Data to User.
                Console.WriteLine("Center of Mass Position: ");
                centerMassPos.PrintRect();
                Console.WriteLine("Time: " + time);
                Console.WriteLine("Angular Acceleration: " + angAccel + " radians / S^2");
                Console.WriteLine("Angular Velocity: " + angVel + " radians / S");
                Console.WriteLine("Angular Position: " + theta + " radians");

                Console.WriteLine();
                WriteFile("Rotational Dynamics", time, olAccel, olVel, olTheta);        //Writing to .CSV document.
                time += timeStep;   //Updating Time.
            }
            Console.WriteLine();
            Console.WriteLine("End of Simulation");
        }

        //Streamwriter Method to create .CSV file.
        private static void WriteFile(string filename, float time, float acceleration, float velocity, float position)
        {
            //Verifies if the directory exists, if not create it and inform the user.
            if (Directory.Exists(Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory) + "\\MathPhysics Output\\") == false)
            {
                Console.WriteLine("Filepath did not exist, Creating and writing!");
                System.IO.Directory.CreateDirectory((System.Environment.SpecialFolder.DesktopDirectory) + "\\MathPhysics Output\\");
            }
                
            //Outputs data to a .CSV file and seperates them amongst their own cells.
            using (StreamWriter stream = new StreamWriter(Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory) + "\\MathPhysics Output\\" + filename + ".csv", true))
            {
                string output = time.ToString() + "," + acceleration.ToString() + "," + velocity.ToString() + "," + position.ToString();
                stream.WriteLine(output);
            }
        }
    }
}
