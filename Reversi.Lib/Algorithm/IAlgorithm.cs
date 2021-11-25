using Reversi.Lib.Enums;

namespace Reversi.Lib.Algorithm
{
    internal interface IAlgorithm
    {
        public Chip[] Find(Chip[] board);
    }
}
