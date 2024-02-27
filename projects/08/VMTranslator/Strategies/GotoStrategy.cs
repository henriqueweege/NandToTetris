using VMTranslator.Strategies.Contract;

namespace VMTranslator.Strategies
{
    public class GotoStrategy : IStrategy
    {
        public string Translate(string functionName = "", string numberOfArguments = "")
        {
            return @$"
                @{functionName}
                0;JMP
             ";
        }
    }
}
