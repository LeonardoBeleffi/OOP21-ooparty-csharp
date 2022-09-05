using iTextSharp.awt.geom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace OOP_csharp
{
    class SimpleGameBoardFactory : AbstractFixedSizeGameBoardFactory
    {
        private readonly Random _rand = new Random();

        public override IList<IGameMapSquare> CreateGameBoard()
        {
            IList<IGameMapSquare> _board = new List<IGameMapSquare>();
            _board.Add(new GameMapSquareImpl());

            while (_board.Count < base.Size)
            {
                IGameMapSquare _square = GetRandomSquare();
                if (SquareCanBeAdded(_board, _square))
                {
                    _board.Add(_square);
                } else if (BoardIsFullOfSpecialSquares(_board))
                {
                    _board.Concat(Enumerable.Repeat(new GameMapSquareImpl(), base.Size - _board.Count()).ToList());
                }
            }

            do
            {
                _board.OrderBy(e => new Random().Next());
            } while (!CompareSquare(_board[0], new GameMapSquareImpl()));
            return _board;
        }

        private bool BoardIsFullOfSpecialSquares(IList<IGameMapSquare> board)
        {
            return _s_squareTypeMaxOccurrences
                .Where(st => SquareCanBeAdded(board, (IGameMapSquare)Activator.CreateInstance(st.Item2)))
                .Any();
            
        }

        private bool SquareCanBeAdded(in IList<IGameMapSquare> board, in IGameMapSquare square)
        {
            Type _squareType = square.GetType();
            IGameMapSquare _squareTypeInstance;

            _squareTypeInstance = (IGameMapSquare) Activator.CreateInstance(_squareType);
            var _elementsCount = board
                .Where(s => CompareSquare(s, _squareTypeInstance))
                .LongCount();

            var _maxOcc = _s_squareTypeMaxOccurrences
            .Where(e => e.Item2.Equals(_squareType))
            .First()
            .Item3;
            
            

            if (CompareSquare(square, _squareTypeInstance) && _elementsCount >= _maxOcc)
            {
                return false;
            }

            return true;
        }

        private bool CompareSquare(in IGameMapSquare s1, in IGameMapSquare s2)
        {
            return s1.GetType().Equals(s2.GetType());
        }

        private IGameMapSquare GetRandomSquare()
        {
            Array _squares = Enum.GetValues(typeof(SquareType));
            SquareType _randSquareType = (SquareType) _squares.GetValue(_rand.Next(_squares.Length));
            IGameMapSquare _square;
            
            switch (_randSquareType)
            {
                case SquareType.COIN:
                    _square = new CoinsGameMapSquare();
                    break;
                case SquareType.POWERUP:
                    _square = new PowerUpGameMapSquare();
                    break;
                case SquareType.DAMAGE:
                    _square = new DamageGameMapSquare();
                    break;
                case SquareType.STAR:
                    _square = new StarGameMapSquare();
                    break;
                default:
                    _square = new GameMapSquareImpl();
                    break;
            }

            return _square;
        }

        private static readonly List<Tuple<SquareType, Type, int>> _s_squareTypeMaxOccurrences = new List<Tuple<SquareType, Type, int>>{
            Tuple.Create(SquareType.DEFAULT, typeof(GameMapSquareImpl), 100),
            Tuple.Create(SquareType.COIN, typeof(CoinsGameMapSquare), 4),
            Tuple.Create(SquareType.POWERUP, typeof(PowerUpGameMapSquare), 4),
            Tuple.Create(SquareType.DAMAGE, typeof(DamageGameMapSquare), 4),
            Tuple.Create(SquareType.STAR, typeof(StarGameMapSquare), 1)
        };

        public static List<Tuple<SquareType, Type, int>> GetSquareTypeMaxOccurrences()
        {
            return _s_squareTypeMaxOccurrences;
        }

    }
}
