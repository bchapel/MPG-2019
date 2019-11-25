using System;
using System.Collections.Generic;
using System.Text;

namespace MPG_Labs
{
    class Lab09
    {
        public Lab09()
        {
            Vector3D dir = new Vector3D(-1, 2, 0);
            dir.PrintDirections();


            float rest = 0.83f;
            Vector3D final = new Vector3D();
            Vector3D initial = new Vector3D(13.2f, 126.0f, -25.3f);
            initial.PrintMag();
            Vector3D normal = new Vector3D();

            Vector3D p1 = new Vector3D(7.24f, 0.12f, -0.67f);
            Vector3D p2 = new Vector3D(-0.3f, 0.21f, 0.17f);
            Vector3D p3 = new Vector3D(-0.45f, 8.34f, 6.71f);

           normal = normal.PlaneEquation(p1, p2, p3);

            Vector3D interim = (initial ^ normal) * normal;
            interim.PrintRect();
            final = initial - (1 + rest) * interim;

            final.PrintRect();
            final.PrintMag();
            Console.ReadLine();
        }
    }
}
