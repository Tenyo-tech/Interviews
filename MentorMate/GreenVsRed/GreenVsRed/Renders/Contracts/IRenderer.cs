using GreenVsRed.Field.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenVsRed.Renders.Contracts
{
    public interface IRenderer
    {
         char[,] RenderField(IField field, int inspectedRow, int inspectedCol, int generation, int counter);

    }
}
