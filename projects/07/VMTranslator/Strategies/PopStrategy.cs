using VMTranslator.Strategies.Contract;

namespace VMTranslator.Strategies
{
    public class PopStrategy : IStrategy
    {
        public string Translate(string pointerName, string index)
        {
            var pointer = Pointers.Addresses[pointerName];

            return @$"
                    @SP
                    A=M
                    D=M
                    @{pointer}
                    A=M+{index}
                    M=D
                    @SP
                    M=M-1";

        }
    }
}
