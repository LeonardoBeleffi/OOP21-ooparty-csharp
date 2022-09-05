using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_csharp
{
    interface IGameBoardFactory
    {
        int Size
        {
            get;
        }

        IList<IGameMapSquare> CreateGameBoard();
    }
}
