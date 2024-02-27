using System.Runtime.InteropServices;
using System.Text;
using VMTranslator.Strategies;
using VMTranslator.Strategies.Contract;
[DllImport("kernel32.dll")]
static extern IntPtr GetConsoleWindow();

[DllImport("user32.dll")]
static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

const int SW_HIDE = 0;
var handle = GetConsoleWindow();

ShowWindow(handle, SW_HIDE);

string[] syslines = new string[0];
string[] mainlines = new string[0];

try
{

    syslines = File.ReadAllLines(@"D:\Arquitetura de Computadores I\NandToTetris\projects\08\FunctionCalls\SimpleFunction\sys.vm", Encoding.UTF8);
}
catch { }

try
{

    mainlines = File.ReadAllLines(@"D:\Arquitetura de Computadores I\NandToTetris\projects\08\FunctionCalls\SimpleFunction\SimpleFunction.vm", Encoding.UTF8);
}
catch
{

}

var archives = new List<string[]>()
{
    syslines, mainlines
};

var selector = new Selector();

var translated = new StringBuilder();

translated.AppendLine(@"
@17
D=A
@16
M=D
 ");

foreach (var lines in archives)
{
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
            command = values[0].Replace("\t", "");
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
}

var result = translated.ToString();

var debug = 0;
