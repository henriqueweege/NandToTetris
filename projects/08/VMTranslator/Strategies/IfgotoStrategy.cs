using VMTranslator.Strategies.Contract;

namespace VMTranslator.Strategies
{
    public class IfgotoStrategy : IStrategy
    {
        public string Translate(string functionName = "", string numberOfArguments = "")
        {
            return @$"
                @SP
                A=M
                D=M
                @{functionName}
                D;JGT
            
             ";
        }
    }
}
