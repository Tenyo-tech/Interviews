namespace GreenVsRed.Engine
{
    using GreenVsRed.Engine.Contracts;
    using GreenVsRed.Engine.Initializations;
    using GreenVsRed.Field.Contracts;
    using GreenVsRed.Field;
    using GreenVsRed.InputProviders.Contracts;
    using GreenVsRed.Renders.Contracts;
    using System.Linq;
    using GreenVsRed.Comon;
    using System;
    using System.Runtime.CompilerServices;
    using System.Net;
    using GreenVsRed.Cells.Contracts;
    using System.Collections.Generic;

    public class GVREngine : IEngine
    {
        private readonly IRenderer renderer;
        private readonly IInputProvider inputProvider;

        private IField field;


        public GVREngine(IRenderer renderer, IInputProvider inputProvider)
        {
            this.renderer = renderer;
            this.inputProvider = inputProvider;
        }

        public void Initialize()
        {

        }

        public void Start(IFieldInitialization fieldInitialization)
        {
            var gridSize = this.inputProvider.GetGridSize();
            var rows = gridSize[1];
            var cols = gridSize[0];

            this.field = new Field(rows, cols);

            var gridZero = this.inputProvider.GenerationZeroGrid(rows, cols);

            var coordinatesAndGenerations = this.inputProvider.GetCoordinatesAndGenerations();

            int isnpectedRow = int.Parse(coordinatesAndGenerations[1]);
            int InspectedCol = int.Parse(coordinatesAndGenerations[0]);
            int generations = int.Parse(coordinatesAndGenerations[2]);


            fieldInitialization.Initialize(this.field, gridZero);

            int counter = 0;

            for (int generation = 0; generation <= generations; generation++)
            {
                

                var inspectedCell = this.field.Cells.FirstOrDefault(c => c.Position.Row == isnpectedRow && c.Position.Col == InspectedCol);


                if (inspectedCell.Color == CellColor.Green)
                {
                    counter++;
                }

                var currentGrid = this.renderer.RenderField(this.field, isnpectedRow, InspectedCol, generation,counter);


                IField newGenField = new Field(this.field.TotalRows,this.field.TotalCols);

                fieldInitialization.Initialize(newGenField, currentGrid);
                


                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        var currentCell = this.field.Cells.FirstOrDefault(c => c.Position.Row == row && c.Position.Col == col);

                        if (currentCell.Color == CellColor.Green)
                        {
                            int greenCounter = CheckGreenRedCells(this.field, row, col);

                            if (greenCounter == 2 || greenCounter == 3 || greenCounter == 6)
                            {
                                newGenField.Cells.FirstOrDefault(c => c.Position.Row == row && c.Position.Col == col).ChangeColor(CellColor.Green);
                            }
                            else
                            {
                                newGenField.Cells.FirstOrDefault(c => c.Position.Row == row && c.Position.Col == col).ChangeColor(CellColor.Red);
                            }
                        }
                        else
                        {
                            int greenCounter = CheckGreenRedCells(this.field, row, col);

                            if (greenCounter == 3 || greenCounter == 6)
                            {
                                newGenField.Cells.FirstOrDefault(c => c.Position.Row == row && c.Position.Col == col).ChangeColor(CellColor.Green);
                            }
                            else
                            {
                                newGenField.Cells.FirstOrDefault(c => c.Position.Row == row && c.Position.Col == col).ChangeColor(CellColor.Red);
                            }
                        }
                    }
                }

                

                this.field = newGenField;
            }
        }

        private static int CheckGreenRedCells(IField field, int row, int col)
        {
            int greenCounter = 0;

            if (IsInside(field, row - 1, col - 1))
            {
                switch (field.Cells.FirstOrDefault(c => c.Position.Row == row - 1 && c.Position.Col == col - 1).Color)
                {
                    case CellColor.Green:
                        greenCounter++;
                        break;
                }
            }
            if (IsInside(field, row, col - 1))
            {
                switch (field.Cells.FirstOrDefault(c => c.Position.Row == row && c.Position.Col == col - 1).Color)
                {
                    case CellColor.Green:
                        greenCounter++;
                        break;
                }
            }
            if (IsInside(field, row + 1, col - 1))
            {
                switch (field.Cells.FirstOrDefault(c => c.Position.Row == row + 1 && c.Position.Col == col - 1).Color)
                {
                    case CellColor.Green:
                        greenCounter++;
                        break;
                }
            }
            if (IsInside(field, row - 1, col))
            {
                switch (field.Cells.FirstOrDefault(c => c.Position.Row == row - 1 && c.Position.Col == col).Color)
                {
                    case CellColor.Green:
                        greenCounter++;
                        break;
                }
            }
            if (IsInside(field, row + 1, col))
            {
                switch (field.Cells.FirstOrDefault(c => c.Position.Row == row + 1 && c.Position.Col == col).Color)
                {
                    case CellColor.Green:
                        greenCounter++;
                        break;
                }
            }
            if (IsInside(field, row - 1, col + 1))
            {
                switch (field.Cells.FirstOrDefault(c => c.Position.Row == row - 1 && c.Position.Col == col + 1).Color)
                {
                    case CellColor.Green:
                        greenCounter++;
                        break;
                }
            }
            if (IsInside(field, row, col + 1))
            {
                switch (field.Cells.FirstOrDefault(c => c.Position.Row == row && c.Position.Col == col + 1).Color)
                {
                    case CellColor.Green:
                        greenCounter++;
                        break;
                }
            }
            if (IsInside(field, row + 1, col + 1))
            {
                switch (field.Cells.FirstOrDefault(c => c.Position.Row == row + 1 && c.Position.Col == col + 1).Color)
                {
                    case CellColor.Green:
                        greenCounter++;
                        break;
                }
            }

            return greenCounter;
        }

        private static bool IsInside(IField field, int row, int col)
        {
            return row < field.TotalRows && col < field.TotalCols
                && row >= 0 && col >= 0;
        }
    }
}
