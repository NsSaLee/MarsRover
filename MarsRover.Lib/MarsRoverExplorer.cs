using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Lib
{
    public class MarsRoverExplorer
    {
        private readonly ExplorerParameters explorerParameters;
        private SpinningControl spinningControl;
        private MovingControl movingControl;

        public MarsRoverExplorer(ExplorerParameters explorerParameters)
        {
            this.explorerParameters = explorerParameters;
            spinningControl = new SpinningControl();
            movingControl = new MovingControl();
        }

        public string Explore()
        {
            var command = explorerParameters.Command;

            foreach (var step in command)
            {
                DoAStep(step);
            }

            var result = $"{explorerParameters.CurrentCoordinates.X} {explorerParameters.CurrentCoordinates.Y} {explorerParameters.CurrentDirection}";

            return result;
        }

        private void DoAStep(char stepCommand)
        {
            var newDirection = spinningControl.GetNextDirection(explorerParameters.CurrentDirection, stepCommand);

            explorerParameters.UpdateCurrentDirection(newDirection);

            var newCoordinates = movingControl.Move(stepCommand, explorerParameters.CurrentDirection, explorerParameters.CurrentCoordinates);

            if (newCoordinates.X > explorerParameters.PlateauDimenstions.X || newCoordinates.Y > explorerParameters.PlateauDimenstions.Y)
            {
                throw new InvalidCommandException();
            }

            explorerParameters.UpdateCurrentCoordinates(newCoordinates);
        }
    }
}
