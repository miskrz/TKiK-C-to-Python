using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.IO;

namespace CGrammar
{
    class TestTreePrint
    {
        static void Main(string[] args)
        {
            string inputCode;

            /* Czytanie kodu z pliku
            using (StreamReader sr = new StreamReader("../../TestPrograms/test1.c"))
            {
                inputCode = sr.ReadToEnd();
            }

            // Tworzenie strumienia wejściowego z kodem
            AntlrInputStream inputStream = new AntlrInputStream(inputCode);
            */

            // Tworzenie strumienia wejściowego z przykładowym kodem w języku C
            AntlrInputStream inputStream =
                new AntlrInputStream("#include <stdio.h>\n" + "int main(void) {\n" + "int i = 0;\n" + "}");

        // Tworzenie lexer'a
            C_GrammarLexer lexer = new C_GrammarLexer(inputStream);

            // Tworzenie strumienia tokenów na podstawie lexer'a
            CommonTokenStream tokenStream = new CommonTokenStream(lexer);

            // Tworzenie parsera
            C_GrammarParser parser = new C_GrammarParser(tokenStream);

            // Rozpoczęcie analizy od reguły startowej
            IParseTree tree = parser.start();

            // Wyświetlenie drzewa parsowania
            PrintTree(tree, parser);
        }

        // Funkcja do wyświetlania drzewa parsowania
        static void PrintTree(IParseTree tree, C_GrammarParser parser)
        {
            Console.WriteLine(PrintTreeHelper(tree, parser, ""));
        }

        // Pomocnicza funkcja rekurencyjna dla wyświetlania drzewa parsowania
        static string PrintTreeHelper(IParseTree tree, C_GrammarParser parser, string indent)
        {
            string text = "";

            if (tree is ParserRuleContext)
            {
                ParserRuleContext ctx = tree as ParserRuleContext;
                string ruleName = parser.RuleNames[ctx.RuleIndex];
                text += ruleName + "\n";
                indent += "    ";

                for (int i = 0; i < ctx.ChildCount; i++)
                {
                    IParseTree child = ctx.GetChild(i);
                    text += indent + PrintTreeHelper(child, parser, indent);
                }
            }
            else if (tree is ITerminalNode)
            {
                ITerminalNode terminalNode = tree as ITerminalNode;
                IToken symbol = terminalNode.Symbol;
                string tokenName = parser.Vocabulary.GetDisplayName(symbol.Type);
                string tokenText = symbol.Text;
                text += tokenName + ": " + tokenText + "\n";
            }
            else
            {
                text += tree.ToString() + "\n";
            }

            return text;
        }
    }
}
