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
            Dictionary<int, GameState> children = state.GenerateChildren();
            if (children.Count < 1)
            {
                return default;
            }

            int key = children.Keys.First();
            T bestState = (T)children[key];
            foreach (T child in children.Values)
            {
                int value = MiniMax(state, depth - 1, !maximize);
                if (maximize && value > Calculate(child))
                {
                    bestState = child;
                }

                if (!maximize && value < Calculate(child))
                {
                    bestState = child;
                }
            }

            return bestState;
        }

        private int MiniMax(T state, int depth, bool maximize, int alpha = int.MinValue, int beta = int.MaxValue, Chip player = Chip.Black)
        {
            Dictionary<int, GameState> children = state.GenerateChildren(player);
            if (depth == 0 || children.Count < 1)
            {
                return Calculate(state);
            }

            Chip nextPlayer = player == Chip.Black ? Chip.White : Chip.Black;
            int value = maximize ? int.MinValue : int.MaxValue;
            foreach (T child in children.Values)
            {
                int nextStateValue = MiniMax(child, depth - 1, !maximize, alpha, beta, nextPlayer);
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
            int a = 0;
            int b = 0;
            foreach (Chip chip in state.Board)
            {
                if (chip != Chip.Black)
                {
                    b++;
                    continue;
                }

                a++;
            }

            return a - b;
        }
    }
}
