using VMTranslator.Strategies.Contract;

namespace VMTranslator.Strategies
{
    internal class ReturnStrategy : IStrategy
    {
        public string Translate(string functionName = "", string numberOfArguments = "")
        {
            return @$"
                     {Utils.PopOneValue()}
                     @ARG
                     A = M
                     M = D
                     @{Utils.ReturnAddress}
                     D = M
                     @SP
                     M = D
                     {Utils.IncrementStackPointer()}
                     @RETURN
                     0;JMP
                    ";
        }
    }
}
