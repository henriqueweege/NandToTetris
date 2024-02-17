using VMTranslator.Strategies.Contract;

namespace VMTranslator.Strategies
{
    public class PopStrategy : IStrategy
    {
        public string Translate(string pointerName, string index)
        {
            if (pointerName.Equals("pointer") && index.Equals("0"))
            {
                return @$"
                    //pop this
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    @THIS
                    M=D";

            }

            if (pointerName.Equals("pointer") && index.Equals("1"))
            {
                return @$"
                    //pop that
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    @THAT
                    M=D";

            }
            var pointer = Pointers.Addresses[pointerName];
            return @$"
                    //get address
                    {Utils.GetIndexNumber(index)}
                    @{pointer}
                    D=M+D
                    //store address at R13
                    @13
                    M=D
                    {Utils.RetrieveFirstValue()}
                    //put value at right address
                    @R13
                    A=M
                    M=D";

        }
    }
}
