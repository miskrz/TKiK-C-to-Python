public class HtmlFormatter {
    public static void FormatTokens(List<Token> tokens, string outputPath) {
        using (StreamWriter writer = new StreamWriter(outputPath)) {
            writer.WriteLine("<!DOCTYPE html>");
            writer.WriteLine("<html>");
            writer.WriteLine("<head>");
            writer.WriteLine("<style>");
            writer.WriteLine("  body { background-color: #21252b; color: white; font-family: 'Cascadia Mono', monospace; letter-spacing: -0.25px; word-spacing: -5px; padding-left: 0px; }");            
            writer.WriteLine("  .KEYWORD_1 { color: #d55fde; }");
            writer.WriteLine("  .KEYWORD_2 { color: #2bbac5; }");
            writer.WriteLine("  .KEYWORD_3 { color: #F4D03F; }");
            writer.WriteLine("  .operator1 { color: #3498DB; }");
            writer.WriteLine("  .operator2 { color: white; }");
            writer.WriteLine("  .identifier { color: #ef596f; }");
            writer.WriteLine("  .text { color: #89ca78; }");
            writer.WriteLine("  .ws { color: #ECE73E; }");
            writer.WriteLine("  .comment { color: #196F3D; }");
            writer.WriteLine("</style>");
            writer.WriteLine("</head>");
            writer.WriteLine("<body>");

            int currline = 1;
            writer.Write(printLineNumber(currline));
            foreach (var token in tokens) {                
                writer.WriteLine(FormatToken(token));
                if (token.Type == TokenType.LF) {
                    currline++;
                    writer.Write(printLineNumber(currline));
                }
            }

            writer.WriteLine("</body>");
            writer.WriteLine("</html>");
        }
    }

    private static string printLineNumber(int currline) {
        if (currline < 10) return $"<span style='color: #CCCCCC;'>&emsp;&nbsp;{currline.ToString().PadRight(10)}&emsp;</span>";
        if (currline < 100) return $"<span style='color: #CCCCCC;'>&ensp;&nbsp{currline.ToString().PadRight(10)}&emsp;</span>";
        if (currline < 1000) return $"<span style='color: #CCCCCC;'>&nbsp;{currline.ToString().PadRight(10)}&emsp;</span>";
        return $"<span style='color: #CCCCCC;'>{currline.ToString().PadRight(10)}&emsp;&ensp;</span>";
    }


    private static string FormatToken(Token token) {
        switch (token.Type) {                                       
            case TokenType.ADD:
            case TokenType.SUB:
            case TokenType.MUL:
            case TokenType.DIV:
            case TokenType.ADD_ASSIGN:
            case TokenType.SUB_ASSIGN:
            case TokenType.MUL_ASSIGN:
            case TokenType.DIV_ASSIGN:
            case TokenType.AND:
            case TokenType.OR:
            case TokenType.NOT:                    
            case TokenType.LESS:
            case TokenType.LESS_EQUAL:
            case TokenType.GREATER:
            case TokenType.GREATER_EQUAL:
            case TokenType.ASSIGN:                    
            case TokenType.COMMA:
            case TokenType.L_PAREN:
            case TokenType.R_PAREN:
            case TokenType.L_BRACKET:
            case TokenType.R_BRACKET:
            case TokenType.L_BRACE:
            case TokenType.R_BRACE:
            case TokenType.DOT:
            case TokenType.ARROW:
            case TokenType.COLON:                    
            case TokenType.DOUBLE_COLON:
            case TokenType.QUESTION:                    
            case TokenType.BACK_SLASH:
            case TokenType.INCREMENT:
            case TokenType.DECREMENT:                                      
                return $"<span class='operator1'>{token.Value}</span>";
            case TokenType.SEMICOLON:
            case TokenType.AMPERSAND:                    
            case TokenType.EQUAL:
            case TokenType.NOT_EQUAL:
                return $"<span class='operator2'>{token.Value}</span>"; 
            case TokenType.KEYWORD_1:
            case TokenType.HASH:
                return $"<span class='KEYWORD_1'>{token.Value}</span>";
            case TokenType.KEYWORD_2:            
                return $"<span class='KEYWORD_2'>{token.Value}</span>";
            case TokenType.KEYWORD_3:
                return $"<span class='KEYWORD_3'>{token.Value}</span>";      
            case TokenType.ID:
            case TokenType.UNDER_SCORE:
                return $"<span class='identifier'>{token.Value}</span>";            
            case TokenType.SINGLE_LINE_COMMENT:
            case TokenType.MULTI_LINE_COMMENT: 
                return $"<span class='comment'>{token.Value}</span>";
            case TokenType.LF_TEXT:
            case TokenType.CR_TEXT:
            case TokenType.TAB_TEXT:                                                     
            case TokenType.BACK_SLASH_TEXT:
                return $"<span class='ws'>{token.Value}</span>"; 
            case TokenType.TAB: 
                return $"<span class='KEYWORD_1'>      </span>";
            case TokenType.CR:                        
                return "";
            case TokenType.LF:
                return $"<span class='KEYWORD_1'><br /></span>";
            case TokenType.SPACE:
                return $"<span class='KEYWORD_1'>&nbsp;</span>"; 
            case TokenType.CHAR_LITERAL:
            case TokenType.STRING_LITERAL:
                return $"<span class='text'>{token.Value}</span>";
            case TokenType.LIBRARY:
                return $"<span class='text'>{System.Net.WebUtility.HtmlEncode(token.Value)}</span>";                
            default:
                return $"<span class='text'>{token.Value}</span>";
        }
    }
}