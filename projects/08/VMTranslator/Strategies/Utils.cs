using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMTranslator.Strategies
{
    public static class Utils
    {
        public static string ReturnAddress = "ReturnAddress";
        public static string PopTwoValues()
        {
            return @$"  
                    {PopOneValue()}
                    //retrieve second value
                    @SP
                    {DecrementStackPointer()}
                    A=M";
        }

        public static string PopOneValue()
        {
            return $@"
                    //retrieve first value
                    {DecrementStackPointer()}
                    A=M
                    D=M";
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
                    D=A";
        }

        public static string InitializeLocalVars(string qntVarsStr)
        {
            var qntVars = int.Parse(qntVarsStr);
            var builder = new StringBuilder();

            for(var i =0; i< qntVars; i++)
            {
                builder.AppendLine($@"
                                      //initialize local vars
                                      @{i}
                                      D=A
                                      @LCL
                                      D = M + D
                                      @R13
                                      M = D
                                      @0
                                      D = A
                                      @R13
                                      A = M 
                                      M = D
                                      {Utils.IncrementStackPointer()}
                                      ");
            }

            return builder.ToString();
        }

        public static object PushToStack()
        {
            return @$"@SP
                     A = M
                     M = D 
                     {IncrementStackPointer()}";
        }

        public static object PushReturnAddress(string numberOfArguments)
        {
            var argsNum = int.Parse(numberOfArguments);

            return $@"
                    @{argsNum}
                    D = A
                    @SP
                    D = D - M
                    @{ReturnAddress}
                    M = A
                    ";
        }

        internal static object SetNewARGAddress(string numberOfArguments)
        {
            var argsNum = int.Parse(numberOfArguments);

            return $@"
                    @{argsNum}
                    D = A
                    @5
                    D = D - A
                    @SP
                    D = D - M
                    @ARG
                    M = D
                    ";
        }
    }
}
