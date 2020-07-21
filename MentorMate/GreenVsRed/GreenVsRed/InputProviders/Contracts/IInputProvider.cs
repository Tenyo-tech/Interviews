using System;
using System.Collections.Generic;
using System.Text;

namespace GreenVsRed.InputProviders.Contracts
{
    public interface IInputProvider
    {
        int[] GetGridSize();

        char[,] GenerationZeroGrid(int rows, int cols);

        List<string> GetCoordinatesAndGenerations();
    }
}
