using System;
using System.Collections.Generic;
using System.Text;

namespace MPG_Labs
{
    class Quaternion
    {
        float scalar;
        Vector3D vector;

        //Based Constructor for if no specific scalar or Vector is defined.
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


        //Scalar Multiplication

        //Conjugate

        //Inverse

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
        public static Quaternion operator !(Quaternion input)
        {
            return new Quaternion(input.scalar, input.vector * -1);
        }
        //Quaternion Multiplication
        public static Quaternion operator ^(Quaternion q1, Quaternion q2)
        {
            Quaternion r = new Quaternion(q1.scalar * q2.scalar - (q1.vector ^ q2.vector), q2.vector * q1.scalar + q1.vector * q2.scalar + (q1.vector / q2.vector));
            return r;
        }

        //Inverse of a Quaternion
        public static Quaternion operator %(Quaternion inverse)
        {
            return (float)Math.Acos((U ^ V) / (U.GetMag() * V.GetMag()));
        }

        //Scalar Multiplication of a Quaternion.  Operator Overload for easy use.
        public static Vector3D operator *(Vector3D U, float scale)
        {
            U.X *= scale;
            U.Y *= scale;
            U.Z *= scale;
            return U;
        }
        //Magnitude of a Quaternion.
        public static float operator !(Quaternion input)
        {
            return (float)Math.Sqrt((input.scalar * input.scalar) + input.vector.GetMagSq());
        }


    }
}
