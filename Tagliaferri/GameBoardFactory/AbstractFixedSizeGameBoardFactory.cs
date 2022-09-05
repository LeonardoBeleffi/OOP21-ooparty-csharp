using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_csharp
{
    abstract class AbstractFixedSizeGameBoardFactory : IGameBoardFactory
    {
        public int Size
        {
            get { return _s_size; }
        }

        public abstract IList<IGameMapSquare> CreateGameBoard();

        private static readonly int _s_size = 34;
    }
}
