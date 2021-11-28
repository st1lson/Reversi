using Reversi.Lib.Enums;
using System.Linq;

namespace Reversi.Lib.Algorithm
{
    public sealed class AlphaBetaPruning
    {
        private readonly Difficulty _difficulty;

        public AlphaBetaPruning(Difficulty difficulty)
        {
            _difficulty = difficulty;
        }

        public int Find(Chip[] board)
        {
            GameState gameState = new GameState(board);
            GameTree<GameState> gameTree = new GameTree<GameState>();
            GameState bestState = gameTree.GetTheBest(gameState, (int)_difficulty, true);

            return bestState != null ? gameState.Children.FirstOrDefault(x => x.Value.Board.SequenceEqual(bestState.Board)).Key : -1;
        }
    }
}
