using System;
using System.Collections.Generic;

namespace TBON
{
    public class Parser
    {
        public static List<TBONClass> ParseTBONSource(string source)
        {
            return new Parser(new Scanner().Scan(source)).Parse();
        }
        public List<Token> Tokens { get; private set; }
        public List<TBONClass> Result { get; private set; }
        public bool Eof { get { return position >= Tokens.Count; } }

        private int position;
        private Token current { get { return Tokens[position]; } }

        public Parser(List<Token> tokens)
        {
            Tokens = tokens;
            Result = new List<TBONClass>();
            position = 0;
        }

        public List<TBONClass> Parse()
        {
            while (!Eof)
                Result.Add(parseClass());
            return Result;
        }

        private TBONClass parseClass()
        {
            TBONClass result = new TBONClass(expectToken(TokenType.Identifier).Value);
            expectToken(TokenType.OpenBracket);
            while (!acceptToken(TokenType.CloseBracket))
                result.AddObject(parseObject());
            return result;
        }

        private TBONObject parseObject()
        {
            expectToken(TokenType.OpenParentheses);
            TBONObject result = new TBONObject(expectToken(TokenType.Identifier).Value);
            expectToken(TokenType.Colon);
            while (!acceptToken(TokenType.CloseParentheses))
                result.AddAttribute(parseKeyValuePair());
            return result;
        }

        private TBONKeyValuePair parseKeyValuePair()
        {
            TBONKeyValuePair result = new TBONKeyValuePair(expectToken(TokenType.Identifier).Value);
            expectToken(TokenType.Colon);
            if (matchToken(TokenType.OpenSquare))
                result.Value = parseArray();
            else
                result.Value = new TBONString(expectToken(TokenType.String).Value);
            return result;
        }

        private TBONArray parseArray()
        {
            TBONArray result = new TBONArray();
            expectToken(TokenType.OpenSquare);
            while (!acceptToken(TokenType.CloseSquare))
            {
                result.Elements.Add(new TBONString(expectToken(TokenType.String).Value));
                acceptToken(TokenType.Comma);
            }
            return result;
        }

        private bool matchToken(TokenType tokenType)
        {
            return !Eof && current.TokenType == tokenType;
        }
        private bool matchToken(TokenType tokenType, string value)
        {
            return matchToken(tokenType) && current.Value == value;
        }

        private bool acceptToken(TokenType tokenType)
        {
            bool ret = matchToken(tokenType);
            if (ret)
                position++;
            return ret;
        }
        private bool acceptToken(TokenType tokenType, string value)
        {
            bool ret = matchToken(tokenType, value);
            if (ret)
                position++;
            return ret;
        }

        private Token expectToken(TokenType tokenType)
        {
            if (matchToken(tokenType))
                return Tokens[position++];
            throw new ExpectedTokenException(current, tokenType);
        }
        private Token expectToken(TokenType tokenType, string value)
        {
            if (matchToken(tokenType, value))
                return Tokens[position++];
            throw new ExpectedTokenException(current, tokenType, value);
        }
    }
}