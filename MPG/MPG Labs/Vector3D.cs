using System;
using System.Collections.Generic;
using System.Text;

namespace MPG_Labs
{
    class Vector3D
    {
        /* Vector 3D class
          Author: Bowen Walker Chapel
          Version: 1.0
          Date: August 26 2019.
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
        //Add two vectors.  Operator overload for easy use.
        public static Addition operator+(Vector3D one, Vector3D two)
        {
            Vector3D sum = new Vector3D(one.X + two.X, one.Y + two.Y, one.Z + two.Z);
            return sum;
        }

        //Subtract two vectors. Operator Overload for easy use.
        public static Subtraction operator -(Vector3D one, Vector3D two)
        {
            Vector3D difference = new Vector3D(one.X - two.X, one.Y - two.Y, one.Z - two.Z);
            return difference;
        }

        //Scales a specified Vector by a designated scaling amount.  Operator Overload for easy use.
        public static Scale operator *(Vector3D one, float scale)
        {
            one.X *= scale;
            one.Y *= scale;
            one.Z *= scale;
            return one;
        }
        //Normalizes the specified Vector.
        public static Normalize operator !(Vector3D input)
        {
            if (input.X == 0 && input.Y == 0 & input.Z == 0)
            {
                return input * 0;
                //Write an error log here.
            }
            else
            {
                float normal = (float)Math.Sqrt(input.X + input.Y + input.Z);
                input.X / normal;
                input.Y / normal;
                input.Z / normal;

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

        //Adds the input xyz values to the X Y Z of this vector.
        public void SumRect(float x, float y, float z)
        {
            X += x;
            Y += y;
            Z += z;
        }

        //Subtracts the input values from the Vector.
        public void SubtractRect(float x, float y, float z)
        {
            X -= x;
            Y -= y;
            Z -= z;
        }

        //Scales/Multiplies the rect by the input values.
        public void ScaleRect(float input)
        {
            X *= input;
            Y *= input;
            Z *= input;
        }

    }
}
