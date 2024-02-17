using VMTranslator.Strategies.Contract;

namespace VMTranslator.Strategies
{
    public class PushStrategy : IStrategy
    {
        public string Translate(string pointerName, string index)
        {
            if (pointerName.Equals("pointer") && index.Equals("0"))
            {
                return @$"
                    //Get THIS value
                    @THIS
                    D=M
                    //Push THIS value
                    @SP
                    A=M
                    M=D
                    {Utils.IncrementStackPointer()}";

            }

            if (pointerName.Equals("pointer") && index.Equals("1"))
            {
                return @$"
                    //Get THAT value
                    @THAT
                    D=M
                    //Push THAT value
                    @SP
                    A=M
                    M=D
                    {Utils.IncrementStackPointer()}";

            }

            if (pointerName.Equals("constant"))
            {
                return PushConstant(index);
            }
            var pointer = Pointers.Addresses[pointerName];

            return @$"
                     {Utils.GetIndexNumber(index)}
                     //Get value
                     @{pointer}
                     A = M + D
                     D = M
                     //put value in stack
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
