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
                    //retrieve first value
                    @SP
                    M = M - 1
                    A=M
                    D=M
                    //retrieve second value
                    @SP
                    M = M - 1
                    A=M
                    //calculate dif
                    D= D - M
                    @EQUAL{Equals}
                    D;JEQ
                    //result is false
                    @0
                    D=A
                    @SP
                    A=M
                    M=D
                    @ENDEQUAL{Equals}
                    0;JMP
                    (EQUAL{Equals})
                    //Result is true 
                    @1
                    D=A
                    @SP
                    A=M
                    M=D
                    @ENDEQUAL{Equals}
                    0;JMP
                    (ENDEQUAL{Equals})
                    @SP
                    M = M + 1";

        }
    }
}
