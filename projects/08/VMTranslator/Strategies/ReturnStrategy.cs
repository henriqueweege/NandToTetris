using VMTranslator.Strategies.Contract;

namespace VMTranslator.Strategies
{
    internal class ReturnStrategy : IStrategy
    {
        public string Translate(string functionName = "", string numberOfArguments = "")
        {
            return @$"
                      // RETURN
                     {Utils.PopOneValue()}
                     @ARG
                     A = M
                     M = D
                     {Utils.SetAddressToReturnToR12()}
                     {Utils.RepositionTHISAddressToReturn()}                     
                     {Utils.RepositionTHATAddressToReturn()}
                     {Utils.RepositionSPAddressToReturn()}
                     {Utils.RepositionARGAddressToReturn()}
                     {Utils.RepositionLCLAddressToReturn()}
                     @R12
                     A = M
                     0;JMP
                    ";
        }
    }
}
