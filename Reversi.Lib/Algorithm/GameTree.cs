using System;
using System.Collections.Generic;
using System.Linq;
using Reversi.Lib.Enums;

namespace Reversi.Lib.Algorithm
{
    internal sealed class GameTree<T> where T : GameState
    {
        public T GetTheBest(T state, int depth, bool maximize)
        {
            List<GameState> children = state.GenerateChildren();
            if (children.Count < 1)
            {
                return default;
            }

            T bestState = default;
            foreach (T child in children)
            {
                int value = MiniMax(state, depth - 1, maximize);
                if (maximize && value > Calculate(child))
                {
                    bestState = child;
                }
            }

            return bestState;
        }

        private int MiniMax(T state, int depth, bool maximize, int alpha = int.MinValue, int beta = int.MaxValue)
        {
            List<GameState> children = state.GenerateChildren();
            if (depth == 0 || children.Count < 1)
            {
                return Calculate(state);
            }

            int value = maximize ? int.MinValue : int.MaxValue;
            foreach (T child in children)
            {
                int nextStateValue = MiniMax(child, depth - 1, !maximize, alpha, beta);
                if (maximize)
                {
                    value = Math.Max(value, nextStateValue);
                    alpha = Math.Max(alpha, nextStateValue);
                }
                else
                {
                    value = Math.Min(value, nextStateValue);
                    beta = Math.Min(beta, nextStateValue);
                }
            }

            return value;
        }

        private static int Calculate(T state)
        {
            int value = 0;
            foreach (Chip chip in state.Board)
            {
                if (chip != Chip.Black)
                {
                    continue;
                }

                value++;
            }

            return value;
        }
    }
}
