using Reversi.Lib.Enums;

namespace Reversi.Lib.Algorithm
{
    public sealed class AlphaBetaPruning
    {
        private readonly Difficulty _difficulty;
        private readonly GameTree<GameState> _gameTree;

        public AlphaBetaPruning(Difficulty difficulty)
        {
            _difficulty = difficulty;
            _gameTree = new GameTree<GameState>();
        }

        public Chip[,] Find(Chip[,] board)
        {
            GameState bestState = _gameTree.GetTheBest(new(board), (int)_difficulty, maximize: true);

            return bestState.Board;
        }
    }
}
