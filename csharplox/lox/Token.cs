namespace csharplox;

class Token {
    TokenType type;
    string lexeme;
    Object literal;
    int line;

    public Token(TokenType type, string lexeme, Object literal, int line) {
        this.type  = type;
        this.lexeme = lexeme;
        this.literal = literal;
        this.line = line;
    }


    public string toString() {
        return type + " " + lexeme + " " + literal;
    }
}
