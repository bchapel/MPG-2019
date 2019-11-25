using System;
using System.Collections.Generic;
using System.Text;

namespace MPG_Labs
{
    /*Name: Quaternion Class
     * Author: Bowen W Chapel
     * Version: 1
     * Summary: This class is similar to the Vector3D class, and contains a library of mathematical functions to use with Quaternions.
     * The class takes a Float scalar and a Vector3D as it's input components, but will default to using zeros if nothing is initially given.
     * 
     * 
     */
    class Quaternion
    {
        //Components of Quaternion
        float scalar;
        Vector3D vector;

        //Basic Constructor for if no specific scalar or Vector is defined.
        public Quaternion()
        {
            scalar = 0;
            vector.SetRectGivenRect(0, 0, 0);
        }

        //Proper constructor so user can define an input scalar and Vector value.
        public Quaternion(float inputScalar, Vector3D inputVector)
        {
            scalar = inputScalar;
            vector = inputVector;
        }

        //Add two Quaternions.  Operator overload for easy use.
        public static Quaternion operator +(Quaternion U, Quaternion V)
        {
            return new Quaternion(U.scalar + V.scalar, U.vector + V.vector);
        }

        //Subtract two Quaternions. Operator Overload for easy use.
        public static Quaternion operator -(Quaternion U, Quaternion V)
        {
            return new Quaternion(U.scalar - V.scalar, U.vector - V.vector);
        }

        //Conjugate of a Quaternion
        public static Quaternion operator ~(Quaternion input)
        {
            return new Quaternion(input.scalar, input.vector * -1);
        }

        //Quaternion Multiplication
        public static Quaternion operator ^(Quaternion q1, Quaternion q2)
        {
            Quaternion r = new Quaternion(q1.scalar * q2.scalar - (q1.vector ^ q2.vector), (q2.vector * q1.scalar) + (q1.vector * q2.scalar) + (q1.vector / q2.vector));
            return r;
        }

        //Returns the Inverse of the Quaternion.
        //Contains a failsafe to avoid a divide by zero error.
        public static Quaternion operator -(Quaternion input)
        {
            float mag = !input;
            if (mag == 0)
            {
                Console.WriteLine("Quaternion Magnitude returned Zero!");
                return input;
            }
            else
                return ~input * (1 / (mag * mag));
        }

        //Scalar Multiplication of a Quaternion.Operator Overload for easy use.
        public static Quaternion operator *(Quaternion input, float scale)
        {
            return new Quaternion(input.scalar * scale, input.vector * scale);
        }

        //Additional Scalar multiplication of the above Operator to allow user to input scalar first.
        public static Quaternion operator *(float scale, Quaternion input)
        {
            return new Quaternion(input.scalar * scale, input.vector * scale);
        }

        //Returns the Magnitude of a Quaternion.
        public static float operator !(Quaternion input)
        {
            return (float)Math.Sqrt((input.scalar * input.scalar) + input.vector.GetMagSq());
        }

        //Rotates the Quaternion.
        public Quaternion Rotation(Quaternion input, float angleTheta)
        {


            return new Quaternion();
        }

        //Prints the Scalar value of the Quaternion.
        public void PrintScalar()
        {
            Console.WriteLine("Scalar: " + scalar);
        }

        //Prints the Vector value of the Quaternion.
        public void PrintVector()
        {
            Console.WriteLine("Vector: <" + vector.GetX() + ", " + vector.GetY() + ", " + vector.GetZ() + ">");
        }

        //Prints both the Vector and Scalar components of the Quaternion
        public void PrintQuaternion()
        {
            Console.WriteLine("[" + scalar + ", <" + vector.GetX() + ", " + vector.GetY() + ", " + vector.GetZ() + ">]");
        }

        //Prints the Magnitude of the Quaternion.
        public void PrintMagnitude()
        {
            Console.WriteLine("Magnitude: " + !this);
        }

    }
}
