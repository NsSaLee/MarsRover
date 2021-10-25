using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Lib
{
    [Serializable]
    public class InvalidCommandException : Exception
    {
        public InvalidCommandException()
        {
        }

        public InvalidCommandException(string? message) : base(message)
        {
            message = "Command is invalid: Rover is sent outside the Plateau";
        }

        public InvalidCommandException(string? message, Exception? innerException) : base(message, innerException)
        {
            message = "Command is invalid: Rover is sent outside the Plateau";
        }

        protected InvalidCommandException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class IncorrectInputFormatException : Exception
    {
        public IncorrectInputFormatException()
        {
        }

        public IncorrectInputFormatException(string? message) : base(message)
        {
            message = "Error occured while splitting the input: format is incorrect";
        }

        public IncorrectInputFormatException(string? message, Exception? innerException) : base(message, innerException)
        {
            message = "Error occured while splitting the input: format is incorrect";
        }

        protected IncorrectInputFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class IncorrectPlateauDimensionsException : Exception
    {
        public IncorrectPlateauDimensionsException()
        {
        }

        public IncorrectPlateauDimensionsException(string? message) : base(message)
        {
            message = "Plateau dimensions should contain two int parameters: x and y";
        }

        public IncorrectPlateauDimensionsException(string? message, Exception? innerException) : base(message, innerException)
        {
            message = "Plateau dimensions should contain two int parameters: x and y";
        }

        protected IncorrectPlateauDimensionsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class IncorrectStartPositionException : Exception
    {
        public IncorrectStartPositionException()
        {
        }

        public IncorrectStartPositionException(string? message) : base(message)
        {
            message = "Start position and direction should contain three parameters: int x, int y and direction (N, S, W or E)";
        }

        public IncorrectStartPositionException(string? message, Exception? innerException) : base(message, innerException)
        {
            message = "Start position and direction should contain three parameters: int x, int y and direction (N, S, W or E)";
        }

        protected IncorrectStartPositionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
