public class Interprete : Expresion.IVisitante<Object>
{
    public object visitarAsignacionExpresion(Expresion.AsignarExpresion obj)
    {
        throw new NotImplementedException();
        
    }

    public object visitarExpresionAgrupacion(Expresion.ExpresionAgrupacion obj)
    {
        return evaluar(obj.expresion);
    }

    public object visitarExpresionBinaria(Expresion.ExpresionBinaria obj)
    {
        object izquierda = evaluar(obj.izquierda);
        object derecha = evaluar(obj.derecha); 

        switch (obj.operador.Tipo) 
        {
            case TokenType.Mayor:
                comprobarNumero(obj.operador, izquierda, derecha);
                return (double)izquierda > (double)derecha;
            case TokenType.Mayor_igual:
                comprobarNumero(obj.operador, izquierda, derecha);
                return (double)izquierda >= (double)derecha;
            case TokenType.Menor:
                comprobarNumero(obj.operador, izquierda, derecha);
                return (double)izquierda < (double)derecha;
            case TokenType.Menor_igual:
                comprobarNumero(obj.operador, izquierda, derecha);
                return (double)izquierda <= (double)derecha;
            case TokenType.Menos:
                comprobarNumero(obj.operador, izquierda, derecha);
                return (double)izquierda - (double)derecha;
            case TokenType.Bang_igual: 
                return !esIgual(izquierda, derecha);
            case TokenType.Igual_igual: 
                return esIgual(izquierda, derecha);
            case TokenType.Más:
                if (izquierda is double && derecha is double) 
                {
                    return (double)izquierda + (double)derecha;
                } 
                throw new RuntimeError(obj.operador, "Los operandos deben ser dos números o dos cadenas.");
            break;
            case TokenType.Slach:
                comprobarNumero(obj.operador, izquierda, derecha);
                return (double)izquierda / (double)derecha;
            case TokenType.Asterizco:
                comprobarNumero(obj.operador, izquierda, derecha);
                return (double)izquierda * (double)derecha;
        }

        return null;        
    }

    public object visitarExpresionLiteral(Expresion.ExpresionLiteral obj)
    {
        return obj.valor;
    }

    public object visitarExpresionLogica(Expresion.ExpresionLogica obj)
    {
        throw new NotImplementedException();
    }

    public object visitarExpresionUnaria(Expresion.ExpresionUnaria obj)
    {
        object derecha = evaluar(obj.derecha);
        switch (obj.operador.Tipo) 
        { 
            case TokenType.Bang:
            return !esVerdad(derecha);        
            case TokenType.Menos:
            return -(double)derecha;    
        }
        return null;    
    }

    public object visitarExpresionVariable(Expresion.ExpresionVariable obj)
    {
        throw new NotImplementedException();
    }

    public object visitarGetExpresion(Expresion.GetExpresion obj)
    {
        throw new NotImplementedException();
    }

    public object visitarLlamarExpresion(Expresion.LlamarExpresion obj)
    {
        throw new NotImplementedException();
    }

    public object visitarSetExpresion(Expresion.SetExpresion obj)
    {
        throw new NotImplementedException();
    }

    public object visitarSuperExpresion(Expresion.SuperExpresion obj)
    {
        throw new NotImplementedException();
    }

    public void interpretar(Expresion expresion) 
    { 
        try 
        {
            object value = evaluar(expresion);
            Console.WriteLine(encadenar(value));        
        } 
        catch (RuntimeError error) 
        {
            Inicio.runtimeError(error);
        }
    }

    private object evaluar(Expresion obj) 
    { 
        return obj.Aceptar(this);
    }

    private bool esVerdad(object obj) 
    { 
        if (obj == null) return false;
        if (obj is bool boleanValue) return (bool)obj; 
        return true;
    }

    private bool esIgual(object a, object b) 
    {
        if (a == null && b == null) return true;
        if (a == null) return false;

        return a.Equals(b);
    }

    private void comprobarNumero(Token operador, object operando) 
    {
        if (operando is double) return;
        throw new RuntimeError(operador, "El operando debe ser un número.");
    }

    private void comprobarNumero(Token operador, object izquierda, object derecha) 
    {
        if (izquierda is double && derecha is double) return;
        throw new RuntimeError(operador, "El operando debe ser un número.");
    }

    private string encadenar(object obj) 
    { 
        if (obj == null) return "null";
        if (obj is double) 
        { 
            string texto = obj.ToString(); 
            if (texto.EndsWith(".0")) 
            {
                texto = texto.Substring(0, texto.Length - 2);
            }
            return texto;

        }
        return obj.ToString();
    }
}