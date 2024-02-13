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
                    @SP
                    A=M
                    D=M
                    @SP
                    M = M - 1
                    @SP
                    A=M
                    D= D - M
                    M=-1
                    @LESSTHAN{Lesses}
                    D;JLT
                    @ENDLESSTHAN{Lesses}
                    0;JMP
                    
                    (LESSTHAN{Lesses})
                    @SP
                    A=M
                    M=1
                    @ENDLESSTHAN{Lesses}
                    0;JMP
                    (ENDLESSTHAN{Lesses})
                    ";

        }
    }
}
