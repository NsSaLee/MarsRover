using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Lib
{
    public class ExplorerParameters
    {
        public string CurrentDirection { get; private set; }
        public string Command { get; }
        public Coordinates PlateauDimenstions { get; }
        public Coordinates CurrentCoordinates { get; private set; }

        public ExplorerParameters(string currentDirection, Coordinates plateauDimenstions, Coordinates currentCoordinates, string command)
        {
            CurrentDirection = currentDirection;
            PlateauDimenstions = plateauDimenstions;
            CurrentCoordinates = currentCoordinates;
            Command = command;
        }

        public void UpdateCurrentDirection(string newDirection)
        {
            CurrentDirection = newDirection;
        }

        internal void UpdateCurrentCoordinates(Coordinates newCoordinates)
        {
            CurrentCoordinates = newCoordinates;
        }
    }
}
