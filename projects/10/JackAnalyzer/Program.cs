using JackAnalyzer.CompilationEngine;
using JackAnalyzer.JackTokenizer;
using System.Text;

var filelines = File.ReadAllLines(@"D:\Arquitetura de Computadores I\NandToTetris\projects\10\ArrayTest\Main.jack", Encoding.UTF8);

var tokenizer = new Tokenizer(filelines);
//var engine = new Engine(tokenizer);
//engine.GenerateXML();

//var xml = engine.XMLBuilder.ToString();

var debug = 0;