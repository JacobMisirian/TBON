using System;
using System.Collections.Generic;
using System.Text;

namespace TBON
{
    public class Scanner
    {
        private string code;
        private int position;
        private List<Token> result;

        public List<Token> Scan(string source)
        {
            code = source;
            position = 0;
            result = new List<Token>();

            while (peekChar() != -1)
            {
                whiteSpace();
                if (char.IsLetterOrDigit((char)peekChar()))
                    scanIdentifier();
                else
                {
                    switch ((char)peekChar())
                    {
                        case '\"':
                            scanString();
                            break;
                        case ',':
                            result.Add(new Token(TokenType.Comma, ((char)readChar()).ToString()));
                            break;
                        case ':':
                            result.Add(new Token(TokenType.Colon, ((char)readChar()).ToString()));
                            break;
                        case '(':
                            result.Add(new Token(TokenType.OpenParentheses, ((char)readChar()).ToString()));
                            break;
                        case ')':
                            result.Add(new Token(TokenType.CloseParentheses, ((char)readChar()).ToString()));
                            break;
                        case '{':
                            result.Add(new Token(TokenType.OpenBracket, ((char)readChar()).ToString()));
                            break;
                        case '}':
                            result.Add(new Token(TokenType.CloseBracket, ((char)readChar()).ToString()));
                            break;
                        case '[':
                            result.Add(new Token(TokenType.OpenSquare, ((char)readChar()).ToString()));
                            break;
                        case ']':
                            result.Add(new Token(TokenType.CloseSquare, ((char)readChar()).ToString()));
                            break;
                        default:
                            Console.WriteLine("Unknown char: {0}", (char)readChar());
                            break;
                    }
                }
            }

            return result;
        }

        private void scanIdentifier()
        {
            StringBuilder sb = new StringBuilder();
            while (char.IsLetterOrDigit((char)peekChar()) && peekChar() != -1)
                sb.Append((char)readChar());
            result.Add(new Token(TokenType.Identifier, sb.ToString()));
        }

        private void scanString()
        {
            StringBuilder sb = new StringBuilder();
            readChar(); // "
            while ((char)peekChar() != '\"' && peekChar() != -1)
                sb.Append((char)readChar());
            readChar(); // "
            result.Add(new Token(TokenType.String, sb.ToString()));
        }

        private void whiteSpace()
        {
            while (char.IsWhiteSpace((char)peekChar()))
                readChar();
        }

        private int peekChar(int n = 0)
        {
            return position + n < code.Length ? code[position + n] : -1;
        }
        private int readChar()
        {
            return position < code.Length ? code[position++] : -1;
        }
    }
}

