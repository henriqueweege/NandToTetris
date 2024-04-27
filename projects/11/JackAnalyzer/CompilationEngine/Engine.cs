using JackAnalyzer.CompilationEngine.Extensions;
using JackAnalyzer.JackTokenizer;
using JackAnalyzer.Variables;
using System.Text;

namespace JackAnalyzer.CompilationEngine;

internal class Engine
{

    private Tokenizer _tokenizer;
    public StringBuilder Xml = new StringBuilder();
    public StringBuilder VmCode = new StringBuilder();
    private int LocalVarCount = 0;
    private string _identation = string.Empty;
    private Dictionary<string, Variable> ClassSymbolTable = new Dictionary<string, Variable>();
    private Dictionary<string, Variable> FuncSymbolTable = new Dictionary<string, Variable>();
    private string ClassName = default!;
    private int LabelsCount = 0;
    public Engine(Tokenizer tokenizer)
    {
        _tokenizer = tokenizer;
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
            case "static":
            case "field":
                CompileClassVarDec();
                break;
            case "function":
            case "constructor":
            case "method":
                CompileSubroutineDec();
                break;
            default:
                break;


        }
        if (_tokenizer.HasMoreTokens())
        {
            _tokenizer.Advance();
            Eat();
        }

    }

    private void CompileSubroutineDec()
    {

        if (_tokenizer.IsVoidFunction())
        {
            _tokenizer.Advance();
            _tokenizer.Advance();
            var funcName = _tokenizer.GetToken().Value;
            _tokenizer.Advance();
            if (_tokenizer.IsParameterlessFunction())
            {
                _tokenizer.Advance();
                CompileSubroutine();
            }

            CompileVoidReturn();

            var stringBuilder = new StringBuilder();
            stringBuilder.Function(ClassName, funcName, LocalVarCount);
            stringBuilder.Append(VmCode);
            VmCode = stringBuilder;

            LocalVarCount = 0;
        }

    }

    private void CompileVoidReturn()
    {
        VmCode.AppendLine("return");
    }

    private void CompileSubroutine()
    {
        while (_tokenizer.GetToken().Value != "{")
        {
            _tokenizer.Advance();
        }
        _tokenizer.Advance();

        var tokenValue = GetCurrTokenValue();
        var stack = 1;
        while (stack > 0)
        {
            switch (tokenValue)
            {
                case "do":
                    CompileDoCall();
                    break;
                case "var":
                    CompileVar();
                    break;
                case "let":
                    CompileLet();
                    break;
                case "while":
                    {

                        CompileWhile();
                        tokenValue = GetCurrTokenValue();
                        continue;
                    }
                    break;
                case "{":
                    stack++;
                    break;
                case "}":
                    stack--;
                    break;
                default:
                    break;

            }
            if (GetCurrTokenValue() == "return")
            {
                return;
            }
            if(_tokenizer.GetToken().Value == "}")
            {
                stack--;
            }
            if(stack == 0)
            {
                _tokenizer.Advance();
                return;
            }

            _tokenizer.Advance();
            tokenValue = GetCurrTokenValue();
        }
    }

    private void CompileWhile()
    {
        VmCode.AppendLine($"label label{LabelsCount}");
        _tokenizer.Advance();
        var qntOfParams = 0;
        CompileExpression(ref qntOfParams);
        VmCode.AppendLine($"not");
        VmCode.AppendLine($"if-goto label{LabelsCount + 1}");
        CompileSubroutine();



        VmCode.AppendLine($"goto label{LabelsCount}"); //volta para a verificação do loop

        VmCode.AppendLine($"label label{++LabelsCount}");// a verificação do loop quebrando, segue o fluxo

        //CompileSubroutine();
    }

    private void CompileLet()
    {
        var token = GetNextToken();

        if (_tokenizer.NextToken().Value == "[")
        {
            CompileArrayAccess();

            _tokenizer.Advance();
            _tokenizer.Advance();
            _tokenizer.Advance();

            token = _tokenizer.GetToken();
            CompileRightSideOfStatement(token);

            VmCode.Pop(EMemSegments.That, 0);

            return;
        }

        var variableInfo = GetVariableInfo(token);

        _tokenizer.Advance();
        token = GetNextToken();
        CompileRightSideOfStatement(token);

        VmCode.Pop(variableInfo.Kind, variableInfo.Position);
    }

    private void CompileRightSideOfStatement(Token token)
    {
        if (token.Value.Equals("Keyboard") || token.Value.Equals("Array"))
        {
            CompileFuncCall(token);
        }
        else if (token.TokenType.Equals(TokenTypeEnum.IntConst) && !_tokenizer.NextToken().IsOp())
        {
            VmCode.Push(EMemSegments.Constant, token.Value);
        }
        else if (_tokenizer.NextToken().IsOp())
        {
            var quantOfParameters = 1;
            CompileExpression(ref quantOfParameters, false);
        }
    }

    private void CompileArrayAccess()
    {
        var token = _tokenizer.GetToken();
        var tokenInfo = GetVariableInfo(token);
        VmCode.Push(tokenInfo.Kind, tokenInfo.Position);

        _tokenizer.Advance();
        _tokenizer.Advance();

        token = _tokenizer.GetToken();
        tokenInfo = GetVariableInfo(token);
        VmCode.Push(tokenInfo.Kind, tokenInfo.Position);

        VmCode.AppendLine("add");

        VmCode.Pop(EMemSegments.Pointer, 1);



    }

    private Token CompileFuncCall(Token token)
    {
        var funcToCall = new StringBuilder();
        while (token.Value != "(")
        {
            funcToCall.Append(token.Value);
            token = GetNextToken();
        }
        var quantOfParameters = 1;
        CompileExpression(ref quantOfParameters);

        VmCode.Call(funcToCall.ToString(), quantOfParameters);
        return token;
    }

    private Variable GetVariableInfo(Token token)
    {
        var variableInfo = FuncSymbolTable.FirstOrDefault(x => x.Key.Equals(token.Value)).Value;
        if (variableInfo is null)
        {
            variableInfo = ClassSymbolTable.FirstOrDefault(x => x.Key.Equals(token.Value)).Value;
        }
        return variableInfo;
    }

    private void CompileVar()
    {
        LocalVarCount++;
        var token = GetNextToken();
        if (!token.TokenType.Equals(TokenTypeEnum.Identifier))
        {
            token = GetNextToken();
        }

        var variableType = GetVariableType(token);
        var position = GetPosition();

        FuncSymbolTable.Add(token.Value, new Variable(variableType, EMemSegments.Local, position));

        token = GetNextToken();
        if (token.Value.Equals(","))
        {
            CompileVar();
        }
        return;
    }

    private int GetPosition()
    {
        return FuncSymbolTable.LastOrDefault(x => x.Value.Kind.Equals(EMemSegments.Local)).Value is null ? 0 : FuncSymbolTable.LastOrDefault(x => x.Value.Kind.Equals(EMemSegments.Local)).Value.Position + 1;
    }

    private EVariableType GetVariableType(Token token)
    {
        EVariableType toReturn = default!;
        switch (token.TokenType)
        {
            case TokenTypeEnum.IntConst:
                toReturn = EVariableType.Int;
                break;
            default:
                break;
        }
        return toReturn;
    }

    private void CompileDoCall()
    {
        var currTokenVal = GetNextToken().Value;
        var funcName = new StringBuilder();
        var qntOfParams = 1;

        while (currTokenVal != "(")
        {
            funcName.Append(currTokenVal);
            currTokenVal = GetNextToken().Value;
        }

        CompileExpression(ref qntOfParams);

        VmCode.Call(funcName.ToString(), qntOfParams);
    }

    private bool CompileExpression(ref int quantOfParams, bool startFromNext = true)
    {
        Token currToken;
        if (startFromNext)
        {
            currToken = GetNextToken();
        }
        else
        {
            currToken = _tokenizer.GetToken();
        }

        var notToBreak = true;
        while (notToBreak)
        {
            if (currToken.Value == ",")
            {
                quantOfParams++;
            }
            else if (_tokenizer.NextToken().Value == "[")
            {
                CompileArrayAccess();
                VmCode.Push(EMemSegments.That, 0);
            }
            else if (currToken.Value == ")" || currToken.Value == "]" || currToken.Value == ";") 
            {
                return false;
            }
            else if (currToken.Value == "(" || currToken.Value == "[")
            {
                notToBreak = CompileExpression(ref quantOfParams);
            }
            else if (currToken.TokenType.Equals(TokenTypeEnum.StringConst))
            {
                CompileStringConstant();
            }
            else if (currToken.TokenType.Equals(TokenTypeEnum.Identifier))
            {
                CompileIdentifier();
            }
            else if (currToken.IsNumber())
            {
                VmCode.Push(EMemSegments.Constant, currToken.Value);
            }
            else if (currToken.IsOp())
            {
                notToBreak = CompileExpression(ref quantOfParams);
                VmCode.PushOp(currToken.Value);
            }

            currToken = GetNextToken();
        }
        return false;
    }
    private void CompileIdentifier()
    {
        var variableInfo = GetVariableInfo(_tokenizer.GetToken());
        VmCode.Push(variableInfo.Kind, variableInfo.Position);
    }

    private void CompileStringConstant()
    {
        var token = _tokenizer.GetToken();
        VmCode.Push(EMemSegments.Constant, token.Value.Length);

        VmCode.Call("String.new", 1);
        foreach (var v in token.Value)
        {
            if (v == 34)
            {
                continue;
            }
            VmCode.Push(EMemSegments.Constant, (int)v);
            VmCode.Call("String.appendChar ", 2);
        }
    }

    private Token GetNextToken()
    {
        _tokenizer.Advance();
        return _tokenizer.GetToken();
    }
    private string GetCurrTokenValue()
    {
        return _tokenizer.GetToken().Value;
    }

    private void CompileClassVarDec()
    {
        var kind = _tokenizer.GetToken().Value.Equals("static") ? EMemSegments.Static : EMemSegments.Field;

        _tokenizer.Advance();

        var type = GetVarType(_tokenizer.GetToken().Value);

        _tokenizer.Advance();
        while (_tokenizer.GetToken().Value != ";")
        {
            int position = 0;
            var lastVariableWithSameKind = ClassSymbolTable.LastOrDefault(x => x.Value.Kind.Equals(kind)).Value;

            if (lastVariableWithSameKind is not null)
            {
                position = lastVariableWithSameKind.Position + 1;
            }

            ClassSymbolTable.Add(_tokenizer.GetToken().Value, new Variable(type, kind, position));
        }

        _tokenizer.Advance();
        Eat();

    }

    private void CompileClass()
    {
        ClassSymbolTable = new();
        _tokenizer.Advance();
        ClassName = _tokenizer.GetToken().Value;
        _tokenizer.Advance();
        _tokenizer.Advance();
        Eat();
    }

    private void DecrementIdentation()
    {
        _identation = _identation.Substring(0, _identation.Length - 2);
    }
    private void IncrementIdentation()
    {
        _identation += "  ";
    }

    private EVariableType GetVarType(string var)
    {
        EVariableType type = default;
        switch (var)
        {
            case "int":
                type = EVariableType.Int;
                break;
            case "boolean":
                type = EVariableType.Boolean;
                break;
            case "char":
                type = EVariableType.Char;
                break;
            default:
                break;
        }

        return type;
    }
}
