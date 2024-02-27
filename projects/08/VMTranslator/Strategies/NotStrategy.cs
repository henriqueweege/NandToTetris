using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMTranslator.Strategies.Contract;

namespace VMTranslator.Strategies
{
    public class NotStrategy : IStrategy
    {
        public string Translate(string pointerName, string position)
        {

            return $@"
                    @SP
                    {Utils.DecrementStackPointer()}
                    A=M
                    M=!M
                    {Utils.IncrementStackPointer()}";

        }
    }
}
