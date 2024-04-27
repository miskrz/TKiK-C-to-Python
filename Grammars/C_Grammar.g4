grammar C_Grammar;
import C_Tokens;

start: translationUnit? EOF;

translationUnit
    : hashStatement
    | externalDeclaration
    | translationUnit hashStatement
    | translationUnit externalDeclaration
    ;

//preprocessor 
hashStatement
    : includeStatement
    | defineStatement
    | undefStatement
    | ifdefStatement
    | ifndefStatement
    | ifStatement
    | elifStatement
    | elseStatement
    | endIfStatement
    ;
    
undefStatement
    : Hash_undef Identifier
    ;
    
ifdefStatement 
    : Hash_ifdef Identifier
    ;

ifStatement
    : Hash_if expression
    ;

elifStatement
    : Hash_elif expression
    ;
    
elseStatement
    : Hash_else
    ;
    
ifndefStatement 
    : Hash_ifndef Identifier
    ;
  
endIfStatement
    : Hash_endif
    ;
    
defineStatement
    : Hash_Define Identifier Constant
    ;

includeStatement
    : Hash_Include Less libraryName Greater
    ;

libraryName     
    : LibraryName
    ;

//Parser rules
externalDeclaration
	: functionDefinition
	| declaration
	;
	
functionDefinition
	: declarationSpecifiers declarator declarationList compoundStatement
	| declarationSpecifiers declarator compoundStatement
	| declarator declarationList compoundStatement
	| declarator compoundStatement
	;
	
jumpStatement
	: Continue Semicolon
	| Break Semicolon
	| Return Semicolon
	| Return expression Semicolon
	;
	
iterationStatement
	: While LeftParen expression RightParen statement
	| Do statement While LeftParen expression RightParen Semicolon
	| For LeftParen (expressionStatement|declaration) expressionStatement RightParen statement
	| For LeftParen (expressionStatement|declaration) expressionStatement expression RightParen statement
	;
	
selectionStatement
	: If LeftParen expression RightParen statement
	| If LeftParen expression RightParen statement Else statement
	| Switch LeftParen expression RightParen statement
	;
	
expressionStatement
	: Semicolon
	| expression Semicolon
	;
	
statementList
	: statement
	| statementList statement
	;
	
declarationList
	: declaration
	| declarationList declaration
	;
	
compoundStatement
	: LeftBrace blockItemList? RightBrace
	;

blockItemList
    :   blockItem
    |   blockItemList blockItem
    ;

blockItem
    : statementList
    | declarationList
    ;
    
labeledStatement
	: Identifier Colon statement
	| Case constantExpression Colon statement
	| Default Colon statement
	;
	
statement
	: labeledStatement
	| compoundStatement
	| expressionStatement
	| selectionStatement
	| iterationStatement
	| jumpStatement
	;
	
initializerList
	: initializer
	| initializerList Comma initializer
	;
	
initializer
	: assignmentExpression
	| LeftBrace initializerList RightBrace
	| LeftBrace initializerList Comma RightBrace
	;

directAbstractDeclarator
	: LeftParen abstractDeclarator RightParen
	| LeftBracket RightBracket
	| LeftBracket constantExpression RightBracket
	| directAbstractDeclarator LeftBracket RightBracket
	| directAbstractDeclarator LeftBracket constantExpression RightBracket
	| LeftParen RightParen
	| LeftParen parameterList RightParen
	| directAbstractDeclarator LeftParen RightParen
	| directAbstractDeclarator LeftParen parameterList RightParen
	;
	
abstractDeclarator
	: pointer
	| directAbstractDeclarator
	| pointer directAbstractDeclarator
	;
	
identifierList
	: Identifier
	| identifierList Comma Identifier
	;
	
parameterDeclaration
	: declarationSpecifiers declarator
	| declarationSpecifiers abstractDeclarator
	| declarationSpecifiers
	;
	
parameterList
	: parameterDeclaration
	| parameterList Comma parameterDeclaration
	;
	
typeQualifierList
	: Const
	| typeQualifierList Const
	;
	
pointer
	: Multiply
	| Multiply typeQualifierList
	| Multiply pointer
	| Multiply typeQualifierList pointer
	;
	
directDeclarator
	: Identifier
	| LeftParen declarator RightParen
	| directDeclarator LeftBracket constantExpression RightBracket
	| directDeclarator LeftBracket RightBracket
	| directDeclarator LeftParen parameterList RightParen
	| directDeclarator LeftParen identifierList RightParen
	| directDeclarator LeftParen RightParen
	;
	
