using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Lib
{
    public class Validator
    {
        private static Coordinates plateauDimenstions;
        private static Coordinates currentCoordinates;
        private static string currentDirection;
        private static string command;

        private static string[] inputByLines;

        private const int expectedNumberOfInputLines = 3;
        private const int expectedLineWithPlateauDimension = 0;
        private const int expectedLineWithStartPosition = 1;
        private const int expectedLineWithCommand = 2;

        private const char linesDelimeter = '\n';
        private const char parametersDelimeter = ' ';

        private static readonly List<string> allowedDirections = new List<string> { "N", "W", "E", "S" };

        public static ExplorerParameters GetNaviagtionParametersFromInput(string input)
        {
            SplitInputByLines(input);
            SetPlateauDimensions(inputByLines);
            SetStartPositionAndDirection(inputByLines);
            SetCommand();

            return new ExplorerParameters(currentDirection, plateauDimenstions, currentCoordinates, command);
        }

        private static void SplitInputByLines(string input)
        {
            var splitString = input.Split(linesDelimeter);

            if (splitString.Length != expectedNumberOfInputLines)
            {
                throw new IncorrectInputFormatException();
            }

            inputByLines = splitString;
        }

        private static void SetPlateauDimensions(string[] inputLines)
        {
            var stringPlateauDimenstions = inputLines[expectedLineWithPlateauDimension].Split(parametersDelimeter);

            if (PlateauDimensionsAreInvalid(stringPlateauDimenstions))
            {
                throw new IncorrectPlateauDimensionsException();
            }

            plateauDimenstions = new Coordinates
            {
                X = Int32.Parse(stringPlateauDimenstions[0]),
                Y = Int32.Parse(stringPlateauDimenstions[1])
            };
        }

        private static void SetStartPositionAndDirection(string[] inputByLines)
        {
            var stringCurrentPositionAndDirection = inputByLines[expectedLineWithStartPosition].Split(parametersDelimeter);

            if (StartPositionIsInvalid(stringCurrentPositionAndDirection))
            {
                throw new IncorrectStartPositionException();
            }

            currentCoordinates = new Coordinates
            {
                X = Int32.Parse(stringCurrentPositionAndDirection[0]),
                Y = Int32.Parse(stringCurrentPositionAndDirection[1])
            };

            currentDirection = stringCurrentPositionAndDirection[2];
        }

        private static void SetCommand()
        {
            command = inputByLines[expectedLineWithCommand];
        }

        private static bool StartPositionIsInvalid(string[] stringCurrentPositionAndDirection)
        {
            if (stringCurrentPositionAndDirection.Length != 3 || !stringCurrentPositionAndDirection[0].All(char.IsDigit)
               || !stringCurrentPositionAndDirection[1].All(char.IsDigit) || !allowedDirections.Any(stringCurrentPositionAndDirection[2].Contains))
            {
                return true;
            }

            if (Int32.Parse(stringCurrentPositionAndDirection[0]) > plateauDimenstions.X ||
                Int32.Parse(stringCurrentPositionAndDirection[1]) > plateauDimenstions.Y)
            {
                return true;
            }

            return false;
        }

        private static bool PlateauDimensionsAreInvalid(string[] stringPlateauDimenstions)
        {
            if (stringPlateauDimenstions.Length != 2 || !stringPlateauDimenstions[0].All(char.IsDigit)
               || !stringPlateauDimenstions[1].All(char.IsDigit))
            {
                return true;
            }

            return false;
        }
    }
}
