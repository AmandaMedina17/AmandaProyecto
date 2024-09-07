using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Linq;

public class DeckScript
{
    
    public static List<UnityBaseCard> GreekList= new List<UnityBaseCard>
    {
        new UnityLeaderCard("Zeus", 0, Faction.Greek_Gods, TipoDeCarta.Leader, new List<Zonas>{Zonas.Melee, Zonas.Range, Zonas.Siege}, Resources.Load<Sprite>("Zeus"), " "),
        new UnityUnitCard("Poseidón", 5, Faction.Greek_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Siege},  Resources.Load<Sprite>("Poseidon"), "Poner un clima", Worth.Golden, SavedEffects.AddIncrease),
        new UnityUnitCard("Hades", 6, Faction.Greek_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Siege},  Resources.Load<Sprite>("Hades"), "Eliminar la carta con mas poder del campo rival", Worth.Golden, SavedEffects.EliminateMostPowerfullCard),
        new UnityUnitCard("Afrodita", 3, Faction.Greek_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Melee},  Resources.Load<Sprite>("Afrodita"), "Robar una carta", Worth.Silver, SavedEffects.DrawCard),
        new UnityUnitCard("Apolo", 4, Faction.Greek_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Range},  Resources.Load<Sprite>("Apolo"), "Limpia la fila del campo del rival (no vacia) con menos unidades", Worth.Silver, SavedEffects.ClearRow),
        new UnityUnitCard("Ares", 3, Faction.Greek_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Siege},  Resources.Load<Sprite>("Ares"), "Eliminar la carta con menos poder del rival", Worth.Silver, SavedEffects.RemoveLeastPowerfulCard),
        new UnityUnitCard("Artemisa", 4, Faction.Greek_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Melee},   Resources.Load<Sprite>("Artemisa"), "Robar una carta",Worth.Silver, SavedEffects.DrawCard),
        new UnityUnitCard("Atenas", 3, Faction.Greek_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Range},  Resources.Load<Sprite>("Atenas"), "Caclula el promedio de poder entre todas las cartas del campo (propio y del rival). Luego iguala el poder de todas las cartas del campo a ese promedio", Worth.Silver, SavedEffects.CalculateAverage),
        new UnityUnitCard("Hefesto", 2, Faction.Greek_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Melee},   Resources.Load<Sprite>("Hefesto"), "Multiplica por n su ataque, siendo n la cantidad de cartas iguales a ella en el campo",Worth.Silver, SavedEffects.MultiplyPower),
        new UnityUnitCard("Hera", 3, Faction.Greek_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Range},  Resources.Load<Sprite>("Hera"), "Poner un aumento en la fila propia ", Worth.Silver, SavedEffects.AddIncrease),
        new UnityClimateCard("Climate Melee", 0, Faction.Greek_Gods, TipoDeCarta.Climate, new List<Zonas>{Zonas.Melee},   Resources.Load<Sprite>("Clima"), "Reduce el poder de todas las cartas de la fila en 2 puntos"),
        new UnityClimateCard("Climate Siege", 0, Faction.Greek_Gods, TipoDeCarta.Climate, new List<Zonas>{Zonas.Siege},   Resources.Load<Sprite>("Clima"), "Reduce el poder de todas las cartas de la fila en 2 puntos"),
        new UnityClimateCard("Climate Range", 0, Faction.Greek_Gods, TipoDeCarta.Climate, new List<Zonas>{Zonas.Melee},   Resources.Load<Sprite>("Clima"), "Reduce el poder de todas las cartas de la fila en 2 puntos"),
        new UnityClearanceCard("Clearance Melee", 0, Faction.Greek_Gods, TipoDeCarta.Clearance, new List<Zonas>{Zonas.Melee},   Resources.Load<Sprite>("Despeje"), "Despeja el clima existente en la fila"),
        new UnityClearanceCard("Clearance Range", 0, Faction.Greek_Gods, TipoDeCarta.Clearance, new List<Zonas>{Zonas.Range},   Resources.Load<Sprite>("Despeje"), "Despeja el clima existente en la fila"),
        new UnityClearanceCard("Clearance Siege", 0, Faction.Greek_Gods, TipoDeCarta.Clearance, new List<Zonas>{Zonas.Siege},   Resources.Load<Sprite>("Despeje"), "Despeja el clima existente en la fila"),
        new UnityBaitCard("Bait", 0, Faction.Greek_Gods, TipoDeCarta.Bait, new List<Zonas>{Zonas.Melee, Zonas.Range, Zonas.Siege},   Resources.Load<Sprite>("Señuelo"), "Se intercambia por la carta de mayor poder en el campo propio"),
        new UnityIncreaseCard("Increase Melee", 0, Faction.Greek_Gods, TipoDeCarta.Increase, new List<Zonas>{Zonas.Melee},  Resources.Load<Sprite>("Aumento"), "Bonifica en 1 punto el poder de las cartas de la fila", 1),
        new UnityIncreaseCard("Increase Range", 0, Faction.Greek_Gods, TipoDeCarta.Increase, new List<Zonas>{Zonas.Range},  Resources.Load<Sprite>("Aumento"), "Bonifica en 1 punto el poder de las cartas de la fila", 1),
        new UnityIncreaseCard("Increase Siege", 0, Faction.Greek_Gods, TipoDeCarta.Increase, new List<Zonas>{Zonas.Siege},  Resources.Load<Sprite>("Aumento"), "Bonifica en 1 punto el poder de las cartas de la fila", 1),
    };

    public static List<UnityBaseCard> NordicList= new List<UnityBaseCard>
    {
        new UnityLeaderCard("Odin", 0, Faction.Nordic_Gods, TipoDeCarta.Leader, new List<Zonas>{Zonas.Melee, Zonas.Range, Zonas.Siege}, Resources.Load<Sprite>("Odin"), " "),

        new UnityUnitCard("Loki", 5, Faction.Nordic_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Siege},   Resources.Load<Sprite>("Loki"), "Eliminar la carta con mas poder del campo rival",Worth.Golden, SavedEffects.EliminateMostPowerfullCard),
        new UnityUnitCard("Thor", 6, Faction.Nordic_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Range},   Resources.Load<Sprite>("Thor"), "Poner un clima",Worth.Golden, SavedEffects.AddIncrease),
        new UnityUnitCard("Balder", 3, Faction.Nordic_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Melee},   Resources.Load<Sprite>("Balder"), "Poner un aumento en la fila propia",Worth.Silver, SavedEffects.AddIncrease),
        new UnityUnitCard("Frey", 4, Faction.Nordic_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Range},   Resources.Load<Sprite>("Frey"), "Robar una carta",Worth.Silver, SavedEffects.DrawCard),
        new UnityUnitCard("Freya", 3, Faction.Nordic_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Siege},   Resources.Load<Sprite>("Freya"), "Caclula el promedio de poder entre todas las cartas del campo (propio y del rival). Luego iguala el poder de todas las cartas del campo a ese promedio",Worth.Silver, SavedEffects.CalculateAverage),
        new UnityUnitCard("Heimdall", 4, Faction.Nordic_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Melee},   Resources.Load<Sprite>("Heimdall"), "Robar una carta",Worth.Silver, SavedEffects.DrawCard),
        new UnityUnitCard("Skadi", 2, Faction.Nordic_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Range},   Resources.Load<Sprite>("Skadi"), "Multiplica por n su ataque, siendo n la cantidad de cartas iguales a ella en el campo",Worth.Silver, SavedEffects.MultiplyPower),
        new UnityUnitCard("Tyr", 4, Faction.Nordic_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Melee},   Resources.Load<Sprite>("Tyr"), "Eliminar la carta con menos poder del rival",Worth.Silver, SavedEffects.RemoveLeastPowerfulCard),
        new UnityUnitCard("Valquiria", 3, Faction.Nordic_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Range},   Resources.Load<Sprite>("Valquiria"), "Limpia la fila del campo del rival (no vacia) con menos unidades",Worth.Silver, SavedEffects.ClearRow),
        new UnityClimateCard("Climate Melee", 0, Faction.Nordic_Gods, TipoDeCarta.Climate, new List<Zonas>{Zonas.Melee},  Resources.Load<Sprite>("Tormenta"), "Reduce el poder de todas las cartas de la fila en 2 puntos"),
        new UnityClimateCard("Climate Siege", 0, Faction.Nordic_Gods, TipoDeCarta.Climate, new List<Zonas>{Zonas.Siege},   Resources.Load<Sprite>("Tormenta"), "Reduce el poder de todas las cartas de la fila en 2  puntos"), 
        new UnityClimateCard("Climate Range", 0, Faction.Nordic_Gods, TipoDeCarta.Climate, new List<Zonas>{Zonas.Range},   Resources.Load<Sprite>("Tormenta"), "Reduce el poder de todas las cartas de la fila en 2 puntos"),
        new UnityClearanceCard("Clearance Melee", 0, Faction.Nordic_Gods, TipoDeCarta.Clearance, new List<Zonas>{Zonas.Melee},   Resources.Load<Sprite>("Despeje"), "Despeja el clima existente en la fila"),
        new UnityClearanceCard("Clearance Range", 0, Faction.Nordic_Gods, TipoDeCarta.Clearance, new List<Zonas>{Zonas.Range},   Resources.Load<Sprite>("Despeje"), "Despeja el clima existente en la fila"),
        new UnityClearanceCard("Clearance Siege", 0, Faction.Nordic_Gods, TipoDeCarta.Clearance, new List<Zonas>{Zonas.Siege},   Resources.Load<Sprite>("Despeje"), "Despeja el clima existente en la fila"),
        new UnityBaitCard("Bait", 0, Faction.Nordic_Gods, TipoDeCarta.Bait, new List<Zonas>{Zonas.Melee, Zonas.Range, Zonas.Siege},   Resources.Load<Sprite>("Señuelo"), "Se intercambia por la carta de mayor poder en el campo propio"),
        new UnityIncreaseCard("Increase Melee", 0, Faction.Nordic_Gods, TipoDeCarta.Increase, new List<Zonas>{Zonas.Melee},   Resources.Load<Sprite>("Aumento"), "Bonifica en 1 punto el poder de las cartas de la fila", 1),
        new UnityIncreaseCard("Increase Range", 0, Faction.Nordic_Gods, TipoDeCarta.Increase, new List<Zonas>{Zonas.Range},   Resources.Load<Sprite>("Aumento"), "Bonifica en 1 punto el poder de las cartas de la fila", 1),
        new UnityIncreaseCard("Increase Siege", 0, Faction.Nordic_Gods, TipoDeCarta.Increase, new List<Zonas>{Zonas.Siege},   Resources.Load<Sprite>("Aumento"), "Bonifica en 1 punto el poder de las cartas de la fila", 1),
    };

    static List<UnityBaseCard> CreateDeck(List<UnityBaseCard> list)
    {
        List<UnityBaseCard> deck = new List<UnityBaseCard>();
        List<UnityLeaderCard> Leader = new List<UnityLeaderCard>();

        foreach (var card in list)
        {
            if (card is UnityUnitCard unit && unit.worth is Worth.Silver) deck.AddRange(Enumerable.Repeat<UnityBaseCard>(unit, 2));
            else if(card is UnityLeaderCard leader) Leader.Add(leader);
        }

        deck.AddRange(list);
        foreach(var item in Leader) deck.Remove(item);
        return deck;
    }

    static UnityBaseCard GetLeader(List<UnityBaseCard> list)
    {
        UnityBaseCard card = null;

        foreach (var item in list)
        {
            if(item is UnityLeaderCard) card = item;;
        }
        return card;

    }

    public static List<UnityBaseCard> CreateDeck(string name) => name == "GreekGods" ? CreateDeck(GreekList) : CreateDeck(NordicList);
    public static UnityBaseCard GetLeader(string name) => name == "GreekGods" ? GetLeader(GreekList) : GetLeader(NordicList);
}
