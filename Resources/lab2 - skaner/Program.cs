using System;
using System.Collections.Generic;
using System.IO;

public enum TokenType {
    NUMBER,
    ID,
    KEYWORD_1,
    KEYWORD_2,
    KEYWORD_3,
    ADD,
    SUB,
    MUL,
    DIV,
    ADD_ASSIGN,
    SUB_ASSIGN,
    MUL_ASSIGN,
    DIV_ASSIGN,
    AND,
    OR,
    NOT,
    EQUAL,
    NOT_EQUAL,
    LESS,
    LESS_EQUAL,
    GREATER,
    GREATER_EQUAL,
    ASSIGN,
    SEMICOLON,
    COMMA,
    L_PAREN,
    R_PAREN,
    L_BRACKET,
    R_BRACKET,
    L_BRACE,
    R_BRACE,
    DOT,
    ARROW,
    COLON,
    HASH,
    DOUBLE_COLON,
    QUESTION,
    EOF,
    ERROR,
    CHAR_LITERAL,
    STRING_LITERAL,
    SPACE,
    TAB,
    TAB_TEXT,
    CR,
    CR_TEXT,
    LF,
    LF_TEXT,
    BACK_SLASH,
    BACK_SLASH_TEXT,
    AMPERSAND,
    INCREMENT,
    DECREMENT,
    MULTI_LINE_COMMENT,
    SINGLE_LINE_COMMENT,
    LIBRARY,
    UNDER_SCORE
}

public class Token {
    public TokenType Type { get; set; }
    public string Value { get; set; }
    public int Position { get; set; }

    public Token(TokenType type, string value, int position) {
        Type = type;
        Value = value;
        Position = position;
    }
}

public class Scanner {
    private readonly string input;
    private int position;

    public Scanner(string input) {
        this.input = input;
        position = 0;
    }

    public Scanner(FileStream fileStream) {
        StreamReader reader = new StreamReader(fileStream);
        input = reader.ReadToEnd();
        position = 0;
    }

    private char CurrentChar => input[position];

    // Keyword checking methods
    private bool IsKEYWORD_1(string input) {
        string[] KEYWORD_1s = { 
            "auto", "char", "double", "float", "int", "long", "short",
            "sizeof", "void", "break", "case",  "continue", "default", 
            "do", "else", "for", "if", "return",  "switch",  
            "while", "include", "define"
        };
        
        return Array.Exists(KEYWORD_1s, keyword => keyword == input);
    }

    private bool IsKEYWORD_2(string input) {
        string[] KEYWORD_2s = {            
            "struct", "goto", "union", "const", "sizeof", "typedef"
        };
        
        return Array.Exists(KEYWORD_2s, keyword => keyword == input);
    }

    private bool IsKEYWORD_3(string input) {
        string[] KEYWORD_3s = { 
            "printf", "scanf", "main", "signed", "unsigned",  "strcmp", "strlen", "strcpy"
        };
        
        return Array.Exists(KEYWORD_3s, keyword => keyword == input);
    }
    
