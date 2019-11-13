using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MPG_Labs
{
    class Lab_02
    {

        /*  Author: Bowen Chapel
            Version: 1.2
            Date: 9/16/2019
            Summary: Lab for simulating motion of a projectile to compare and contrast different integration methods and timesteps for said methods.
            ChangeNotes: Fixed a couple typos with comments and added more commenting.

        */

        public Lab_02()
        {
            float elapsedTime = 0;                  //seconds
            float timeStep = 0.1f;                  //seconds
            float newVelocity = 49f;                //meters per second     
            float oldVelocity = newVelocity;        //meters per second
            float newPosition = 2f;                 //meters
            float oldPositon = newPosition;         //meters
            float newAcceleration = -9.8f;          //meters per second
            float oldAcceleration = newAcceleration;//meters per second

            //Forward Euler with TimeStamp of 0.1 seconds
            while (elapsedTime < 10)        //While elapsed time is less than 10 seconds
            {
                Console.WriteLine("Elapsed Time: " + elapsedTime + ", Position: " + newPosition + ", Velocity: " + newVelocity);    //Output velocity, time, location data to screen
                WriteFile("ex02_euler_0-10", newVelocity, elapsedTime, newPosition);        //Output velocity, time, and location data to file.

                newPosition = oldPositon + newVelocity * timeStep;                     //Update position based off of old position, velocity, and time change
                newVelocity = oldVelocity + newAcceleration * timeStep;                //Update velocity based off of ol velocity, new acceleration, and time change

                //Housekeeping
                elapsedTime += timeStep;                                               //Update the elapsed time based off current time change
                oldPositon = newPosition;                                              //Update old position to new position to start over
                oldVelocity = newVelocity;                                              //update old velocity to new velocity to start over
            }

            Console.ReadLine();                                                         //Let user observe data and press button when ready to continue
            Console.Clear();                                                            //Let user clear data when they want to

            // Forward Euler with Time Stamp of 1 second.
            //reset variables.
            elapsedTime = 0;                        //seconds
            timeStep = 1f;                          //seconds
            newVelocity = 49f;                      //meters per second
            oldVelocity = newVelocity;              //meters per second
            newPosition = 2f;                       //meters
            oldPositon = newPosition;               //meters
            newAcceleration = -9.8f;
            oldAcceleration = newAcceleration;

            while (elapsedTime < 10)            //While elapsed time is less than 10 seconds
            {
                Console.WriteLine("Elapsed Time: " + elapsedTime + ", Position: " + newPosition + ", Velocity: " + newVelocity);
                WriteFile("ex02_euler_1-0", newVelocity, elapsedTime, newPosition);

                newPosition = oldPositon + newVelocity * timeStep;
                newVelocity = oldVelocity + newAcceleration * timeStep;

                //Housekeeping
                elapsedTime += timeStep;
                oldPositon = newPosition;
                oldVelocity = newVelocity;
            }

            Console.ReadLine();
            Console.Clear();

            //Forward Euler with TimeStamp of 0.01 seconds.
            //reset variables.
            elapsedTime = 0;
            timeStep = 0.01f; //seconds
            newVelocity = 49f; //meters per second
            oldVelocity = newVelocity; //meters per second
            newPosition = 2f;       //meters
            oldPositon = newPosition;      //meters
            newAcceleration = -9.8f;        //meters per second squared
            oldAcceleration = newAcceleration;  //meters per second squared

            while (elapsedTime < 10)  //While elapsed time is less than 10 seconds
            {
                Console.WriteLine("Elapsed Time: " + elapsedTime + ", Position: " + newPosition + ", Velocity: " + newVelocity);
                WriteFile("ex02_euler_0-01", newVelocity, elapsedTime, newPosition);

                newPosition = oldPositon + newVelocity * timeStep;
                newVelocity = oldVelocity + newAcceleration * timeStep;

                //Housekeeping
                elapsedTime += timeStep;
                oldPositon = newPosition;
                oldVelocity = newVelocity;
            }

            Console.ReadLine();
            Console.Clear();

            //Velocity Verlet - no air resistance

            //reset variables.
            elapsedTime = 0;                    //seconds
            timeStep = 0.1f;                    //seconds
            newVelocity = 49f;                  //meters per second
            oldVelocity = newVelocity;          //meters per second
            newPosition = 2f;                   //meters
            oldPositon = newPosition;           //meters
            newAcceleration = -9.8f;            //meters per second squared
            oldAcceleration = newAcceleration;  //meters per second squared

            while (elapsedTime < 10)  //While elapsed time is less than 10 seconds
            {
                Console.WriteLine("Elapsed Time: " + elapsedTime + ", Position: " + newPosition + ", Velocity: " + newVelocity);
                WriteFile("ex02_verlet", newVelocity, elapsedTime, newPosition);

                newPosition = oldPositon + oldVelocity * timeStep + 1 / 2 * oldAcceleration * (timeStep * timeStep);
                //New acceleration is constant so it is not calculated
                newVelocity = oldVelocity + (newAcceleration + oldAcceleration) * 0.5f * timeStep;

                //housekeeping
                elapsedTime += timeStep;
                oldAcceleration = newAcceleration;
                oldPositon = newPosition;
                oldVelocity = newVelocity;
            }

            Console.ReadLine();
            Console.Clear();

            //Resetting variables for air resistance
            elapsedTime = 0;                                //seconds
            timeStep = 0.1f;                                //seconds
            newVelocity = 49f;                              //meters per second
            oldVelocity = newVelocity;                      //meters per second
            newPosition = 2f;                               //meters
            oldPositon = newPosition;                       //meters
            newAcceleration = -9.8f + (0.1f * newVelocity); //meters per second squared.  Note acceleration now accounts for air resistance.
            oldAcceleration = newAcceleration;              //meters per second squared


            while (elapsedTime < 10)  //While elapsed time is less than 10 seconds
            {
                Console.WriteLine("Elapsed Time: " + elapsedTime + ", Position: " + newPosition + ", Velocity: " + newVelocity);
                WriteFile("ex02_wind", newVelocity, elapsedTime, newPosition);

                newPosition = oldPositon + oldVelocity * timeStep + 1 / 2 * oldAcceleration * (timeStep * timeStep);
                newAcceleration = -9.8f - (0.1f * newVelocity);
                newVelocity = oldVelocity + (newAcceleration + oldAcceleration) * 0.5f * timeStep;

                //Housekeeping.
                elapsedTime += timeStep;            //Updating elapsedTime with change in time
                oldAcceleration = newAcceleration; //Updating old acceleration to new acceleration
                oldPositon = newPosition;           //updating old position to new position
                oldVelocity = newVelocity;          //updating old velocity to new velocity.

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
