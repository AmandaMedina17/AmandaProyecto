using System.Linq.Expressions;
using System.Text.Json;

class Parser
{
    public class ParseError : Exception{}
    public List<Token> tokens; 
    private int Current = 0;

    public Parser(List<Token> tokens)
    {
        this.tokens = tokens;
    }

    public Expresion parse() 
    {
        try {
        return expresion();
        } catch (ParseError error) {
        return null;
        }
    }

    
    // expresión → igualdad
    private Expresion expresion()
    {
        return igualdad();
    }

    //igualdad → comparación ( ( "!=" | "==" ) comparación )*
    private Expresion igualdad()
    {
        Expresion expr = comparacion();
        while (coincide(TokenType.Bang_igual, TokenType.Igual_igual)) 
        { 
            Token operador = anterior();
            Expresion derecha = comparacion();
            expr = new Expresion.ExpresionBinaria(expr, derecha, operador);

        }
        return expr;
    }

    private bool coincide(params TokenType[] tipos) 
    { 
        foreach (TokenType tipo in tipos) {
            if (verifica(tipo)) 
            { 
                avanza(); 
                return true;

            }
        }
        return false;
    }

    private bool verifica(TokenType tipo) 
    { 
        if (esFinal()) return false;
        return mira().Tipo == tipo;

    }

    private Token avanza() 
    {
        if (!esFinal()) Current++; 
        return anterior();

    }

    private bool esFinal() 
    { 
        return mira().Tipo == TokenType.Fin;
    }
    private Token mira() 
    {
        return tokens[Current];
    }
    private Token anterior() 
    {
        return tokens[Current - 1];
    }

    //comparación → término ( ( ">" | ">=" | "<" | "<=" ) término )*
    private Expresion comparacion()
    {
        Expresion expr = termino();

        while (coincide(TokenType.Mayor, TokenType.Mayor_igual, TokenType.Menor, TokenType.Menor_igual)) 
        {
            Token operador = anterior(); 
            Expresion derecha = termino();
            expr = new Expresion.ExpresionBinaria(expr, derecha, operador);

        }
        return expr;
    }

    //término → factor ( ("-" | "+" ) factor )*
    private Expresion termino() 
    { 
        Expresion expr = factor();
        while (coincide(TokenType.Menos, TokenType.Más)) 
        { 
            Token operador = anterior(); 
            Expresion derecha = factor();
            expr = new Expresion.ExpresionBinaria(expr, derecha, operador);
        }
        return expr;
    }

    //factor → unario ( ( "/" | "*" ) unario )* 
    private Expresion factor() 
    { 
        Expresion expr = unario();
        while (coincide(TokenType.Slach, TokenType.Asterizco)) 
        { 
            Token operador = anterior(); 
            Expresion derecha = unario();
            expr = new Expresion.ExpresionBinaria(expr, derecha, operador);
        }
        return expr;
    }

    //unario → ( "!" | "-" ) unario| primaria
    private Expresion unario() 
    {
        if (coincide(TokenType.Bang, TokenType.Menos)) 
        { 
            Token operador = anterior(); 
            Expresion derecha = unario();
            return new Expresion.ExpresionUnaria(operador, derecha);
        
        }
        return primario();
    }

    //primario → NUMBER | STRING | "true" | "false" | "nil"| "(" expresión ")"
    private Expresion primario() 
    {
        if (coincide(TokenType.False)) return new Expresion.ExpresionLiteral(false); 
        if (coincide(TokenType.True)) return new Expresion.ExpresionLiteral(true); 
        if (coincide(TokenType.Null)) return new Expresion.ExpresionLiteral(null);
        
        if (coincide(TokenType.Número, TokenType.Cadena)) 
        {
            return new Expresion.ExpresionLiteral(anterior().Literal);
        }
        
        if (coincide(TokenType.Parentesis_abierto)) 
        { 
            Expresion expr = expresion();
            consume(TokenType.Parentesis_cerrado, "Expect ')' after expression."); 
            return new Expresion.ExpresionAgrupacion(expr);
        }

        throw error(mira(), "Espera expresion");
    }

    private Token consume(TokenType tipo, string mensaje) 
    { 
        if (verifica(tipo)) return avanza();

        throw error(mira(), mensaje);
    }

    private ParseError error(Token token, String mensaje) 
    { 
        Inicio.error(token, mensaje);
        return new ParseError();
    }

    private void sincronizar() {
        avanza();

        while (!esFinal()) {
        if (anterior().Tipo == TokenType.Punto_y_coma) return;

        switch (mira().Tipo) 
        {
            case TokenType.Class:
            case TokenType.Fun:
            case TokenType.Var:
            case TokenType.For:
            case TokenType.If:
            case TokenType.While:
            case TokenType.Return:
            return;
        }

        avanza();
        }
    }

    
        
}