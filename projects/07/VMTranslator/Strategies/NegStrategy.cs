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
                    M = M - 1
                    A = M
                    M = D - M
                    @SP
                    M = M + 1";

        }
    }
}
