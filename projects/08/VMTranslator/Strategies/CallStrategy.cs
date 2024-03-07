using VMTranslator.Strategies.Contract;

namespace VMTranslator.Strategies
{
    internal class CallStrategy : IStrategy
    {
        public string Translate(string functionName = "", string numberOfArguments = "")
        {
            return @$"
                     //push return address
                     {Utils.PushReturnAddress(numberOfArguments)} 
                     //save LCL
                     @LCL
                     D = M
                     {Utils.PushToStack()}
                    //save ARG 
                     @ARG
                     D = M
                     {Utils.PushToStack()}
                    //save THIS
                     @THIS
                     D = M
                     {Utils.PushToStack()}
                     //save THAT
                     @THAT
                     D = M
                     {Utils.PushToStack()}
                     //set new ARG address
                     {Utils.SetNewARGAddress(numberOfArguments)}
                     //set LCL Address
                     @SP
                     D = M
                     @LCL
                     M = D
                     @{functionName}
                     0;JMP
                     ({Utils.CurrentReturnAddress})
                    ";
        }
    }
}
