using System;
using System.Collections.Generic;
using System.Text;

namespace MPG_Labs
{
    /* Name: Collision Detection
     * Author: Bowen Chapel
     * Date: 
     * Summary: 
     * 
     *
     */
    class Lab08
    {

        //Vectors and Array for Object 1.
        Vector3D[] object1 = new Vector3D[2];
        Vector3D obj1p1 = new Vector3D();
        Vector3D obj1p2 = new Vector3D();

        //Vectors and Array for Object 2
        Vector3D[] object2 = new Vector3D[2];
        Vector3D obj2p1 = new Vector3D();
        Vector3D obj2p2 = new Vector3D();


        //Sphere One Position & Radius
        Vector3D sphere1 = new Vector3D();
        float sphere1Rad = 0;

        //Sphere Two Position & Radius
        Vector3D sphere2 = new Vector3D();
        float sphere2Rad = 0;

        //Line Segment 1 Point A & B
        Vector3D ls1A;
        Vector3D ls1B;

        //Line Segment 2 Point A & B
        Vector3D ls2A;
        Vector3D ls2B;


        public Lab08()
        {
            //Let user choose scenario to run.
            Console.WriteLine("Please Choose a test scenario style:");
            Console.WriteLine("(1) Sphere");
            Console.WriteLine("(2) Axially-Aligned Bounding Box");
            Console.WriteLine("(3) Line Segment");
            Console.WriteLine("(4) Exit Program");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (choice)
            {
                case 1: //Sphere Collision Scenario.
                    //Prompts user for input, gives formatting example on how to input Vectors.
                    Console.WriteLine("Please Input a Vector for Sphere 1");
                    Console.WriteLine("Format Example:   0 2 14");

                    //Code so User can input an entire Vector in one line instead of by individiual component.
                    string input = Console.ReadLine();
                    string[] split = input.Split(' ');
                    float[] num = Array.ConvertAll<string, float>(split, float.Parse);
                    sphere1.SetRectGivenRect(num[0], num[1], num[2]);

                    //Defining Radius for Sphere.
                    Console.WriteLine("Please Input a Radius for Sphere 1");
                    sphere1Rad = float.Parse(Console.ReadLine());

                    Console.WriteLine("Please Input a Vector for Sphere 2");
                    Console.WriteLine("Format Example:   0 2 14");
                    //Code so User can input an entire Vector in one line instead of by individiual component.
                    input = Console.ReadLine();
                    split = input.Split(' ');
                    num = Array.ConvertAll<string, float>(split, float.Parse);

                    sphere2.SetRectGivenRect(num[0], num[1], num[2]);

                    Console.WriteLine("Please Input a Radius for Sphere 2");
                    sphere2Rad = float.Parse(Console.ReadLine());

                    //Referencing Sphere Collision Method, which is boolean.
                    //If Method returns true, output collision to screen.
                    if (Sphere(sphere1, sphere1Rad, sphere2, sphere2Rad))
                        Console.WriteLine("Spheres collide");
                    else
                        Console.WriteLine("Spheres do not collide");
                    Console.ReadLine();
                    break;


                case 2: //Axially Aligned Bounding Box Collision
                    //Prompts User for Vector coordinate input and gives guidance on how to delimit their input.
                    Console.WriteLine("Please Input a Vector for OBj1 point 1");
                    Console.WriteLine("Format Example:   0 2 14");
                    //Delimits input so to allow entire Vector be input in one line.
                    input = Console.ReadLine();
                    split = input.Split(' ');
                    num = Array.ConvertAll<string, float>(split, float.Parse);
                    obj1p1.SetRectGivenRect(num[0], num[1], num[2]); //Set Object One Point 1.

                    Console.WriteLine("Please Input a Vector for OBj1 point 2");
                    Console.WriteLine("Format Example:   0 2 14");
                    input = Console.ReadLine();
                    split = input.Split(' ');
                    num = Array.ConvertAll<string, float>(split, float.Parse);
                    obj1p2.SetRectGivenRect(num[0], num[1], num[2]);


                    Console.Clear();
                    obj1p1.PrintRect();
                    obj1p2.PrintRect();
                    //Assigning Vectors into array for later.
                    object1[0] = obj1p1;
                    object1[1] = obj1p2;


                    Console.WriteLine("Please Input a Vector for OBj2 point 1");
                    Console.WriteLine("Format Example:   0 2 14");
                    input = Console.ReadLine();
                    split = input.Split(' ');
                    num = Array.ConvertAll<string, float>(split, float.Parse);
                    obj2p1.SetRectGivenRect(num[0], num[1], num[2]);

                    Console.WriteLine("Please Input a Vector for OBj2 point 2");
                    Console.WriteLine("Format Example:   0 2 14");
                    input = Console.ReadLine();
                    split = input.Split(' ');
                    num = Array.ConvertAll<string, float>(split, float.Parse);
                    obj2p2.SetRectGivenRect(num[0], num[1], num[2]);


                    object2[0] = obj2p1;
                    object2[1] = obj2p2;

                    if (AABB(object1, object2))
                        Console.WriteLine("Collision has occured");
                    else
                        Console.WriteLine("Collision has not occured");
                    Console.ReadLine();

                    break;

                case 3:
                    Console.WriteLine("Lab currently not impleneted");
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }

        float Distance(Vector3D one, Vector3D two)
        {
            float x = (two.GetX() - one.GetX()) * (two.GetX() - one.GetX());
            float y = (two.GetY() - one.GetY()) * (two.GetY() - one.GetY());
            float z = (two.GetZ() - one.GetZ()) * (two.GetZ() - one.GetZ());
            float d = (float)Math.Sqrt(x + y + z);
            return d;
        }

        bool Sphere(Vector3D sphere1, float rad1, Vector3D sphere2, float rad2)
        {
            Console.WriteLine("Distance: " + Distance(sphere1, sphere2));
            Console.WriteLine("Rad Combined: " + (rad1 + rad2));
            if (Distance(sphere1, sphere2) > rad1 + rad2)
                return false;
            else
                return true;
        }

        //Axially Aligned Bounding Box Collission Calculations.
        //Take Vector Array for Box One and Box Two.
        bool AABB(Vector3D[] obj1, Vector3D[] obj2)
        {
            int i = 0;

            Vector3D minObj1 = new Vector3D();
            Vector3D maxObj1 = new Vector3D();

            Vector3D minObj2 = new Vector3D();
            Vector3D maxObj2 = new Vector3D();

            //Keep track of Smallest value of each Axis.
            float smallX = obj1[0].GetX();
            float smallY = obj1[0].GetY();
            float smallZ = obj1[0].GetZ();

            //Keep Track of Largest value of each Axis
            float largeX = obj1[0].GetX();
            float largeY = obj1[0].GetY();
            float largeZ = obj1[0].GetZ();

            //^ In both cases note that the initial value is array[0]
            //This is to avoid an edge case with defining them as zero.
            //As at 0 if the lowest X is 10, for example, smallX would be 0 rather than 10!

            //For loop going through the Object1 Vector Array.
            //Sorting and saving the smallest and largest values from each Axis.
            for (i = 1; i < obj1.Length; i++)
            {
                if (smallX > obj1[i].GetX())
                    smallX = obj1[i].GetX();
                if (smallY > obj1[i].GetY())
                    smallY = obj1[i].GetY();
                if (smallZ > obj1[i].GetZ())
                    smallZ = obj1[i].GetZ();

                if (largeX > obj1[i].GetX())
                    largeX = obj1[i].GetX();
                if (largeY > obj1[i].GetY())
                    largeY = obj1[i].GetY();
                if (largeZ > obj1[i].GetZ())
                    largeZ = obj1[i].GetZ();
            }

            //Store min and max values of Obj X Y Z in array.
            minObj1.SetRectGivenRect(smallX, smallY, smallZ);
            maxObj1.SetRectGivenRect(largeX, largeY, largeZ);

            //Reset everything for use again.
            i = 0;
            smallX = 0;
            smallY = 0;
            smallZ = 0;
            largeX = 0;
            largeY = 0;
            largeZ = 0;

            // For loop going through the Object2 Vector Array.
            //Sorting and saving the smallest and largest values from each Axis.
            for (i = 1; i < obj2.Length; i++)
            {
                if (smallX > obj2[i].GetX())
                    smallX = obj2[i].GetX();
                if (smallY > obj2[i].GetY())
                    smallY = obj2[i].GetY();
                if (smallZ > obj2[i].GetZ())
                    smallZ = obj2[i].GetZ();

                if (largeX > obj2[i].GetX())
                    largeX = obj2[i].GetX();
                if (largeY > obj2[i].GetY())
                    largeY = obj2[i].GetY();
                if (largeZ > obj2[i].GetZ())
                    largeZ = obj2[i].GetZ();
            }

            //Store min and max values for Obj2.
            minObj2.SetRectGivenRect(smallX, smallY, smallZ);
            maxObj2.SetRectGivenRect(largeX, largeY, largeZ);

            //Calculated Obj1 Radius for each Axis.  Formula example X axis Sqrt((minObjX - maxObjX)^2)
            float rX1 = 0.5f * (float)Math.Sqrt((minObj1.GetX() - maxObj1.GetX()) * (minObj1.GetX() - maxObj1.GetX()));
            float rY1 = 0.5f * (float)Math.Sqrt((minObj1.GetY() - maxObj1.GetY()) * (minObj1.GetY() - maxObj1.GetY()));
            float rZ1 = 0.5f * (float)Math.Sqrt((minObj1.GetZ() - maxObj1.GetZ()) * (minObj1.GetZ() - maxObj1.GetZ()));

            //Calculated Obj2 Radius for each Axis
            float rX2 = 0.5f * (float)Math.Sqrt((minObj2.GetX() - maxObj2.GetX()) * (minObj2.GetX() - maxObj2.GetX()));
            float rY2 = 0.5f * (float)Math.Sqrt((minObj2.GetY() - maxObj2.GetY()) * (minObj2.GetY() - maxObj2.GetY()));
            float rZ2 = 0.5f * (float)Math.Sqrt((minObj2.GetZ() - maxObj2.GetZ()) * (minObj2.GetZ() - maxObj2.GetZ()));

            //Calculated Obj1 center for each Axis.  Formula Example X: (minObj1.X + maxObj1.X) / 2
            float Cx1 = (minObj1.GetX() + maxObj1.GetX()) * 0.5f;
            float Cy1 = (minObj1.GetY() + maxObj1.GetY()) * 0.5f;
            float Cz1 = (minObj1.GetZ() + maxObj1.GetZ()) * 0.5f;

            //Calculated Obj2 Center for each Axis
            float Cx2 = (minObj2.GetX() + maxObj2.GetX()) * 0.5f;
            float Cy2 = (minObj2.GetY() + maxObj2.GetY()) * 0.5f;
            float Cz2 = (minObj2.GetZ() + maxObj2.GetZ()) * 0.5f;

            //Get Distance Between the two X Centers, compare if it's less than or equal to the sum of both Object's X Radius
            if ((float)Math.Sqrt((Cx1 - Cx2) * (Cx1 - Cx2)) <= rX1 + rX2)
            {
                //If true, advance to Y axis and do same as above.
                if ((float)Math.Sqrt((Cy1 - Cy2) * (Cy1 - Cy2)) <= rY1 + rY2)
                {
                    //If true, advance to Z axis and do same as above.
                    if ((float)Math.Sqrt((Cz1 - Cz2) * (Cz1 - Cz2)) <= rZ1 + rZ2)
                    {
                        Console.WriteLine("Returned True");
                        return true; //If Z is true, collission has occured.
                    }

                    else
                        return false;

                }
                else
                    return false;
            }
            else
                return false;
            //If any fail return false. No collission detected.
        }

        bool LineSegment(Vector3D l1a, Vector3D l1b, Vector3D l2a, Vector3D l2b)
        {
            return false;
        }
    }


}
