﻿using JackAnalyzer.JackTokenizer;
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
        //tem alguma coisa estranha acontecendo quando chamamos CompileExpression envolvendo a palavra "do"
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
            case "var": 
                CompileVarDec(); 
                break;
            case "let": case "if": case "do": case "return":
                CompileStatements();
                break;
            default:
                OrchestrateStatmentCompilation(token); break;


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
        Xml.AddOpenTag(compilationTag, _identation);
        IncrementIdentation();
        Xml.NewLine();

        while (_tokenizer.NextToken().Value != ")")
        {
            _tokenizer.Advance();
            AddToken();
            Xml.NewLine();
        }

        DecrementIdentation();
        Xml.AddCloseTag(compilationTag, _identation);
        Xml.NewLine();
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
        Xml.AddOpenTag(compilationTag, _identation);
        IncrementIdentation();
        Xml.NewLine();

        OrchestrateStatmentCompilation(_tokenizer.GetToken());

        DecrementIdentation();
        Xml.AddCloseTag(compilationTag, _identation);
        Xml.NewLine();
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
        Xml.AddOpenTag(compilationTag, _identation);
        IncrementIdentation();
        Xml.NewLine();
        AddToken();

        while (!_tokenizer.NextToken().Value.Equals(";") && !_tokenizer.GetToken().Value.Equals(";"))
        {
            _tokenizer.Advance();
            OrchestrateStatmentCompilation(_tokenizer.GetToken());
        }
        DecrementIdentation();
        Xml.AddCloseTag(compilationTag, _identation);
        Xml.NewLine();
        DecrementIdentation();

        if (!_tokenizer.HasMoreTokens())
        {
            return;
        }
        _tokenizer.Advance();

        OrchestrateStatmentCompilation(_tokenizer.GetToken());

    }

    private void CompileWhileStatement()
    {
        var compilationTag = "whileStatement";
        IncrementIdentation();
        Xml.AddOpenTag(compilationTag, _identation);
        IncrementIdentation();
        Xml.NewLine();
        AddToken();

        while (_tokenizer.NextToken().Value != "}")
        {
            _tokenizer.Advance();
            OrchestrateStatmentCompilation(_tokenizer.GetToken());


            if(!_tokenizer.HasMoreTokens())
            {
                return;
            }
        }

        _tokenizer.Advance();
        AddToken();
        DecrementIdentation();
        Xml.AddCloseTag(compilationTag, _identation);
        Xml.NewLine();
        DecrementIdentation();

        if(!_tokenizer.HasMoreTokens())
        {
            return;
        }
        _tokenizer.Advance();

        OrchestrateStatmentCompilation(_tokenizer.GetToken());

    }

    private void CompileDoStatement()
    {
        var compilationTag = "doStatement";
        IncrementIdentation();
        Xml.AddOpenTag(compilationTag, _identation);
        IncrementIdentation();
        Xml.NewLine();
        AddToken();

        while (!_tokenizer.GetToken().Value.Equals(";"))
        {
            _tokenizer.Advance();
            OrchestrateStatmentCompilation( _tokenizer.GetToken());
        }

        AddToken();
        DecrementIdentation();
        Xml.AddCloseTag(compilationTag, _identation);
        Xml.NewLine();
        DecrementIdentation();

        if (!_tokenizer.HasMoreTokens())
        {
            return;
        }
        _tokenizer.Advance();

        OrchestrateStatmentCompilation(_tokenizer.GetToken());

    }

    private void CompileReturnStatement()
    {
        var compilationTag = "returnStatement";
        IncrementIdentation();
        Xml.AddOpenTag(compilationTag, _identation);
        IncrementIdentation();
        Xml.NewLine();
        AddToken();

        while (_tokenizer.NextToken().Value != ";")
        {
            _tokenizer.Advance();
            OrchestrateStatmentCompilation(_tokenizer.GetToken());
        }

        _tokenizer.Advance();
        AddToken();
        DecrementIdentation();
        Xml.AddCloseTag(compilationTag, _identation);
        Xml.NewLine();
        DecrementIdentation();

        if (!_tokenizer.HasMoreTokens())
        {
            return;
        }
        _tokenizer.Advance();

        OrchestrateStatmentCompilation(_tokenizer.GetToken());

    }

    private void OrchestrateStatmentCompilation(Token token)
    {
        if(token.Value.Equals("(") && _tokenizer.IsFuncDec())
            CompileParamList();
        else if(
                (token.IsTerm() && !_tokenizer.IsVarName() && _tokenizer.NextToken().IsOp()) || 
                _tokenizer.IsFuncCall() || 
                _tokenizer.GetToken().Value.Equals("=") || 
                _tokenizer.GetToken().Value.Equals("[")
                )
            CompileExpression();
        else if (token.IsTerm() || _tokenizer.IsFuncCall())
            CompileTerm();
        else if(token.Value.Equals("let"))
            CompileLetStatement();
        else if(token.Value.Equals("while"))
            CompileWhileStatement();
        else if(token.Value.Equals("do"))
            CompileDoStatement();
        else if(token.Value.Equals("return"))
            CompileReturnStatement();
        else
            AddToken();
    }

    private void CompileVarDec()
    {
        var compilationTag = "varDec";
        IncrementIdentation();
        Xml.AddOpenTag(compilationTag, _identation);
        IncrementIdentation();
        Xml.NewLine();
        AddToken();
        while (_tokenizer.NextToken().Value != ";")
        {
            _tokenizer.Advance();
            OrchestrateStatmentCompilation(_tokenizer.GetToken());
        }

        _tokenizer.Advance();
        AddToken();
        DecrementIdentation();
        Xml.AddCloseTag(compilationTag, _identation);
        Xml.NewLine();
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

    private void Compile(string compilationTag)
    {
        Xml.AddOpenTag(compilationTag, _identation);
        Xml.NewLine();

        IncrementIdentation();

        AddToken();

        Xml.NewLine();

        _tokenizer.Advance();
        Eat();

        DecrementIdentation();
        Xml.NewLine();
        Xml.AddCloseTag(compilationTag, _identation);
    }

    private void AddToken()
    {
        var token = _tokenizer.GetToken();
        AddDefault(token);
    }

    private void AddDefault(Token token)
    {
        Xml.Append($"{_identation}{token.Tag.Open}");
        Xml.Append(token.Value);
        Xml.Append(token.Tag.Close);
        Xml.NewLine();
    }

    private void CompileExpression()
    {
        var expressionTag = "expression";
        var expressionListTag = "expressionList";
        var termTag = "term";

        var token = _tokenizer.GetToken();
        if(token.Value == "=")
        {
            AddDefault(token);
            _tokenizer.Advance();
            token = _tokenizer.GetToken();
        }
        if (token.Value.Equals("("))
        {
            AddDefault(token);
            _tokenizer.Advance();
            token = _tokenizer.GetToken();
        }

        if (_tokenizer.IsFuncCall())
        {
            Xml.AddOpenTag(expressionTag, _identation);
            IncrementIdentation();

            Xml.AddOpenTag(termTag, _identation);
            IncrementIdentation();
            Xml.NewLine();
            while (!_tokenizer.NextToken().Value.Equals(";") && !_tokenizer.GetToken().Value.Equals(";"))
            {
                token = _tokenizer.GetToken();

                if (token.Value.Equals("(") || token.Value.Equals("["))
                {
                    AddDefault(token);
                    Xml.NewLine();
                    Xml.AddOpenTag(expressionListTag, _identation);
                    IncrementIdentation();
                    Xml.NewLine();

                    Xml.AddOpenTag(expressionTag, _identation);
                    IncrementIdentation();
                    Xml.NewLine();

                    _tokenizer.Advance();
                    token = _tokenizer.GetToken();

                    while (!_tokenizer.GetToken().Value.Equals(")") && !_tokenizer.GetToken().Value.Equals("]"))
                    {
                        if (token.Value.Equals(","))
                        {
                            DecrementIdentation();
                            Xml.AddCloseTag(expressionTag, _identation);
                            Xml.NewLine();
                            Xml.AddOpenTag(expressionTag, _identation);
                            IncrementIdentation();
                            Xml.NewLine();
                        }
                        OrchestrateStatmentCompilation(_tokenizer.GetToken());
                        _tokenizer.Advance();
                    }
                    if (!_tokenizer.HasMoreTokens())
                    {
                        break;
                    }

                    token = _tokenizer.GetToken();
                    DecrementIdentation();
                    Xml.AddCloseTag(expressionTag, _identation);
                    Xml.NewLine();
                    DecrementIdentation();
                    Xml.AddCloseTag(expressionListTag, _identation);
                    Xml.NewLine();
                    AddDefault(token);
                }
                else if (token.IsTerm())
                {
                    CompileTerm();
                }
                else
                {
                    AddDefault(token);
                }

                
                _tokenizer.Advance();
                
            }
            DecrementIdentation();
            Xml.AddCloseTag(termTag, _identation);
            Xml.NewLine();
        }
        else if (token.Value.Equals("["))
        {
            var expressionTags = 0;

            AddDefault(token);
            Xml.NewLine();
            Xml.AddOpenTag(expressionListTag, _identation);
            IncrementIdentation();
            Xml.NewLine();

            Xml.AddOpenTag(expressionTag, _identation);
            expressionTags++;
            IncrementIdentation();
            Xml.NewLine();

            _tokenizer.Advance();
            token = _tokenizer.GetToken();

            while (!_tokenizer.GetToken().Value.Equals("]"))
            {
                if (token.Value.Equals(","))
                {
                    DecrementIdentation();
                    Xml.AddCloseTag(expressionTag, _identation);
                    Xml.NewLine();
                    IncrementIdentation();
                    expressionTags++;
                }

                if(token.IsOp() || token.IsTerm() || token.TokenType.Equals(TokenTypeEnum.Symbol))
                {

                    OrchestrateStatmentCompilation(token);
                }
                else
                {
                    CompileTerm();
                }

                _tokenizer.Advance();
                token = _tokenizer.GetToken();
            }

            token = _tokenizer.GetToken();
            for(int i = 0; i < expressionTags; i++)
            {
                DecrementIdentation();
                Xml.AddCloseTag(expressionTag, _identation);
                Xml.NewLine();
            }
            Xml.AddCloseTag(expressionListTag, _identation);
            Xml.NewLine();
            AddDefault(token);
            _tokenizer.Advance();
        }
        else
        {
            Xml.AddOpenTag(expressionTag, _identation);
            IncrementIdentation();
            Xml.NewLine();
            while (!token.Value.Equals(")") && !token.Value.Equals(";"))
            {
                if (token.TokenType.Equals(TokenTypeEnum.Symbol) || token.TokenType.Equals(TokenTypeEnum.IntConst)) 
                {
                    OrchestrateStatmentCompilation(token);
                }
                else if (token.TokenType.Equals(TokenTypeEnum.KeyWord))
                {
                    AddDefault(token);
                }
                else
                {
                    CompileTerm();
                }
                _tokenizer.Advance();
                token = _tokenizer.GetToken();
            }
        }
        
        Xml.NewLine();
        DecrementIdentation();
        Xml.AddCloseTag(expressionTag, _identation);
        Xml.NewLine();
        OrchestrateStatmentCompilation(_tokenizer.GetToken());


    }

    private void CompileTerm()
    {
        var termTag = "term";

        var token = _tokenizer.GetToken();
        Xml.NewLine();
        Xml.AddOpenTag(termTag, _identation);
        IncrementIdentation();
        Xml.NewLine();
        AddDefault(token);
        DecrementIdentation();
        Xml.AddCloseTag(termTag, _identation);
        Xml.NewLine();
    }

    private  void DecrementIdentation()
    {
        _identation = _identation.Substring(0, _identation.Length - 2);
    }
    private  void IncrementIdentation()
    {
        _identation += "  ";
    }
}
