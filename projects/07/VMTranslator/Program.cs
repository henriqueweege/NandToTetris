using System.Text;
using VMTranslator.Strategies;
using VMTranslator.Strategies.Contract;
using System.Runtime.InteropServices;
[DllImport("kernel32.dll")]
static extern IntPtr GetConsoleWindow();

[DllImport("user32.dll")]
static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

const int SW_HIDE = 0;
const int SW_SHOW = 5;
var handle = GetConsoleWindow();

// Hide
ShowWindow(handle, SW_HIDE);


string[] lines = File.ReadAllLines(@"D:\Arquitetura de Computadores I\NandToTetris\projects\07\MemoryAccess\StaticTest\StaticTest.vm", Encoding.UTF8);
var selector = new Selector();

var translated = new StringBuilder();

translated.AppendLine(@"
@17
D=A
@16
M=D
 ");


foreach (var line in lines)
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