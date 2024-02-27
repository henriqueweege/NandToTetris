using VMTranslator.Strategies.Contract;

namespace VMTranslator.Strategies
{
    public class SubStrategy : IStrategy
    {
        public string Translate(string pointerName, string position)
        {
            return @$"
                    {Utils.PopTwoValues()}
                    M = M - D
                    {Utils.IncrementStackPointer()}";

        }
    }
}
