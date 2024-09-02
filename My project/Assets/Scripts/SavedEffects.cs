using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public static class SavedEffects
{
    public static Dictionary<string, EffectDelegate> efectos = new Dictionary<string, EffectDelegate>();

    public static void AgregarEfecto(string name, EffectDelegate effect)
    {
        efectos.Add(name, effect);
    }

    public static EffectDelegate ObtenerEfecto(string name)
    {
        try
        {
            return efectos[name];
        }
        catch (System.ArgumentOutOfRangeException)
        {
            return efectos["Empty"];
        }
    }

    public static EffectDelegate CogerEfecto(string nombre)
    {
        if (effects.ContainsKey(nombre))
        {
            return effects[nombre];
        }
        else
        {
            return effects["Empty"];
        }
    }

    //Efectos
    public static bool EmptyEffect(EstadoDeJuego estadoDeJuego)
    {
        return true;
    }
    public static bool DrawCard(EstadoDeJuego estadoDeJuego)
    {
        if (!(estadoDeJuego.player.Deck.Count == 0)) 
        {
            estadoDeJuego.player.Hand.Add(estadoDeJuego.player.Deck[0]);
            return true;
        }
        else 
        {
            System.Console.WriteLine("There are no more cards in the deck.");
            return false;
        }
    }

    public static bool EliminateMostPowerfullCard(EstadoDeJuego estadoDeJuego)
    {
        BaseCard mostPowerfulCard = null;
        int maxPower = int.MinValue;

        if(estadoDeJuego.enemy.zonasdelplayer.MeleeZone.Count > 0)
        {
            FindMostPowerfulCardInListMelee();
        }
        else if(estadoDeJuego.enemy.zonasdelplayer.RangedZone.Count >0)
        {
            FindMostPowerfulCardInListRange();
        }
        
        else if(estadoDeJuego.enemy.zonasdelplayer.SiegeZone.Count > 0)
        {
            FindMostPowerfulCardInListSiege();
        }
        else return false;
      
        void FindMostPowerfulCardInListMelee()
        {
            for (int i = 0; i < estadoDeJuego.enemy.zonasdelplayer.MeleeZone.Count; i++)
            {
           
                if(estadoDeJuego.enemy.zonasdelplayer.MeleeZone[i].Power  > maxPower)
                {
                    mostPowerfulCard = estadoDeJuego.enemy.zonasdelplayer.MeleeZone[i];
                    maxPower = estadoDeJuego.enemy.zonasdelplayer.MeleeZone[i].Power;
                }
            }
        }
 
        void FindMostPowerfulCardInListRange()
        {
            for (int i = 0; i < estadoDeJuego.enemy.zonasdelplayer.RangedZone.Count; i++)
            {
          
                if(estadoDeJuego.enemy.zonasdelplayer.RangedZone[i].Power > maxPower)
                {
                    mostPowerfulCard = estadoDeJuego.enemy.zonasdelplayer.RangedZone[i];
                    maxPower = estadoDeJuego.enemy.zonasdelplayer.RangedZone[i].Power;
                }
            }
        }

        void FindMostPowerfulCardInListSiege()
        {
            for (int i = 0; i < estadoDeJuego.enemy.zonasdelplayer.SiegeZone.Count; i++)
            {
            
                if(estadoDeJuego.enemy.zonasdelplayer.SiegeZone[i].Power > maxPower)
                {
                    mostPowerfulCard = estadoDeJuego.enemy.zonasdelplayer.SiegeZone[i];
                    maxPower = estadoDeJuego.enemy.zonasdelplayer.SiegeZone[i].Power;
                }
            }    
        }
        if(mostPowerfulCard != null)
        {
            if(estadoDeJuego.enemy.zonasdelplayer.MeleeZone.Contains(mostPowerfulCard))
            {
                estadoDeJuego.enemy.zonasdelplayer.MeleeZone.Remove(mostPowerfulCard);
            }
            else if(estadoDeJuego.enemy.zonasdelplayer.RangedZone.Contains(mostPowerfulCard))
            {
                estadoDeJuego.enemy.zonasdelplayer.RangedZone.Remove(mostPowerfulCard);
            }
            else if(estadoDeJuego.enemy.zonasdelplayer.SiegeZone.Contains(mostPowerfulCard))
            {
                estadoDeJuego.enemy.zonasdelplayer.SiegeZone.Remove(mostPowerfulCard);
            }
        }

        return true;
    }

     public static bool CalculateAverage(EstadoDeJuego estadoDeJuego)
    {
        try{
            List<UnitCard> list = new List<UnitCard>();
            double Total = 0;

            for (int i = 0; i < estadoDeJuego.player.zonasdelplayer.listaDeLasZonas.Count; i++)
            {
                Average(estadoDeJuego.player.zonasdelplayer.listaDeLasZonas[i], list, ref Total);
                Average(estadoDeJuego.enemy.zonasdelplayer.listaDeLasZonas[i], list, ref Total);
            }

            double average = Total / list.Count;

            foreach (UnitCard item in list)
            {
                if (item.worth == Worth.Silver) item.Power = (int)average;
            }
            return true;
        }
        catch
        {
            return false;
        }
        
    }

    static void Average(List<BaseCard> listToCheck, List<UnitCard> listToStore, ref double power)
    {
        foreach (BaseCard item in listToCheck)
        {
            if (item is UnitCard unit)
            {
                listToStore.Add(unit);
                power += unit.Power;
            }
        }
    }

    public static bool MultiplyPower(EstadoDeJuego estadoDeJuego)
    {
        try
        {
            int repetitions = 0; 
            List<UnitCard> list = new List<UnitCard>();

            for (int i = 0; i < estadoDeJuego.player.zonasdelplayer.listaDeLasZonas.Count; i++)
                FindMatchingCards(estadoDeJuego.player.zonasdelplayer.listaDeLasZonas[i], (UnitCard)estadoDeJuego.card, list, ref repetitions);

            foreach (UnitCard item in list)
            {
                item.Power = repetitions * item.InitialPower;
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    static void FindMatchingCards(List<BaseCard> list, UnitCard card, List<UnitCard> listToSave, ref int repetitions)
    {
        foreach (BaseCard item in list)
        {
            if (card.Equals(item))
            {
                repetitions++;
                listToSave.Add((UnitCard)item);
            }
        }
    }


    public static bool RemoveLeastPowerfulCard(EstadoDeJuego estadoDeJuego)
    {
        BaseCard leastPowerfulCard = null;
        int minPower = int.MaxValue;

        if(estadoDeJuego.enemy.zonasdelplayer.MeleeZone.Count > 0)
        {
            FindleastPowerfulCardInListMelee();
        }
        else if(estadoDeJuego.enemy.zonasdelplayer.RangedZone.Count >0)
        {
            FindleastPowerfulCardInListRange();
        }
        
        else if(estadoDeJuego.enemy.zonasdelplayer.SiegeZone.Count > 0)
        {
            FindleastPowerfulCardInListSiege();
        }
        else return false; 
      
        void FindleastPowerfulCardInListMelee()
        {
            for (int i = 0; i < estadoDeJuego.enemy.zonasdelplayer.MeleeZone.Count; i++)
            {
           
                if(estadoDeJuego.enemy.zonasdelplayer.MeleeZone[i].Power  < minPower)
                {
                    leastPowerfulCard = estadoDeJuego.enemy.zonasdelplayer.MeleeZone[i];
                    minPower = estadoDeJuego.enemy.zonasdelplayer.MeleeZone[i].Power;
                }
            }
        }
 
        void FindleastPowerfulCardInListRange()
        {
            for (int i = 0; i < estadoDeJuego.enemy.zonasdelplayer.RangedZone.Count; i++)
            {
          
                if(estadoDeJuego.enemy.zonasdelplayer.RangedZone[i].Power < minPower)
                {
                    leastPowerfulCard = estadoDeJuego.enemy.zonasdelplayer.RangedZone[i];
                    minPower = estadoDeJuego.enemy.zonasdelplayer.RangedZone[i].Power;
                }
            }
        }

        void FindleastPowerfulCardInListSiege()
        {
            for (int i = 0; i < estadoDeJuego.enemy.zonasdelplayer.SiegeZone.Count; i++)
            {
            
                if(estadoDeJuego.enemy.zonasdelplayer.SiegeZone[i].Power < minPower)
                {
                    leastPowerfulCard = estadoDeJuego.enemy.zonasdelplayer.SiegeZone[i];
                    minPower = estadoDeJuego.enemy.zonasdelplayer.SiegeZone[i].Power;
                }
            }    
        }
        if(leastPowerfulCard != null)
        {
            if(estadoDeJuego.enemy.zonasdelplayer.MeleeZone.Contains(leastPowerfulCard))
            {
                estadoDeJuego.enemy.zonasdelplayer.MeleeZone.Remove(leastPowerfulCard);
            }
            else if(estadoDeJuego.enemy.zonasdelplayer.RangedZone.Contains(leastPowerfulCard))
            {
                estadoDeJuego.enemy.zonasdelplayer.RangedZone.Remove(leastPowerfulCard);
            }
            else if(estadoDeJuego.enemy.zonasdelplayer.SiegeZone.Contains(leastPowerfulCard))
            {
                estadoDeJuego.enemy.zonasdelplayer.SiegeZone.Remove(leastPowerfulCard);
            }
        }
        return true;
    }

    public static bool ClearRow(EstadoDeJuego estadoDeJuego)
    {
        List<List<BaseCard>> rows = new List<List<BaseCard>> {estadoDeJuego.enemy.zonasdelplayer.MeleeZone, estadoDeJuego.enemy.zonasdelplayer.RangedZone, estadoDeJuego.enemy.zonasdelplayer.SiegeZone};

        List<BaseCard> smallesNonEmptyRow = null;
        int minCount = int.MaxValue;

        for (int i = 0; i < rows.Count; i++)
        {
            if(rows[i].Count > 0 && rows[i].Count < minCount)
            {
                smallesNonEmptyRow = rows[i];
                minCount = rows[i].Count;
            }
        }
        if(smallesNonEmptyRow != null)
        { 
            smallesNonEmptyRow.Clear();
            return true;
        }
        else return false;
    }

    public static bool AddIncrease(EstadoDeJuego estadoDeJuego)
    {
        try
        {
            if(estadoDeJuego.card.destinations[0] == Zonas.Melee) AddPowerMelee();
            if(estadoDeJuego.card.destinations[0] == Zonas.Range) AddPowerRange();
            if(estadoDeJuego.card.destinations[0] == Zonas.Siege) AddPowerSiege();
            
            void AddPowerMelee()
            {
                if(estadoDeJuego.player.zonasdelplayer.MeleeZone.Count > 0)
                {
                    for (int i = 0; i < estadoDeJuego.player.zonasdelplayer.MeleeZone.Count; i++)
                    {
                    estadoDeJuego.player.zonasdelplayer.MeleeZone[i].Power += 1;
                    };
                }
            } 
            
            void AddPowerRange()
            {
                if(estadoDeJuego.player.zonasdelplayer.RangedZone.Count > 0)
                {
                    for (int i = 0; i < estadoDeJuego.player.zonasdelplayer.RangedZone.Count; i++)
                    {
                    estadoDeJuego.player.zonasdelplayer.RangedZone[i].Power += 1;
                    }
                }
            } 
            
            void AddPowerSiege()
            {
                if(estadoDeJuego.player.zonasdelplayer.SiegeZone.Count > 0)
                {
                    for (int i = 0; i < estadoDeJuego.player.zonasdelplayer.SiegeZone.Count; i++)
                    {
                    estadoDeJuego.player.zonasdelplayer.SiegeZone[i].Power += 1;
                    }
                }
            }
            return true;
        } 
        catch
        {
            return false;
        }
    }

     static Dictionary<string, EffectDelegate> effects = new Dictionary<string, EffectDelegate>
    {
        {"Empty", EmptyEffect },
        {"Afrodita", DrawCard },
        {"Artemisa", DrawCard },
        {"Frey", DrawCard },
        {"Heimdall", DrawCard },

        {"Hades", EliminateMostPowerfullCard },
        {"Loki", EliminateMostPowerfullCard },

        {"Atenas", CalculateAverage },
        {"Freya", CalculateAverage },

        {"Hefesto" , MultiplyPower },
        {"SKadi" , MultiplyPower },

        {"Ares", RemoveLeastPowerfulCard },
        {"Tyr", RemoveLeastPowerfulCard },

        {"Apolo", ClearRow },
        {"Valquiria", ClearRow },

        {"Hera", AddIncrease },
        {"Poseidón", AddIncrease },
        {"Balder", AddIncrease },
        {"Thor", AddIncrease }
    };
}

public delegate bool EffectDelegate(EstadoDeJuego estadoDeJuego);