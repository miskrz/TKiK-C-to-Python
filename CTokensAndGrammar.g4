grammar CTokensAndGrammar;

start
    :   translationUnit? EOF
    ;

translationUnit
    :   includeStatement
    |   defineStatement
    |   statement
    |   translationUnit includeStatement
    |   translationUnit defineStatement
    |   translationUnit statement
    ;
    
defineStatement
    : Hash_Define value (value|string)
    ;

includeStatement
                : Hash_Include (Less libraryName Greater)
                ;
                
libraryName     : Identifier;

statement
         : switchStatement
         | declaration Semicolon
         | functionDefinition
         | ifElseSwitchStatement
         | primaryExpression
         | assignExpression Semicolon
         | jumpStatement
         | loopStatement
         | additionalStatement 
         | typedefStructDefinition
         | structDefinition        
         | BlockComment 
         | LineComment
         ;

additionalStatement
    : (
        Printf LeftParen string ( Comma expression )* RightParen
    |   Scanf LeftParen string ( Comma value postfixOperation?)* RightParen
    |   Srand LeftParen value RightParen
    |   Exit LeftParen value RightParen
    ) Semicolon
    ;


loopStatement
    : For LeftParen (declaration|assignExpression)? Semicolon expression? Semicolon (expression|assignExpression)? RightParen (statement|compoundStatement)
    | While LeftParen (expression|assignExpression) RightParen (statement|compoundStatement)
    | Do (statement|compoundStatement) While LeftParen (expression|assignExpression) RightParen Semicolon
    ;
         
switchStatement
    : Case (expression) Colon (statement|compoundStatement)
    | Default Colon statement
    ;

jumpStatement
    : (
        | Continue
        | Break
        | Return (expression|value)?
    ) Semicolon
    ;

ifElseSwitchStatement
    : If LeftParen expression RightParen (statement|compoundStatement) (BlockComment | LineComment)* (Else (statement|compoundStatement))?
    | Switch LeftParen expression RightParen compoundStatement
    ;
         
functionDefinition
    :  (typePrefix)* typeSpecifier expression parameterTypeList (compoundStatement|Semicolon)
    ;

parameterTypeList
    : LeftParen functionParameterList? RightParen
    ;

functionParameterList
    : declaration (Comma declaration)*
    ;
    
structDefinition
    : Struct value compoundStatement Semicolon
    ;

typedefStructDefinition
    : Typedef Struct value compoundStatement value Semicolon
    ;

compoundStatement
    : LeftBrace statementList? RightBrace
    ;
    
statementList
    : statement+
    ;

expressionList
    : expression (Comma expression)*
    ;

typeSpecifier
    : 'void'
    | 'char'
    | 'short'
    | 'int'
    | 'long'
    | 'long long int'
    | 'float'
    | 'double'
    | 'FILE'
    | 'struct' + value
    | 'auto'
    | value
    ;
 
 value
     :   (       
       prefixOperation? Identifier arrayStatement? parenStatement?
     | IntegerConstant
     | FloatConstant
     ) 
     ; 
 
typePrefix
    : 'const'
    | 'unsigned'
    | 'static'
    | 'inline'
    ; 
    
prefixOperation
    : Multiply + Multiply
    | Multiply
    | PlusPlus
    | MinusMinus
    | Ampersand
    | Exclamation
    | LeftParen (typePrefix)* typeSpecifier prefixOperation? RightParen //cast
    ;
    
postfixOperation
    : (
      Assign 
    | Multiply + Assign
    | Divide + Assign
    | Plus + Assign
    | Minus + Assign
    | Mod + Assign
    | PlusPlus 
    | MinusMinus
    | Arrow expression   
    | Dot expression
    ) 
    ; 

arrayStatement
    : (LeftBracket (expression|value)? RightBracket) (LeftBracket (expression|value)? RightBracket)* (postfixOperation expression)? (Assign arrayAssign)?
    ;
 
arrayAssign
    :  LeftBrace (
       (arrayAssign Comma)* arrayInitList
     | arrayAssign (Comma arrayAssign)*
     ) RightBrace
    ;
 
arrayInitList
    : expression (Comma expression)*
    ; 
     
