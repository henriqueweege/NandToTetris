using VMTranslator.Strategies.Contract;

namespace VMTranslator.Strategies
{
    public class AddStrategy : IStrategy
    {
        public string Translate(string pointerName, string position)
        {

            return $@"
                    {Utils.PopTwoValues()}
                    M = D + M
                    {Utils.IncrementStackPointer()}                    
                    ";

        }
    }
}
