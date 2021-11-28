using System;
using System.Collections.Generic;
using System.Linq;
using Reversi.Lib.Enums;

namespace Reversi.Lib.Algorithm
{
    public class GameState
    {
        internal Chip[] Board { get; set; }
        private Dictionary<int, GameState> _children;

        public GameState(Chip[] board)
        {
            Board = board;
            _children = new Dictionary<int, GameState>();
        }

        internal Dictionary<int, GameState> GenerateChildren(Chip attacker = Chip.Black)
        {
            _children = new Dictionary<int, GameState>();
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
            if (neighborIndex >= 64)
            {
                return;
            }

            Array.Copy(board, nextState, board.Length);
            while (neighborIndex >= 0 && board[neighborIndex] != attacker && board[neighborIndex] != Chip.Empty)
            {
                nextState[neighborIndex] = attacker;
                neighborIndex = GetNeighborPosition(neighborIndex, move);
            }

            if (neighborIndex == -1 || board[neighborIndex] == attacker || board.SequenceEqual(nextState))
            {
                return;
            }

            nextState[neighborIndex] = attacker;
            if (_children.ContainsKey(neighborIndex))
            {
                _children[neighborIndex].Board = Union(_children[neighborIndex].Board, nextState);
            }
            else
            {
                _children.Add(neighborIndex, new GameState(nextState));
            }
        }

        private static Chip[] Union(Chip[] a, Chip[] b)
        {
            Chip[] board = new Chip[64];
            for (int i = 0; i < board.Length; i++)
            {
                if (a[i] != b[i])
                {
                    board[i] = b[i];
                    continue;
                }

                board[i] = a[i];
            }

            return board;
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
