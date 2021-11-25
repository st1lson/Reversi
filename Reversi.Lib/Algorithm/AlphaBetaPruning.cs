using Reversi.Lib.Enums;

namespace Reversi.Lib.Algorithm
{
    public sealed class AlphaBetaPruning : IAlgorithm
    {
        private readonly Difficulty _difficulty;

        public AlphaBetaPruning(Difficulty difficulty)
        {
            _difficulty = difficulty;
        }

        public Chip[] Find(Chip[] board)
        {
            return default;
        }
    }
}
