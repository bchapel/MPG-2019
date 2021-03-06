﻿using System;
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
        //Overloaded constructor allowing for defining the X, Y, and Z when creating the Vector
        public Vector3D(float initX, float initY, float initZ)
        {
            X = initX;
            Y = initY;
            Z = initZ;
            W = 1;
        }
        //Overloaded constructor allowing for defining the X, Y, Z, and W when creating the Vecotr
        public Vector3D(float initX, float initY, float initZ, float initW)
        {
            X = initX;
            Y = initY;
            Z = initZ;
            W = initW;
        }

        //Overload so User can use 2D values.
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

        //Overloaded SetRectGivenRect function, allowing for inputing a W value.
        public void SetRectGivenRect(float inputX, float inputY, float inputZ, float inputW)
        {
            X = inputX;
            Y = inputY;
            Z = inputZ;
            W = inputW;
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

        //PrintMatrix lets the user print all Vector values, even W.  
        //This was made as a seperate function rather than an Overload, because W is present in all Vector3s.
        public void PrintMatrix()
        {
            Console.WriteLine("(" + X + ", " + Y + ", " + Z + ", " + W + ")");
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
            return new Vector3D((U.Y * V.Z) - (V.Y * U.Z), -((U.X * V.Z) - (V.X * U.Z)), (U.X * V.Y) - (V.X * U.Y));
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
            return new Vector3D(U.X * scale, U.Y * scale, U.Z * scale);
        }

        //Overload to allow for putting a scale first and a Vector second.
        public static Vector3D operator *(float scale, Vector3D U)
        {
            return new Vector3D(U.X * scale, U.Y * scale, U.Z * scale);
        }

        //Normalizes the specified Vector.
        public static Vector3D operator !(Vector3D input)
        {
            //V^ = 1/|V|
            if (input.X == 0 && input.Y == 0 & input.Z == 0)
            {
                Console.WriteLine("ERROR: DIVIDE BY ZERO ERROR. RETURNING VALUE OF ZERO INSTEAD");
                return input * 0;
            }
            else
            {
                return (1 /input.GetMag()) * input;
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
                    Console.WriteLine("Test Data: " + X / Math.Sqrt(X * X + Y * Y));
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
        public Vector3D ParaProjection(Vector3D U, Vector3D V)
        {
            float dotProduct = V ^ U;

            float vMag = V.GetMagSq();
            return V * (dotProduct / vMag);
        }

        //Returns a Pepindicular Projection of Two Vectors.
        public Vector3D PerpProjection(Vector3D V, Vector3D U)
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

        //Returns the Normal Vector of a plane defined by the three input Vectors.
        public Vector3D PlaneEquation(Vector3D pointOne, Vector3D pointTwo, Vector3D pointThree)
        {
            Vector3D V1 = pointTwo - pointOne;
            V1.PrintRect();
            Vector3D V2 = pointThree - pointOne;
            V2.PrintRect();

            Vector3D Normal = V1 / V2;
            Console.WriteLine("Normal");
            Normal.PrintRect();

            if (Normal.X < 0 || Normal.Y < 0 || Normal.Z < 0)
            {
                Normal.SetRectGivenRect((float)Math.Sqrt(Normal.X * Normal.X),
                (float)Math.Sqrt(Normal.Y * Normal.Y), (float)Math.Sqrt(Normal.Z * Normal.Z));
            }

            return Normal;
        }

        //Returns the Dot Product of this Vector times another 4D Input Vector, using both Vector's W values.
        public float DotProduct4D(Vector3D input)
        {

            return (X * input.X) + (Y * input.Y) + (Z * input.Z) + (W * input.W);
        }

        //Adds another Vector to this current Vector.
        public void MatrixTranslation(Vector3D input)
        {
            X += input.X;
            Y += input.Y;
            Z += input.Z;
        }

        //Scales this Vector by another Vector.
        public void MatrixRawScale(Vector3D input)
        {
            X *= input.X;
            Y *= input.Y;
            Z *= input.Z;
        }

        //Scales this Vector by another Vector, taking into account a specified center point rather than traditional <0,0,0>.
        public void MatrixCenterScale(Vector3D scale, Vector3D center)
        {
            X = (((X - center.X) * scale.X) + center.X);
            Y = (((Y - center.Y) * scale.Y) + center.Y);
            Z = ((((Z - center.Z) * scale.Z) + center.Z));

        }


        //Returns the Closest point, S, on a line P + d to a specified point Q.
        public Vector3D ClosestPointLine(Vector3D p, Vector3D q, Vector3D d)
        {
            Vector3D PQ = q - p;
            Vector3D S = p + p.ParaProjection(PQ, d);
            return S;
        }

        //Returns the Closest Point, S, on a Plane, n, to a Specified Point Q
        public Vector3D ClosestPointsPlane(Vector3D p, Vector3D q, Vector3D n)
        {
            Vector3D PQ = q - p;
            Vector3D S = q - (n.ParaProjection(PQ, n));
            return S;
        }

        //Miscallaneous Functions added to Vector3D class over time.

        //Distance between two Vectors.
        public float Distance(Vector3D One, Vector3D Two)
        {

            return (float)Math.Sqrt((Two.GetX() - One.GetX()) * (Two.GetX() - One.GetX()) +
                (Two.GetY() - One.GetY() * (Two.GetY() - One.GetY())));
        }

        //Used for Constructing a Vector's values from User Console input.
        public void ConstructInput(string ConsoleRead)
        {

            string input = ConsoleRead;
            string[] split = input.Split(' ');
            float[] num = Array.ConvertAll<string, float>(split, float.Parse);
            SetRectGivenRect(num[0], num[1], num[2]);
        }

        //Rotate a Vector around the X axis by the specified angle (degrees).
        public Vector3D XRotation(float theta)
        {
            theta = this.DegreeToRad(theta);
            float X = this.X;
            float Y = this.Y * (float)Math.Cos(theta) + this.Z * (float)Math.Sin(theta);
            float Z = this.Y * (float)Math.Sin(theta) + this.Z * (float)Math.Cos(theta);

            return new Vector3D(X, Y, Z);
        }

        //Rotate a Vector around the Y axis by the specified angle (degrees).
        public Vector3D YRotation(float theta)
        {
            theta = this.DegreeToRad(theta);
            float X = this.X * ((float)Math.Cos(theta)) + this.Z * (float)Math.Sin(theta);
            float Y = this.Y;
            float Z = this.X * -(float)Math.Sin(theta) + this.Z * (float)Math.Cos(theta);

            return new Vector3D(X, Y, Z);
        }

        //Rotate a Vector around the Z axis by the specified angle (degrees).
        public Vector3D ZRotation(float theta)
        {
            theta = this.DegreeToRad(theta);
            float X = this.X * (float)Math.Cos(theta) + this.Y * -(float)Math.Sin(theta);
            float Y = this.X * (float)Math.Sin(theta) + this.Y * (float)Math.Cos(theta);
            float Z = this.Z;

            return new Vector3D(X, Y, Z);
        }
    }
}
