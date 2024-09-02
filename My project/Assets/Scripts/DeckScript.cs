using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Linq;

public class DeckScript
{
    
    public static List<UnityBaseCard> GreekList= new List<UnityBaseCard>
    {
        new UnityLeaderCard("Zeus", 0, Faction.Greek_Gods, TipoDeCarta.Leader, new List<Zonas>{Zonas.Melee, Zonas.Range, Zonas.Siege}, Resources.Load<Sprite>("Zeus"), " "),
        new UnityUnitCard("Poseidón", 5, Faction.Greek_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Siege},  Resources.Load<Sprite>("Poseidon"), " ", Worth.Golden, SavedEffects.AddIncrease),
        new UnityUnitCard("Hades", 6, Faction.Greek_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Siege},  Resources.Load<Sprite>("Hades"), " ", Worth.Golden, SavedEffects.EliminateMostPowerfullCard),
        new UnityUnitCard("Afrodita", 3, Faction.Greek_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Melee},  Resources.Load<Sprite>("Afrodita"), " ", Worth.Silver, SavedEffects.DrawCard),
        new UnityUnitCard("Apolo", 4, Faction.Greek_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Range},  Resources.Load<Sprite>("Apolo"), " ", Worth.Silver, SavedEffects.ClearRow),
        new UnityUnitCard("Ares", 3, Faction.Greek_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Siege},  Resources.Load<Sprite>("Ares"), " ", Worth.Silver, SavedEffects.RemoveLeastPowerfulCard),
        new UnityUnitCard("Artemisa", 4, Faction.Greek_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Melee},   Resources.Load<Sprite>("Artemisa"), " ",Worth.Silver, SavedEffects.DrawCard),
        new UnityUnitCard("Atenas", 3, Faction.Greek_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Range},  Resources.Load<Sprite>("Atenas"), " ", Worth.Silver, SavedEffects.CalculateAverage),
        new UnityUnitCard("Hefesto", 4, Faction.Greek_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Melee},   Resources.Load<Sprite>("Hefesto"), " ",Worth.Silver, SavedEffects.MultiplyPower),
        new UnityUnitCard("Hera", 3, Faction.Greek_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Range},  Resources.Load<Sprite>("Hera"), " ", Worth.Silver, SavedEffects.AddIncrease),
        new UnityClimateCard("Climate Melee", 0, Faction.Greek_Gods, TipoDeCarta.Climate, new List<Zonas>{Zonas.Melee},   Resources.Load<Sprite>("Zeus"), " "),
        new UnityClimateCard("Climate Siege", 0, Faction.Greek_Gods, TipoDeCarta.Climate, new List<Zonas>{Zonas.Siege},   Resources.Load<Sprite>("Zeus"), " "),
        new UnityClimateCard("Climate Range", 0, Faction.Greek_Gods, TipoDeCarta.Climate, new List<Zonas>{Zonas.Melee},   Resources.Load<Sprite>("Zeus"), " "),
        new UnityClearanceCard("Clearance Melee", 0, Faction.Greek_Gods, TipoDeCarta.Clearance, new List<Zonas>{Zonas.Melee},   Resources.Load<Sprite>("Zeus"), " "),
        new UnityClearanceCard("Clearance Range", 0, Faction.Greek_Gods, TipoDeCarta.Clearance, new List<Zonas>{Zonas.Range},   Resources.Load<Sprite>("Zeus"), " "),
        new UnityClearanceCard("Clearance Siege", 0, Faction.Greek_Gods, TipoDeCarta.Clearance, new List<Zonas>{Zonas.Siege},   Resources.Load<Sprite>("Zeus"), " "),
        new UnityBaitCard("Bait", 0, Faction.Greek_Gods, TipoDeCarta.Bait, new List<Zonas>{Zonas.Melee, Zonas.Range, Zonas.Siege},   Resources.Load<Sprite>("Zeus"), " "),
        new UnityIncreaseCard("Increase Melee", 0, Faction.Greek_Gods, TipoDeCarta.Increase, new List<Zonas>{Zonas.Melee},  Resources.Load<Sprite>("Zeus"), " ", 2),
        new UnityIncreaseCard("Increase Range", 0, Faction.Greek_Gods, TipoDeCarta.Increase, new List<Zonas>{Zonas.Range},  Resources.Load<Sprite>("Zeus"), " ", 2),
        new UnityIncreaseCard("Increase Siege", 0, Faction.Greek_Gods, TipoDeCarta.Increase, new List<Zonas>{Zonas.Siege},  Resources.Load<Sprite>("Zeus"), " ", 2),
    };

    public static List<UnityBaseCard> NordicList= new List<UnityBaseCard>
    {
        new UnityLeaderCard("Odin", 0, Faction.Nordic_Gods, TipoDeCarta.Leader, new List<Zonas>{Zonas.Melee, Zonas.Range, Zonas.Siege}, Resources.Load<Sprite>("Odin"), " "),

        new UnityUnitCard("Loki", 5, Faction.Nordic_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Siege},   Resources.Load<Sprite>("Loki"), " ",Worth.Golden, SavedEffects.EliminateMostPowerfullCard),
        new UnityUnitCard("Thor", 6, Faction.Nordic_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Siege},   Resources.Load<Sprite>("Thor"), " ",Worth.Golden, SavedEffects.AddIncrease),
        new UnityUnitCard("Balder", 3, Faction.Nordic_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Melee},   Resources.Load<Sprite>("Balder"), " ",Worth.Silver, SavedEffects.AddIncrease),
        new UnityUnitCard("Frey", 4, Faction.Nordic_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Range},   Resources.Load<Sprite>("Frey"), " ",Worth.Silver, SavedEffects.DrawCard),
        new UnityUnitCard("Freya", 3, Faction.Nordic_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Siege},   Resources.Load<Sprite>("Freya"), " ",Worth.Silver, SavedEffects.CalculateAverage),
        new UnityUnitCard("Heimdall", 4, Faction.Nordic_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Melee},   Resources.Load<Sprite>("Heimdall"), " ",Worth.Silver, SavedEffects.DrawCard),
        new UnityUnitCard("Skadi", 3, Faction.Nordic_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Range},   Resources.Load<Sprite>("Skadi"), " ",Worth.Silver, SavedEffects.MultiplyPower),
        new UnityUnitCard("Tyr", 4, Faction.Nordic_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Melee},   Resources.Load<Sprite>("Tyr"), " ",Worth.Silver, SavedEffects.RemoveLeastPowerfulCard),
        new UnityUnitCard("Valquiria", 3, Faction.Nordic_Gods, TipoDeCarta.Unit, new List<Zonas>{Zonas.Range},   Resources.Load<Sprite>("Valquiria"), " ",Worth.Silver, SavedEffects.ClearRow),
        new UnityClimateCard("Climate Melee", 0, Faction.Nordic_Gods, TipoDeCarta.Climate, new List<Zonas>{Zonas.Melee},  Resources.Load<Sprite>("Zeus"), " "),
        new UnityClimateCard("Climate Siege", 0, Faction.Nordic_Gods, TipoDeCarta.Climate, new List<Zonas>{Zonas.Siege},   Resources.Load<Sprite>("Zeus"), " "), 
        new UnityClimateCard("Climate Range", 0, Faction.Nordic_Gods, TipoDeCarta.Climate, new List<Zonas>{Zonas.Melee},   Resources.Load<Sprite>("Zeus"), " "),
        new UnityClearanceCard("Clearance Melee", 0, Faction.Nordic_Gods, TipoDeCarta.Clearance, new List<Zonas>{Zonas.Melee},   Resources.Load<Sprite>("Zeus"), " "),
        new UnityClearanceCard("Clearance Range", 0, Faction.Nordic_Gods, TipoDeCarta.Clearance, new List<Zonas>{Zonas.Range},   Resources.Load<Sprite>("Zeus"), " "),
        new UnityClearanceCard("Clearance Siege", 0, Faction.Nordic_Gods, TipoDeCarta.Clearance, new List<Zonas>{Zonas.Siege},   Resources.Load<Sprite>("Zeus"), " "),
        new UnityBaitCard("Bait", 0, Faction.Nordic_Gods, TipoDeCarta.Bait, new List<Zonas>{Zonas.Melee, Zonas.Range, Zonas.Siege},   Resources.Load<Sprite>("Zeus"), " "),
        new UnityIncreaseCard("Increase Melee", 0, Faction.Nordic_Gods, TipoDeCarta.Increase, new List<Zonas>{Zonas.Melee},   Resources.Load<Sprite>("Zeus"), " ", 2),
        new UnityIncreaseCard("Increase Range", 0, Faction.Nordic_Gods, TipoDeCarta.Increase, new List<Zonas>{Zonas.Range},   Resources.Load<Sprite>("Zeus"), " ", 2),
        new UnityIncreaseCard("Increase Siege", 0, Faction.Nordic_Gods, TipoDeCarta.Increase, new List<Zonas>{Zonas.Siege},   Resources.Load<Sprite>("Zeus"), " ", 2),
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

    public static List<UnityBaseCard> CreateDeck(string name) => name == "GreekGods" ? CreateDeck(GreekList) : CreateDeck(NordicList);
}
