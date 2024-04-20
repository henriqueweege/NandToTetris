using JackAnalyzer.CompilationEngine;
using JackAnalyzer.JackTokenizer;
using System.Text;

var filelines = File.ReadAllLines(@"D:\Arquitetura de Computadores I\NandToTetris\projects\11\Seven\Main.jack", Encoding.UTF8);

var tokenizer = new Tokenizer(filelines);
var engine = new Engine(tokenizer);
engine.CreateXml();

var xml = engine.VmCode.ToString();

var debug = 0;