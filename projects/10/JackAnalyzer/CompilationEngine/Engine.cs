using JackAnalyzer.JackTokenizer;
using System.Text;

namespace JackAnalyzer.CompilationEngine;

internal class Engine
{

    private Tokenizer _tokenizer;
    public StringBuilder Xml = new StringBuilder();
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

            case "class": 
                CompileClass(); 
                break;
            case "static": case "field":
                CompileClassVarDec();
                break;
            case "function": case "constructor": case "method": 
                CompileSubroutineDec(); 
                break;
            case "(": 
                CompileParamList(); 
                break;
            case ")": 
                CompileCloseParentesis(); 
                break;
            case "var": 
                CompileVarDec(); 
                break;
            case "let": case "if": case "do": case "return":
                CompileStatements();
                break;
            default:
                AddToken(); break;


        }
        if(_tokenizer.HasMoreTokens())
        {
            _tokenizer.Advance();
            Eat();
        }

    }
    private void CompileParamList()
    {
        AddToken();
        IncrementIdentation();
        var compilationTag = "parameterList";
        AddOpenTag(compilationTag);
        IncrementIdentation();
        NewLine();

        while (_tokenizer.NextToken().Value != ")")
        {
            _tokenizer.Advance();
            AddToken();
            NewLine();
        }

        DecrementIdentation();
        AddIdentedCloseTag(compilationTag);
        NewLine();
        DecrementIdentation();

        if (!_tokenizer.HasMoreTokens())
        {
            return;
        }
        _tokenizer.Advance();
        Eat();
    }

    private void CompileStatements()
    {
        var compilationTag = "statements";
        IncrementIdentation();
        AddOpenTag(compilationTag);
        IncrementIdentation();
        NewLine();

        OrchestrateStatmentCompilation(_tokenizer.GetToken().Value);

        DecrementIdentation();
        AddIdentedCloseTag(compilationTag);
        NewLine();
        DecrementIdentation();

        if (!_tokenizer.HasMoreTokens())
        {
            return;
        }
        _tokenizer.Advance();
        Eat();
    }

    private void CompileLetStatement()
    {
        var compilationTag = "letStatement";
        IncrementIdentation();
        AddOpenTag(compilationTag);
        IncrementIdentation();
        NewLine();
        AddToken();

        while (_tokenizer.NextToken().Value != ";")
        {
            _tokenizer.Advance();
            AddToken();
        }

        _tokenizer.Advance();
        AddToken();
        DecrementIdentation();
        AddIdentedCloseTag(compilationTag);
        NewLine();
        DecrementIdentation();

        if (!_tokenizer.HasMoreTokens())
        {
            return;
        }
        _tokenizer.Advance();

        OrchestrateStatmentCompilation(_tokenizer.GetToken().Value);

    }

    private void CompileWhileStatement()
    {
        var compilationTag = "whileStatement";
        IncrementIdentation();
        AddOpenTag(compilationTag);
        IncrementIdentation();
        NewLine();
        AddToken();

        while (_tokenizer.NextToken().Value != "}")
        {
            _tokenizer.Advance();
            var token = _tokenizer.GetToken();
            if (token.IsStatemnent())
            {
                OrchestrateStatmentCompilation(_tokenizer.GetToken().Value);
            }
            else
            {
                AddToken();
            }
        }

        _tokenizer.Advance();
        AddToken();
        DecrementIdentation();
        AddIdentedCloseTag(compilationTag);
        NewLine();
        DecrementIdentation();

        if(!_tokenizer.HasMoreTokens())
        {
            return;
        }
        _tokenizer.Advance();

        OrchestrateStatmentCompilation(_tokenizer.GetToken().Value);

    }

    private void CompileDoStatement()
    {
        var compilationTag = "doStatement";
        IncrementIdentation();
        AddOpenTag(compilationTag);
        IncrementIdentation();
        NewLine();
        AddToken();

        while (_tokenizer.NextToken().Value != ";")
        {
            _tokenizer.Advance();
            AddToken();
        }

        _tokenizer.Advance();
        AddToken();
        DecrementIdentation();
        AddIdentedCloseTag(compilationTag);
        NewLine();
        DecrementIdentation();

        if (!_tokenizer.HasMoreTokens())
        {
            return;
        }
        _tokenizer.Advance();

        OrchestrateStatmentCompilation(_tokenizer.GetToken().Value);

    }

    private void CompileReturnStatement()
    {
        var compilationTag = "returnStatement";
        IncrementIdentation();
        AddOpenTag(compilationTag);
        IncrementIdentation();
        NewLine();
        AddToken();

        while (_tokenizer.NextToken().Value != ";")
        {
            _tokenizer.Advance();
            AddToken();
        }

        _tokenizer.Advance();
        AddToken();
        DecrementIdentation();
        AddIdentedCloseTag(compilationTag);
        NewLine();
        DecrementIdentation();

        if (!_tokenizer.HasMoreTokens())
        {
            return;
        }
        _tokenizer.Advance();

        OrchestrateStatmentCompilation(_tokenizer.GetToken().Value);

    }

    private void OrchestrateStatmentCompilation(string token)
    {
        
        switch (token)
        {
            case "let":
                CompileLetStatement();
                break;
            case "while":
                CompileWhileStatement();
                break;
            case "do":
                CompileDoStatement();
                break;
            case "return":
                CompileReturnStatement();
                break;
            default:
                return;
        }
    }

    private void CompileVarDec()
    {
        var compilationTag = "varDec";
        IncrementIdentation();
        AddOpenTag(compilationTag);
        IncrementIdentation();
        NewLine();
        AddToken();
        while (_tokenizer.NextToken().Value != ";")
        {
            _tokenizer.Advance();
            AddToken();
        }

        _tokenizer.Advance();
        AddToken();
        DecrementIdentation();
        AddIdentedCloseTag(compilationTag);
        NewLine();
        DecrementIdentation();

        if (!_tokenizer.HasMoreTokens())
        {
            return;
        }
        _tokenizer.Advance();
        Eat();
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

    private void CompileCloseParentesis()
    {
        AddToken();
        if (_tokenizer.NextToken().Value.Equals("{"))
        {
            _tokenizer.Advance();
            Compile("subroutineBody");
        }
    }

    private void Compile(string compilationTag)
    {
        AddOpenTag(compilationTag);
        NewLine();

        IncrementIdentation();

        AddToken();

        NewLine();

        _tokenizer.Advance();
        Eat();

        DecrementIdentation();
        NewLine();
        AddCloseTag(compilationTag);
    }

    private void AddToken()
    {
        var token = _tokenizer.GetToken();
        Append($"{_identation}{token.Tag.Open}");
        Append(token.Value);
        Append(token.Tag.Close);
        NewLine();
    }

    private void NewLine()
    {
        Xml.AppendLine();
    }

    private void Append(string value)
    {
        Xml.Append($"{value}");
    }

    private void AddOpenTag(string token)
    {
        Xml.Append($"{_identation}<{token}>");
    }

    private void AddIdentedCloseTag(string token)
    {
        Xml.Append($"{_identation}</{token}>");
    }

    private void AddCloseTag(string token)
    {
        Xml.Append($"</{token}>");
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
