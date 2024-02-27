using VMTranslator.Strategies.Contract;

namespace VMTranslator.Strategies
{
    public class Negtrategy : IStrategy
    {
        public string Translate(string pointerName, string position)
        {

            return $@"@SP
                    M = M - 1
                    A=M
                    D=M * -1
                    @SP
                    M = M + 1";

        }
    }
}
