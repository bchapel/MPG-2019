using System;

    public class Lab03
    {
        /*  Author: Bowen Chapel
        Date:  September 17 2019.
        Version: 1.1
        Summary: Simulation of a sample scenario in a video game: A ship moving at a user-defined velocity vector hits a Velocity-boosting gate with a defined velocity vector.
        Using newly-created Vector Angle calculations, lab simulates the ship's change in velocity based on how close the two's angles were during the 'collision'.
        ChangeLog:
         - 1.0 - Code at conclusion of class: Feature complete, bug free(?)
         - 1.1 - Added comments, summary, and formatting for readability.

    */
        public static void Lab03Main()
        {

            //Asks the user to enter the magnitude, heading, and pitch of the space ship's velocity
            Console.WriteLine("A space ship is moving - please enter the components for it's velocity vector");
            Console.WriteLine("Please enter a Magnitude");
            float tempM = float.Parse(Console.ReadLine());
            Console.WriteLine("Please enter a Heading (Degrees)");
            float tempH = float.Parse(Console.ReadLine());
            Console.WriteLine("Please enter a Pitch (Degrees)");
            float tempP = float.Parse(Console.ReadLine());

            Vector3D velocity = new Vector3D();                     //Defining new Vector
            tempH = velocity.DegreeToRad(tempH);                    //Converting temp heading to radians
            tempP = velocity.DegreeToRad(tempP);                    //Converting temp heading to radians
            velocity.SetRectGivenMagHeadPitch(tempM, tempH, tempP); //Defining velocity Vector via Magnitude, Heading, and Pitch

            Console.WriteLine();        //Spacing for Readability.
            //asks the user to enter the x, y, and z components of the speed boost gate's normal vector
            Console.WriteLine("The ship is approaching a gate. Please enter the XYZ components of the gate's normal vector");
            Console.WriteLine("Please Input an X Coordinate");
            float tempX = float.Parse(Console.ReadLine());
            Console.WriteLine("Please Input an Y Coordinate");
            float tempY = float.Parse(Console.ReadLine());
            Console.WriteLine("Please Input an Z Coordinate");
            float tempZ = float.Parse(Console.ReadLine());

            Vector3D gateNormal = new Vector3D(tempX, tempY, tempZ);    //Defining new Vector

            Console.WriteLine();
            Console.WriteLine();        //Spacing for Readability.  
            //report the x, y, and z components of the space ship's velocity
            Console.WriteLine("Old Velocity: Cartesian");
            velocity.PrintRect();

            Console.WriteLine();        //Spacing for Readability.
            //report the magnitude, heading, and pitch of the speed boost gate's normal vector
            Console.WriteLine("Gate Magnitude, Heading, and Pitch (Degrees)");
            gateNormal.PrintMagHeadPitch();                                         //Displaying the Magnitude, Heading, and Pitch, in degrees, to the user.

            Console.WriteLine();        //Spacing for Readability.
            //reports the dot product of the two vectors
            float dotProduct =  velocity ^ gateNormal;
            Console.WriteLine("Dot Product: " +  dotProduct);                       //Calculating dot product of the velocity and gateNormal via custom operator

            //report the angle between the two vectors in degrees
            float angleDifference = velocity % gateNormal;                          //Computing angle difference of two vectors via custom Operator
            angleDifference = velocity.RadToDegree(angleDifference);                //Converting to degrees
            Console.WriteLine("Angle Difference: " + angleDifference + "Degrees");  //Displaying difference between both angles back to user in degrees

            //reports the space ship's new velocity vector in Cartesian form
            Console.WriteLine("New Velocity: Cartesian");
            Vector3D newVelocity = velocity* dotProduct;
            newVelocity.PrintRect();

            Console.WriteLine();        //Spacing for Readability.
            //reports the space ship's new velocity vector in MHP form
            Console.WriteLine("New Velocity: Magnitude, Heading, Pitch (Degrees)");
            newVelocity.PrintMagHeadPitch();

            Console.WriteLine();        //Spacing for Readability.
            Console.WriteLine("New Velocity: Direction Angles");
            //reports the direction angles of the space ship's new velocity vector
            newVelocity.PrintDirections();

            Console.ReadLine();                                                     //Giving User opportunity to read the results before program closes.
        }
    }
