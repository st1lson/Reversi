using System;
using System.Collections.Generic;
using System.Linq;
using Reversi.Lib.Enums;

namespace Reversi.Lib.Algorithm
{
    public class GameState
    {
        internal Chip[,] Board { get; set; }
        private readonly List<GameState> _children;

        public GameState(Chip[,] board)
        {
            Board = board;
            _children = new List<GameState>();
        }

        internal List<GameState> GenerateChildren(Chip chip = Chip.White)
        {
            _children.Clear();
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Board[i, j] != chip)
                    {
                        continue;
                    }

                    CheckNeighbors(Board, i, j);
                }
            }

            return _children;
        }

        private void CheckNeighbors(Chip[,] board, int positionI, int positionJ)
        {
            Neighbor(board, positionI, positionJ, Move.Up);
            Neighbor(board, positionI, positionJ, Move.Down);
            Neighbor(board, positionI, positionJ, Move.Right);
            Neighbor(board, positionI, positionJ, Move.Left);
            Neighbor(board, positionI, positionJ, Move.UpRight);
            Neighbor(board, positionI, positionJ, Move.UpLeft);
            Neighbor(board, positionI, positionJ, Move.DownRight);
            Neighbor(board, positionI, positionJ, Move.DownLeft);
        }

        private void Neighbor(Chip[,] board, int positionI, int positionJ, Move move)
        {
            int neighborPositionI = positionI;
            int neighborPositionJ = positionJ;
            GetNeighborPosition(ref neighborPositionI, ref neighborPositionJ, move);
            Chip[,] nextState = new Chip[8, 8];
            Array.Copy(board, nextState, board.Length);

            while (neighborPositionI >= 0 && neighborPositionJ >= 0 && board[neighborPositionI, neighborPositionJ] != Chip.Black
                   && board[neighborPositionI, neighborPositionJ] != Chip.Empty)
            {
                nextState[neighborPositionI, neighborPositionJ] = Chip.Black;
                GetNeighborPosition(ref neighborPositionI, ref neighborPositionJ, move);
            }

            if (neighborPositionI == -1 || neighborPositionJ == -1 ||
                board[neighborPositionI, neighborPositionJ] == Chip.Black)
            {
                return;
            }

            if (_children.Count(p => p.Board == nextState) > 0)
            {
                return;
            };

            _children.Add(new GameState(nextState));
        }

        private static void GetNeighborPosition(ref int neighborPositionI, ref int neighborPositionJ, Move move)
        {
            switch (move)
            {
                case Move.Up:
                    neighborPositionI -= 1;
                    return;
                case Move.Down:
                    neighborPositionI += 1;
                    return;
                case Move.Right:
                    neighborPositionJ += 1;
                    return;
                case Move.Left:
                    neighborPositionJ -= 1;
                    return;
                case Move.UpRight:
                    neighborPositionI -= 1;
                    neighborPositionJ += 1;
                    return;
                case Move.UpLeft:
                    neighborPositionI -= 1;
                    neighborPositionJ -= 1;
                    return;
                case Move.DownRight:
                    neighborPositionI += 1;
                    neighborPositionJ += 1;
                    return;
                case Move.DownLeft:
                    neighborPositionI += 1;
                    neighborPositionJ -= 1;
                    return;
                default:
                    return;
            }
        }
    }
}
