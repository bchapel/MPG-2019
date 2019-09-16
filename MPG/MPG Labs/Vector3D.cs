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

        //Set the X, Y, and Z values of the Vector via external input.
        public void SetRectGivenRect(float inputX, float inputY)
        {
            X = inputX;
            Y = inputY;
            Z = 0;
        }

        //Overloaded SetRectGivenRect function, allowing for inputing a W value.
        public void SetRectGivenRect(float inputX, float inputY, float inputZ)
        {
            X = inputX;
            Y = inputY;
            Z = inputZ;
        }
        public void SetRectGivenPolar(float magnitude, float heading)
        {
            X =  magnitude * (float) Math.Cos(heading);
            Y =  magnitude * (float)Math.Sin(heading);
        }

        public void SetRectGivenMagHeadPitch( float magnitude, float heading, float pitch)
        {
            X = magnitude * (float)Math.Cos(heading) * (float) Math.Cos(pitch);
            Y = magnitude * (float)Math.Sin(heading) * (float) Math.Cos(pitch);
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

        public void PrintPolar()
        {
        Console.WriteLine("Magnitude: " + GetMag() + " @ Angle: " + Math.Tan(X/Y));
        }
        public void PrintMagHeadPitch()
        {
            Console.WriteLine("Magnitude: " + GetMag() + ", Heading: " + RadToDegree(GetHeading()) + " Degrees, Pitch: " + RadToDegree(GetPitch()) + " Degrees");
        }
        public void PrintDirections()
        {
            Console.WriteLine("Alpha: " + RadToDegree(GetAlpha()) + ", Beta: " + RadToDegree(GetBeta()) + ", Gamma: "+ RadToDegree(GetGamma()));
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
        //Dot Product of two vectors
        public static float operator ^(Vector3D U, Vector3D V)
        {
            return (U.X * V.X) + (U.Y * V.Y) + (U.Z * V.Z);
        }

        //Difference of Two Angles 
        public static float operator %(Vector3D U, Vector3D V)
        {
            return (float) Math.Acos((U ^ V) / (U.GetMag() * V.GetMag()));
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
            if (Y >= 0)
            {
                if (X * X + Y * Y == 0)
                    return 0;
                else
                    return (float)Math.Acos(X / Math.Sqrt(X * X + Y * Y));
            }                
            else
                return 2 * (float)Math.PI - (float)Math.Acos(X / Math.Sqrt(X * X + Y * Y));
        }

        public float GetPitch()
        {
            return (float) Math.Asin(Z / GetMag());
        }

        public float GetAlpha()        
        {
            return (float)Math.Acos(X/this.GetMag());
        }
        public float GetBeta()
        {
            return (float)Math.Acos(Y/ this.GetMag());
        }
        public float GetGamma()
        {
            return(float)Math.Acos(Z/this.GetMag());
        }

        public float DegreeToRad(float Degrees)
        {
            return Degrees * (float) Math.PI/180;
        }
        public float RadToDegree(float Radians)
        {
            return Radians * 180/(float) Math.PI;
        }

    }
}
