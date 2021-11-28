using Reversi.Lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reversi.Lib.Algorithm
{
    internal sealed class GameTree<T> where T : GameState
    {
        public T GetTheBest(T state, int depth, bool maximize)
        {
            Dictionary<int, GameState> children = state.GenerateChildren();
            if (children.Count == 0)
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
            if (depth <= 0 || children.Count < 1)
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

                if (beta <= alpha)
                {
                    break;
                }
            }

            return value;
        }

        private static int Calculate(T state)
        {
            int blackScore = state.GetScore(Chip.Black);
            int whiteScore = state.GetScore(Chip.White);
            if (blackScore == 0)
            {
                return int.MinValue;
            }
            else if (whiteScore == 0)
            {
                return int.MaxValue;
            }

            if (blackScore + whiteScore == 64)
            {
                if (blackScore < whiteScore)
                {
                    return int.MinValue;
                }
                else if (blackScore > whiteScore)
                {
                    return int.MaxValue;
                }
                else
                {
                    return 0;
                }
            }

            return blackScore - whiteScore;
        }
    }
}