    public Token NextToken() {
        if (position >= input.Length) {
            return new Token(TokenType.EOF, "", position);
        }

        // Number handling
        if (char.IsDigit(CurrentChar)) {
            return ScanNumber();
        }

        // Identifier and Keyword handling
        if (char.IsLetter(CurrentChar)) {
            return ScanIdentifierOrKeyword();
        }

        // String and Character literals
        if (CurrentChar == '"') {
            return ScanStringLiteral();
        }

        if (CurrentChar == '\'') {
            return ScanCharLiteral();
        }

        // Comments handling
        if (input.Substring(position).StartsWith("//")) {
            return ScanSingleLineComment();
        }

        if (input.Substring(position).StartsWith("/*")) {
            return ScanMultiLineComment();
        }

        // Library handling
        if (input.Substring(position).StartsWith("<stdio.h>")) {
            return ScanLibrary("<stdio.h>");
        }

        if (input.Substring(position).StartsWith("<string.h>")) {
            return ScanLibrary("<string.h>");
        }         

        // Character handling
        switch (CurrentChar) {
            case ' ':
                return ScanWhiteSpace(TokenType.SPACE, " ");
            case '\t':
                return ScanWhiteSpace(TokenType.TAB, "\\t");
            case '\n':
                return ScanWhiteSpace(TokenType.LF, "\\n");
            case '\r':
                return ScanWhiteSpace(TokenType.CR, "\\r");  
            case '\\':
                return ScanBackSlash();
            case '+':
                return ScanPlus();
            case '-':
                return ScanMinus();
            case '*':
                return ScanStar();
            case '/':
                return ScanSlash();
            case '&':
                return ScanAmpersand();
            case '|':
                return ScanPipe();
            case '!':
                return ScanExclamation();
            case '=':
                return ScanEqual();
            case '<':
                return ScanLess();
            case '>':
                return ScanGreater();
            case ';':
                return ScanSingleChar(TokenType.SEMICOLON, ";");
            case ',':
                return ScanSingleChar(TokenType.COMMA, ",");
            case '(':
                return ScanSingleChar(TokenType.L_PAREN, "(");
            case ')':
                return ScanSingleChar(TokenType.R_PAREN, ")");
            case '[':
                return ScanSingleChar(TokenType.L_BRACKET, "[");
            case ']':
                return ScanSingleChar(TokenType.R_BRACKET, "]");
            case '{':
                return ScanSingleChar(TokenType.L_BRACE, "{");
            case '}':
                return ScanSingleChar(TokenType.R_BRACE, "}");
            case '.':
                return ScanSingleChar(TokenType.DOT, ".");
            case ':':
                return ScanColon();
            case '#':
                return ScanSingleChar(TokenType.HASH, "#");
            case '?':
                return ScanSingleChar(TokenType.QUESTION, "?"); 
            case '_': 
                return ScanSingleChar(TokenType.UNDER_SCORE, "_");                       
            default:
                return ScanError();
        }
    }

    private Token ScanNumber() {
        int start = position;
        while (position < input.Length && char.IsDigit(input[position])) {
            position++;
        }
        return new Token(TokenType.NUMBER, input.Substring(start, position - start), start + 1);
    }

    private Token ScanIdentifierOrKeyword() {
        int start = position;
        while (position < input.Length && char.IsLetterOrDigit(input[position])) {
            position++;
        }

        string value = input.Substring(start, position - start);
        if (IsKEYWORD_1(value)) {
            return new Token(TokenType.KEYWORD_1, value, start + 1);
        }

        if (IsKEYWORD_2(value)) {
            return new Token(TokenType.KEYWORD_2, value, start + 1);
        }

        if (IsKEYWORD_3(value)) {
            return new Token(TokenType.KEYWORD_3, value, start + 1);
        }

        return new Token(TokenType.ID, value, start + 1);
    }

    private Token ScanStringLiteral() {
        int start = position;
        position++;
        while (position < input.Length && input[position] != '"') {
            if (input[position] == '\\') position++;
            position++;
        }
        if (position >= input.Length) {
            return new Token(TokenType.ERROR, "Unmatched quote", start + 1);
        }
        position++;  
        return new Token(TokenType.STRING_LITERAL, input.Substring(start, position - start), start + 1);
    }

    private Token ScanCharLiteral() {
        int start = position;
        position++;
        while (position < input.Length && input[position] != '\'') {
            position++;
        }
        if (position >= input.Length) {
            return new Token(TokenType.ERROR, "Unmatched quote", start + 1);
        }
        position++;  
        return new Token(TokenType.CHAR_LITERAL, input.Substring(start, position - start), start + 1);
    }

    private Token ScanSingleLineComment() {
        int start = position;
        position += 2;  // skip '//'
        while (position < input.Length && input[position] != '\n' && input[position] != '\r') {
            position++;
        }
        return new Token(TokenType.SINGLE_LINE_COMMENT, input.Substring(start, position - start), start + 1);
    }

    private Token ScanMultiLineComment() {
        int start = position;
        position += 2;  // skip '/*'
        while (position < input.Length && !input.Substring(position).StartsWith("*/")) {
            position++;
        }
        if (position >= input.Length) {
            return new Token(TokenType.ERROR, "Unmatched /*", start + 1);
        }
        position += 2;  // skip '*/'
        return new Token(TokenType.MULTI_LINE_COMMENT, input.Substring(start, position - start), start + 1);
    }

    private Token ScanLibrary(string libraryName) {
        int start = position;
        position += libraryName.Length;
        return new Token(TokenType.LIBRARY, input.Substring(start, position - start), start + 1);
    }

    private Token ScanWhiteSpace(TokenType tokenType, string value) {
        position++;
        return new Token(tokenType, value, position);
    }

