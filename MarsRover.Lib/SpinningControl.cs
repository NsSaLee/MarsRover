using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Lib
{
    public class SpinningControl
    {
        static readonly LinkedList<string> directions =
                    new LinkedList<string>(new[] { "N", "W", "S", "E" });

        public readonly Dictionary<char, Func<string, string>> SpinningFunctions =
                                new Dictionary<char, Func<string, string>>
        {
        {'L', TurnLeft},
        {'R', TurnRight},
        {'M', Stay }
        };

        public string GetNextDirection(string currentDirection, char stepCommand)
        {
            return SpinningFunctions[stepCommand](currentDirection);
        }

        private static string TurnRight(string currentDirection)
        {
            LinkedListNode<string> currentIndex = directions.Find(currentDirection);
            return currentIndex.PreviousOrLast().Value;
        }

        private static string TurnLeft(string currentDirection)
        {
            LinkedListNode<string> currentIndex = directions.Find(currentDirection);
            return currentIndex.NextOrFirst().Value;
        }

        private static string Stay(string currentDirection)
        {
            return currentDirection;
        }
    }

    public static class CircularLinkedList
    {
        public static LinkedListNode<T> NextOrFirst<T>(this LinkedListNode<T> current)
        {
            return current.Next ?? current.List.First;
        }

        public static LinkedListNode<T> PreviousOrLast<T>(this LinkedListNode<T> current)
        {
            return current.Previous ?? current.List.Last;
        }
    }
}
