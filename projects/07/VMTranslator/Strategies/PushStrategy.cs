using System.Reflection;
using System.Reflection.Metadata;
using VMTranslator.Strategies.Contract;

namespace VMTranslator.Strategies
{
    public class PushStrategy : IStrategy
    {
        public string Translate(string pointerName, string index)
        {
            if (pointerName.Equals("constant"))
            {
                return PushConstant(index);
            }
            var pointer = Pointers.Addresses[pointerName];

            return @$"
                     {Utils.GetIndexNumber(index)}
                     @{pointer}
                     A = M + D
                     D = M
                     @SP
                     A = M
                     M = D
                     {Utils.IncrementStackPointer()}";

        }

        private string PushConstant(string constValue)
        {
            return @$"
                        @{constValue}
                        D=A
                        @SP
                        A = M
                        M = D
                        {Utils.IncrementStackPointer()}";
        }
    }
}
