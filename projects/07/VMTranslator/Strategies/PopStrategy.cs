using VMTranslator.Strategies.Contract;

namespace VMTranslator.Strategies
{
    public class PopStrategy : IStrategy
    {
        public string Translate(string pointerName, string index)
        {
            var pointer = Pointers.Addresses[pointerName];

            return @$"
                    {Utils.GetIndexNumber(index)}
                    @{pointer}
                    A=M+D
                    M=D
                    {Utils.DecrementStackPointer()}";

        }
    }
}
