using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMTranslator.Strategies.Contract;

namespace VMTranslator.Strategies
{
    internal class LessStrategy : IStrategy
    {
        public int Lesses { get; set; }
        public string Translate(string pointerName, string position)
        {
            Lesses++;

            return $@"
                    {Utils.PopTwoValues()}
                    {Utils.CalculateDifference()}
                    @LESSTHAN{Lesses}
                    D;JLT
                    {Utils.ResultIsFalse()}
                    @ENDLESSTHAN{Lesses}
                    0;JMP
                    (LESSTHAN{Lesses})
                    {Utils.ResultIsTrue()}
                    @ENDLESSTHAN{Lesses}
                    0;JMP
                    (ENDLESSTHAN{Lesses})
                    {Utils.IncrementStackPointer()}";

        }
    }
}