parenStatement
      : prefixOperation? (      
        LeftParen RightParen
      | (LeftParen ((typeSpecifier prefixOperation?)|value|expressionList) RightParen)
      )      
      ;             
          
declaration    
           :   (typePrefix)* typeSpecifier value postfixOperation (arrayAssign|expression) (Comma value postfixOperation (arrayAssign|expression))*
           |   (typePrefix)* typeSpecifier value (Comma value)* postfixOperation (arrayAssign|expression) (Comma expression)*
           |   (typePrefix)* typeSpecifier value (Comma value)*
           |   (typePrefix)* typeSpecifier
           |   (typePrefix)* typeSpecifier postfixOperation (arrayAssign|expression)
           ;  

expression
    :   expression opr=( '*' | '/' | '%' ) expression                       # mulDivExpr
    |   expression opr=( '+' | '-' ) expression                             # addminExp
    |   expression opr=( '<' | '>' | '<=' | '>=' | '!=' | '==') expression  # condExpr
    |   expression opr=( '&&' | '||' | '|' | '&') expression                # andOrExpr
    |   value primaryExpression?                                            # valueExpr
    |   prefixOperation? primaryExpression                                  # primExpr
    |   prefixOperation                                                     # preOpExpr
    |   parenStatement expression?                                          # parenExpr
    |   additionalStatement expression?                                     # addStatExpr
    |   value postfixOperation expression                                   # postExpr
    ;
    
string
      : StringLiteral
      | CharLiteral
      ;

primaryExpression   
      : value postfixOperation? expression?
      | parenStatement postfixOperation? expression?
      | string
      ;
      
assignExpression    
      : value postfixOperation arrayAssign? prefixOperation? (expression)?
      ;

//Tokens 
Hash_Include        : '#include';
Hash_Define         : '#DEFINE' | '#define';
Return              : 'return';
If                  : 'if';
Else                : 'else';
Switch              : 'switch';
For                 : 'for';
While               : 'while';
Case                : 'case';
Default             : 'default';
Continue            : 'continue';
Break               : 'break';
Do                  : 'do';
Printf              : 'printf';
Scanf               : 'scanf';
Srand               : 'srand';
Exit                : 'exit';
Struct              : 'struct';
Typedef              : 'typedef';
Less                : '<';
Greater             : '>';
Semicolon           : ';';
Comma               : ',';
Assign              : '=';
QuestionMark        : '?';
Colon               : ':';
Multiply            : '*';
Divide              : '/';
Plus                : '+';
Minus               : '-';
LeftParen           : '(';
RightParen          : ')';
LeftBrace           : '{';
RightBrace          : '}';
LeftBracket         : '[';
RightBracket        : ']';
SingleQuote         : '\'';
DoubleQuote         : '"';
PlusPlus            : '++';
MinusMinus          : '--';
Ampersand           : '&';
Mod                 : '%';
Arrow               : '->';
Dot                 : '.';
Exclamation         : '!';

Identifier
    : IdentifierNondigit (IdentifierNondigit | Digit)*
    | Library_Identifier
    ;

fragment IdentifierNondigit
    : Nondigit
    ; 

fragment Nondigit
    : [a-zA-Z_]
    ;

fragment Digit
    : [0-9]
    ;
    
fragment
NonzeroDigit
    :   [1-9]
    ;
    
fragment
DigitSequence
    :   Digit+
    ;

fragment
Constant
    :   IntegerConstant
    |   FloatConstant
    ;

fragment 
Library_Identifier
    : ([a-zA-Z0-9/_])* '.h'
    ;
   
IntegerConstant
    :   ('-' ' '*)? NonzeroDigit Digit*
    |   '0'
    ;

FloatConstant
    :   ('-' ' '*)? DigitSequence? '.' DigitSequence
    |   DigitSequence '.'
    ;
                
StringLiteral
    : DoubleQuote ~["\r\n]* DoubleQuote
    ;

CharLiteral
    : SingleQuote '\\'? ~['\r\n] SingleQuote
    ;

Whitespace      : [ \t\r\n]+ -> skip;

BlockComment
    :   '/*' .*? '*/'
    ;

LineComment
    :   '//' ~[\r\n]*
    ;