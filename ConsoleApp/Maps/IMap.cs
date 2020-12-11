using System.Collections.Generic;

namespace ConsoleApp.Maps
{
    public interface IMap
    {
        public List<ICell> PossibleMoves();
    }
}