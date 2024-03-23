using JackAnalyzer.JackTokenizer;
using System.Text;

namespace JackAnalyzer.CompilationEngine;

internal class Engine
{

    private Tokenizer _tokenizer;
    private StringBuilder _xml = new StringBuilder();
    private string _identation = string.Empty;
    public Engine(Tokenizer tokenizer)
    {
        _tokenizer = tokenizer;
        //okay, o problema da implementação que temos aqui é que ela
        //recurssivamente vai consumir o arquivo todo, e apenas
        //no final do arquivo vai passar a fechar as tags,
        //o que vai resultar num arquivo inválido.
        //é necessário que seja refeitos os métodos para que 
        //cumpram, passo a passo, a implementação proposta no livro
    }

    public void CreateXml()
    {
        Eat();
    }

    private void Eat()
    {
        var token = _tokenizer.GetToken();
        switch (token.Value)
        {

            case "class": CompileClass(); break;
            case "static": CompileClassVarDec(); break;
            case "field": CompileClassVarDec(); break;
            case "constructor": CompileSubroutineDec(); break;
            case "function": CompileSubroutineDec(); break;
            case "method": CompileSubroutineDec(); break;
            case "(": CompileParamList(); break;
            //case ")": CompileCloseParentesis(); break;


        }

    }
    private void CompileParamList()
    {
        var compilationTag = "paramList";
        AddOpenTag(compilationTag);

        IncrementIdentation();
        AddToken();
        while (_tokenizer.NextToken().Value != ")")
        {
            _tokenizer.Advance();
            AddToken();
            NewLine();
        }

        _tokenizer.Advance();
        Eat();

        DecrementIdentation();
        AddCloseTag(compilationTag);
    }

    private void CompileSubroutineDec()
    {
        var compilationTag = "subroutineDec";
        Compile(compilationTag);
    }

    private void CompileClassVarDec()
    {
        var compilationTag = "classVarDec";
        Compile(compilationTag);
    }

    private void CompileClass()
    {
        var compilationTag = "class";
        Compile(compilationTag);
    }

    private void Compile(string compilationTag)
    {
        AddOpenTag(compilationTag);

        IncrementIdentation();

        AddToken();

        NewLine();

        _tokenizer.Advance();
        Eat();

        DecrementIdentation();
        AddCloseTag(compilationTag);
    }

    private void AddToken()
    {
        var token = _tokenizer.GetToken();
        Append(token.Tag.Open);
        Append(token.Value);
        Append(token.Tag.Close);
        NewLine();
    }

    private void NewLine()
    {
        _xml.AppendLine();
    }

    private void Append(string value)
    {
        _xml.Append($"{_identation}{value}");
    }

    private void AddOpenTag(string token)
    {
        _xml.Append($"{_identation}<{token}>");
    }

    private void AddCloseTag(string token)
    {
        _xml.Append($"{_identation}</{token}>");
    }

    private void DecrementIdentation()
    {
        _identation = _identation.Substring(0, _identation.Length - 2);
    }
    private void IncrementIdentation()
    {
        _identation += "  ";
    }
}
