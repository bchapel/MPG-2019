using System;
using System.Collections.Generic;
using System.Text;

namespace MPG_Labs
{
    class Lab07
    {

        static void Main()
        {
            Console.WriteLine("Test");
            Vector3D ship = new Vector3D(282, 791, 456);
            Vector3D meteroird = new Vector3D(151, 366, 965);
            Vector3D metDir = new Vector3D(12, 31, -46);

            Vector3D lun1 = new Vector3D(377, 912, 598);
            Vector3D lun2 = new Vector3D(385, 920, 593);
            Vector3D lun3 = new Vector3D(388, 914, 604);

           Vector3D lunN = lun1.PlaneEquation(lun1, lun2, lun3);

           Vector3D closePlane = ship.ClosestPointsPlane(lun1, ship, lunN);
            Console.WriteLine("Closest Point on Lunar surface to ship");
           closePlane.PrintRect();

        }
    }
}
