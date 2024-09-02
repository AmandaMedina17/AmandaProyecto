using System.Dynamic;
using System.Text.RegularExpressions;
using System.Collections;

public class Escaner
{
    public string fuente{ get; set; }
    public List<Token> Tokens = new List<Token>();
    private int start = 0;
    private int current = 0;
    private int linea = 1;
    public Escaner(string fuente) 
    {
        this.fuente = fuente;
    }

    private bool isAtEnd() 
    {
        return current >= fuente.Length;
    }

    public List<Token> escanearTokens() 
    {
        while (!isAtEnd()) 
        {
            start = current;
            escanearTokens();
        }
            
        Tokens.Add(new Token(TokenType.Fin, "", null, linea));
        return Tokens;
        
    }

    private void Tokenescaneado() 
    {
        char c = advance();
        switch (c) 
        {
            //Un caracter
            case '(': addToken(TokenType.Parentesis_abierto); 
            break;
            case ')': addToken(TokenType.Parentesis_cerrado); 
            break;
            case '{': addToken(TokenType.Llave_abierta); 
            break;
            case '}': addToken(TokenType.Llave_cerrada); 
            break;
            case ',': addToken(TokenType.Coma); 
            break;
            case '.': addToken(TokenType.Punto); 
            break;
            case '-': addToken(TokenType.Menos); 
            break;
            case ';': addToken(TokenType.Punto_y_coma); 
            break;
            case '*': addToken(TokenType.Asterizco); 
            break;

            
            //Dos caracteres
            case '!': addToken(match('=') ? TokenType.Bang_igual : TokenType.Bang);
            break;
            case '=': addToken(match('=') ? TokenType.Igual_igual : TokenType.Igual);
            break;
            case '<': addToken(match('=') ? TokenType.Menor_igual : TokenType.Menor);
            break;
            case '>': addToken(match('=') ? TokenType.Mayor_igual : TokenType.Mayor);
            break;
            case '+': addToken(match('+') ? TokenType.Mas_mas : TokenType.Más);
            break;
            case '&': addToken(match('&') ? TokenType.And : throw new ArgumentException(linea + "caracter inesperado"));
            break;
            case '|': addToken(match('|') ? TokenType.Or : throw new ArgumentException(linea + "caracter inesperado"));
            break;
            case '@': addToken(match('@') ? TokenType.Concatenacion_Espaciado : TokenType.Concatenacion);
            break;

            case '/':
            if (match('/')) {
            // Un comentario va hasta el final de la línea.
            while (peek() != '\n' && !isAtEnd()) advance();} 
            else 
            {
            addToken(TokenType.Slach);
            }
            break;


            //Nuevas lineas y espacios en blanco
            case ' ':
            case '\r':
            case '\t':
            break;
            case '\n':
            linea++;
            break;

            

            //Literales de cadena
            case '"': String();
            break;

            //Literales numericos
            default:
            if (isDigit(c)) 
            {
                número();
            } 
            else if (isAlpha(c)) 
            {
                identificador();
            }
            else 
            {
                throw new ArgumentException(linea + "Caracter inesperado");
            }
            break;

        
            
        }
    }
    private bool isAlpha(char c) 
    {
        return (c >= 'a' && c <= 'z') ||
        (c >= 'A' && c <= 'Z') ||
        c == '_';
    }

    private bool isAlphaNumeric(char c) 
    {
        return isAlpha(c) || isDigit(c);
    }

    private void identificador() 
    {
        while (isAlphaNumeric(peek())) advance();
        string text = fuente.Substring(start, current);
        TokenType type = keywords[text];
        if (type == null) type = TokenType.Identificador;
        addToken(type);
    }


    private void número() 
    {
        while (isDigit(peek())) advance();
        // Busca una parte fraccionaria.
        if (peek() == '.' && isDigit(peekNext())) {
        // Consume el "."
        advance();
        
        while (isDigit(peek())) advance();
        }
        addToken(TokenType.Número, double.Parse(fuente.Substring(start, current)));
    }

    private char peekNext() 
    {
        if (current + 1 >= fuente.Length) return '\0';
        return fuente[current + 1];
    }
    private bool isDigit(char c) 
    {
        return c >= '0' && c <= '9';
    }

    private void String() 
    {
        while (peek() != '"' && !isAtEnd()) 
        {
            if (peek() == '\n') linea++;
            advance();
            }
            if (isAtEnd()) {
            throw new ArgumentException(linea + "Cadena sin terminar.");
        }

        advance();

        string value = fuente.Substring(start + 1, current - 1);
        addToken(TokenType.Cadena, value);    
    }

    private char peek() 
    {
        if (isAtEnd()) return '\0';
        return fuente[current];
    }

    public char advance() 
    {
        current++;
        return fuente[current - 1];
    }
    
    private void addToken(TokenType type) 
    {
        addToken(type, null);
    }
    
    private void addToken(TokenType type, Object literal) 
    {
        String text = fuente.Substring(start, current);
        Tokens.Add(new Token(type, text, literal, linea));
    }

    private bool match(char expected) 
    {
        if (isAtEnd()) return false;
        if (fuente[current] != expected) return false;

        current++;
        return true;
    }
        
    private static Dictionary<string, TokenType> keywords;
   
    private void palabrasReservadas()
    {
        keywords = new Dictionary<string, TokenType>();

        keywords.Add("class", TokenType.Class);
        keywords.Add("false", TokenType.False);
        keywords.Add("for", TokenType.For);
        keywords.Add("else", TokenType.Else);
        keywords.Add("return", TokenType.Return);
        keywords.Add("true", TokenType.True);
        keywords.Add("while", TokenType.While);
        keywords.Add("effect", TokenType.Effect);
        keywords.Add("Name", TokenType.Name);
        keywords.Add("Params", TokenType.Params);
        keywords.Add("Amount", TokenType.Amount);
        keywords.Add("Action", TokenType.Action);
        keywords.Add("card", TokenType.Card);
        keywords.Add("Type", TokenType.Type);
        keywords.Add("Faction", TokenType.Faction);
        keywords.Add("Power", TokenType.Power);
        keywords.Add("Range", TokenType.Range);
        keywords.Add("OnActivation", TokenType.OnActivation);
        keywords.Add("Efect", TokenType.Effect_card);
        keywords.Add("Selector", TokenType.Selector);
        keywords.Add("Source", TokenType.Source);
        keywords.Add("Single", TokenType.Single);
        keywords.Add("Predicate", TokenType.Predicate);
        keywords.Add("PostAction", TokenType.PosAction);

    }
}