using HackAssembler.Parser.Instructions.Contract;

namespace HackAssembler.Parser.Instructions;

public class AInstruction : IInstruction
{
    public string Symbol { get; private set; }
    private AInstruction(string row)
    {
        GetSymbol(row);
    }
    private void GetSymbol(string row)
        => Symbol = string.Concat(row.Where(x => x != '@').Select(x => x).ToList()).Trim();

    public static AInstruction Create(string row)
        => new AInstruction(row);
}
