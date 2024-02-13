using VMTranslator.Strategies.Contract;

namespace VMTranslator.Strategies
{
    public class OrStrategy : IStrategy
    {
        public string Translate(string pointerName, string position)
        {

            return $@"
                    @SP
                    A=M
                    D=M
                    @SP
                    M = M - 1
                    @SP
                    A=M
                    M= D|M
                    @SP
                    M = M + 1";

        }
    }
}
