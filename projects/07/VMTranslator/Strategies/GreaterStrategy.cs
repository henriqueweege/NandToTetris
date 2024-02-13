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
                    {Utils.RetrieveLastTwoStackValues()}
                    {Utils.CalculateDifference()}
                    @GREATERTHAN{Greaters}
                    D;JGT
                    {Utils.ResultIsFalse()}
                    @ENDGREATERTHAN{Greaters}
                    0;JMP
                    (GREATERTHAN{Greaters})
                    {Utils.ResultIsTrue()}
                    @ENDGREATERTHAN{Greaters}
                    0;JMP
                    (ENDGREATERTHAN{Greaters})
                    {Utils.IncrementStackPointer()} 
                   ";

        }
    }
}
