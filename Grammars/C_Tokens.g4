grammar C_Tokens;

//Hash statements
Hash_Include        : '#include';
Hash_Define         : '#DEFINE' | '#define';
Hash_ifndef         : '#ifndef';
Hash_endif          : '#endif';
Hash_undef          : '#undef';
Hash_ifdef          : '#ifdef';
Hash_if             : '#if';
Hash_elif           : '#elif';
Hash_else           : '#else';

//Storage Class and Type Qualifier
Const               : 'const';
Struct              : 'struct';
Typedef             : 'typedef';
Auto                : 'auto';
Extern              : 'extern';
Static              : 'static';
Register            : 'register';
Sizeof              : 'sizeof';

//Types
Void                : 'void';
Char                : 'char';
Short               : 'short';
Int                 : 'int';
Long                : 'long';
Float               : 'float';
Double              : 'double';
Signed              : 'signed';
Unsigned            : 'unsigned';
Bool                : 'bool';

//Keywords
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

//Character Definitions
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
Ampersand           : '&';
Mod                 : '%';
Arrow               : '->';
Dot                 : '.';
Exclamation         : '!';

//Logical Operators and Assignment Definitions
DecOp               : '--';
IncOp               : '++';
OrOp                : '||';
AndOp               : '&&';
NeOp                : '!=';
EqOp                : '==';
GeOp                : '>=';
LeOp                : '<=';
AddAssign           : '+=';
SubAssign           : '-=';
MulAssign           : '*=';
DivAssign           : '/=';
ModAssign           : '%=';

//Const Definitions
Identifier
    : IdentifierNondigit (IdentifierNondigit | Digit)*
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

Constant
    : IntegerConstant
    | FloatingConstant
    | CharacterConstant
    ;

fragment IntegerConstant
    : DecimalConstant IntegerSuffix?
    | '0'
    ;

fragment DecimalConstant
    : NonzeroDigit Digit*
    ;

fragment NonzeroDigit
    : [1-9]
    ;

fragment IntegerSuffix
    : UnsignedSuffix LongSuffix?
    | UnsignedSuffix LongLongSuffix
    | LongSuffix UnsignedSuffix?
    | LongLongSuffix UnsignedSuffix?
    ;

fragment UnsignedSuffix
    : [uU]
    ;

fragment LongSuffix
    : [lL]
    ;

fragment LongLongSuffix
    : 'll'
    | 'LL'
    ;

fragment FloatingConstant
    : DecimalFloatingConstant
    ;

fragment DecimalFloatingConstant
    : FractionalConstant ExponentPart? FloatingSuffix?
    | DigitSequence ExponentPart FloatingSuffix?
    ;

fragment FractionalConstant
    : DigitSequence? '.' DigitSequence
    | DigitSequence '.'
    ;

fragment ExponentPart
    : [eE] Sign? DigitSequence
    ;

fragment Sign
    : [+-]
    ;

DigitSequence
    : Digit+
    ;

fragment FloatingSuffix
    : [flFL]
    ;

fragment CharacterConstant
    : '\'' CCharSequence '\''
    ;

fragment CCharSequence
    : CChar+
    ;

fragment CChar
    : ~['\\\r\n]
    | EscapeSequence
    ;

fragment EscapeSequence
    : SimpleEscapeSequence
    ;

fragment SimpleEscapeSequence
    : '\\' ['"?abfnrtv0\\]
    ;

StringLiteral
    : '"' ('\\' . | ~('\\' | '"'))* '"'
    ;
    
LibraryName
    : ([a-zA-Z0-9/_])* '.h' 
    ;

//Ignored Elements
Whitespace
    : [ \t]+ -> skip
    ;

Newline
    : ('\r' '\n'? | '\n') -> skip
    ;

BlockComment
    : '/*' .*? '*/' -> skip
    ;

LineComment
    : '//' ~[\r\n]* -> skip
    ;