using System;

namespace MPG_Labs
{
    public class Lab03
    {
        /*  Author: Bowen Chapel
        Date:  September 16 2019.
        Summary:

    */
        public Lab03()
        {

            //asks the user to enter the magnitude, heading, and pitch of the space ship's velocity
            Console.WriteLine("A space ship is moving - please enter the components for it's velocity vector");
            Console.WriteLine("Please enter a Magnitude");
            tempM = float.Parse(Console.ReadLine());
            Console.WriteLine("Please enter a Heading");
            tempH = float.Parse(Console.ReadLine());
            Console.WriteLine("Please enter a Pitch");
            tempP = float.Parse(Console.ReadLine());

            Vector3D velocity = new Vector3D();
            velocity.SetRectGivenMagHeadPitch(tempM, tempH, tempP);
            //asks the user to enter the x, y, and z components of the speed boost gate's normal vector
            Console.WriteLine("The ship is approaching a gate. Please enter the XYZ components of the gate's normal vector");
            Console.WriteLine("Please Input an X Coordinate");
            tempX = float.Parse(Console.ReadLine());
            Console.WriteLine("Please Input an Y Coordinate");
            tempY = float.Parse(Console.ReadLine());
            Console.WriteLine("Please Input an Z Coordinate");
            tempZ = float.Parse(Console.ReadLine());

            Vector3D gateNormal = new Vector3D(tempX, tempY, tempZ);
            //report the x, y, and z components of the space ship's velocity
            velocity.PrintRect();

            //report the magnitude, heading, and pitch of the speed boost gate's normal vector
            gateNormal.PrintmagHeadPitch();

            //reports the dot product of the two vectors
            float dotProduct = velocity ^ gateNormal;
            Console.WriteLine("Dot Product: " +  dotProduct);

            //report the angle between the two vectors in degrees
            float angleDifference = velocity % gateNormal;
            Console.WriteLine("Angle Difference: " + angleDifference);

            //reports the space ship's new velocity vector in Cartesian form
            velocity.SetRectGivenMagHeadPitch(dotProduct, velocity.GetHeading(), velocity.GetPitch());
            velocity.PrintRect();
            //reports the space ship's new velocity vector in MHP form
            velocity.PrintMagHeadPitch();

            //reports the direction angles of the space ship's new velocity vector
            velocity.PrintDirections();

        }
    }
}
