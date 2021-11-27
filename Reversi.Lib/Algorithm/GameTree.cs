using Reversi.Lib.Enums;
using System;
using System.Collections.Generic;

namespace Reversi.Lib.Algorithm
{
    internal sealed class GameTree<T> where T : GameState
    {
        public T GetTheBest(T state, int depth)
        {
            int value = MiniMax(state, depth, true);
            return default;
        }

        private int MiniMax(T state, int depth, bool maximize, int alpha = Int32.MinValue, int beta = Int32.MaxValue)
        {
            List<T> childs = GenerateChilds(state);
            if (depth == 0 || childs.Count < 1)
            {
                return Calculate(state);
            }

            int value = maximize ? int.MinValue : int.MaxValue;
            foreach (T child in childs)
            {
                int nextStateValue = MiniMax(child, depth - 1, !maximize, alpha, beta);
                if (maximize)
                {
                    if (nextStateValue > alpha)
                    {
                        value = alpha = nextStateValue;
                    }
                }
                else
                {
                    if (nextStateValue < beta)
                    {
                        value = beta = nextStateValue;
                    }
                }
            }

            return value;
        }

        private int Calculate(T state)
        {
            return default;
        }

        private static List<T> GenerateChilds(T parent, Chip chip = Chip.White)
        {
            List<T> childs = new ();
            for (int i = 0; i < parent.Board.GetLength(0); i++)
            {
                for (int j = 0; j < parent.Board.GetLength(1); j++)
                {
                    if (parent.Board[i, j] != chip)
                    {
                        continue;
                    }


                }
            }

            return childs;
        }
    }
}
