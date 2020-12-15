using System.Collections.Generic;
using System.ComponentModel;

namespace ConsoleApp.Maps
{
    public interface IMap
    {
        public Cell[,] Map { get; }
        Cell StartingCell { get; }
        Cell LastCell { get; }
        public List<GlobalDirection> PossibleMoves(ICell currentCell);
    }
}