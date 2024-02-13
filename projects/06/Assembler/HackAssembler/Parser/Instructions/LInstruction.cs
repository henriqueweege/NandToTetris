using HackAssembler.Parser.Instructions.Contract;

namespace HackAssembler.Parser.Instructions;

public class LInstruction : IInstruction
{
    public string Symbol { get; private set; }
    private LInstruction(string row)
    {
        GetSymbol(row);
    }
    private void GetSymbol(string row)
        => Symbol = string.Concat(row.Where(x => x != '(' && x != ')').Select(x => x).ToList()).Trim();

    public static LInstruction Create(string row)
        => new LInstruction(row);
}
