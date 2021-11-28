using System;
using System.Collections.Generic;
using System.Linq;
using Reversi.Lib.Enums;

namespace Reversi.Lib.Algorithm
{
    public class GameState
    {
        internal Chip[] Board { get; set; }
        private List<GameState> _children;

        public GameState(Chip[] board)
        {
            Board = board;
            _children = new List<GameState>();
        }

        internal List<GameState> GenerateChildren(Chip attacker = Chip.Black)
        {
            _children = new List<GameState>();
            for (int i = 0; i < Board.Length; i++)
            {
                if (Board[i] != attacker)
                {
                    continue;
                }

                CheckNeighbors(Board, i, attacker);
            }

            return _children;
        }

        private void CheckNeighbors(Chip[] board, int cellIndex, Chip attacker)
        {
            Neighbor(board, cellIndex, Move.Up, attacker);
            Neighbor(board, cellIndex, Move.Down, attacker);
            Neighbor(board, cellIndex, Move.Right, attacker);
            Neighbor(board, cellIndex, Move.Left, attacker);
            Neighbor(board, cellIndex, Move.UpLeft, attacker);
            Neighbor(board, cellIndex, Move.UpRight, attacker);
            Neighbor(board, cellIndex, Move.DownRight, attacker);
            Neighbor(board, cellIndex, Move.DownLeft, attacker);
        }

        private void Neighbor(Chip[] board, int cellIndex, Move move, Chip attacker)
        {
            Chip[] nextState = new Chip[64];
            int neighborIndex = GetNeighborPosition(cellIndex, move);
            nextState[neighborIndex] = Chip.Black;
            Array.Copy(board, nextState, board.Length);

            while (neighborIndex >= 0 && board[neighborIndex] != attacker && board[neighborIndex] != Chip.Empty)
            {
                nextState[neighborIndex] = Chip.Black;
                neighborIndex = GetNeighborPosition(neighborIndex, move);
            }

            if (neighborIndex == -1 || nextState[neighborIndex] == Chip.Black)
            {
                return;
            }

            if (_children.Count(p => p.Board == nextState) > 0)
            {
                return;
            };

            _children.Add(new GameState(nextState));
        }

        private static int GetNeighborPosition(int cellIndex, Move move)
        {
            switch (move)
            {
                case Move.Up:
                    return cellIndex >= 8 ? cellIndex - 8 : -1;
                case Move.Down:
                    return cellIndex + 8 < 64 ? cellIndex + 8 : -1;
                case Move.Right:
                    return Math.Floor((double)(cellIndex / 8)) == Math.Floor((double)(cellIndex + 1) / 8) ? cellIndex + 1 : -1;
                case Move.Left:
                    return Math.Floor((double)(cellIndex / 8)) == Math.Floor((double)(cellIndex - 1) / 8) ? cellIndex - 1 : -1;
                case Move.UpRight:
                    return GetNeighborPosition(GetNeighborPosition(cellIndex, Move.Right), Move.Up);
                case Move.UpLeft:
                    return GetNeighborPosition(GetNeighborPosition(cellIndex, Move.Left), Move.Up);
                case Move.DownRight:
                    return GetNeighborPosition(GetNeighborPosition(cellIndex, Move.Right), Move.Down);
                case Move.DownLeft:
                    return GetNeighborPosition(GetNeighborPosition(cellIndex, Move.Left), Move.Down);
                default:
                    return -1;
            }
        }
    }
}