declarator
	: pointer directDeclarator
	| directDeclarator
	;
	
specifierQualifierList
	: typeSpecifier specifierQualifierList
	| typeSpecifier
	| Const specifierQualifierList
	| Const
	;
	
structSpecifier
	: Struct Identifier LeftBrace structDeclarationList RightBrace
	| Struct LeftBrace structDeclarationList RightBrace
	| Struct Identifier
	;

structDeclarationList
	: structDeclaration
	| structDeclarationList structDeclaration
	;

structDeclaration
	: specifierQualifierList structDeclaratorList Semicolon
	;
	
structDeclaratorList
	: structDeclarator
	| structDeclaratorList Comma structDeclarator
	;
	
structDeclarator
	: declarator
	| Colon constantExpression
	| declarator Colon constantExpression
	;
	
storageClassSpecifier
	: Typedef
	| Extern
	| Static
	| Auto
	| Register
	;

typeSpecifier
	: Void
	| Char
	| Short
	| Int
	| Long
	| Float
	| Double
	| Signed
	| Unsigned
	| Bool
	| structSpecifier
	| typeNameIdentifier
	;

typeNameIdentifier
    : Identifier
    ;
    
typeName
	: specifierQualifierList
	| specifierQualifierList abstractDeclarator
	;
	
declarationSpecifiers
	: storageClassSpecifier
	| storageClassSpecifier declarationSpecifiers
	| typeSpecifier
	| typeSpecifier declarationSpecifiers
	| Const
	| Const declarationSpecifiers
	;
	
initDeclaratorList
	: initDeclarator
	| initDeclaratorList Comma initDeclarator
	;

initDeclarator
	: declarator
	| declarator Assign initializer
	;
	
declaration
	: declarationSpecifiers Semicolon
	| declarationSpecifiers initDeclaratorList Semicolon
	;
	
constantExpression
	: conditionalExpression
	;
	
expression
	: assignmentExpression
	| expression Comma assignmentExpression
	;
	
assignmentOperator
	: Assign
	| MulAssign
	| DivAssign
	| ModAssign
	| AddAssign
	| SubAssign
	;
	
assignmentExpression
	: conditionalExpression
	| unaryExpression assignmentOperator assignmentExpression
	;
	
conditionalExpression
	: logicalOrExpression
	| logicalOrExpression QuestionMark expression Colon conditionalExpression
	;
	
logicalOrExpression
	: logicalAndExpression
	| logicalOrExpression OrOp logicalAndExpression
	;
	
logicalAndExpression
	: equalityExpression
	| logicalAndExpression AndOp equalityExpression
	;
	
equalityExpression
	: relationalExpression
	| equalityExpression EqOp relationalExpression
	| equalityExpression NeOp relationalExpression
	;
	
relationalExpression
	: additiveExpression
	| relationalExpression Less additiveExpression
	| relationalExpression Greater additiveExpression
	| relationalExpression LeOp additiveExpression
	| relationalExpression GeOp additiveExpression
	;
	
additiveExpression
	: multiplicativeExpression
	| additiveExpression Plus multiplicativeExpression
	| additiveExpression Minus multiplicativeExpression
	;
	
multiplicativeExpression
	: castExpression
	| multiplicativeExpression Multiply castExpression
	| multiplicativeExpression Divide castExpression
	| multiplicativeExpression Mod castExpression
	;
	
castExpression
	: unaryExpression
	| LeftParen typeName RightParen castExpression
	;
	
unaryOperator
	: Ampersand
	| Multiply
	| Plus
	| Minus
	| Exclamation
	;
	
unaryExpression
	: postfixExpression
	| IncOp unaryExpression
	| DecOp unaryExpression
	| unaryOperator castExpression
	| Sizeof unaryExpression
	| Sizeof LeftParen typeName RightParen
	;
	
argumentExpressionList
	: assignmentExpression
	| argumentExpressionList Comma assignmentExpression
	;
	
postfixExpression
	: primaryExpression
	| postfixExpression LeftBracket expression RightBracket
	| postfixExpression LeftParen RightParen
	| postfixExpression LeftParen argumentExpressionList RightParen
	| postfixExpression Dot Identifier
	| postfixExpression Arrow Identifier
	| postfixExpression IncOp
	| postfixExpression DecOp
	;
	
primaryExpression
	: Identifier
	| Constant
	| StringLiteral
	| LeftParen expression RightParen
	;