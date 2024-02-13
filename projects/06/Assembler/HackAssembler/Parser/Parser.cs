namespace HackAssembler.Parser;

public class Parser
{
    private readonly IList<string> _file;
    public Parser(IList<string> file)
    {
        _file = file;
    }

    public bool HasMoreLines(int row)
        => row <= _file.Count;

    public bool Advance(string row)
        => string.IsNullOrWhiteSpace(row) || row.TrimStart().StartsWith("//");


    public EInstruction? InstructionType(string row)
    {
        row = row.Trim();
        if (row.StartsWith('@'))
        {
            return EInstruction.A_INSTRUCTUION;
        }
        else if (row.Contains('=')|| row.Contains(';'))
        {
            return EInstruction.C_INSTRUCTUION;
        }
        if (row.StartsWith('('))
        {
            return EInstruction.L_INSTRUCTUION;
        }
    
        return null;
    
    }
}
