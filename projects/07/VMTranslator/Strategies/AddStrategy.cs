using VMTranslator.Strategies.Contract;

namespace VMTranslator.Strategies
{
    public class AddStrategy : IStrategy
    {
        public string Translate(string pointerName, string position)
        {

            return $@"
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    @SP
                    M = M - 1
                    @SP
                    A=M
                    M = M + D
                    @SP
                    M = M + 1";

        }
    }
}
