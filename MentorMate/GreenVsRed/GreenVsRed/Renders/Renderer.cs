using GreenVsRed.Comon;
using GreenVsRed.Field.Contracts;
using GreenVsRed.Renders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreenVsRed.Renders
{
    public class Renderer : IRenderer
    {
        public char[,] RenderField(IField field,int inspectedRow,int inspectedCol, int generation,int counter)
        {
            string green = "Green";
            string red = "Red";
            Console.WriteLine();
            Console.WriteLine($"Generation {generation}");

            char[,] grid = new char[field.TotalRows, field.TotalCols];

            for (int row = 0; row < field.TotalRows; row++)
            {
                for (int col = 0; col < field.TotalCols; col++)
                {
                    var currentCell = field.Cells.FirstOrDefault(c => c.Position.Row == row && c.Position.Col == col);
                    if (currentCell.Color == CellColor.Green)
                    {
                        Console.Write($"1 ");
                        grid[row, col] = '1';
                    }
                    else
                    {
                        Console.Write($"0 ");
                        grid[row, col] = '0';
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Position row: {inspectedRow} column:{inspectedCol} is {field.Cells.FirstOrDefault(c=> c.Position.Row == inspectedRow && c.Position.Col == inspectedCol).Color}");
            Console.WriteLine($"Count: {counter}");


            return grid;
        }
    }
}