    private Token ScanBackSlash() {
        position++;
        if (input[position] == 't') {
            position++;
            return new Token(TokenType.TAB_TEXT, "\\t", position);
        }
        if (input[position] == 'n') {
            position++;
            return new Token(TokenType.LF_TEXT, "\\n", position);
        }
        if (input[position] == 'r') {
            position++;
            return new Token(TokenType.CR_TEXT, "\\r", position);
        }
        if (input[position] == '\\') {
            position++;
            return new Token(TokenType.BACK_SLASH_TEXT, "\\\\", position);
        }
        return new Token(TokenType.BACK_SLASH, "\\", position);       
    }

    private Token ScanPlus() {
        position++;
        if (input[position] == '=') {
            position++;
            return new Token(TokenType.ADD_ASSIGN, "+=", position);
        }
        if (input[position] == '+') {
            position++;
            return new Token(TokenType.INCREMENT, "++", position);
        }
        return new Token(TokenType.ADD, "+", position);
    }

    private Token ScanMinus() {
        position++;
        if (input[position] == '=') {
            position++;
            return new Token(TokenType.SUB_ASSIGN, "-=", position);
        }   
        if (input[position] == '-') {
            position++;
            return new Token(TokenType.DECREMENT, "--", position);
        }             
        if (input[position] == '>') {
            position++;
            return new Token(TokenType.ARROW, "->", position);
        }
        return new Token(TokenType.SUB, "-", position);
    }

    private Token ScanStar() {
        position++;
        if (input[position] == '=') {
            position++;
            return new Token(TokenType.MUL_ASSIGN, "*=", position);
        }
        return new Token(TokenType.MUL, "*", position);
    }

    private Token ScanSlash() {
        position++;
        if (input[position] == '=') {
            position++;
            return new Token(TokenType.DIV_ASSIGN, "/=", position);
        }                
        return new Token(TokenType.DIV, "/", position);
    }

    private Token ScanAmpersand() {
        position++;
        if (input[position] == '&') {
            position++;
            return new Token(TokenType.AND, "&&", position);
        }
        return new Token(TokenType.AMPERSAND, "&", position);                
    }

    private Token ScanPipe() {
        position++;
        if (input[position] == '|') {
            position++;
            return new Token(TokenType.OR, "||", position);
        }
        return new Token(TokenType.ERROR, "|", position);
    }

    private Token ScanExclamation() {
        position++;
        if (input[position] == '=') {
            position++;
            return new Token(TokenType.NOT_EQUAL, "!=", position);
        }
        return new Token(TokenType.NOT, "!", position);
    }

    private Token ScanEqual() {
        position++;
        if (input[position] == '=') {
            position++;
            return new Token(TokenType.EQUAL, "==", position);
        }
        return new Token(TokenType.ASSIGN, "=", position);
    }

    private Token ScanLess() {
        position++;
        if (input[position] == '=') {
            position++;
            return new Token(TokenType.LESS_EQUAL, "<=", position);
        }
        return new Token(TokenType.LESS, "<", position);
    }

    private Token ScanGreater() {
        position++;
        if (input[position] == '=') {
            position++;
            return new Token(TokenType.GREATER_EQUAL, ">=", position);
        }
        return new Token(TokenType.GREATER, ">", position);
    }

    private Token ScanColon() {
        position++;
        if (input[position] == ':') {
            position++;
            return new Token(TokenType.DOUBLE_COLON, "::", position);
        }
        return new Token(TokenType.COLON, ":", position);
    }

    private Token ScanSingleChar(TokenType tokenType, string value) {
        position++;
        return new Token(tokenType, value, position);
    }

    private Token ScanError() {
        Token defaultToken = new(TokenType.ERROR, CurrentChar.ToString(), position + 1);
        position++;
        return defaultToken;
    }
}


public class Program {
    public static void Main(string[] args) {        
        try {
            using (FileStream fileStream = new FileStream("dane2.c", FileMode.Open, FileAccess.Read)) {
                Scanner scanner = new(fileStream);
                Token token;
                List<Token> tokenArray = new();

                do {
                    token = scanner.NextToken();
                    tokenArray.Add(token);
                } while (token.Type != TokenType.EOF);

                HtmlFormatter.FormatTokens(tokenArray, "Highlighted.html");
                Console.WriteLine("Pomyślnie utworzono plik");
            }
            return;
        } catch (Exception e) {
            Console.WriteLine($"Błąd z wczytywaniem pliku: {e.Message}");
            return;
        }
    } 
}
