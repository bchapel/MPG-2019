using System;
using System.Collections.Generic;
using System.Text;

namespace MPG_Labs
{
    class Vector3D
    {
        /* Vector 3D class
          Author: Bowen Walker Chapel
          Version: 1.2
          Date: September 20 2019.
          Summary: Mathematical Vector.  Stores an X, Y, and Z coordinate and contains several common Vector operations.
          There are several operator functions that allow for doing quick Vector operations against one another,
          as well as more complex return functions.  All angle values will be returned as radians unless otherwise specified.         
        */

        //Stored X, Y, Z, coordinates of this Vector, and W scalar.
        private float X;
        private float Y;
        private float Z;
        private float W = 1;


        //Initializing the X, Y, and Z values for this vector to zero. 
        public Vector3D()
        {
            X = 0;
            Y = 0;
            Z = 0;
            W = 1;
        }
        //Overloaded constructor allowing for defining the X, Y, and Z when creating the Vecotr
        public Vector3D(float initX, float initY, float initZ)
        {
            X = initX;
            Y = initY;
            Z = initZ;
            W = 1;
        }

        //Set this 2D Vector's X and Y values externally.
        public void SetRectGivenRect(float inputX, float inputY)
        {
            X = inputX;
            Y = inputY;
            Z = 0;
        }

        //Set this 3D Vector's X, Y, and Z values externally.
        public void SetRectGivenRect(float inputX, float inputY, float inputZ)
        {
            X = inputX;
            Y = inputY;
            Z = inputZ;
        }

        //Set this 2D Vector's X and Y values externally via magnitude and heading.
        public void SetRectGivenPolar(float magnitude, float heading)
        {
            X = magnitude * (float)Math.Cos(heading);
            Y = magnitude * (float)Math.Sin(heading);
        }

        //Set this 3D Vector's X, Y, and Z values externally via magnitude, heading, and pitch.
        public void SetRectGivenMagHeadPitch(float magnitude, float heading, float pitch)
        {
            if (magnitude < 0)
                magnitude *= -1;

            heading = DegreeToRad(heading);
            pitch = DegreeToRad(pitch);

            X = magnitude * (float)Math.Cos(heading) * (float)Math.Cos(pitch);
            Y = magnitude * (float)Math.Sin(heading) * (float)Math.Cos(pitch);
            Z = magnitude * (float)Math.Sin(pitch);
        }

        //Print the X, Y, and Z coordinate of this vector.
        public void PrintRect()
        {
            Console.WriteLine("(" + X + ", " + Y + ", " + Z + ")");
        }

        //Print the magnitude of this vector. Square Root of ( x*x + y*y + z*z)
        public void PrintMag()
        {
            float magnitude = GetMag();
            Console.WriteLine("Magnitude: " + magnitude);
        }
        //Prints the object's magnitude and heading - angle in degrees.
        public void PrintPolar()
        {
            Console.WriteLine("Magnitude: " + GetMag() + " @ Angle: " + RadToDegree((float)Math.Tan(X / Y)));
        }
        //Pritns the object's Magnitude, Heading, and Pitch.  Angles are in degrees.
        public void PrintMagHeadPitch()
        {
            Console.WriteLine("Magnitude: " + GetMag() + ", Heading: " + RadToDegree(GetHeading()) + " Degrees, Pitch: " + RadToDegree(GetPitch()) + " Degrees");
        }
        //Prints the object's Alpha, Beta, and Gamma directions - Angles are in degrees.
        public void PrintDirections()
        {
            Console.WriteLine("Alpha: " + RadToDegree(GetAlpha()) + ", Beta: " + RadToDegree(GetBeta()) + ", Gamma: " + RadToDegree(GetGamma()));
        }

        //Add two vectors.  Operator overload for easy use.
        public static Vector3D operator +(Vector3D U, Vector3D V)
        {
            return new Vector3D(U.X + V.X, U.Y + V.Y, U.Z + V.Z);
        }

        //Subtract two vectors. Operator Overload for easy use.
        public static Vector3D operator -(Vector3D U, Vector3D V)
        {
            return new Vector3D(U.X - V.X, U.Y - V.Y, U.Z - V.Z);
        }

        //Cross Product of Two Vectors
        public static Vector3D operator /(Vector3D U, Vector3D V)
        {
            return new Vector3D((V.Y * U.Z) - (U.Y * V.Z), -((V.X * U.Z) - (U.X * V.Z)), (V.X * U.Y) - (U.X * V.Y));
        }
        //Dot Product of two vectors
        public static float operator ^(Vector3D U, Vector3D V)
        {
            return (U.X * V.X) + (U.Y * V.Y) + (U.Z * V.Z);
        }

        //Difference of Two Angles 
        public static float operator %(Vector3D U, Vector3D V)
        {
            return (float)Math.Acos((U ^ V) / (U.GetMag() * V.GetMag()));
        }

