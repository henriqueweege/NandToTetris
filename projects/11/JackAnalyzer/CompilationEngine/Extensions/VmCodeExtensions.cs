using JackAnalyzer.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackAnalyzer.CompilationEngine.Extensions
{
    public static class VmCodeExtensions
    {
        public static void Push(this StringBuilder stringBuilder, EMemSegments memSegment, string position)
        {
            stringBuilder.AppendLine($"push {memSegment.ToString().ToLower()} {position}");
        }

        public static void Push(this StringBuilder stringBuilder, EMemSegments memSegment, int position)
        {
            stringBuilder.AppendLine($"push {memSegment.ToString().ToLower()} {position}");
        }

        public static void PushOp (this StringBuilder stringBuilder, string value)
        {
            switch(value)
            {
                case "*":
                    stringBuilder.Call("Math.multiply", 2);
                    break;
                case "+":
                    stringBuilder.AppendLine($"add");
                    break;
                case "-":
                    stringBuilder.AppendLine($"sub");
                    break;
                case "<":
                    stringBuilder.AppendLine($"lt");
                    break;
                case "/":
                    stringBuilder.Call("Math.divide 2");
                    break;
                default:
                    break;

            }
        }
        public static void Call(this StringBuilder stringBuilder, string funcName, int qntParams)
        {
            stringBuilder.AppendLine($"call {funcName} {qntParams}");
        }

        public static void Pop(this StringBuilder stringBuilder, EMemSegments memSegment, string position)
        {
            stringBuilder.AppendLine($"pop {memSegment.ToString().ToLower()} {position}");
        }
        public static void Pop(this StringBuilder stringBuilder, EMemSegments memSegment, int position)
        {
            stringBuilder.AppendLine($"pop {memSegment.ToString().ToLower()} {position}");
        }
        public static void Function(this StringBuilder stringBuilder, string className, string funcName, int qntParams = 0)
        {
            stringBuilder.AppendLine($"function {className}.{funcName} {qntParams}");
        }

        public static void Call(this StringBuilder stringBuilder, string funcName)
        {
            stringBuilder.AppendLine($"call {funcName}");
        }
    }
}
