using VMTranslator.Strategies.Contract;

namespace VMTranslator.Strategies
{
    internal class FunctionStrategy : IStrategy
    {
        public string Translate(string functionName = "", string numberOfArguments = "")
        {
            return @$"
                      ({functionName})
                      {Utils.InitializeLocalVars(numberOfArguments)}
                        ";
        }
    }
}
