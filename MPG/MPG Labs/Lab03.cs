using System;

namespace MPG_Labs
{
    public class Lab03
    {
        /*  Author: Bowen Chapel
        Date:  September 16 2019.
        Summary:

    */
        public static void Main()
        {

            //asks the user to enter the magnitude, heading, and pitch of the space ship's velocity
            Console.WriteLine("A space ship is moving - please enter the components for it's velocity vector");
            Console.WriteLine("Please enter a Magnitude");
            float tempM = float.Parse(Console.ReadLine());
            Console.WriteLine("Please enter a Heading (Degrees)");
            float tempH = float.Parse(Console.ReadLine());
            Console.WriteLine("Please enter a Pitch (Degrees)");
            float tempP = float.Parse(Console.ReadLine());

            Vector3D velocity = new Vector3D();
            tempH = velocity.DegreeToRad(tempH);
            tempP = velocity.DegreeToRad(tempP);
            velocity.SetRectGivenMagHeadPitch(tempM, tempH, tempP);

            Console.WriteLine();
            //asks the user to enter the x, y, and z components of the speed boost gate's normal vector
            Console.WriteLine("The ship is approaching a gate. Please enter the XYZ components of the gate's normal vector");
            Console.WriteLine("Please Input an X Coordinate");
            float tempX = float.Parse(Console.ReadLine());
            Console.WriteLine("Please Input an Y Coordinate");
            float tempY = float.Parse(Console.ReadLine());
            Console.WriteLine("Please Input an Z Coordinate");
            float tempZ = float.Parse(Console.ReadLine());

            Vector3D gateNormal = new Vector3D(tempX, tempY, tempZ);

            Console.WriteLine();
            Console.WriteLine();
            //report the x, y, and z components of the space ship's velocity
            Console.WriteLine("Old Velocity: Cartesian");
            velocity.PrintRect();

            //report the magnitude, heading, and pitch of the speed boost gate's normal vector
            Console.WriteLine("Gate MHP (Degrees)");
            gateNormal.PrintMagHeadPitch();
            Console.WriteLine("Pitch Radian: " + gateNormal.GetPitch());

            //reports the dot product of the two vectors
            float dotProduct =  velocity ^ gateNormal;
            Console.WriteLine("Dot Product: " +  dotProduct);

            //report the angle between the two vectors in degrees
            float angleDifference = velocity % gateNormal;
            float angleDifferenceDeg = velocity.RadToDegree(angleDifference);
            Console.WriteLine("Angle Difference: " + angleDifferenceDeg + "Degrees");
            Console.WriteLine("Angle Difference: " + angleDifference + "Radians");

            //reports the space ship's new velocity vector in Cartesian form
            Console.WriteLine("New Velocity: Cartesian");
            Vector3D newVelocity = velocity* dotProduct;
            newVelocity.PrintRect();
            Console.WriteLine("New Velocity: MHP");
            //reports the space ship's new velocity vector in MHP form
            newVelocity.PrintMagHeadPitch();
            Console.WriteLine("Pitch Radian: " + newVelocity.GetPitch());
            Console.WriteLine("New Velocity: Direction Angles");
            //reports the direction angles of the space ship's new velocity vector
            newVelocity.PrintDirections();

            Console.ReadLine();

        }
    }
}
