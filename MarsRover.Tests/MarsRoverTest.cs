using MarsRover.Lib;
using Xunit;

namespace MarsRover.Tests
{
    public class MarsRoverNavigatorShould
    {

        [InlineData("5 5\n0 0 N\nL", "0 0 W")]
        [InlineData("5 5\n0 0 N\nR", "0 0 E")]
        [InlineData("5 5\n0 0 W\nL", "0 0 S")]
        [InlineData("5 5\n0 0 W\nR", "0 0 N")]
        [InlineData("5 5\n0 0 S\nL", "0 0 E")]
        [InlineData("5 5\n0 0 S\nR", "0 0 W")]
        [InlineData("5 5\n0 0 E\nL", "0 0 N")]
        [InlineData("5 5\n0 0 E\nR", "0 0 S")]
        [InlineData("5 5\n1 1 N\nM", "1 2 N")]
        [InlineData("5 5\n1 1 W\nM", "0 1 W")]
        [InlineData("5 5\n1 1 S\nM", "1 0 S")]
        [InlineData("5 5\n1 1 E\nM", "2 1 E")]
        [Theory]
        public void UpdateDirectionWhenPassSpinDirections(string input, string expectedDirection)
        {
            var marsRover = new MarsRover.Lib.MarsRover(input);
            marsRover.Initialize();
            marsRover.Explore();

            var actualResult = marsRover.FinalPosition;

            Assert.Equal(actualResult, expectedDirection);
        }

        [InlineData("5 5\n0 0 N\nM", "0 1 N")]
        [InlineData("5 5\n1 1 N\nMLMR", "0 2 N")]
        [InlineData("5 5\n1 1 W\nMLMLMLM", "1 1 N")]
        [InlineData("5 5\n0 0 N\nMMMMM", "0 5 N")]
        [InlineData("5 5\n0 0 E\nMMMMM", "5 0 E")]
        [InlineData("5 5\n0 0 N\nRMLMRMLMRMLMRMLM", "4 4 N")]
        [Theory]
        public void UpdatePositionWhenPassCorrectInput(string input, string expectedPosition)
        {
            var marsRover = new MarsRover.Lib.MarsRover(input);
            marsRover.Initialize();
            marsRover.Explore();

            var actualResult = marsRover.FinalPosition;

            Assert.Equal(actualResult, expectedPosition);
        }

        [InlineData("1 1\n0 0 N\nMM")]
        [InlineData("1 1\n0 0 E\nMM")]
        [Theory]
        public void ReturnExceptionWhenCommandSendsRoverOutOfPlateau(string input)
        {
            var marsRover = new MarsRover.Lib.MarsRover(input);
            marsRover.Initialize();

            Assert.Throws<InvalidCommandException>(() => marsRover.Initialize());
        }
    }

    public class MarsRoverShould
    {
        [InlineData("5 5\n0 0 N\nM", 5, 5, 0, 0, "N", "M")]
        [InlineData("10 10\n5 9 E\nLMLMLM", 10, 10, 5, 9, "E", "LMLMLM")]
        [Theory]
        public void ParseAnInputCorrectly(string input, int expectedXPlateauDimension, int expectedYPlateauDimension,
                            int expectedXStartPosition, int expectedYStartPosition, string expectedDirection, string expectedCommand)
        {
            var expectedPlateausDimensions = new Coordinates() { X = expectedXPlateauDimension, Y = expectedYPlateauDimension };
            var expectedStartingPosition = new Coordinates() { X = expectedXStartPosition, Y = expectedYStartPosition };

            var expectedExplorerParameters = new ExplorerParameters(expectedDirection, expectedPlateausDimensions,
                                                        expectedStartingPosition, expectedCommand);

            var marsRover = new MarsRover.Lib.MarsRover(input);
            marsRover.Initialize();
            var actualResult = marsRover._explorerParameters;

            Assert.Equal(actualResult, expectedExplorerParameters);
        }

        [InlineData("10 10 5\n1 9 E\nLMLMLM")]
        [InlineData("10\n5 9 E\nLMLMLM")]
        [InlineData("10 A\n5 9 E\nLMLMLM")]
        [Theory]
        public void ReturnExceptionWhenWrongPlateauDimensionsInput(string input)
        {
            var marsRover = new MarsRover.Lib.MarsRover(input);

            Assert.Throws<IncorrectPlateauDimensionsException>(() => marsRover.Initialize());
        }

        [InlineData("1 1\n1 1\nLMLMLM")]
        [InlineData("1 1\n1 N\nLMLMLM")]
        [InlineData("1 1\n1\nLMLMLM")]
        [InlineData("5 5\n5 A N\nLMLMLM")]
        [InlineData("5 5\n5 1 A\nLMLMLM")]
        [InlineData("1 1\n5 1 N\nLMLMLM")]
        [Theory]
        public void ReturnExceptionWhenWrongStartPositionInput(string input)
        {
            var marsRover = new MarsRover.Lib.MarsRover(input);

            Assert.Throws<IncorrectStartPositionException>(() => marsRover.Initialize());
        }

        [InlineData("10 10; 5 9; LMLMLM")]
        [InlineData("10 10\nLMLMLM")]
        [Theory]
        public void ReturnExceptionWhenWrongInputFormat(string input)
        {
            var marsRover = new MarsRover.Lib.MarsRover(input);

            Assert.Throws<IncorrectInputFormatException>(() => marsRover.Initialize());
        }
    }
}

