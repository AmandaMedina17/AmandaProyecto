using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Inicio {

    Escaner escaner;
    Parser parser; 
    Final CartasyEfectos;
    public bool EsValido = true;
    public List<BaseCard> CreatedCards;
    
    public Inicio(List<string> CartasHechas = null, List<string> EfectosHechos = null)
    {
        Card.cartas = new List<BaseCard>();
        Card.cartasCreadas = new Dictionary<string, string>();
        Effect.efectosCreados = new Dictionary<string, string>();
        Effect.efectosGuardados = new Dictionary<string, Effect>();
        Final.UltimoEfecto = 0;

        try
        {
            if(!(EfectosHechos is null)) 
            {
                foreach (var item in EfectosHechos)
                {
                    StreamReader fuente = new StreamReader("Assets\\Scripts\\Codigo\\Effects" + item + ".gwf" );
                    this.Evaluate(fuente.ReadLine());
                    fuente.Close();
                }
            }

             if(!(CartasHechas is null)) 
            {
                foreach (var item in CartasHechas)
                {
                    StreamReader fuente = new StreamReader("Assets\\Scripts\\Codigo\\Cards" + item + ".gwc" );
                    if(!this.Evaluate(fuente.ReadLine()))
                    {
                        System.Console.WriteLine("Declaraciones invalidas");
                        EsValido = false;
                    }
                    fuente.Close();
                }
            }
        }
        catch{
            System.Console.WriteLine("Invalid Load");
            EsValido = false;
        }
    }

    public bool Evaluate(string fuente)
    {
        if(Semantica(fuente))
        {
            try
            {
                CartasyEfectos.Ejecutar();
            }
            catch
            {
                return false;
            }
            CreatedCards.AddRange(CartasyEfectos.CreatedCards());
            return true;
        }
        else return false;
    }

    public bool Semantica(string fuente)
    {
        if(!EsValido) return false;
        
        try
        {
            escaner = new Escaner(fuente);
            List<Token> tokens = escaner.escanearTokens();
            parser = new Parser(tokens);
            CartasyEfectos = parser.parse();
            CartasyEfectos.Semantica();
        }
        catch
        {
            return false;
        }
        return true;
    }

    public static bool hadError = false;
    static bool hadRuntimeError = false;

    public static void Error(int linea, string mensaje)
    {
        Report(linea, "", mensaje);
    }

    private static void Report(int linea, string donde, string mensaje)
    {
        Console.Error.WriteLine($"[línea {linea}] Error{donde}: {mensaje}");
        hadError = true;
    }

    public static void error(Token token, string message) {
        if (token.Tipo == TokenType.Fin) {
        Report(token.linea, " al final", message);
        } else {
        Report(token.linea, " en '" + token.Valor + "'", message);
        }
    }

  public static void runtimeError(RuntimeError error) 
  {
    Console.Error.WriteLine(error.Message + $"\n[line {error.token.linea}]");
    hadRuntimeError = true;
  }
}
