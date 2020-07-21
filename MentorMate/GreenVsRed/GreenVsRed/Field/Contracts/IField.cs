namespace GreenVsRed.Field.Contracts
{
    using GreenVsRed.Comon;
    using GreenVsRed.Cells.Contracts;
    using System.Collections.Generic;
    using GreenVsRed.Cells;

    public interface IField
    {
        int TotalRows { get; }

        int TotalCols { get; }

        IReadOnlyList<ICell> Cells { get; }

        void Add(ICell cell);

    }
}
