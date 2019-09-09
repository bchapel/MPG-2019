using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MPG_Labs
{
    class Lab_02
    {
        static void Main(string[] args)
        {
            float elapsedTime = 0;
            float timeStep = 0.1f;
            float newVelocity = 49f;
            float oldVelocity = newVelocity;
            float newPosition = 2f;
            float oldPositon = newPosition;
            float newAcceleration = -9.8f;
            float oldAcceleration = newAcceleration;

            //Forward Euler with TimeStamp of 0.1 seconds
            while (elapsedTime < 10)
            {
                Console.WriteLine("Elapsed Time: " + elapsedTime + ", Position: " + newPosition + ", Velocity: " + newVelocity);
                WriteFile("ex02_euler_0-10", newVelocity, elapsedTime, newPosition);

                newPosition = oldPositon + newVelocity * timeStep;
                newVelocity = oldVelocity + newAcceleration * timeStep;
                timeStep += timeStep;

                oldPositon = newPosition;
                oldVelocity = newVelocity;
            }

            Console.ReadLine();
            Console.Clear();
            // Forward Euler with Time Stamp of 1 second.
            //reset variables.
            elapsedTime = 0;
            timeStep = 1f;
            newVelocity = 49f;
            oldVelocity = newVelocity;
            newPosition = 2f;
            oldPositon = newPosition;
            newAcceleration = -9.8f;
            oldAcceleration = newAcceleration;

            while (elapsedTime < 10)
            {
                Console.WriteLine("Elapsed Time: " + elapsedTime + ", Position: " + newPosition + ", Velocity: " + newVelocity);
                WriteFile("ex02_euler_1-0", newVelocity, elapsedTime, newPosition);

                newPosition = oldPositon + newVelocity * timeStep;
                newVelocity = oldVelocity + newAcceleration * timeStep;
                timeStep += timeStep;

                oldPositon = newPosition;
                oldVelocity = newVelocity;
            }

            Console.ReadLine();
            Console.Clear();
            //Forward Euler with TimeStamp of 0.01 seconds.
            //reset variables.
            elapsedTime = 0;
            timeStep = 0.1f;
            newVelocity = 49f;
            oldVelocity = newVelocity;
            newPosition = 2f;
            oldPositon = newPosition;
            newAcceleration = -9.8f;
            oldAcceleration = newAcceleration;

            while (elapsedTime < 10)
            {
                Console.WriteLine("Elapsed Time: " + elapsedTime + ", Position: " + newPosition + ", Velocity: " + newVelocity);
                WriteFile("ex02_euler_0-01", newVelocity, elapsedTime, newPosition);

                newPosition = oldPositon + newVelocity * timeStep;
                newVelocity = oldVelocity + newAcceleration * timeStep;
                timeStep += timeStep;

                oldPositon = newPosition;
                oldVelocity = newVelocity;
            }

            Console.ReadLine();
            Console.Clear();

            //Velocity Verlet - no air resistance

            //reset variables.
            elapsedTime = 0;
            timeStep = 0.1f;
            newVelocity = 49f;
            oldVelocity = newVelocity;
            newPosition = 2f;
            oldPositon = newPosition;
            newAcceleration = -9.8f;
            oldAcceleration = newAcceleration;

            while (elapsedTime < 10)
            {
                Console.WriteLine("Elapsed Time: " + elapsedTime + ", Position: " + newPosition + ", Velocity: " + newVelocity);
                WriteFile("ex02_euler_0-10", newVelocity, elapsedTime, newPosition);

                newPosition = oldPositon + oldVelocity * timeStep + 1 / 2 * oldAcceleration * (timeStep * timeStep);
                //New acceleration is constant.
                newVelocity = oldVelocity + (newAcceleration + oldAcceleration) * 0.5f * timeStep;

                oldAcceleration = newAcceleration;
                oldPositon = newPosition;
                oldVelocity = newVelocity;
            }

            Console.ReadLine();
            Console.Clear();
            //Resetting for air resistance
            elapsedTime = 0;
            timeStep = 0.1f;
            newVelocity = 49f;
            oldVelocity = newVelocity;
            newPosition = 2f;
            oldPositon = newPosition;
            newAcceleration = -9.8f + (0.1f * newVelocity);
            oldAcceleration = newAcceleration;


            while (elapsedTime < 10)
            {
                Console.WriteLine("Elapsed Time: " + elapsedTime + ", Position: " + newPosition + ", Velocity: " + newVelocity);
                WriteFile("ex02_euler_0-10", newVelocity, elapsedTime, newPosition);

                newPosition = oldPositon + oldVelocity * timeStep + 1 / 2 * oldAcceleration * (timeStep * timeStep);
                newAcceleration = -9.8f + (0.1f * newVelocity);
                newVelocity = oldVelocity + (newAcceleration + oldAcceleration) * 0.5f * timeStep;

                oldAcceleration = newAcceleration;
                oldPositon = newPosition;
                oldVelocity = newVelocity;

            }
        }

        private static void WriteFile(string filename, float velocity, float time, float height)
        {
            //WARNING: CHANGE OUTPUT FOLDER TO SOMEWHERE ELSE
            using (StreamWriter stream = new StreamWriter("C:\\Users\\bowen\\Desktop\\TestFolder\\" + filename + ".csv", true))
            {
                string output = time.ToString() + "," + velocity.ToString() + "," + height.ToString();
                stream.WriteLine(output);
            }
        }
    }
}
