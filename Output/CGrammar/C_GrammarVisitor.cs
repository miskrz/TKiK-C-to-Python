//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:/Users/miskr/TKiK/TKiK_repozytorium/Grammars/C_Grammar.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace CGrammar {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="C_GrammarParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public interface IC_GrammarVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.start"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStart([NotNull] C_GrammarParser.StartContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.translationUnit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTranslationUnit([NotNull] C_GrammarParser.TranslationUnitContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.hashStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHashStatement([NotNull] C_GrammarParser.HashStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.undefStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUndefStatement([NotNull] C_GrammarParser.UndefStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.ifdefStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfdefStatement([NotNull] C_GrammarParser.IfdefStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.ifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfStatement([NotNull] C_GrammarParser.IfStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.elifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElifStatement([NotNull] C_GrammarParser.ElifStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.elseStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElseStatement([NotNull] C_GrammarParser.ElseStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.ifndefStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfndefStatement([NotNull] C_GrammarParser.IfndefStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.endIfStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEndIfStatement([NotNull] C_GrammarParser.EndIfStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.defineStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDefineStatement([NotNull] C_GrammarParser.DefineStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.includeStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIncludeStatement([NotNull] C_GrammarParser.IncludeStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.libraryName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLibraryName([NotNull] C_GrammarParser.LibraryNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.externalDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExternalDeclaration([NotNull] C_GrammarParser.ExternalDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.functionDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionDefinition([NotNull] C_GrammarParser.FunctionDefinitionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.jumpStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitJumpStatement([NotNull] C_GrammarParser.JumpStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.iterationStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIterationStatement([NotNull] C_GrammarParser.IterationStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.selectionStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSelectionStatement([NotNull] C_GrammarParser.SelectionStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.expressionStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpressionStatement([NotNull] C_GrammarParser.ExpressionStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.statementList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatementList([NotNull] C_GrammarParser.StatementListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.declarationList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclarationList([NotNull] C_GrammarParser.DeclarationListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.compoundStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCompoundStatement([NotNull] C_GrammarParser.CompoundStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.blockItemList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlockItemList([NotNull] C_GrammarParser.BlockItemListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.blockItem"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlockItem([NotNull] C_GrammarParser.BlockItemContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.labeledStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLabeledStatement([NotNull] C_GrammarParser.LabeledStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement([NotNull] C_GrammarParser.StatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.initializerList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInitializerList([NotNull] C_GrammarParser.InitializerListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.initializer"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInitializer([NotNull] C_GrammarParser.InitializerContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.directAbstractDeclarator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDirectAbstractDeclarator([NotNull] C_GrammarParser.DirectAbstractDeclaratorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.abstractDeclarator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAbstractDeclarator([NotNull] C_GrammarParser.AbstractDeclaratorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.identifierList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdentifierList([NotNull] C_GrammarParser.IdentifierListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.parameterDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParameterDeclaration([NotNull] C_GrammarParser.ParameterDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.parameterList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParameterList([NotNull] C_GrammarParser.ParameterListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.typeQualifierList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTypeQualifierList([NotNull] C_GrammarParser.TypeQualifierListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.pointer"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPointer([NotNull] C_GrammarParser.PointerContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.directDeclarator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDirectDeclarator([NotNull] C_GrammarParser.DirectDeclaratorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.declarator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclarator([NotNull] C_GrammarParser.DeclaratorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.specifierQualifierList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSpecifierQualifierList([NotNull] C_GrammarParser.SpecifierQualifierListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.structSpecifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStructSpecifier([NotNull] C_GrammarParser.StructSpecifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.structDeclarationList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStructDeclarationList([NotNull] C_GrammarParser.StructDeclarationListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.structDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStructDeclaration([NotNull] C_GrammarParser.StructDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.structDeclaratorList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStructDeclaratorList([NotNull] C_GrammarParser.StructDeclaratorListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.structDeclarator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStructDeclarator([NotNull] C_GrammarParser.StructDeclaratorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.storageClassSpecifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStorageClassSpecifier([NotNull] C_GrammarParser.StorageClassSpecifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.typeSpecifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTypeSpecifier([NotNull] C_GrammarParser.TypeSpecifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.typeNameIdentifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTypeNameIdentifier([NotNull] C_GrammarParser.TypeNameIdentifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.typeName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTypeName([NotNull] C_GrammarParser.TypeNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.declarationSpecifiers"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclarationSpecifiers([NotNull] C_GrammarParser.DeclarationSpecifiersContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.initDeclaratorList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInitDeclaratorList([NotNull] C_GrammarParser.InitDeclaratorListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.initDeclarator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInitDeclarator([NotNull] C_GrammarParser.InitDeclaratorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclaration([NotNull] C_GrammarParser.DeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.constantExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstantExpression([NotNull] C_GrammarParser.ConstantExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression([NotNull] C_GrammarParser.ExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.assignmentOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignmentOperator([NotNull] C_GrammarParser.AssignmentOperatorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.assignmentExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignmentExpression([NotNull] C_GrammarParser.AssignmentExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.conditionalExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConditionalExpression([NotNull] C_GrammarParser.ConditionalExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.logicalOrExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicalOrExpression([NotNull] C_GrammarParser.LogicalOrExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.logicalAndExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicalAndExpression([NotNull] C_GrammarParser.LogicalAndExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.equalityExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEqualityExpression([NotNull] C_GrammarParser.EqualityExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.relationalExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRelationalExpression([NotNull] C_GrammarParser.RelationalExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.additiveExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAdditiveExpression([NotNull] C_GrammarParser.AdditiveExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.multiplicativeExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMultiplicativeExpression([NotNull] C_GrammarParser.MultiplicativeExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.castExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCastExpression([NotNull] C_GrammarParser.CastExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.unaryOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnaryOperator([NotNull] C_GrammarParser.UnaryOperatorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.unaryExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnaryExpression([NotNull] C_GrammarParser.UnaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.argumentExpressionList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArgumentExpressionList([NotNull] C_GrammarParser.ArgumentExpressionListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.postfixExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPostfixExpression([NotNull] C_GrammarParser.PostfixExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="C_GrammarParser.primaryExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrimaryExpression([NotNull] C_GrammarParser.PrimaryExpressionContext context);
}
} // namespace CGrammar