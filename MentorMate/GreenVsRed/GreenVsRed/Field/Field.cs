using GreenVsRed.Cells;
using GreenVsRed.Cells.Contracts;
using GreenVsRed.Field.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenVsRed.Field
{
    public class Field : IField
    {
        private readonly List<ICell> field;
        public Field(int rows, int cols)
        {
            this.field = new List<ICell>();
            this.TotalRows = rows;
            this.TotalCols = cols;
        }

        public Field(int rows, int cols,List<ICell> field)
            : this(rows,cols)
        {
            this.field = field;
        }

        public int TotalRows { get; private set; }

        public int TotalCols { get; private set; }

        public IReadOnlyList<ICell> Cells => this.field;

        public void Add(ICell cell)
        {
            this.field.Add(cell);
        }

    }
}
