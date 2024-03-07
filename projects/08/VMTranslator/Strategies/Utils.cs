using System.Text;

namespace VMTranslator.Strategies
{
    public static class Utils
    {
        public static string ReturnAddress = "ReturnAddress";
        public static string CurrentReturnAddress = "";

        public static int ReturnAddressCount = 0;

        public static string GetReturnAddress()
        {

            var returnValue = @$"{ReturnAddress}-{--ReturnAddressCount}";
            ++ReturnAddressCount;
            return returnValue;
        }

        public static string RepositionTHATAddressToReturn()
        {
            return @$"  
                    //Reposition THAT Address
                    @1
                    D=A
                    @LCL
                    A = M - D
                    D = M
                    @THAT
                    M = D
                    ";
        }

        public static string RepositionTHISAddressToReturn()
        {
            return @$"  
                    //Reposition THIS Address
                    @2
                    D=A
                    @LCL
                    A = M - D
                    D = M
                    @THIS
                    M = D
                    ";
        }

        public static string RepositionARGAddressToReturn()
        {
            return @$"  
                    //Reposition ARG Address
                    @3
                    D=A
                    @LCL
                    A = M - D
                    D = M
                    @ARG
                    M = D
                    ";
        }

        public static string RepositionLCLAddressToReturn()
        {
            return @$"  
                    //Reposition ARG Address
                    @4
                    D=A
                    @LCL
                    A = M - D
                    D = M
                    @LCL
                    M = D
                    ";
        }

        public static string SetAddressToReturnToR12()
        {
            return @$"  
                    //Set Address To Return To R12
                    @5
                    D=A
                    @LCL
                    A = M - D
                    D = M
                    @R12
                    M = D
                    ";
        }

        public static string RepositionSPAddressToReturn()
        {
            return @$"  
                    //Reposition SP Address
                    @1
                    D=A
                    @ARG
                    D = M + D
                    @SP
                    M = D
                    ";
        }

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
            return $@"
                    //result is false
                    @0
                    D=A
                    {PushToStack()}";
        }

        public static string ResultIsTrue()
        {
            return $@"
                    //Result is true 
                    @0
                    D = A
                    D = D -1 
                    {PushToStack()}";
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

            for (var i = 0; i < qntVars; i++)
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

        //public static object PushReturnAddress(string numberOfArguments)
        //{
        //    var argsNum = int.Parse(numberOfArguments);
        //    CurrentReturnAddress = $"{ReturnAddress}-{++ReturnAddressCount}";
        //    return $@"
        //            @5
        //            D = A
        //            @SP
        //            M = A
        //            D = D - M
        //            @R12
        //            M = D
        //            @{CurrentReturnAddress}
        //            D=A
        //            @R12
        //            A =
        //            {PushToStack()}
        //            ";

        //}

        public static object PushReturnAddress(string numberOfArguments)
        {
            var argsNum = int.Parse(numberOfArguments);
            CurrentReturnAddress = $"{ReturnAddress}-{++ReturnAddressCount}";
            return $@"
                    @{CurrentReturnAddress}
                    D=A
                    {PushToStack()}
                    ";

        }

        internal static object SetNewARGAddress(string numberOfArguments)
        {
            var argsNum = int.Parse(numberOfArguments);

            return $@"
                    @{argsNum}
                    D = A
                    @5
                    D = D + A
                    @SP
                    D = M - D
                    @ARG
                    M = D
                    ";
        }
    }
}
