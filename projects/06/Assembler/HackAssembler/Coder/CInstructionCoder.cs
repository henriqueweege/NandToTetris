using HackAssembler.Parser.Instructions;

namespace HackAssembler.Coder;

public static class CInstructionCoder
{
    private static string GetDestBinary(string? dest)
        => dest switch
        {
            "M" => "001",
            "D" => "010",
            "A" => "100",
            "DM" => "011",
            "MD" => "011",
            "AM" => "101",
            "MA" => "101",
            "AD" => "110",
            "DA" => "110",
            "ADM" => "111",
            "DAM" => "111",
            "DMA" => "111",
            "MDA" => "111",
            "MAD" => "111",
            _ => "000"

        };

    private static string GetCompBinary(string comp)
        => comp switch
        {
            "0" => "0101010",
            "1" => "0111111",
            "-1" => "0111010",
            "D" => "0001100",
            "A" => "0110000",
            "M" => "1110000",
            "!D" => "0001101",
            "!A" => "0110001",
            "!M" => "1110001",
            "-D" => "0001111",
            "-A" => "0110011",
            "-M" => "1110011",
            "D+1" => "0011111",
            "A+1" => "0110111",
            "M+1" => "1110111",
            "D-1" => "0001110",
            "A-1" => "0110010",
            "M-1" => "1110010",
            "D+A" => "0000010",
            "D+M" => "1000010",
            "D-A" => "0010011",
            "D-M" => "1010011",
            "A-D" => "0000111",
            "M-D" => "1000111",
            "D&A" => "0000000",
            "D&M" => "1000000",
            "D|A" => "0010101",
            "D|M" => "1010101",
            _ => throw new Exception()
        };
    
    private static string GetJumpBinary(string? jump)
        =>
        jump switch
        {
            "JGT"=> "001",
            "JEQ"=> "010",
            "JGE"=> "011",
            "JLT"=> "100",
            "JNE"=> "101",
            "JLE"=> "110",
            "JMP"=> "111",
            _ => "000"
        };
    
    public static string GetBinary(CInstruction instruction)
    {
        var binary = new List<string>() { "111" };
        binary.Add(GetCompBinary(instruction.Comp));
        binary.Add(GetDestBinary(instruction.Dest));
        binary.Add(GetJumpBinary(instruction.Jump));

        return string.Concat(binary);
    }

}
