using System;

namespace TBON
{
    public class ExpectedTokenException : Exception
    {
        public new string Message { get { return string.Format("Expected {0} with value \"{1}\", instead got {2} \"{3}\"!", TokenType, Value, GotToken.TokenType, GotToken.Value); } }
        public Token GotToken { get; private set; }
        public TokenType TokenType { get; private set; }
        public string Value { get; private set; }

        public ExpectedTokenException(Token gotToken, TokenType tokenType, string value = "")
        {
            GotToken = gotToken;
            TokenType = tokenType;
            Value = value;
        }
    }
}

