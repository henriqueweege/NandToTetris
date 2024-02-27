using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMTranslator.Strategies.Contract;

namespace VMTranslator.Strategies
{
    public class EqStrategy : IStrategy
    {
        public int Equals = 0;
        public string Translate(string pointerName, string position)
        {
            Equals++;

            return $@"
                    {Utils.PopTwoValues()}
                    {Utils.CalculateDifference()}
                    @EQUAL{Equals}
                    D;JEQ
                    {Utils.ResultIsFalse()}
                    @ENDEQUAL{Equals}
                    0;JMP
                    (EQUAL{Equals})
                    {Utils.ResultIsTrue()}
                    @ENDEQUAL{Equals}
                    0;JMP
                    (ENDEQUAL{Equals})
                    {Utils.IncrementStackPointer()} ";

        }
    }
}
