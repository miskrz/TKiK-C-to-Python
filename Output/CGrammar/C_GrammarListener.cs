//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:/Users/kacpe/OneDrive/Pulpit/Kompilatory/ProjektTKiK/Grammars/C_Grammar.g4 by ANTLR 4.13.1

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
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="C_GrammarParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public interface IC_GrammarListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.start"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStart([NotNull] C_GrammarParser.StartContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.start"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStart([NotNull] C_GrammarParser.StartContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.translationUnit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTranslationUnit([NotNull] C_GrammarParser.TranslationUnitContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.translationUnit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTranslationUnit([NotNull] C_GrammarParser.TranslationUnitContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.hashStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterHashStatement([NotNull] C_GrammarParser.HashStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.hashStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitHashStatement([NotNull] C_GrammarParser.HashStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.undefStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUndefStatement([NotNull] C_GrammarParser.UndefStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.undefStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUndefStatement([NotNull] C_GrammarParser.UndefStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.ifdefStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIfdefStatement([NotNull] C_GrammarParser.IfdefStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.ifdefStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIfdefStatement([NotNull] C_GrammarParser.IfdefStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.ifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIfStatement([NotNull] C_GrammarParser.IfStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.ifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIfStatement([NotNull] C_GrammarParser.IfStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.elifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterElifStatement([NotNull] C_GrammarParser.ElifStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.elifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitElifStatement([NotNull] C_GrammarParser.ElifStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.elseStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterElseStatement([NotNull] C_GrammarParser.ElseStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.elseStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitElseStatement([NotNull] C_GrammarParser.ElseStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.ifndefStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIfndefStatement([NotNull] C_GrammarParser.IfndefStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.ifndefStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIfndefStatement([NotNull] C_GrammarParser.IfndefStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.endIfStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEndIfStatement([NotNull] C_GrammarParser.EndIfStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.endIfStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEndIfStatement([NotNull] C_GrammarParser.EndIfStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.defineStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDefineStatement([NotNull] C_GrammarParser.DefineStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.defineStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDefineStatement([NotNull] C_GrammarParser.DefineStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.includeStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIncludeStatement([NotNull] C_GrammarParser.IncludeStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.includeStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIncludeStatement([NotNull] C_GrammarParser.IncludeStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.libraryName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLibraryName([NotNull] C_GrammarParser.LibraryNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.libraryName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLibraryName([NotNull] C_GrammarParser.LibraryNameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.externalDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExternalDeclaration([NotNull] C_GrammarParser.ExternalDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.externalDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExternalDeclaration([NotNull] C_GrammarParser.ExternalDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.functionDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionDefinition([NotNull] C_GrammarParser.FunctionDefinitionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.functionDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionDefinition([NotNull] C_GrammarParser.FunctionDefinitionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.jumpStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterJumpStatement([NotNull] C_GrammarParser.JumpStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.jumpStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitJumpStatement([NotNull] C_GrammarParser.JumpStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.iterationStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIterationStatement([NotNull] C_GrammarParser.IterationStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.iterationStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIterationStatement([NotNull] C_GrammarParser.IterationStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.selectionStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSelectionStatement([NotNull] C_GrammarParser.SelectionStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.selectionStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSelectionStatement([NotNull] C_GrammarParser.SelectionStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.expressionStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpressionStatement([NotNull] C_GrammarParser.ExpressionStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.expressionStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpressionStatement([NotNull] C_GrammarParser.ExpressionStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.statementList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatementList([NotNull] C_GrammarParser.StatementListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.statementList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatementList([NotNull] C_GrammarParser.StatementListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.declarationList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDeclarationList([NotNull] C_GrammarParser.DeclarationListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.declarationList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDeclarationList([NotNull] C_GrammarParser.DeclarationListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.compoundStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCompoundStatement([NotNull] C_GrammarParser.CompoundStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.compoundStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCompoundStatement([NotNull] C_GrammarParser.CompoundStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.blockItemList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBlockItemList([NotNull] C_GrammarParser.BlockItemListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.blockItemList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBlockItemList([NotNull] C_GrammarParser.BlockItemListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.blockItem"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBlockItem([NotNull] C_GrammarParser.BlockItemContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.blockItem"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBlockItem([NotNull] C_GrammarParser.BlockItemContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.labeledStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLabeledStatement([NotNull] C_GrammarParser.LabeledStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.labeledStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLabeledStatement([NotNull] C_GrammarParser.LabeledStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatement([NotNull] C_GrammarParser.StatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatement([NotNull] C_GrammarParser.StatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.initializerList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInitializerList([NotNull] C_GrammarParser.InitializerListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.initializerList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInitializerList([NotNull] C_GrammarParser.InitializerListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.initializer"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInitializer([NotNull] C_GrammarParser.InitializerContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.initializer"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInitializer([NotNull] C_GrammarParser.InitializerContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.directAbstractDeclarator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDirectAbstractDeclarator([NotNull] C_GrammarParser.DirectAbstractDeclaratorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.directAbstractDeclarator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDirectAbstractDeclarator([NotNull] C_GrammarParser.DirectAbstractDeclaratorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.abstractDeclarator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAbstractDeclarator([NotNull] C_GrammarParser.AbstractDeclaratorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.abstractDeclarator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAbstractDeclarator([NotNull] C_GrammarParser.AbstractDeclaratorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.identifierList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdentifierList([NotNull] C_GrammarParser.IdentifierListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.identifierList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdentifierList([NotNull] C_GrammarParser.IdentifierListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.parameterDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParameterDeclaration([NotNull] C_GrammarParser.ParameterDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.parameterDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParameterDeclaration([NotNull] C_GrammarParser.ParameterDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.parameterList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParameterList([NotNull] C_GrammarParser.ParameterListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.parameterList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParameterList([NotNull] C_GrammarParser.ParameterListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.typeQualifierList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTypeQualifierList([NotNull] C_GrammarParser.TypeQualifierListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.typeQualifierList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTypeQualifierList([NotNull] C_GrammarParser.TypeQualifierListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.pointer"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPointer([NotNull] C_GrammarParser.PointerContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.pointer"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPointer([NotNull] C_GrammarParser.PointerContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.directDeclarator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDirectDeclarator([NotNull] C_GrammarParser.DirectDeclaratorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.directDeclarator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDirectDeclarator([NotNull] C_GrammarParser.DirectDeclaratorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.declarator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDeclarator([NotNull] C_GrammarParser.DeclaratorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.declarator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDeclarator([NotNull] C_GrammarParser.DeclaratorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.specifierQualifierList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSpecifierQualifierList([NotNull] C_GrammarParser.SpecifierQualifierListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.specifierQualifierList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSpecifierQualifierList([NotNull] C_GrammarParser.SpecifierQualifierListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.structSpecifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStructSpecifier([NotNull] C_GrammarParser.StructSpecifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.structSpecifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStructSpecifier([NotNull] C_GrammarParser.StructSpecifierContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.structDeclarationList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStructDeclarationList([NotNull] C_GrammarParser.StructDeclarationListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.structDeclarationList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStructDeclarationList([NotNull] C_GrammarParser.StructDeclarationListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.structDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStructDeclaration([NotNull] C_GrammarParser.StructDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.structDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStructDeclaration([NotNull] C_GrammarParser.StructDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.structDeclaratorList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStructDeclaratorList([NotNull] C_GrammarParser.StructDeclaratorListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.structDeclaratorList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStructDeclaratorList([NotNull] C_GrammarParser.StructDeclaratorListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.structDeclarator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStructDeclarator([NotNull] C_GrammarParser.StructDeclaratorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.structDeclarator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStructDeclarator([NotNull] C_GrammarParser.StructDeclaratorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.storageClassSpecifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStorageClassSpecifier([NotNull] C_GrammarParser.StorageClassSpecifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.storageClassSpecifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStorageClassSpecifier([NotNull] C_GrammarParser.StorageClassSpecifierContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.typeSpecifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTypeSpecifier([NotNull] C_GrammarParser.TypeSpecifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.typeSpecifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTypeSpecifier([NotNull] C_GrammarParser.TypeSpecifierContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.typeNameIdentifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTypeNameIdentifier([NotNull] C_GrammarParser.TypeNameIdentifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.typeNameIdentifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTypeNameIdentifier([NotNull] C_GrammarParser.TypeNameIdentifierContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.typeName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTypeName([NotNull] C_GrammarParser.TypeNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.typeName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTypeName([NotNull] C_GrammarParser.TypeNameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.declarationSpecifiers"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDeclarationSpecifiers([NotNull] C_GrammarParser.DeclarationSpecifiersContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.declarationSpecifiers"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDeclarationSpecifiers([NotNull] C_GrammarParser.DeclarationSpecifiersContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.initDeclaratorList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInitDeclaratorList([NotNull] C_GrammarParser.InitDeclaratorListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.initDeclaratorList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInitDeclaratorList([NotNull] C_GrammarParser.InitDeclaratorListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.initDeclarator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInitDeclarator([NotNull] C_GrammarParser.InitDeclaratorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.initDeclarator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInitDeclarator([NotNull] C_GrammarParser.InitDeclaratorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDeclaration([NotNull] C_GrammarParser.DeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDeclaration([NotNull] C_GrammarParser.DeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.constantExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConstantExpression([NotNull] C_GrammarParser.ConstantExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.constantExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConstantExpression([NotNull] C_GrammarParser.ConstantExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpression([NotNull] C_GrammarParser.ExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpression([NotNull] C_GrammarParser.ExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.assignmentOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignmentOperator([NotNull] C_GrammarParser.AssignmentOperatorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.assignmentOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignmentOperator([NotNull] C_GrammarParser.AssignmentOperatorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.assignmentExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignmentExpression([NotNull] C_GrammarParser.AssignmentExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.assignmentExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignmentExpression([NotNull] C_GrammarParser.AssignmentExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.conditionalExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConditionalExpression([NotNull] C_GrammarParser.ConditionalExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.conditionalExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConditionalExpression([NotNull] C_GrammarParser.ConditionalExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.logicalOrExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLogicalOrExpression([NotNull] C_GrammarParser.LogicalOrExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.logicalOrExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLogicalOrExpression([NotNull] C_GrammarParser.LogicalOrExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.logicalAndExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLogicalAndExpression([NotNull] C_GrammarParser.LogicalAndExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.logicalAndExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLogicalAndExpression([NotNull] C_GrammarParser.LogicalAndExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.equalityExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEqualityExpression([NotNull] C_GrammarParser.EqualityExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.equalityExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEqualityExpression([NotNull] C_GrammarParser.EqualityExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.relationalExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRelationalExpression([NotNull] C_GrammarParser.RelationalExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.relationalExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRelationalExpression([NotNull] C_GrammarParser.RelationalExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.additiveExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAdditiveExpression([NotNull] C_GrammarParser.AdditiveExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.additiveExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAdditiveExpression([NotNull] C_GrammarParser.AdditiveExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.multiplicativeExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMultiplicativeExpression([NotNull] C_GrammarParser.MultiplicativeExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.multiplicativeExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMultiplicativeExpression([NotNull] C_GrammarParser.MultiplicativeExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.castExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCastExpression([NotNull] C_GrammarParser.CastExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.castExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCastExpression([NotNull] C_GrammarParser.CastExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.unaryOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnaryOperator([NotNull] C_GrammarParser.UnaryOperatorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.unaryOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnaryOperator([NotNull] C_GrammarParser.UnaryOperatorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.unaryExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnaryExpression([NotNull] C_GrammarParser.UnaryExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.unaryExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnaryExpression([NotNull] C_GrammarParser.UnaryExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.argumentExpressionList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArgumentExpressionList([NotNull] C_GrammarParser.ArgumentExpressionListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.argumentExpressionList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArgumentExpressionList([NotNull] C_GrammarParser.ArgumentExpressionListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.postfixExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPostfixExpression([NotNull] C_GrammarParser.PostfixExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.postfixExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPostfixExpression([NotNull] C_GrammarParser.PostfixExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="C_GrammarParser.primaryExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrimaryExpression([NotNull] C_GrammarParser.PrimaryExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="C_GrammarParser.primaryExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrimaryExpression([NotNull] C_GrammarParser.PrimaryExpressionContext context);
}
} // namespace CGrammar
