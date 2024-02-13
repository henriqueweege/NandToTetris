using HackAssembler.Parser.Instructions;
using HackAssembler.Utils;

namespace HackAssembler.Coder;

public static class AInstructionCoder
{
    public static string GetBinary(AInstruction instruction)
    {
        int intVal;
        if (int.TryParse(instruction.Symbol, out _))
        {

            intVal = int.Parse(instruction.Symbol);
        }
        else
        {

            intVal = SymbolTable.GetSymbolVal(instruction.Symbol);
        }
        var toBinary = Convert.ToString(intVal, 2);
        return toBinary.PadLeft((16 - toBinary.Length) + toBinary.Length, '0');
    }
}
