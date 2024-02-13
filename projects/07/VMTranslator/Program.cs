using System.Text;
using VMTranslator.Strategies;
using VMTranslator.Strategies.Contract;

string[] lines = File.ReadAllLines(@"D:\Arquitetura de Computadores I\NandToTetris\projects\07\StackArithmetic\StackTest\StackTest.vm", Encoding.UTF8);
var selector = new Selector();

var translated = new StringBuilder();
foreach(var line in lines)
{
    if (line.StartsWith("//") || string.IsNullOrWhiteSpace(line)) 
    {
        continue;
    }

    string memBucket = ""; 
    string index = "0";
    string command = "";

    translated.AppendLine($"// {line}");

    var values = line.Split(' ');

    try
    {
        command = values[0];
    }
    catch { }

    try
    {
        memBucket = values[1];
    }
    catch { }

    try
    {
        index = values[2];
    }
    catch { }

    IStrategy strategy = selector._strategies[command];
    translated.AppendLine(strategy.Translate(memBucket, index));

}

var result = translated.ToString();
var debug = 0;