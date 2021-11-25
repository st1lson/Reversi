using Reversi.Lib.Enums;

namespace Reversi.Lib.Algorithm
{
    public class AlphaBetaPruning : IAlgorithm
    {
        private readonly Difficulty _difficulty;

        public AlphaBetaPruning(Difficulty difficulty)
        {
            _difficulty = difficulty;
        }
    }
}
