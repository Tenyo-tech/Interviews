using GreenVsRed.Comon;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenVsRed.Cells.Contracts
{
    public interface ICell
    {
        CellColor Color { get; }

        Position Position { get; }

        void ChangeColor(CellColor newColor);
    }
}
