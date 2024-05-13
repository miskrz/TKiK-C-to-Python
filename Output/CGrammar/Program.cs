using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace CGrammar
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = "../../TestPrograms/inputC.c";

            AntlrFileStream input = new AntlrFileStream(inputFilePath);

            C_GrammarLexer lexer = new C_GrammarLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            C_GrammarParser parser = new C_GrammarParser(tokens);

            var startContext = parser.start();
            var visitor = new MyCGrammarVisitor();
            var result = visitor.VisitStart(startContext);
            
            Console.WriteLine(MyCGrammarVisitor.pythonText);
            
            string outputfilePath = "../../TestPrograms/outputPython.py";

            try
            {
                File.WriteAllText(outputfilePath, MyCGrammarVisitor.pythonText.ToString());
                Console.WriteLine("Plik został zapisany pomyślnie.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd podczas zapisu pliku: {ex.Message}");
            }
        }
    }

    class MyCGrammarVisitor : C_GrammarBaseVisitor<object>
    {
        public static StringBuilder pythonText = new StringBuilder();
        private static string indent = "";
        private static string indentValueS = "    ";
        private static int indentValueI = 4;
        
        // FLAGS --------------------------------------
        private bool printFlag = false;
        private bool printFlag2 = false;
        private bool printFlag3 = false;
        private bool scanfFlag = false;
        private bool scanfFlag2 = false;
        
        private string scanfStringLiteral = "";
        private bool structInitFlag = false;
        private bool declarationFlag = false;
        private bool structDeclarationFlag = false;
        private bool elifBeginningFlag = false;
        private bool caseFlag = false;
        private string tempStructIdentifierHolder = "";

        static void indentPlus()
        {
            indent += indentValueS;
        }
        
        static void indentMinus()
        {
            indent = indent.Remove(indent.Length - indentValueI);
        }
        static StringBuilder RemoveTrailingSpacesAndNewlines(StringBuilder input)
        {
            int i = input.Length - 1;

            while (i >= 0 && (input[i] == ' ' || input[i] == '\n'))
            {
                i--;
            }

            if (i < input.Length - 1)
            {
                input.Length = i + 1;
            }
            input.Append("\n" + indent);
            return input;
        }
        

        
        static string ZamienSpecyfikatoryFormatowaniaPrintf(string tekst)
        {
            string[] specyfikatory = { "%d", "%ld", "%lld", "%u", "%lu", "%llu", "%f", "%lf", "%e", "%E", "%c", "%s", "%p", "%x", "%X" };

            foreach (string specyfikator in specyfikatory)
            {
                tekst = tekst.Replace(specyfikator, "{}");
            }

            return tekst;
        }
        private static int scanfItem1 = 0;
        private static List<string> scanfTypes = new List<string>();

        
        static void ScanfFormatSpecifiers(string text)
        {
            string[] specifiers = { "%d", "%ld", "%lld", "%u", "%lu", "%llu", "%f", "%lf", "%e", "%E", "%c", "%s", "%p", "%x", "%X" };
            
            foreach (string specifier in specifiers)
            {
                if (text.Contains(specifier))
                {
                    if (specifier.Contains("d") || specifier.Contains("u") || specifier.Contains("x") || specifier.Contains("X"))
                        scanfTypes.Add("int");
                    else if (specifier.Contains("f") || specifier.Contains("e") || specifier.Contains("E"))
                        scanfTypes.Add("float");
                    else if (specifier.Contains("c") || specifier.Contains("s") || specifier.Contains("p"))
                        scanfTypes.Add("str");
                    else
                        scanfTypes.Add("bool");
                }
            }
        }

        static string MapSpecifierToType(string specifier)
        {
            if (specifier.Contains("d") || specifier.Contains("u") || specifier.Contains("x") || specifier.Contains("X"))
                return "int";
            else if (specifier.Contains("f") || specifier.Contains("e") || specifier.Contains("E"))
                return "float";
            else if (specifier.Contains("c") || specifier.Contains("s") || specifier.Contains("p"))
                return "str";
            else
                return "bool"; 
        }
        
        // EO FLAGS -----------------------------------
        
        public override object VisitStart(C_GrammarParser.StartContext context)
        {
            pythonText.Append("import sys\n");
            
            if (context.translationUnit() != null)
            {
                Visit(context.translationUnit());
            }
            
            pythonText.Append("\nmain()\n");
            return null;
        }

        public override object VisitTranslationUnit(C_GrammarParser.TranslationUnitContext context)
        {
            if (context.translationUnit() != null)
            {
                Visit(context.translationUnit());

                if (context.hashStatement() != null)
                {
                    Visit(context.hashStatement());
                }
                else if (context.externalDeclaration() != null)
                {
                    Visit(context.externalDeclaration());
                }
            }
            else if (context.hashStatement() != null)
            {
                Visit(context.hashStatement());
            }
            else if (context.externalDeclaration() != null)
            {
                Visit(context.externalDeclaration());
            }
            
            return null;
        }

        public override object VisitHashStatement([NotNull] C_GrammarParser.HashStatementContext context)
        {
            if (context.includeStatement() != null)
            {
                Visit(context.includeStatement());
            }
            else if (context.defineStatement() != null)
            {
                Visit(context.defineStatement());
            }
            else if (context.undefStatement() != null)
            {
                Visit(context.undefStatement());
            }
            else if (context.ifdefStatement() != null)
            {
                Visit(context.ifdefStatement());
            }
            else if (context.ifndefStatement() != null)
            {
                Visit(context.ifndefStatement());
            }
            else if (context.ifStatement() != null)
            {
                Visit(context.ifStatement());
            }
            else if (context.elifStatement() != null)
            {
                Visit(context.elifStatement());
            }
            else if (context.elseStatement() != null)
            {
                Visit(context.elseStatement());
            }
            else if (context.endIfStatement() != null)
            {
                Visit(context.endIfStatement());
            }


            return null;
        }

        public override object VisitIncludeStatement(C_GrammarParser.IncludeStatementContext context)
        {
            if (context.Hash_Include() != null && context.Less() != null && context.libraryName() != null &&
                context.Greater() != null)
            {
                pythonText.Append(context.GetText()+"\n");
            }
            

            return null;
        }
        public override object VisitLibraryName(C_GrammarParser.LibraryNameContext context)
        {
            if (context.LibraryName() != null)
            {
                return null;
            }
            

            return null;
        }
        
        public override object VisitDefineStatement(C_GrammarParser.DefineStatementContext context)
        {
            if (context.Hash_Define() != null && context.Identifier() != null && context.Constant() != null)
            {
                pythonText.Append($"{context.Identifier()} = {context.Constant()}\n");
            }

            return null;
        }
        public override object VisitUndefStatement(C_GrammarParser.UndefStatementContext context)
        {
            if (context.Hash_undef() != null && context.Identifier() != null)
            {
                pythonText.Append($"{context.Hash_undef()} {context.Identifier()}");
            }

            return null;
        }
        public override object VisitIfdefStatement(C_GrammarParser.IfdefStatementContext context)
        {
            if (context.Hash_ifdef() != null && context.Identifier() != null)
            {
                pythonText.Append($"{context.Hash_ifdef()} {context.Identifier()}");
            }

            return null;
        }
        public override object VisitIfndefStatement(C_GrammarParser.IfndefStatementContext context)
        {
            if (context.Hash_ifndef() != null && context.Identifier() != null)
            {
                pythonText.Append($"{context.Hash_ifndef()} {context.Identifier()}");
            }

            return null;
        }
        public override object VisitIfStatement(C_GrammarParser.IfStatementContext context)
        {
            if (context.Hash_if() != null && context.expression() != null)
            {
                pythonText.Append($"{context.Hash_if()}");
                Visit(context.expression());
            }

            return null;
        }
        public override object VisitElifStatement(C_GrammarParser.ElifStatementContext context)
        {
            if (context.Hash_elif() != null && context.expression() != null)
            {
                pythonText.Append($"{context.Hash_elif()}");
                Visit(context.expression());
            }

            return null;
        }
        public override object VisitElseStatement(C_GrammarParser.ElseStatementContext context)
        {
            if (context.Hash_else() != null)
            {
                pythonText.Append($"{context.Hash_else()}");
            }

            return null;
        }
        
        public override object VisitEndIfStatement(C_GrammarParser.EndIfStatementContext context)
        {
            if (context.Hash_endif() != null)
            {
                pythonText.Append($"{context.Hash_endif()}");
            }

            return null;
        }
        
        public override object VisitExternalDeclaration(C_GrammarParser.ExternalDeclarationContext context)
        {
            if (context.functionDefinition() != null)
            {
                Visit(context.functionDefinition());
            }
            else if (context.declaration() != null)
            {
                Visit(context.declaration());
            }
            
            return null;
        }
        
        public override object VisitFunctionDefinition([NotNull] C_GrammarParser.FunctionDefinitionContext context)
        {
            pythonText.Append("\ndef ");
            if (context.declarationSpecifiers() != null && context.declarator() != null)
            {
                declarationFlag = false;
                Visit(context.declarationSpecifiers());
                Visit(context.declarator());
                if (context.declarationList() != null)
                {
                    Visit(context.declarationList());
                }
                else
                {
                    indentPlus();
                    pythonText.Append(":\n" + indent);
                }
            }
            
            else if (context.declarator() != null)
            {
                Visit(context.declarator());
                //dodać else??
                if (context.declarationList() != null)
                {
                    Visit(context.declarationList());
                }
                
            }
            
            if (context.compoundStatement() != null)
            {
                Visit(context.compoundStatement());
            }

            indentMinus();
            pythonText.Append("\n" + indent);
            
            return null;
        }
        
        public override object VisitDeclarationSpecifiers([NotNull] C_GrammarParser.DeclarationSpecifiersContext context)
        {
            if (context.typeSpecifier() != null)
            {
                Visit(context.typeSpecifier());

            }
            else if (context.storageClassSpecifier() != null)
            {
                Visit(context.storageClassSpecifier());
            }
            else if (context.Const() != null)
            {
                
            }
            if (context.declarationSpecifiers() != null)
            {
                Visit(context.declarationSpecifiers());
            }
            
            
            return null;
        }
        
        public override object VisitTypeSpecifier([NotNull] C_GrammarParser.TypeSpecifierContext context)
        {
            if (context.Void() != null)
            {
                
            }
            else if (context.Char() != null)
            {
                
            }
            else if (context.Short() != null)
            {
                
            }
            else if (context.Int() != null)
            {
                
            }
            else if (context.Long() != null)
            {
                
            }
            else if (context.Float() != null)
            {
                
            }
            else if (context.Double() != null)
            {
                
            }
            else if (context.Signed() != null)
            {
                
            }
            else if (context.Unsigned() != null)
            {
                
            }
            else if (context.Bool() != null)
            {
                
            }
            else if (context.structSpecifier() != null)
            {
                Visit(context.structSpecifier());
            }
            else if (context.typeNameIdentifier() != null)
            {
                Visit(context.typeNameIdentifier());
            }
            
            return null;
        }
        
        public override object VisitTypeNameIdentifier([NotNull] C_GrammarParser.TypeNameIdentifierContext context)
        {
            if (context.Identifier() != null)
            {
                pythonText.Append(context.Identifier());
                if (structInitFlag)
                {
                    pythonText.Append($" = {tempStructIdentifierHolder}()");
                    tempStructIdentifierHolder = "";
                    structInitFlag = false;
                    declarationFlag = false;
                    
                }
                else if (declarationFlag)
                {
                    pythonText.Append(" = None");
                    declarationFlag = false;
                }
            }
            return null;
        }
        public override object VisitTypeName([NotNull] C_GrammarParser.TypeNameContext context)
        {
            if (context.specifierQualifierList() != null)
            {
                Visit(context.specifierQualifierList());
                if (context.abstractDeclarator() != null)
                {
                    Visit(context.abstractDeclarator());
                }
            }
            return null;
        } 
        
        public override object VisitDeclarator([NotNull] C_GrammarParser.DeclaratorContext context)
        {
            if (context.pointer() != null && context.directDeclarator() != null)
            {
                Visit(context.pointer());
            }

            if (context.directDeclarator() != null)
            {
                Visit(context.directDeclarator());
            }
            
            return null;
        }
        
        public override object VisitSpecifierQualifierList([NotNull] C_GrammarParser.SpecifierQualifierListContext context)
        {
            if (context.typeSpecifier() != null)
            {
                Visit(context.typeSpecifier());
                if (context.specifierQualifierList() != null)
                {
                    Visit(context.specifierQualifierList());
                }
            }
            else if (context.Const() != null)
            {
                if (context.specifierQualifierList() != null)
                {
                    Visit(context.specifierQualifierList());
                }
            }
            return null;
        }
        
        public override object VisitDirectDeclarator([NotNull] C_GrammarParser.DirectDeclaratorContext context)
        {
            if (context.directDeclarator() != null)
            {
                Visit(context.directDeclarator());
                if(context.LeftParen() != null)
                {
                    pythonText.Append("(");
                    if (context.parameterList() != null)
                    {
                        Visit(context.parameterList());    
                    }
                    else if (context.identifierList() != null)
                    {
                        Visit(context.identifierList());
                    }

                    if (context.RightParen() != null)
                    {
                        pythonText.Append(")");
                    }
                }
                else if (context.LeftBracket() != null && context.RightBracket() != null)
                {
                    /* C:
                     * int myArray[] = {1, 2, 3, 4, 5};
                     * Python:
                     * myArray = [1, 2, 3, 4, 5]
                     *
                     * uwaga bez tego byc moze cos jest zepsute 
                     * 
                    pythonText.Append("[");
                    if (context.constantExpression() != null)
                    {
                        Visit(context.constantExpression());
                    }

                    pythonText.Append("]");
                    */
                }
            }
            else if (context.Identifier() != null)
            {
                pythonText.Append(context.Identifier());
                if (structDeclarationFlag)
                {
                    pythonText.Append(" = None");
                }
                else if (declarationFlag)
                {
                    pythonText.Append(" = None");
                    declarationFlag = false;
                }
            }
            else if (context.LeftParen() != null && context.declarator() != null && context.RightParen() != null)
            {
                pythonText.Append("(");
                Visit(context.declarator());
                pythonText.Append(")");
            }
            
            return null;
        }
        
        public override object VisitStructSpecifier([NotNull] C_GrammarParser.StructSpecifierContext context)
        {
            //?
            if (context.Struct() != null)
            {
                if (context.Identifier() != null && context.LeftBrace() != null && context.structDeclarationList() != null &&
                    context.RightBrace() != null)
                {
                    pythonText.Append("class ");
                    pythonText.Append(context.Identifier());
                    pythonText.Append(":\n");
                    indentPlus();
                    pythonText.Append(indent+"def __init__(self):");
                    indentPlus();
                    structDeclarationFlag = true;
                    Visit(context.structDeclarationList());
                    structDeclarationFlag = false;
                    indentMinus();
                    indentMinus();
                    pythonText.Append("\n\n");
                }
                else if (context.Identifier() != null)
                {
                    structInitFlag = true;
                    tempStructIdentifierHolder = context.Identifier().ToString();
                }
                else //????
                {
                    pythonText.Append("class ");
                    pythonText.Append(":\n");
                    indentPlus();
                    pythonText.Append(indent+"def __init__(self):");
                    indentPlus();    
                    Visit(context.structDeclarationList());
                    indentMinus();
                    indentMinus();
                }
            }
            return null;
        }
        public override object VisitStructDeclarationList([NotNull] C_GrammarParser.StructDeclarationListContext context)
        {
            if (context.structDeclarationList() != null)
            {
                Visit(context.structDeclarationList());
            }

            if (context.structDeclaration() != null)
            {
                Visit(context.structDeclaration());
            }

            return null;
        }
        
        public override object VisitStructDeclaration([NotNull] C_GrammarParser.StructDeclarationContext context)
        {
            if (context.specifierQualifierList() != null)
            {
                Visit(context.specifierQualifierList());
                if (context.structDeclaratorList() != null)
                {
                    Visit(context.structDeclaratorList());
                }
            }
            return null;
        }
        public override object VisitStructDeclaratorList([NotNull] C_GrammarParser.StructDeclaratorListContext context)
        {
            if (context.structDeclaratorList() != null)
            {
                Visit(context.structDeclaratorList());
                pythonText.Append(", ");
            }

            if (context.structDeclarator() != null)
            {
                Visit(context.structDeclarator());
            }
            return null;
        }
        
        public override object VisitStructDeclarator([NotNull] C_GrammarParser.StructDeclaratorContext context)
        {
            if (context.declarator() != null)
            {
                pythonText.Append("\n"+indent +"self.");
                Visit(context.declarator());
                
            }
            // ??????
            if (context.Colon() != null && context.constantExpression() != null)
            {
                pythonText.Append(" : ");
                Visit(context.constantExpression());
            }
            return null;
        }
        
        public override object VisitParameterList([NotNull] C_GrammarParser.ParameterListContext context)
        {
            if (context.parameterList() != null && context.Comma() != null && context.parameterDeclaration() != null)
            {
                Visit(context.parameterList());
                pythonText.Append(", ");
                Visit(context.parameterDeclaration());
            }
            else if (context.parameterDeclaration() != null)
            {
                Visit(context.parameterDeclaration());
            }
            
            return null;
        }
        public override object VisitTypeQualifierList([NotNull] C_GrammarParser.TypeQualifierListContext context)
        {
            if (context.typeQualifierList() != null)
            {
                Visit(context.typeQualifierList());
            }

            if (context.Const() != null)
            {
                //??
                pythonText.Append(context.Const());
            }
            return null;
        }
        public override object VisitPointer([NotNull] C_GrammarParser.PointerContext context)
        {
            if (context.Multiply() != null)
            {
                if (context.typeQualifierList() != null)
                {
                    Visit(context.typeQualifierList());
                }

                if (context.pointer() != null)
                {
                    Visit(context.pointer());
                }
            }
            return null;
        }
        public override object VisitParameterDeclaration([NotNull] C_GrammarParser.ParameterDeclarationContext context)
        {
            if (context.declarationSpecifiers() != null)
            {
                Visit(context.declarationSpecifiers());
                if (context.declarator() != null)
                {
                    Visit(context.declarator());
                }
                else if (context.abstractDeclarator() != null)
                {
                    Visit(context.abstractDeclarator());
                }
            }
            
            return null;
        }
        
        public override object VisitCompoundStatement([NotNull] C_GrammarParser.CompoundStatementContext context)
        {
            if (context.LeftBrace() != null)
            {
                
            }
            
            if (context.blockItemList() != null)
            {
                Visit(context.blockItemList());
                
            }
            
            if (context.RightBrace() != null)
            {

            }
            
            return null;
        }
        
        public override object VisitDeclaration([NotNull] C_GrammarParser.DeclarationContext context)
        {
            if (context.declarationSpecifiers() != null && context.initDeclaratorList() != null)
            {
                declarationFlag = false;
                Visit(context.declarationSpecifiers());
                if (context.initDeclaratorList() != null)
                {
                    Visit(context.initDeclaratorList());
                }
            }
            else
            {
                declarationFlag = true;
                Visit(context.declarationSpecifiers());
            }
            if (context.Semicolon() != null)
            {
                pythonText.Append("\n" + indent);
            }
            
            return null;
        } 
        
        public override object VisitInitDeclaratorList([NotNull] C_GrammarParser.InitDeclaratorListContext context)
        {
            if (context.initDeclaratorList() != null && context.Comma() != null)
            {
                Visit(context.initDeclaratorList());
                /* Comma -> \n
                 * C: int a = 0, b = 0;
                 * Python: a = 0
                 *         b = 0
                 */
                pythonText.Append("\n" + indent);
            }

            if (context.initDeclarator() != null)
            {
                Visit(context.initDeclarator());
            }
            
            return null;
        } 
        
        public override object VisitInitDeclarator([NotNull] C_GrammarParser.InitDeclaratorContext context)
        {
            if (context.declarator() != null && context.Assign() != null && context.initializer() != null)
            {
                Visit(context.declarator());
                pythonText.Append(" = ");
                Visit(context.initializer());
            }
            else if (context.declarator() != null)
            {
                declarationFlag = true;
                Visit(context.declarator());
            }



            return null;
        }
        
        public override object VisitInitializerList([NotNull] C_GrammarParser.InitializerListContext context)
        {
            if (context.initializerList() != null && context.Comma != null)
            {
                Visit(context.initializerList());
                pythonText.Append(", ");
            }

            if (context.initializer() != null)
            {
                Visit(context.initializer());
            }
            
            return null;
        } 
        
        public override object VisitInitializer([NotNull] C_GrammarParser.InitializerContext context)
        {
            if (context.assignmentExpression() != null)
            {
                Visit(context.assignmentExpression());
            }
            else if (context.LeftBrace() != null)
            {
                pythonText.Append("[");
                if (context.initializerList() != null)
                {
                    Visit(context.initializerList());

                    if (context.Comma() != null)
                    {
                        pythonText.Append(", ");
                    }
                    
                    if (context.RightBrace() != null)
                    {
                        pythonText.Append("]");
                    }
                }
            }
            return null;
        }
        public override object VisitDirectAbstractDeclarator([NotNull] C_GrammarParser.DirectAbstractDeclaratorContext context)
        {
            if (context.directAbstractDeclarator() != null)
            {
                Visit(context.directAbstractDeclarator());
                if (context.LeftBracket() != null)
                {
                    pythonText.Append("[");
                    if (context.constantExpression() != null)
                    {
                        Visit(context.constantExpression());
                    }

                    pythonText.Append("]");
                }
                else if (context.LeftParen() != null)
                {
                    pythonText.Append("(");
                    if (context.parameterList() != null)
                    {
                        Visit(context.parameterList());
                    }
                    pythonText.Append(")");
                }
            }
            else if (context.LeftParen() != null && context.RightParen() != null)
            {
                pythonText.Append("(");
                if (context.abstractDeclarator() != null)
                {
                    Visit(context.abstractDeclarator());
                }
                else if (context.parameterList() != null)
                {
                    Visit(context.parameterList());
                }
                pythonText.Append(")");
            }
            else if (context.LeftBracket() != null && context.RightBracket() != null)
            {
                pythonText.Append("[");
                if (context.constantExpression() != null)
                {
                    Visit(context.constantExpression());
                }
                pythonText.Append("]");
            }
            
            return null;
        }
        public override object VisitAbstractDeclarator([NotNull] C_GrammarParser.AbstractDeclaratorContext context)
        {
            if (context.pointer() != null)
            {
                Visit(context.pointer());
            }

            if (context.directAbstractDeclarator() != null)
            {
                Visit(context.directAbstractDeclarator());
            }

            return null;
        }
        
        public override object VisitIdentifierList([NotNull] C_GrammarParser.IdentifierListContext context)
        {
            if (context.identifierList() != null && context.Comma() != null)
            {
                Visit(context.identifierList());
                pythonText.Append(", ");
            }

            if (context.Identifier() != null)
            {
                pythonText.Append(context.Identifier());
            }

            return null;
        }
        
        public override object VisitStorageClassSpecifier([NotNull] C_GrammarParser.StorageClassSpecifierContext context)
        {
            if (context.Typedef() != null)
            {
                return null;
            }
            else if (context.Extern() != null)
            {
                return null;
            }
            else if (context.Static() != null)
            {
                return null;
            }
            else if (context.Auto() != null)
            {
                return null;
            }
            else if (context.Register() != null)
            {
                return null;
            }
            

            return null;
        }
        
        public override object VisitConstantExpression([NotNull] C_GrammarParser.ConstantExpressionContext context)
        {
            if (context.conditionalExpression() != null)
            {
                Visit(context.conditionalExpression());
            }
            
            return null;
        }
        
        public override object VisitExpression([NotNull] C_GrammarParser.ExpressionContext context)
        {
            if (context.expression() != null && context.Comma() != null)
            {
                Visit(context.expression());
                pythonText.Append(", ");
            }

            if (context.assignmentExpression() != null)
            {
                Visit(context.assignmentExpression());
            }
            
            return null;
        }
        
        public override object VisitAssignmentOperator([NotNull] C_GrammarParser.AssignmentOperatorContext context)
        {
            if (context.Assign() != null)
            {
                pythonText.Append(" = ");
            }
            else if (context.MulAssign() != null)
            {
                pythonText.Append(" *= ");
            }
            else if (context.DivAssign() != null)
            {
                pythonText.Append(" /= ");
            }
            else if (context.ModAssign() != null)
            {
                pythonText.Append(" %= ");
            }
            else if (context.AddAssign() != null)
            {
                pythonText.Append(" += ");
            }
            else if (context.SubAssign() != null)
            {
                pythonText.Append(" -= ");
            }
            
            return null;
        }
        
        public override object VisitAssignmentExpression([NotNull] C_GrammarParser.AssignmentExpressionContext context)
        {
            if (context.conditionalExpression() != null)
            {
                Visit(context.conditionalExpression());
            }
            else if (context.unaryExpression() != null && context.assignmentOperator() != null &&
                     context.assignmentExpression() != null)
            {
                Visit(context.unaryExpression());
                Visit(context.assignmentOperator());
                Visit(context.assignmentExpression());
            }
            
            return null;
        }
        
        public override object VisitConditionalExpression([NotNull] C_GrammarParser.ConditionalExpressionContext context)
        {
            if (context.logicalOrExpression() != null)
            {
                Visit(context.logicalOrExpression());
                if (context.QuestionMark() != null && context.expression() != null && context.Colon() != null &&
                    context.conditionalExpression() != null)
                {
                    pythonText.Append(" ? ");
                    Visit(context.expression());
                    pythonText.Append(" : ");
                    Visit(context.conditionalExpression());
                }
            }
            
            return null;
        }
        
        public override object VisitLogicalOrExpression([NotNull] C_GrammarParser.LogicalOrExpressionContext context)
        {
            if (context.logicalOrExpression() != null && context.OrOp() != null)
            {
                Visit(context.logicalOrExpression()); 
                // prob 'or'
                pythonText.Append(" || ");
            }

            if (context.logicalAndExpression() != null)
            {
                Visit(context.logicalAndExpression());
            }
            
            return null;
        }
        
        public override object VisitLogicalAndExpression([NotNull] C_GrammarParser.LogicalAndExpressionContext context)
        {
            if (context.logicalAndExpression() != null && context.AndOp() != null)
            {
                Visit(context.logicalAndExpression()); 
                // prob 'and'
                pythonText.Append(" && ");
            }

            if (context.equalityExpression() != null)
            {
                Visit(context.equalityExpression());
            }
            
            return null;
        }
        
        public override object VisitEqualityExpression([NotNull] C_GrammarParser.EqualityExpressionContext context)
        {
            if (context.equalityExpression() != null)
            {
                Visit(context.equalityExpression());
                if (context.EqOp() != null)
                { 
                    // prob 'is'
                    pythonText.Append(" == ");
                }
                else if (context.NeOp() != null)
                { 
                    // prob 'is not'
                    pythonText.Append(" != ");
                }
            }

            if (context.relationalExpression() != null)
            {
                Visit(context.relationalExpression());
            }
            
            return null;
        }
        
        public override object VisitRelationalExpression([NotNull] C_GrammarParser.RelationalExpressionContext context)
        {
            if (context.relationalExpression() != null)
            {
                Visit(context.relationalExpression());

                if (context.Less() != null)
                {
                    pythonText.Append(" < ");
                }
                else if (context.Greater() != null)
                {
                    pythonText.Append(" > ");
                }
                else if (context.LeOp() != null)
                {
                    pythonText.Append(" <= ");
                }
                else if (context.GeOp() != null)
                {
                    pythonText.Append(" >= ");
                }
            }

            if (context.additiveExpression() != null)
            {
                Visit(context.additiveExpression());
            }
            
            return null;
        }
        
        public override object VisitAdditiveExpression([NotNull] C_GrammarParser.AdditiveExpressionContext context)
        {
            if (context.additiveExpression() != null)
            {
                Visit(context.additiveExpression());

                if (context.Plus() != null)
                {
                    pythonText.Append(" + ");
                }
                else if (context.Minus() != null)
                {
                    pythonText.Append(" - ");
                }
            }

            if (context.multiplicativeExpression() != null)
            {
                Visit(context.multiplicativeExpression());
            }
            
            return null;
        }
        
        public override object VisitMultiplicativeExpression([NotNull] C_GrammarParser.MultiplicativeExpressionContext context)
        {
            if (context.multiplicativeExpression() != null)
            {
                Visit(context.multiplicativeExpression());

                if (context.Multiply() != null)
                {
                    pythonText.Append(" * ");
                }
                else if (context.Divide() != null)
                {
                    pythonText.Append(" / ");
                }
                else if (context.Mod() != null)
                {
                    pythonText.Append(" % ");
                }
            }

            if (context.castExpression() != null)
            {
                Visit(context.castExpression());
            }
            
            return null;
        }
        
        public override object VisitCastExpression([NotNull] C_GrammarParser.CastExpressionContext context)
        {
            if (context.unaryExpression() != null)
            {
                Visit(context.unaryExpression());
            }
            else if (context.LeftParen() != null && context.typeName() != null && context.RightParen() != null &&
                     context.castExpression() != null)
            {
                pythonText.Append(" ( ");
                Visit(context.typeName());
                pythonText.Append(" ) ");
                Visit(context.castExpression());
            }
            
            return null;
        }
        
        public override object VisitUnaryOperator([NotNull] C_GrammarParser.UnaryOperatorContext context)
        {
            if (context.Ampersand() != null)
            {
                if (!scanfFlag)
                {
                    pythonText.Append("&");
                }
            }
            else if (context.Multiply() != null)
            {
                pythonText.Append("*");
            }
            else if (context.Plus() != null)
            {
                pythonText.Append("+");
            }
            else if (context.Minus() != null)
            {
                pythonText.Append("-");
            }
            else if (context.Exclamation() != null)
            {
                pythonText.Append("!");
            }
            
            return null;
        }

        public override object VisitUnaryExpression([NotNull] C_GrammarParser.UnaryExpressionContext context)
        {
            if (context.postfixExpression() != null)
            {
                Visit(context.postfixExpression());
            }
            else if (context.IncOp() != null && context.unaryExpression() != null)
            {
                pythonText.Append(" ++");
                Visit(context.unaryExpression());
            }
            else if (context.DecOp() != null && context.unaryExpression() != null)
            {
                pythonText.Append(" --");
                Visit(context.unaryExpression());
            }
            else if (context.unaryOperator() != null && context.castExpression() != null)
            {
                Visit(context.unaryOperator());
                Visit(context.castExpression());
            }
            else if (context.Sizeof() != null && context.unaryExpression() != null)
            {
                pythonText.Append("sys.getsizeof");
                Visit(context.unaryExpression());
            }
            else if (context.Sizeof() != null && context.LeftParen() != null && context.typeName() != null &&
                     context.RightParen() != null)
            {
                pythonText.Append("sys.getsizeof(x)(");
                Visit(context.typeName());
                pythonText.Append(")");
            }

            return null;
        }
        
        public override object VisitArgumentExpressionList([NotNull] C_GrammarParser.ArgumentExpressionListContext context)
        {
            if (context.argumentExpressionList() != null && context.Comma() != null)
            {
                Visit(context.argumentExpressionList());
                
                if(!scanfFlag)
                {
                    if (printFlag)
                    {
                        pythonText.Append(".format(");
                        printFlag = false;
                        printFlag2 = true;
                    }
                    else
                    {
                        pythonText.Append(", ");
                    }
                }
                else
                {
                    if (scanfFlag2)
                    {
                        scanfFlag2 = false;
                    }
                    else
                    {
                        pythonText.Append($" = {scanfTypes[scanfItem1]}(input(\"\"))");
                        scanfItem1++;
                        pythonText.Append("\n" + indent);
                    }
                }
            }

            if (context.assignmentExpression() != null)
            {
                Visit(context.assignmentExpression());
            }
            
            return null;
        }
        
        public override object VisitPostfixExpression([NotNull] C_GrammarParser.PostfixExpressionContext context)
        {
            if (context.postfixExpression() != null)
            {
                Visit(context.postfixExpression());
                if (context.LeftBracket() != null && context.expression() != null && context.RightBracket() != null)
                {
                    pythonText.Append("[");
                    Visit(context.expression());
                    pythonText.Append("]");
                }
                else if (context.LeftParen() != null)
                {
                    if(!scanfFlag)
                    {
                        pythonText.Append("(");
                    }
                    
                    if (context.argumentExpressionList() != null)
                    {
                        Visit(context.argumentExpressionList());
                        
                        if (printFlag2)
                        {
                            pythonText.Append(")");
                            printFlag2 = false;
                        }
                    }

                    if (context.RightParen() != null)
                    {
                        if(!scanfFlag)
                        {
                            if(printFlag3)
                            {
                                pythonText.Append(", end = '')");
                                printFlag3 = false;
                            }
                            else
                            {
                                pythonText.Append(")");
                            }
                        }
                        else
                        {
                            pythonText.Append($" = {scanfTypes[scanfItem1]}(input(\"\"))");
                            scanfItem1 = 0;
                            scanfTypes.Clear();
                            scanfFlag = false;
                            scanfFlag2 = false;
                            scanfStringLiteral = "";
                        }
                    }
                }
                else if (context.Dot() != null && context.Identifier() != null)
                {
                    pythonText.Append($".{context.Identifier()}");
                }
                else if (context.Arrow() != null && context.Identifier() != null)
                {
                    pythonText.Append($"->{context.Identifier()}");
                }
                else if (context.IncOp() != null)
                {
                    // x++ -> x += 1
                    pythonText.Append(" += 1");
                }
                else if (context.DecOp() != null)
                {
                    // x-- -> x -= 1
                    pythonText.Append(" -= 1");
                }
            }
            else if (context.primaryExpression() != null)
            {
                Visit(context.primaryExpression());
            }
            
            return null;
        }
        
        public override object VisitPrimaryExpression([NotNull] C_GrammarParser.PrimaryExpressionContext context)
        {
            if (context.Identifier() != null)
            {
                if (context.Identifier().GetText() == "printf")
                {
                    pythonText.Append("print");
                    printFlag = true;
                    printFlag3 = true;
                }
                else if (context.Identifier().GetText() == "scanf")
                {
                    scanfFlag = true;
                    scanfFlag2 = true;
                }
                else
                {
                    printFlag = false;
                    pythonText.Append(context.Identifier());
                }
            }
            else if (context.Constant() != null)
            {
                pythonText.Append(context.Constant());
            }
            else if (context.StringLiteral() != null)
            {
                if(!scanfFlag)
                {
                    if (printFlag)
                    {
                        pythonText.Append(ZamienSpecyfikatoryFormatowaniaPrintf(context.StringLiteral().GetText()));
                    }
                    else
                    {
                        pythonText.Append(context.StringLiteral().GetText());
                    }
                }
                else
                {
                    ScanfFormatSpecifiers(context.StringLiteral().GetText());
                }
            }
            else if (context.LeftParen() != null && context.expression() != null && context.RightParen() != null)
            {
                pythonText.Append("(");
                Visit(context.expression());
                pythonText.Append(")");
            }
            
            return null;
        }
        
        public override object VisitExpressionStatement([NotNull] C_GrammarParser.ExpressionStatementContext context)
        {
            if (context.expression() != null)
            {
                Visit(context.expression());
            }

            if (context.Semicolon() != null)
            {
                pythonText.Append("\n" + indent);
            }
            
            return null;
        }
        
        public override object VisitJumpStatement([NotNull] C_GrammarParser.JumpStatementContext context)
        {
            if (context.Continue() != null)
            {
                pythonText.Append("continue");
            }
            else if (context.Break() != null)
            {
                if (!caseFlag)
                {
                    pythonText.Append("break");
                }
                else
                {
                    string ending = "\n"+indent;
                    if (pythonText.ToString().EndsWith(ending))
                    {
                        pythonText.Remove(pythonText.Length - ending.Length, ending.Length);
                    }
                }
            }
            else if (context.Return() != null)
            {
                pythonText.Append("return ");
                if (context.expression() != null)
                {
                    Visit(context.expression());
                }
            }

            if (context.Semicolon() != null)
            {
                pythonText.Append("\n" + indent);
            }
            
            return null;
        }
        
        public override object VisitIterationStatement([NotNull] C_GrammarParser.IterationStatementContext context)
        {
            if (context.Do() != null && context.statement() != null && context.While() != null && context.LeftParen() != null &&
                     context.expression() != null && context.RightParen() != null && context.Semicolon() != null)
            {
                pythonText.Append("do ");
                Visit(context.statement());
                pythonText.Append("while (");
                Visit(context.expression());
                pythonText.Append(")\n" + indent);
            }
            else if (context.While() != null && context.LeftParen() != null && context.expression() != null &&
                  context.RightParen() != null && context.statement() != null)
            {
                pythonText.Append("while (");
                Visit(context.expression());
                pythonText.Append(")");
                Visit(context.statement());
            }
            else if (context.For() != null && context.LeftParen() != null)
            {
                pythonText.Append("for(");
                if (context.declaration() != null && context.expressionStatement() != null)
                {
                    Visit(context.declaration());
                    Visit(context.expressionStatement(0));
                    if (context.expression() != null)
                    {
                        Visit(context.expression());
                    }
                }
                else if (context.expressionStatement() != null && context.expressionStatement() != null)
                {
                    Visit(context.expressionStatement(0));
                    Visit(context.expressionStatement(1));
                    if (context.expression() != null)
                    {
                        Visit(context.expression());
                    }
                }
                
                if(context.RightParen() != null && context.statement() != null)
                {
                    pythonText.Append(")");
                    Visit(context.statement());
                }
            }
            
            return null;
        }
        
        public override object VisitSelectionStatement([NotNull] C_GrammarParser.SelectionStatementContext context)
        {
            if (context.If() != null && context.LeftParen() != null)
            {
                if (elifBeginningFlag)
                {
                    string ending = "else: ";
                    if (pythonText.ToString().EndsWith(ending))
                    {
                        pythonText.Remove(pythonText.Length - ending.Length, ending.Length);
                    }
                    pythonText.Append("elif ");
                    elifBeginningFlag = false;
                }
                else
                {
                    pythonText.Append("if ");
                }
                if (context.expression() != null && context.RightParen() != null && context.statement() != null)
                {
                    Visit(context.expression());
                    pythonText.Append(":");
                    Visit(context.statement(0)); 
                    string ending = indentValueS;
                    if (pythonText.ToString().EndsWith(ending))
                    {
                        pythonText.Remove(pythonText.Length - ending.Length, ending.Length);
                    }
                }
                string ending2 = indent+"\n"+indent;
                if (pythonText.ToString().EndsWith(ending2))
                {
                    pythonText.Remove(pythonText.Length - ending2.Length, ending2.Length);
                }
                
                
                string ending3 = indentValueS+indentValueS+indentValueS+"\n"+indentValueS;
                string ending4 = "\n"; 
                if (pythonText.ToString().EndsWith(ending3))
                {
                    pythonText.Remove(pythonText.Length - ending3.Length, 3*indentValueS.Length+ending4.Length);
                }
            
                if (context.Else() != null && context.statement() != null)
                {

                    pythonText.Append("else: ");
                    elifBeginningFlag = true;
                    Visit(context.statement(1));
                    pythonText.Append("\n" + indent);
                }

                
            }
            else if (context.Switch() != null && context.LeftParen() != null && context.expression() != null &&
                     context.RightParen() != null && context.statement() != null)
            {
                pythonText.Append("match ");
                Visit(context.expression());
                pythonText.Append(":");
                Visit(context.statement(0));
                indentMinus();
            }
            return null;
        }
        
        public override object VisitStatementList([NotNull] C_GrammarParser.StatementListContext context)
        {
            if (context.statementList() != null)
            {
                Visit(context.statementList());
            }

            if (context.statement() != null)
            {
                Visit(context.statement());
            }


            
            return null;
        }
        public override object VisitDeclarationList([NotNull] C_GrammarParser.DeclarationListContext context)
        {
            if (context.declarationList() != null)
            {
                Visit(context.declarationList());
            }

            if (context.declaration() != null)
            {
                Visit(context.declaration());
            }
            
            return null;
        }
        
        public override object VisitStatement([NotNull] C_GrammarParser.StatementContext context) 
        {
            if (context.labeledStatement() != null)
            {
                Visit(context.labeledStatement());
            }
            else if (context.compoundStatement() != null)
            {
                elifBeginningFlag = false;
                indentPlus();
                pythonText.Append("\n" + indent);
                Visit(context.compoundStatement());
                indentMinus();
            }
            else if (context.expressionStatement() != null)
            {
                Visit(context.expressionStatement());
            }
            else if (context.selectionStatement() != null)
            {
                Visit(context.selectionStatement());
                pythonText = RemoveTrailingSpacesAndNewlines(pythonText);
                caseFlag = false;
            }
            else if (context.iterationStatement() != null)
            {
                Visit(context.iterationStatement());
            }
            else if (context.jumpStatement() != null)
            {
                Visit(context.jumpStatement());
            }
            
            return null;
        }
        public override object VisitLabeledStatement([NotNull] C_GrammarParser.LabeledStatementContext context)
        {
            if (caseFlag)
            {
                indentMinus();
                caseFlag = false;
                string ending = indentValueS;
                if (pythonText.ToString().EndsWith(ending))
                {
                    pythonText.Remove(pythonText.Length - ending.Length, ending.Length);
                }
            }
            if (context.Identifier() != null)
            {
                pythonText.Append(context.Identifier());
            }
            else if (context.Case() != null && context.constantExpression() != null)
            {
                pythonText.Append("case ");
                
                
                Visit(context.constantExpression());
            }
            else if (context.Default() != null)
            {
                pythonText.Append("case _");
            }

            if (context.Colon() != null && context.statement() != null)
            {
                pythonText.Append(": ");
                indentPlus();
                pythonText.Append("\n" + indent);
                caseFlag = true;
                Visit(context.statement());
            }
            
            return null;
        }
        
        public override object VisitBlockItem([NotNull] C_GrammarParser.BlockItemContext context)
        {
            
            if (context.statementList() != null)
            {
                Visit(context.statementList());
            }
            else if (context.declarationList() != null)
            {
                Visit(context.declarationList());
            }
            
            return null;
        }
        
        public override object VisitBlockItemList([NotNull] C_GrammarParser.BlockItemListContext context)
        {
            if (context.blockItemList() != null)
            {
                Visit(context.blockItemList());
            }

            if (context.blockItem() != null)
            {
                Visit(context.blockItem());
            }
            return null;
        }
    }
}
