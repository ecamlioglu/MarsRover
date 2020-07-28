using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace MarsRover {
        public enum Directions {
            N = 0,
            S = 1,
            E = 2,
            W = 3
        }
        public interface IDirection {
            void Move(List<int> ranges, string direction);
        }
        public class Location : IDirection {
            public int xLoc { get; set; }
            public int yLoc { get; set; }
            public Directions directionRanger { get; set; }

            public Location()
            {
                xLoc = yLoc = 0;
                directionRanger = Directions.N;
            }
            /*          N
             *        W R E
             *          S
             */         
            private void TurnLeft()
            {
                switch (this.directionRanger)
                {
                    case Directions.N:
                        this.directionRanger = Directions.W;
                        break;
                    case Directions.S:
                        this.directionRanger = Directions.E;
                        break;
                    case Directions.E:
                        this.directionRanger = Directions.N;
                        break;
                    case Directions.W:
                        this.directionRanger = Directions.S;
                        break;
                    default:
                        break;
                }
            }
            private void TurnRight()
            {
                switch (this.directionRanger)
                {
                    case Directions.N:
                        this.directionRanger = Directions.E;
                        break;
                    case Directions.S:
                        this.directionRanger = Directions.W;
                        break;
                    case Directions.E:
                        this.directionRanger = Directions.S;
                        break;
                    case Directions.W:
                        this.directionRanger = Directions.N;
                        break;
                    default:
                        break;
                }
            }
            private void Forward()
            {
                switch (this.directionRanger)
                {
                    case Directions.N:
                        this.yLoc += 1;
                        break;
                    case Directions.S:
                        this.yLoc -= 1;
                        break;
                    case Directions.E:
                        this.xLoc += 1;
                        break;
                    case Directions.W:
                        this.xLoc -= 1;
                        break;
                    default:
                        break;
                }
            }
            public void Move(List<int> Ranges, string move)
            {
                for (int i = 0; i < move.Length; i++)
                {
                    switch (move[i])
                    {
                        case 'M':
                            this.Forward();
                            break;
                        case 'R':
                            this.TurnRight();
                            break;
                        case 'L':
                            this.TurnLeft();
                            break;
                        default:
                            break;
                    }
                    if (this.xLoc < 0 || this.yLoc < 0 || this.yLoc > Ranges[1] || this.xLoc > Ranges[0])
                        Console.WriteLine("ERROR!! LOCATION FAULT .. by Location.cs");
                }
            }
        }
    
}
