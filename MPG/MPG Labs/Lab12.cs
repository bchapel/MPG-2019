using System;
using System.Collections.Generic;
using System.Text;

namespace MPG_Labs
{
    class Lab12
    {

        /* Name: Rotational Dynamics Lab
         * Author: Bowen Chapel
         * Summary: Simulate how center of mass affects movement & rotational acceleration.
         * 
         */

        //Positions of each Object
        Vector3D obj1 = new Vector3D();
        Vector3D obj2 = new Vector3D();          //Masses of Each objects         float massOne;
        float massTwo;          //Center of Mass Between both objects         Vector3D centerMass = new Vector3D();

        //User-supplied Force values
        Vector3D force = new Vector3D();         float forceTime;        //How long force should last
        float time = 0f;        //Overall simulation time         float timeStep = 0.02f; //Time Step.

        float barLength = 0f;   //Distance between both bars.

        float massCo = 0f;      //Mass Coefficient for cheaper division.

        //Values for Velocity Verlet.
        float theta = 0f;       
        float olTheta = 0f;
        float angVel = 0f;         float olVel = 0f;
        float angAccel = 0f;
        float olAccel;


        //Center of Masses.
        float Xcm;
        float Ycm;


       public Lab12()
        {
            //Get Obj1 & 2 Mass
            Console.WriteLine("Please Input a Mass for Object 1 (kg)");
            massOne = float.Parse(Console.ReadLine());
            Console.WriteLine("Please Input a Mass for Object 2 (kg)");
            massTwo = float.Parse(Console.ReadLine());

            //Get Starting Theta
            Console.WriteLine("Please Input a starting Theta angle (degrees)");
            olTheta = float.Parse(Console.ReadLine());

            //How far apart should the two masses be?
            Console.WriteLine("Distance between Objects");
            barLength = float.Parse(Console.ReadLine());

            obj1.SetRectGivenRect(-barLength * 0.5f, 0, 0);
            obj2.SetRectGivenRect(barLength * 0.5f, 0, 0);

            //Get Initial Force Magnitude
            Console.WriteLine("Please Input the magnitude of a force (N)");
            float tempMag = float.Parse(Console.ReadLine());
            Console.WriteLine("Please Input the Direction of the Force (Degrees)");
            float tempDeg = float.Parse(Console.ReadLine());

            force.SetRectGivenPolar(tempMag, tempDeg);

            //Get Time for simulation run
            Console.WriteLine("Please Input a Time (seconds) to run");
            forceTime = float.Parse(Console.ReadLine());

            massCo = 1 / (massOne + massTwo);   //Calculating Mass Coefficient.

                
            while (time < forceTime)    //While elapsed Time is less than simulation time limit.
            {
                //Calculate Center of Mass for each coordinate.
                Xcm = (obj1.GetX() * massOne + obj2.GetX() * massTwo) * massCo;
                Ycm = (obj1.GetY() * massOne + obj2.GetY() * massTwo) * massCo;
                centerMass.SetRectGivenRect(Xcm, Ycm, 0);

                //Velociety Verlet formula
                theta = olTheta + olVel * timeStep + 0.5f * olAccel * timeStep * timeStep;
                //angAccel = HOW TO CALCULATE                 angVel = olVel + 0.5f * (angAccel + olAccel) * timeStep;


                Console.WriteLine("");
                obj1.SetRectGivenPolar(-barLength, theta);
                obj1 = obj1 + centerMass;
                //Calculate Direction Angle (this was done in other lab!) and then 
                //obj2 = obj1 - 

                //Calculate Distance between the two, just to keep track of the Objects and see if they're flying off.
                obj1.Distance(obj1, obj2);

                obj1.PrintRect();
                obj2.PrintRect();


                //Update old variables
                olAccel = angAccel;
                olVel = angVel;
                olTheta = theta;
                time += timeStep;
            }
        }
    }
}
