using System.Collections.Generic;
using System.ComponentModel;

namespace ConsoleApp.Maps
{
    public interface IMap
    {
        public Cell[,] Map { get; }
        ICell StartingCell { get; }
        ICell LastCell { get; }
        public List<ICell> PossibleMoves(ICell currentCell);
    }
}