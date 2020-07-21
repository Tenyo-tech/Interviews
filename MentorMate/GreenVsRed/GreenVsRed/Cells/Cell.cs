using GreenVsRed.Cells.Contracts;
using GreenVsRed.Comon;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenVsRed.Cells
{
    public class Cell : ICell , ICloneable
    {
        public Cell(CellColor color, Position position)
        {
            this.Color = color;
            this.Position = position;
        }

        public CellColor Color { get; private set; }

        public Position Position { get; private set; }

        public void ChangeColor(CellColor newColor)
        {
            this.Color = newColor;
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
