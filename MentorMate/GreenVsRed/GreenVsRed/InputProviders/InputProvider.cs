
namespace GreenVsRed.InputProviders
{
    using GreenVsRed.InputProviders.Contracts;

    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class InputProvider : IInputProvider
    {
        public int[] GetGridSize()
        {
            Console.Write("Enter the grid size in the following format: x, y: ");
            var input = Console.ReadLine().Split(", ").ToArray();

            int[] gridSize = new int[] { int.Parse(input[1]), int.Parse(input[0]) };

            return gridSize;
        }

        public char[,] GenerationZeroGrid(int rows, int cols)
        {
            Console.WriteLine("Enter Generation 0");

            char[,] grid = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    grid[row, col] = input[col];
                }
            }

            return grid;
        }

        public List<string> GetCoordinatesAndGenerations()
        {
            Console.WriteLine("Enter coordinates and number of Generations. ");

            char[] delimiterChars = { ' ', ',', '.' };
            List<string> cordinatesAndGenerations = new List<string>();

            foreach (var item in Console.ReadLine().Split(delimiterChars).ToList())
            {
                if (item != "")
                {
                    cordinatesAndGenerations.Add(item);
                }
            }

            return cordinatesAndGenerations;
        }


    }
}
