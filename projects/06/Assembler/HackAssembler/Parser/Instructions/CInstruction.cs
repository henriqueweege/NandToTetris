using HackAssembler.Parser.Instructions.Contract;

namespace HackAssembler.Parser.Instructions;

public class CInstruction : IInstruction
{
    public string? Dest { get; private set; }
    public string Comp { get; private set; }
    public string? Jump { get; private set; }
    private CInstruction(string row)
    {
        GetDest(row);
        GetComp(row);
        GetJump(row);
    }
    private void GetDest(string row)
        => Dest = row.Contains('=') ? row.Split('=').First().Trim() : null;
    private void GetComp(string row)
        => Comp = row.Split(';').First().Split('=').Last().Trim();
    private void GetJump(string row)
        => Jump = row.Contains(';') ? row.Split(';').Last().Trim() : null;
    public static CInstruction Create(string row)
        => new CInstruction(row);
}
