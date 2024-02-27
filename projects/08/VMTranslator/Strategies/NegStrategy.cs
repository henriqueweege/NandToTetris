using VMTranslator.Strategies.Contract;

namespace VMTranslator.Strategies
{
    public class Negtrategy : IStrategy
    {
        public string Translate(string pointerName, string position)
        {

            return $@"
                    @0
                    D=A
                    @SP
                    {Utils.DecrementStackPointer()}
                    A=M
                    M = D - M
                    {Utils.IncrementStackPointer()}";

        }
    }
}
