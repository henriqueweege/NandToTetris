using VMTranslator.Strategies.Contract;

namespace VMTranslator.Strategies
{
    public class GreaterStrategy : IStrategy
    {
        public int Greaters { get; set; }
        public string Translate(string pointerName, string position)
        {
            Greaters++;
            return $@"
                    @SP
                    A=M
                    D=M
                    @SP
                    M = M - 1
                    @SP
                    A=M
                    D= D - M
                    M=-1
                    @GREATERTHAN{Greaters}
                    D;JGT
                    @ENDGREATERTHAN{Greaters}
                    0;JMP
                    (GREATERTHAN{Greaters})
                    @SP
                    A=M
                    M=1
                    @ENDGREATERTHAN{Greaters}
                    0;JMP
                    (ENDGREATERTHAN{Greaters})
                   ";

        }
    }
}
