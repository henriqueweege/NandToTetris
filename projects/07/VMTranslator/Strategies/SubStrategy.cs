using VMTranslator.Strategies.Contract;

namespace VMTranslator.Strategies
{
    public class SubStrategy : IStrategy
    {
        public string Translate(string pointerName, string position)
        {
            return @$"
                    {Utils.RetrieveLastTwoStackValues()}
                    M = M - D
                    {Utils.IncrementStackPointer()}";

        }
    }
}
