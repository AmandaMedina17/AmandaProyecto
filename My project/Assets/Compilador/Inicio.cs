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
        CreatedCards = new List<BaseCard>();
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
        escaner = new Escaner(fuente);
        List<Token> tokens = escaner.escanearTokens();
        parser = new Parser(tokens);
        CartasyEfectos = parser.parse();
    
        
            CartasyEfectos.Ejecutar();
        
            
            CreatedCards.AddRange(CartasyEfectos.CreatedCards());
            AddCardsToDeck();
        
        
        return true;
    }

    public bool Semantica(string fuente)
    {
        if(!EsValido) return false;
        
        try
        {
            
        }
        catch
        {
            return false;
        }
        return true;
    }

    public void AddCardsToDeck()
    {
        foreach (var item in CreatedCards)
        {
            
            if(item.Faction == Faction.Greek_Gods)
            {
                switch(item)
                {
                    case BaitCard baitCard: DeckScript.GreekList.Add(new UnityBaitCard(item.Name, 0, Faction.Greek_Gods, TipoDeCarta.Bait, new List<Zonas>{Zonas.Melee, Zonas.Range, Zonas.Siege},   Resources.Load<Sprite>("Señuelo"), " "));
                    break;
                    case ClearanceCard : DeckScript.GreekList.Add(new UnityClearanceCard(item.Name, 0, Faction.Greek_Gods, TipoDeCarta.Clearance, item.destinations, Resources.Load<Sprite>("Despeje"), " "));
                    break;
                    case ClimateCard: DeckScript.GreekList.Add(new UnityClimateCard(item.Name, 2, Faction.Greek_Gods, TipoDeCarta.Climate, item.destinations,  Resources.Load<Sprite>("Clima"), " "));
                    break;
                    case IncreaseCard: DeckScript.GreekList.Add(new UnityIncreaseCard(item.Name, 0, Faction.Greek_Gods, TipoDeCarta.Increase, item.destinations, Resources.Load<Sprite>("Aumento"), " ", 2));
                    break;
                    case LeaderCard: DeckScript.GreekList.Add(new UnityLeaderCard(item.Name, 0, Faction.Greek_Gods, TipoDeCarta.Leader, item.destinations, Resources.Load<Sprite>("Zeus"), " "));
                    break;
                    case UnitCard unit: DeckScript.GreekList.Add(new UnityUnitCard(item.Name, item.InitialPower, Faction.Greek_Gods, TipoDeCarta.Unit, item.destinations, Resources.Load<Sprite>("Zeus"), " ", unit.worth, unit.Effect));
                    break;
                }
            }

            if(item.Faction == Faction.Nordic_Gods)
            {
                switch(item)
                {
                    case BaitCard: DeckScript.GreekList.Add(new UnityBaitCard(item.Name, 0, Faction.Nordic_Gods, TipoDeCarta.Bait, new List<Zonas>{Zonas.Melee, Zonas.Range, Zonas.Siege},   Resources.Load<Sprite>("Señuelo"), " "));
                    break;
                    case ClearanceCard : DeckScript.GreekList.Add(new UnityClearanceCard(item.Name, 0, Faction.Nordic_Gods, TipoDeCarta.Clearance, item.destinations, Resources.Load<Sprite>("Despeje"), " "));
                    break;
                    case ClimateCard: DeckScript.GreekList.Add(new UnityClimateCard(item.Name, 2, Faction.Nordic_Gods, TipoDeCarta.Climate, item.destinations,  Resources.Load<Sprite>("Tormenta"), " "));
                    break;
                    case IncreaseCard increase: DeckScript.GreekList.Add(new UnityIncreaseCard(item.Name, 0, Faction.Nordic_Gods, TipoDeCarta.Increase, item.destinations, Resources.Load<Sprite>("Aumento"), " ", increase.Incremento));
                    break;
                    case LeaderCard: DeckScript.GreekList.Add(new UnityLeaderCard(item.Name, 0, Faction.Nordic_Gods, TipoDeCarta.Leader, item.destinations, Resources.Load<Sprite>("Odin"), " "));
                    break;
                    case UnitCard unit: DeckScript.GreekList.Add(new UnityUnitCard(item.Name, item.InitialPower, Faction.Nordic_Gods, TipoDeCarta.Unit, item.destinations, Resources.Load<Sprite>("Odin"), " ", unit.worth, unit.Effect));
                    break;
                }
            }
        }
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
