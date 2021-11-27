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

            T bestState = null;
            foreach (T child in children)
            {
                int value = MiniMax(state, depth, maximize);
                if (maximize && value > Calculate(child, maximize))
                {
                    bestState = child;
                }

                if (!maximize && value < Calculate(child, maximize))
                {
                    bestState = child;
                }

                maximize = !maximize;
            }

            return bestState;
        }

        private int MiniMax(T state, int depth, bool maximize, int alpha = int.MinValue, int beta = int.MaxValue)
        {
            List<GameState> children = state.GenerateChildren();
            if (depth == 0 || children.Count < 1)
            {
                return Calculate(state, maximize);
            }

            int value = maximize ? int.MinValue : int.MaxValue;
            foreach (T child in children)
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

        private static int Calculate(T state, bool maximize)
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
