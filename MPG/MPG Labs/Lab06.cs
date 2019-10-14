using System;
using System.Collections.Generic;
using System.Text;

namespace MPG_Labs
{
    class Lab06
    {
        static void Main()
        {
            Vector3D center = new Vector3D(1.8f, 2.6f, 0);
            Vector3D scale = new Vector3D(10, 0.25f, 1);
            Vector3D v1 = new Vector3D(0, 2, 0);
            Vector3D v2 = new Vector3D(1, 1, 0);
            Vector3D v3 = new Vector3D(1, 4, 0);
            Vector3D v4 = new Vector3D(3, 2, 0);
            Vector3D v5 = new Vector3D(4, 4, 0);

            v1 = v1.MatrixCenterScale(scale, center);
            v1.PrintRect();
            Console.WriteLine();
           v2 = v2.MatrixCenterScale(scale, center);
            v2.PrintRect();
            Console.WriteLine();
           v3 = v3.MatrixCenterScale(scale, center);
            v3.PrintRect();
            Console.WriteLine();
           v4 = v4.MatrixCenterScale(scale, center);
            v4.PrintRect();
            Console.WriteLine();
           v5 = v5.MatrixCenterScale(scale, center);
            v5.PrintRect();
        }
    }
}
