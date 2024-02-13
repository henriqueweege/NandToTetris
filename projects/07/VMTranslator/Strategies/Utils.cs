using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMTranslator.Strategies
{
    public static class Utils
    {

        public static string RetrieveLastTwoStackValues()
        {
            return @$"  
                    //retrieve first value
                    @SP
                    {DecrementStackPointer()}
                    A=M
                    D=M
                    //retrieve second value
                    @SP
                    {DecrementStackPointer()}
                    A=M";
        }

        public static string CalculateDifference()
        {
            return @"
                    //calculate dif
                    D = M - D";
        }

        public static string ResultIsFalse()
        {
            return @"
                    //result is false
                    @0
                    D=A
                    @SP
                    A=M
                    M=D";
        }

        public static string ResultIsTrue()
        {
            return @"
                    //Result is true 
                    @0
                    D = A
                    D = D -1 
                    @SP
                    A = M
                    M = D";
        }

        public static string IncrementStackPointer()
        {
            return @"
                    //increment pointer
                    @SP
                    M = M + 1";
        }
        public static string DecrementStackPointer()
        {
            return @"
                    //Decrement pointer
                    @SP
                    M = M - 1";
        }
        public static string GetIndexNumber(string index)
        {
            return $@"
                    @{index}
                    D=M";
        }
    }
}
