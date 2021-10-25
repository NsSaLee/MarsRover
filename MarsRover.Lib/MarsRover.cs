using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Lib
{
    public class MarsRover
    {
        private readonly string input;
        private MarsRoverExplorer marsRoverExplorer;

        public MarsRover(string input)
        {
            this.input = input;
        }

        public ExplorerParameters _explorerParameters { get; private set; }
        public string FinalPosition { get; private set; }

        public void Initialize()
        {
            _explorerParameters = Validator.GetNaviagtionParametersFromInput(input);
        }

        public void Explore()
        {
            marsRoverExplorer = new MarsRoverExplorer(_explorerParameters);
            FinalPosition = marsRoverExplorer.Explore();
        }
    }
}
