

using HackAssembler.Coder;
using HackAssembler.Parser;
using HackAssembler.Parser.Instructions;
using HackAssembler.Parser.Instructions.Contract;
using HackAssembler.Utils;
using System.Text;

string[] lines = File.ReadAllLines(@"D:\Arquitetura de Computadores I\nand2tetris\projects\06\pong\Pong.asm", Encoding.UTF8);
var parser = new Parser(lines);
var instructions = new List<IInstruction>();
var line = 0;

for (var i = 0; i < lines.Length; i++)
{
    if (parser.HasMoreLines(i) && !parser.Advance(lines[i]))
    {
        var instruction = parser.InstructionType(lines[i]);

        if(instruction == EInstruction.L_INSTRUCTUION)
        {
            var symbol = LInstruction.Create(lines[i]).Symbol;
            SymbolTable.Symbols.Add(new Symbol(symbol, line));
        }
        else if(instruction == EInstruction.A_INSTRUCTUION || instruction == EInstruction.C_INSTRUCTUION)
        {
            line++;
        }
    }
}

for (var i = 0; i < lines.Length; i++)
{
    if (parser.HasMoreLines(i) && !parser.Advance(lines[i]))
    {
        var instruction = parser.InstructionType(lines[i]);

        if (instruction == EInstruction.A_INSTRUCTUION)
        {
            var symbol = AInstruction.Create(lines[i]).Symbol;
            if(!int.TryParse(symbol, out _) && !SymbolTable.Symbols.Any(x=>x.Name == symbol))
            {
                SymbolTable.AddASymbol(symbol);
            }
        }
    }
}

for (var i =0; i < lines.Length; i++)
{
    if(parser.HasMoreLines(i) && !parser.Advance(lines[i]))
    {
        IInstruction instruction = parser.InstructionType(lines[i]) switch
        {
            EInstruction.A_INSTRUCTUION  => AInstruction.Create(lines[i]),
            EInstruction.L_INSTRUCTUION => LInstruction.Create(lines[i]),
            EInstruction.C_INSTRUCTUION => CInstruction.Create(lines[i]),
            _ => throw new Exception()
        };
        instructions.Add(instruction);
    }
}

var binary = new StringBuilder();
for(var i =0; i< instructions.Count; i++)
{
    if(instructions[i].GetType() == typeof(CInstruction))
    {
        binary.AppendLine(CInstructionCoder.GetBinary((CInstruction)instructions[i]));
    }
    else if(instructions[i].GetType() == typeof(AInstruction))
    {
        binary.AppendLine(AInstructionCoder.GetBinary((AInstruction)instructions[i]));

    }
    //else
    //{
    //    binary.AppendLine(LInstructionCoder.GetBinary((LInstruction)instructions[i]));
    //}
}

var debug = binary.ToString();

var x = 0;