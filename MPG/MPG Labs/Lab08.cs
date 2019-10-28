using System;
using System.Collections.Generic;
using System.Text;

namespace MPG_Labs
{
    class Lab08
    {
        Vector3D[] object1 = new Vector3D[2];
        Vector3D obj1p1 = new Vector3D();
        Vector3D obj1p2 = new Vector3D();
        Vector3D obj1p3 = new Vector3D();
        Vector3D obj1p4 = new Vector3D();

        Vector3D[] object2 = new Vector3D[2];
        Vector3D obj2p1 = new Vector3D();
        Vector3D obj2p2 = new Vector3D();
        Vector3D obj2p3 = new Vector3D();
        Vector3D obj2p4 = new Vector3D();


        Vector3D sphere1 = new Vector3D();
        float sphere1Rad = 0;

        Vector3D sphere2 = new Vector3D();
        float sphere2Rad = 0;

        Vector3D ls1A;
        Vector3D ls1B;

        Vector3D ls2A;
        Vector3D ls2B;


        public Lab08()
        {
            Console.WriteLine("Please Choose a test scenario style:");
            Console.WriteLine("(1) Sphere");
            Console.WriteLine("(2) Axially-Aligned Bounding Box");
            Console.WriteLine("(3) Line Segment");
            Console.WriteLine("(4) Exit Program");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (choice)
            {
                case 1:

                    Console.WriteLine("Please Input a Vector for Sphere 1");
                    Console.WriteLine("Format Example:   0 2 14");
                    string input = Console.ReadLine();
                    string[] split = input.Split(' ');
                    float[] num = Array.ConvertAll<string, float>(split, float.Parse);
                    sphere1.SetRectGivenRect(num[0], num[1], num[2]);

                    Console.WriteLine("Please Input a Radius for Sphere 1");
                    sphere1Rad = float.Parse(Console.ReadLine());

                    Console.WriteLine("Please Input a Vector for Sphere 2");
                    Console.WriteLine("Format Example:   0 2 14");
                    input = Console.ReadLine();
                    split = input.Split(' ');
                    num = Array.ConvertAll<string, float>(split, float.Parse);

                    sphere2.SetRectGivenRect(num[0], num[1], num[2]);

                    Console.WriteLine("Please Input a Radius for Sphere 2");
                    sphere2Rad = float.Parse(Console.ReadLine());

                    if (Sphere(sphere1, sphere1Rad, sphere2, sphere2Rad))
                        Console.WriteLine("Spheres collide");
                    else
                        Console.WriteLine("Spheres do not collide");
                    Console.ReadLine();

                    break;


                case 2:
                    Console.WriteLine("Please Input a Vector for OBj1 point 1");
                    Console.WriteLine("Format Example:   0 2 14");
                    input = Console.ReadLine();
                    split = input.Split(' ');
                    num = Array.ConvertAll<string, float>(split, float.Parse);
                    obj1p1.SetRectGivenRect(num[0], num[1], num[2]);

                    Console.WriteLine("Please Input a Vector for OBj1 point 2");
                    Console.WriteLine("Format Example:   0 2 14");
                    input = Console.ReadLine();
                    split = input.Split(' ');
                    num = Array.ConvertAll<string, float>(split, float.Parse);
                    obj1p2.SetRectGivenRect(num[0], num[1], num[2]);


                    Console.Clear();
                    obj1p1.PrintRect();
                    obj1p2.PrintRect();

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

        bool AABB(Vector3D[] obj1, Vector3D[] obj2)
        {
            int i = 0;

            Vector3D minObj1 = new Vector3D();
            Vector3D maxObj1 = new Vector3D();

            Vector3D minObj2 = new Vector3D();
            Vector3D maxObj2 = new Vector3D();

            //Why this? Instead of instantiating it as zero, what if X Y Z is above zero? So always relative to Vector
            float smallX = obj1[0].GetX();
            float smallY = obj1[0].GetY();
            float smallZ = obj1[0].GetZ();

            float largeX = obj1[0].GetX();
            float largeY = obj1[0].GetY();
            float largeZ = obj1[0].GetZ();

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
            //Store min and max values of Obj X Y Z
            minObj1.SetRectGivenRect(smallX, smallY, smallZ);
            maxObj1.SetRectGivenRect(largeX, largeY, largeZ);

            //Reset everything.
            i = 0;
            smallX = 0;
            smallY = 0;
            smallZ = 0;
            largeX = 0;
            largeY = 0;
            largeZ = 0;

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

            //Calculated Obj1 Radius
            float rX1 = 0.5f * (float)Math.Sqrt((minObj1.GetX() - maxObj1.GetX()) * (minObj1.GetX() - maxObj1.GetX()));
            float rY1 = 0.5f * (float)Math.Sqrt((minObj1.GetY() - maxObj1.GetY()) * (minObj1.GetY() - maxObj1.GetY()));
            float rZ1 = 0.5f * (float)Math.Sqrt((minObj1.GetZ() - maxObj1.GetZ()) * (minObj1.GetZ() - maxObj1.GetZ()));

            //Calculated Obj2 Radius
            float rX2 = 0.5f * (float)Math.Sqrt((minObj2.GetX() - maxObj2.GetX()) * (minObj2.GetX() - maxObj2.GetX()));
            float rY2 = 0.5f * (float)Math.Sqrt((minObj2.GetY() - maxObj2.GetY()) * (minObj2.GetY() - maxObj2.GetY()));
            float rZ2 = 0.5f * (float)Math.Sqrt((minObj2.GetZ() - maxObj2.GetZ()) * (minObj2.GetZ() - maxObj2.GetZ()));

            //Calculated Obj center
            float Cx1 = (minObj1.GetX() + maxObj1.GetX()) * 0.5f;
            float Cy1 = (minObj1.GetY() + maxObj1.GetY()) * 0.5f;
            float Cz1 = (minObj1.GetZ() + maxObj1.GetZ()) * 0.5f;

            //Calculated Obj Center
            float Cx2 = (minObj2.GetX() + maxObj2.GetX()) * 0.5f;
            float Cy2 = (minObj2.GetY() + maxObj2.GetY()) * 0.5f;
            float Cz2 = (minObj2.GetZ() + maxObj2.GetZ()) * 0.5f;

            if ((float)Math.Sqrt(Cx1 - Cx2) <= rX1 + rX2)
            {
                if ((float)Math.Sqrt(Cy1 - Cy2) <= rY1 + rY2)
                {
                    if ((float)Math.Sqrt(Cz1 - Cz2) <= rZ1 + rZ2)
                        return true;
                    else
                        return false;

                }
                else
                    return false;
            }
            else
                return false;
        }

        bool LineSegment(Vector3D l1a, Vector3D l1b, Vector3D l2a, Vector3D l2b)
        {
            return false;
        }
    }


}
