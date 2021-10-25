using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Lib
{
    public class MovingControl
    {
        public Dictionary<string, Func<Coordinates, Coordinates>> MoveFunctions =
                           new Dictionary<string, Func<Coordinates, Coordinates>>
   {
        {"N", MoveNorth},
        {"W", MoveWest},
        {"S", MoveSouth},
        {"E", MoveEast}
   };

        public Coordinates Move(char command, string currentDirection, Coordinates currentCoordinates)
        {
            if (command == 'M')
            {
                return MoveFunctions[currentDirection](currentCoordinates);
            }

            return currentCoordinates;
        }

        private static Coordinates MoveEast(Coordinates coordinates)
        {
            return new Coordinates()
            {
                X = coordinates.X + 1,
                Y = coordinates.Y
            };
        }

        private static Coordinates MoveSouth(Coordinates coordinates)
        {
            return new Coordinates()
            {
                X = coordinates.X,
                Y = coordinates.Y - 1
            };
        }

        private static Coordinates MoveWest(Coordinates coordinates)
        {
            return new Coordinates()
            {
                X = coordinates.X - 1,
                Y = coordinates.Y
            };
        }

        private static Coordinates MoveNorth(Coordinates coordinates)
        {
            return new Coordinates()
            {
                X = coordinates.X,
                Y = coordinates.Y + 1
            };
        }
    }
}
