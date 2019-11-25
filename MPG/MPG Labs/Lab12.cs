using System;
using System.Collections.Generic;
using System.Text;

namespace MPG_Labs
{
    class Lab12
    {

        /* Name: Rotational Dynamics Lab
         * Author: Bowen Chapel
         * Summary: Moving 
         * 
         */

        //Positions of each Object
        Vector3D obj1 = new Vector3D();
        Vector3D obj2 = new Vector3D();          //Masses of Each objects         float massOne;
        float massTwo;          //Center of Mass Between both objects         Vector3D centerMass = new Vector3D();

        //User-supplied Force
        Vector3D force = new Vector3D();         //How long should force         float forceTime;
        float time = 0f;         float timeStep = 0.02f;
        float barLength = 0f;

        float massCo = 0f;

        float theta = 0f;
        float olTheta = 0f;
        float angVel = 0f;         float olVel = 0f;
        float angAccel = 0f;
        float olAccel;

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

            //Get Initial Force Vector
            Console.WriteLine("Please Input a  force (N)");
            Console.WriteLine("Format Example:   0 2 14");

            force.ConstructInput(Console.ReadLine());

            //Get Time for simulation run
            Console.WriteLine("Please Input a Time (seconds) to run");
            forceTime = float.Parse(Console.ReadLine());

            massCo = 1 / (massOne + massTwo);

                
            while (time < forceTime)
            {
                //Calculate Center of Mass for each coordinate.
                Xcm = (obj1.GetX() * massOne + obj2.GetX() * massTwo) * massCo;
                Ycm = (obj1.GetY() * massOne + obj2.GetY() * massTwo) * massCo;
                centerMass.SetRectGivenRect(Xcm, Ycm, 0);

                theta = olTheta + olVel * timeStep + 0.5f * olAccel * timeStep * timeStep;
                //angAccel = HOW WE CALCULATE                 angVel = olVel + 0.5f * (angAccel + olAccel) * timeStep;


                Console.WriteLine("");
                obj1.SetRectGivenPolar(10, theta);
                obj2.SetRectGivenPolar(10, theta);

                obj1.Distance(obj1, obj2);

                obj1 += centerMass;
                obj2 += centerMass;
                obj1.PrintRect();
                obj2.PrintRect();


                olAccel = angAccel;
                olVel = angVel;
                olTheta = theta;
                time += timeStep;
            }
        }
    }
}