        //Scales a specified Vector by a designated scaling amount.  Operator Overload for easy use.
        public static Vector3D operator *(Vector3D U, float scale)
        {
            U.X *= scale;
            U.Y *= scale;
            U.Z *= scale;
            return U;
        }
        //Normalizes the specified Vector.
        public static Vector3D operator !(Vector3D input)
        {
            if (input.X == 0 && input.Y == 0 & input.Z == 0)
            {
                Console.WriteLine("ERROR: DIVIDE BY ZERO ERROR. RETURNING VALUE OF ZERO INSTEAD");
                return input * 0;
            }
            else
            {
                float normal = (float)Math.Sqrt(input.X + input.Y + input.Z);
                input.X /= normal;
                input.Y /= normal;
                input.Z /= normal;

                return input;
            }
        }

        //Return the private X value.
        public float GetX()
        {
            return X;
        }
        //Return the private Y value.
        public float GetY()
        {
            return Y;
        }
        //Return the private Z value.
        public float GetZ()
        {
            return Z;
        }

        //Returns the private W value.
        public float GetW()
        {
            return W;
        }

        //Calculate and return the magnitude of the vector.
        public float GetMag()
        {
            float tempMagSquare = (X * X) + (Y * Y) + (Z * Z);
            if (tempMagSquare != 0)
                return (float)Math.Sqrt(tempMagSquare);
            else
            {
                Console.WriteLine("ERROR: Output is Zero.  Is this a Zero vector?");
                return 0;
            }
        }

        //Calculate and return the SQUARED magnitude of the vector.
        public float GetMagSq()
        {
            float tempMagSquare = (X * X) + (Y * Y) + (Z * Z);

            if (tempMagSquare != 0)
                return tempMagSquare;
            else
            {
                Console.WriteLine("ERROR: Output is Zero.  Is this a Zero vector?");
                return 0;
            }
        }

        //Returns the Heading angle, in radians, of the Vector.
        //Will return a zero, and inform user, to avoid a divide by zero error.
        public float GetHeading()
        {
            if (X * X + Y * Y == 0)
            {
                Console.WriteLine("ERROR: Divide by ZERO");
                return 0;
            }
            else
            {
                if (Y >= 0)
                {
                    Console.WriteLine("Test Data: "+ X / Math.Sqrt(X * X + Y * Y));
                    return (float)Math.Acos(X / Math.Sqrt(X * X + Y * Y));
                }

                else
                {
                    Console.WriteLine("Compensating for negative Y");
                    return 2 * (float)Math.PI - (float)Math.Acos(X / Math.Sqrt(X * X + Y * Y));
                }

            }
        }

        //Returns the Pitch angle, in radians, of the Vector.
        //Will return a zero, and inform user, to avoid a divide by zero error.
        public float GetPitch()
        {
            if (GetMag() != 0)
                return (float)Math.Asin(Z / GetMag());
            else
            {
                Console.WriteLine("ERROR: Divide by ZERO");
                return 0;
            }
        }

        //Returns the Alpha direction angle, in radians, of the Vector.
        public float GetAlpha()
        {
            return (float)Math.Acos(X / this.GetMag());
        }
        //Returns the Beta direction angle, in radians, of the Vector.
        public float GetBeta()
        {
            return (float)Math.Acos(Y / this.GetMag());
        }
        //Returns the Gamma direction angle, in radians, of the Vector.
        public float GetGamma()
        {
            return (float)Math.Acos(Z / this.GetMag());
        }

        //Converts an input angle, in Degrees, to Radians.
        public float DegreeToRad(float Degrees)
        {
            return Degrees * (float)Math.PI / 180;
        }

        //Converts an input angle, in Degrees, to Radians.
        public float RadToDegree(float Radians)
        {
            return Radians * 180 / (float)Math.PI;
        }

        //Returns a Parallel Projection of two Vectors.
        public Vector3D ParaProjection(Vector3D V, Vector3D U)
        {
            float dotProduct = V ^ U;
            return V * dotProduct;
        }

        //Returns a Parallel Projection of Two Vectors.
        public Vector3D PerpProjection (Vector3D V, Vector3D U)
        {
            return U - V.ParaProjection(V, U);
        }

        //Returns the closest point point on a line to a specified Vector.
        public Vector3D Line3DClosestPoint(Vector3D P, Vector3D Pvector, Vector3D Q)
        {
            Vector3D PQ = Q - P;
            Vector3D para = P.ParaProjection(PQ, Pvector);
            return P + para;

        }

        //Returns the 
        public Vector3D PlaneEquation(Vector3D pointOne, Vector3D pointTwo, Vector3D pointThree)
        {
            Vector3D U = pointTwo - pointOne;   
            Vector3D V = pointThree - pointOne;

            Vector3D Normal = U / V;

            if (Normal.X < 0 || Normal.Y < 0 || Normal.Z < 0)
            {
                Normal.SetRectGivenRect((float)Math.Sqrt(Normal.X * Normal.X),
                (float)Math.Sqrt(Normal.Y * Normal.Y), (float)Math.Sqrt(Normal.Z * Normal.Z));
            }

            return Normal;
        }
    }
}
