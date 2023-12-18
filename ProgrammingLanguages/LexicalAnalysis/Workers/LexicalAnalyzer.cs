using LexicalAnalysis.Exceptions;
using LexicalAnalysis.Extensions;
using LexicalAnalysis.Interfaces;
using LexicalAnalysis.Types;
using Microsoft.VisualBasic;
using Tokens;
using Tokens.Enum;
using Tokens.Extensions;
using Tokens.Interface;
using Data = LexicalAnalysis.Models.LexicalAnalysisData;
using Constants = LexicalAnalysis.Models.Constants;

namespace LexicalAnalysis.Workers;

public class LexicalAnalyzer : ILexicalAnalyzer
{
    private string _sourceFile;
    private List<string> _data;
    private List<IToken> _tokens;
    private int _currentState;

    public LexicalAnalyzer(string sourceFile)
    {
        _sourceFile = sourceFile;
        _data = new List<string>();
        _tokens = new List<IToken>();
        _currentState = 0;
        Read();
    }

    public void Analyze()
    {
        foreach (var line in _data)
        {
            if (!string.IsNullOrEmpty(line) && line != "\n")
            {
                AnalyzeLine(line);
            }
        }

        // for (int i = 0; i < _data.Count; i++)
        // {
        //     var line = _data[i];
        //     
        //     if (!string.IsNullOrEmpty(line) && line != "\n")
        //     {
        //         AnalyzeLine(i != _data.Count - 1 ? line + Environment.NewLine : line);
        //     }
        // }
    }
    
    private void AnalyzeLine(string line)
    {
        var endProg = KeywordsEnum.EndProg.Description();
        
        if (line == endProg)
            _tokens.Add(TokenTypes.EndProg.GetToken());
        else
            line += Environment.NewLine;
        
        int left = 0, right = 0;

        while (right <= line.Length - 1)
        {
            char symbol = line[right];

            string tableKey;

            if (char.IsDigit(symbol))
                tableKey = "digits";
            else if (char.IsLetter(symbol) && _currentState != 10)
                tableKey = "letters";
            else
                tableKey = symbol.ToString();

            if (!Data.StateTransitionTable.ContainsKey(tableKey))
                tableKey = "another";

            if (_currentState == 2 && tableKey != "}")
            {
                right += 1;
                continue;
            }
            else if (_currentState == 2 && tableKey == "}")
            {
                _currentState = 0;
                right += 1;
                left = right;
                continue;
            }

            int newState = Data.StateTransitionTable[tableKey][_currentState];

            if (newState == Constants.Inf)
                throw new WrongSymbolException(symbol);

            if (newState < 0)
            {
                string lexeme = line.Substring(left,   right - left + (left == right ? 1 : 0));

                if (Data.KeywordsTokenMapping.TryGetValue(lexeme, out TokenTypes keyword))
                    _tokens.Add(keyword.GetToken());
                else
                {
                    if (Data.StateTokenMapping.TryGetValue(newState, out TokenTypes value))
                        _tokens.Add(value.GetToken());
                    else
                    {
                        if (newState == -21 || newState == -22)
                        {
                            TypesEnum type = newState == -21 ? TypesEnum.Int : TypesEnum.Float;
                            _tokens.Add(DigitalToken.GetOrCreate(lexeme, type));
                        }
                        else
                        {
                            var token = IdentifierToken.GetOrCreate(lexeme);
                            if (token != null)
                                _tokens.Add(token);
                        }
                    }
                }
                
                if (newState == -11 || newState == -12 || newState == -13 || newState == -16 ||
                    newState == -18 || newState == -20 || newState == -21 || newState == -22)
                {
                    left = right;
                }
                else
                {
                    right += 1;
                    left = right;
                }
                    
                _currentState = 0;
            }
            else
            {
                right += 1;
                _currentState = newState;
            }
        }
    }
    
    private void Read()
    {
        using var reader = new StreamReader(_sourceFile);
        
        while (!reader.EndOfStream)
        {
            string? line = reader.ReadLine();
            if (!string.IsNullOrEmpty(line))
                _data.Add(line.ChangePrefixToTabs());
        }
    }

    public void Write(string filename)
    {
        using var writer = new StreamWriter(filename);
        
        foreach (var token in _tokens)
        {
            writer.Write(token.ToString());
        }
    }

}