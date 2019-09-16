using System;
using System.Collections.Generic;
using System.Text;

namespace MPG_Labs
{
    class Vector3D
    {
        /* Vector 3D class
          Author: Bowen Walker Chapel
          Version: 1.1
          Date: September 16 2019.
          Summary: 
         
             */

        //Stored X, Y, Z, coordinates of this Vector, and W scalar.
        private float X;
        private float Y;
        private float Z;
        private float W = 1;


        //Initializing the X, Y, and Z values for this vector. 
        public Vector3D(float initX, float initY, float initZ)
        {
            X = initX;
            Y = initY;
            Z = initZ;
        }
        //Overloaded constructor allowing for additional defining of a W value so user doesn't always need a W value.
        public Vector3D(float initX, float initY, float initZ, float initW)
        {
            X = initX;
            Y = initY;
            Z = initZ;
            W = initW;
        }

        //Set the X, Y, and Z values of the Vector via external input.
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
        public void SetRectGivenPolar(float magnitude, float heading)
        {
            X = (float) magnitude * Math.Cos(heading);
            Y = (float) magnitude * Math.Sin(heading);
        }

        public void SetRectGivenMagHeadPitch( float magnitude, float heading, float pitch)
        {
            X = (float) magnitude * Math.Cos(heading);
            Y = (float) magnitude * Math.Sin(heading);
            Z = (float) magnitude * Math.Sin(pitch);
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

        public void PrintPolar()
        {
        Console.WriteLine("Magnitude: " + GetMag() + " @ Angle: " + Math.Tan(X/Y));
        }
        public void PrintmagHeadPitch()
        {
            Console.WriteLine("Magnitude: " + GetMag() + ", Heading: " + GetHeading() + ", Pitch: " + GetPitch());
        }
        public void PrintDirections()
        {
            Console.WriteLine("Alpha: " + GetAlpha() + ", Beta: " + GetBeta() + ", Gamma: "+ GetGamma());
        }
        //Add two vectors.  Operator overload for easy use.
        public static Vector3D operator +(Vector3D U, Vector3D V)
        {
            return (U.X + V.X, U.Y + V.Y, U.Z + V.Z);
        }

        //Subtract two vectors. Operator Overload for easy use.
        public static Vector3D operator -(Vector3D U, Vector3D V)
        {
            return (U.X - V.X, U.Y - V.Y, U.Z - V.Z);
        }
        //Dot Product of two vectors
        public static Vector3D operator ^(Vector3D U, Vector3D V)
        {
            return (U.X * V.X) + (U.Y * V.Y) + (U.Z * V.Z);
        }

        //Difference of Two Angles 
        public static float operator %(Vector3D U, Vector3D V)
        {
            return U.GetHeading() - V.GetHeading();
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
                //Write an error log here.
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

        public float GetHeading()
        {
            return (float) Math.Cos(X/Math.Sqrt(X*X + Y*Y));
        }

        public float GetPitch()
        {
            return (float) Math.Sin(Z / GetMag());
        }

        public float GetAlpha()        
        {
            return (float)Math.Acos(X/! this);
        }
        public float GetBeta()
        {
            return (float)Math.Acos(X/ !this);
        }
        public float GetGamma()
        {
            return(float)Math.Acos(X/ !this);
        }

        public float DegreeToRad(float Degrees)
        {
            return Degrees * (float) Math.Pi/180;
        }
        public float RadToDegree(float Radians)
        {
            return Radians * 180/(float) Math.Pi;
        }

    }
}
