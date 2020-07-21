using GreenVsRed.Cells;
using GreenVsRed.Comon;
using GreenVsRed.Field.Contracts;
using GreenVsRed.InputProviders.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenVsRed.Engine.Initializations
{
    public class FieldInitialization : IFieldInitialization
    {
        public void Initialize(IField field, char[,] gridZero)
        {
            for (int row = 0; row < field.TotalRows; row++)
            {
                for (int col = 0; col < field.TotalCols; col++)
                {
                    if (gridZero[row,col] == '1')
                    {
                        Position position = new Position(row,col);
                        Cell cell = new Cell(CellColor.Green,position);
                        field.Add(cell);
                    }
                    else
                    {
                        Position position = new Position(row, col);
                        Cell cell = new Cell(CellColor.Red, position);
                        field.Add(cell);
                    }
                }
            }
        }

    }
}
