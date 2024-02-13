using VMTranslator.Strategies.Contract;

namespace VMTranslator.Strategies
{
    public class OrStrategy : IStrategy
    {
        public string Translate(string pointerName, string position)
        {

            return $@"
                    {Utils.RetrieveLastTwoStackValues()}
                    M = D|M
                    {Utils.IncrementStackPointer()}";

        }
    }
}
