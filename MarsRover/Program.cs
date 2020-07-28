using System;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace MarsRover {
    class Program {
        static void Main(string[] args)
        {
            bool roverDone = false;
            int roverCount = 1;
            var maxCoordinate = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            while (!roverDone)
            {
                Console.WriteLine(roverCount + ". rover");
                var startPos = Console.ReadLine().Trim().Split(' ');
                Location location = new Location();


                if (startPos.Count() == 3)
                {
                    location.xLoc = Convert.ToInt32(startPos[0]);
                    location.yLoc = Convert.ToInt32(startPos[1]);
                    location.directionRanger = (Directions)Enum.Parse(typeof(Directions), startPos[2]);
                }
            
                var move = Console.ReadLine().ToUpper();
                try
                {
                    location.Move(maxCoordinate, move);
                    Console.WriteLine($"{location.xLoc} {location.yLoc} {location.directionRanger.ToString()}");
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                    throw;
                }
                Console.WriteLine("U want to enter another rover in this plateau? (yes or no)");
                if(Console.ReadLine() == "yes")
                {
                    roverDone = false;
                    roverCount += 1;
                }
                else
                {
                    roverDone = true;
                    System.Environment.Exit(-1);
                }

            }
            
        }
    }
}
