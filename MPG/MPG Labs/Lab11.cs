using System;
using System.Collections.Generic;
using System.Text;

namespace MPG_Labs
{
    class Lab11
    {
        //


        Quaternion P = new Quaternion(1, new Vector3D(0,2,-3));
        Quaternion Q = new Quaternion(2, new Vector3D(4, -1, 1));

        public Lab11()
        {
            Console.WriteLine("Starting Quaternions)");
            P.PrintQuaternion();
            Q.PrintQuaternion();

            Console.WriteLine("");
            Console.WriteLine("Addition");
            Quaternion T = P + Q;
            T.PrintQuaternion();

            Console.WriteLine("");
            Console.WriteLine("Subtraction");
            T = P - Q;
            T.PrintQuaternion();

            Console.WriteLine("");
            Console.WriteLine("Scalar Multiplication");
            //T = 5 * P;
            //T.PrintQuaternion();

            Console.WriteLine("");
            Console.WriteLine("Quaternion Multiplication");
            T = P ^ Q;
            T.PrintQuaternion();

            Console.WriteLine("");
            Console.WriteLine("P Mag");
            P.PrintMagnitude();
            Console.WriteLine("Q Mag");
            Q.PrintMagnitude();

            Console.WriteLine("");
            Console.WriteLine("Conjugate");

            T = ~P;
            T.PrintQuaternion();


            T = -P;
            Console.WriteLine("");
            Console.WriteLine("Inverse");
            T.PrintQuaternion();

            Console.ReadLine();
        }
    }
}
