using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
public static class SavedEffects
{
    static ScriptZone GreekMelee = GameObject.Find("GreekMelee").GetComponent<ScriptZone>();
    static ScriptZone NordicMelee = GameObject.Find("NordicMelee").GetComponent<ScriptZone>();
    static ScriptZone GreekRange = GameObject.Find("GreekRange").GetComponent<ScriptZone>();
    static ScriptZone NordicRange = GameObject.Find("NordicRange").GetComponent<ScriptZone>();
    static ScriptZone GreekSiege = GameObject.Find("GreekSiege").GetComponent<ScriptZone>();
    static ScriptZone NordicSiege = GameObject.Find("NordicSiege").GetComponent<ScriptZone>();
    static ScriptZone Climate = GameObject.Find("Climate").GetComponent<ScriptZone>();
    static ScriptZone GreekIncreaseMelee = GameObject.Find("GreekIncreaseMelee").GetComponent<ScriptZone>();
    static ScriptZone GreekIncreaseRange = GameObject.Find("GreekIncreaseRange").GetComponent<ScriptZone>();
    static ScriptZone GreekIncreaseSiege = GameObject.Find("GreekIncreaseSiege").GetComponent<ScriptZone>();
    static ScriptZone NordicIncreaseMelee = GameObject.Find("NordicIncreaseMelee").GetComponent<ScriptZone>();
    static ScriptZone NordicIncreaseRange = GameObject.Find("NordicIncreaseRange").GetComponent<ScriptZone>();
    static ScriptZone NordicIncreaseSiege = GameObject.Find("NordicIncreaseSiege").GetComponent<ScriptZone>();
    static ScriptZone GreekGraveyard = GameObject.Find("GreekGraveyard").GetComponent<ScriptZone>();
    static ScriptZone NordicGraveyard = GameObject.Find("NordicGraveyard").GetComponent<ScriptZone>();

    
    public static void AgregarEfecto(string name, EffectDelegate effect)
    {
        effects.Add(name, effect);
    }

    public static EffectDelegate ObtenerEfecto(string name)
    {
        try
        {
            return effects[name];
        }
        catch (System.ArgumentOutOfRangeException)
        {
            return effects["Empty"];
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

    private static void UpdateLists()
    {
        GreekMelee.UpdateList();
        NordicMelee.UpdateList();
        GreekRange.UpdateList();
        NordicRange.UpdateList();
        GreekSiege.UpdateList();
        NordicSiege.UpdateList();
        GreekIncreaseMelee.UpdateList();
        NordicIncreaseMelee.UpdateList();
        GreekIncreaseRange.UpdateList();
        NordicIncreaseRange.UpdateList();
        GreekIncreaseSiege.UpdateList();
        NordicIncreaseSiege.UpdateList();
        Climate.UpdateList();
        GreekGraveyard.UpdateList();
        NordicGraveyard.UpdateList();
    }



    //Efectos
    public static bool EmptyEffect(EstadoDeJuego estadoDeJuego)
    {
        return true;
    }
    public static bool DrawCard(EstadoDeJuego estadoDeJuego)
    {
        if (estadoDeJuego.player == Player.Griegos)
        {
            ScriptZone hand = GameObject.Find("GreekHand").GetComponent<ScriptZone>();
            List<UnityBaseCard> deck = DeckManager.player1Deck;
             if (hand.Cards.Count < 1)
            {
                Debug.LogError("No hay suficientes cartas en el mazo.");
                return false;
            }

            // Baraja el mazo
            List<UnityBaseCard> shuffledDeck = deck.OrderBy(x => UnityEngine.Random.value).ToList();
           
            hand.Cards.Add(shuffledDeck[0]);
            hand.UpdateList();
            deck.RemoveRange(0, 1);

            return true;
        }
        else 
        {
            ScriptZone hand = GameObject.Find("NordicHand").GetComponent<ScriptZone>();
            List<UnityBaseCard> deck = DeckManager.player2Deck;
             if (hand.Cards.Count < 1)
            {
                Debug.LogError("No hay suficientes cartas en el mazo.");
                return false;
            }

            // Baraja el mazo
            List<UnityBaseCard> shuffledDeck = deck.OrderBy(x => UnityEngine.Random.value).ToList();
           
            hand.Cards.Add(shuffledDeck[0]);
            hand.UpdateList();
            deck.RemoveRange(0, 1);

            return true;
        }
    }

    public static bool EliminateMostPowerfullCard(EstadoDeJuego estadoDeJuego)
    {
        UnityBaseCard mostPowerfulCard = null;
        int maxPower = int.MinValue;

        if(estadoDeJuego.enemy == Player.Griegos)
        {
            if(GreekMelee.Cards.Count > 0) FindMostPowerfulCardInListMelee();
            else if(GreekRange.Cards.Count >0) FindMostPowerfulCardInListRange();
            else if(GreekSiege.Cards.Count > 0) FindMostPowerfulCardInListSiege();
            else return false;
        
            void FindMostPowerfulCardInListMelee()
            {
                for (int i = 0; i < GreekMelee.Cards.Count; i++)
                {
            
                    if(GreekMelee.Cards[i].Power  > maxPower)
                    {
                        mostPowerfulCard = GreekMelee.Cards[i];
                        maxPower = GreekMelee.Cards[i].Power;
                    }
                }
            }
    
            void FindMostPowerfulCardInListRange()
            {
                for (int i = 0; i < GreekRange.Cards.Count; i++)
                {
            
                    if(GreekRange.Cards[i].Power > maxPower)
                    {
                        mostPowerfulCard = GreekRange.Cards[i];
                        maxPower = GreekRange.Cards[i].Power;
                    }
                }
            }

            void FindMostPowerfulCardInListSiege()
            {
                for (int i = 0; i < GreekSiege.Cards.Count; i++)
                {
                
                    if(GreekSiege.Cards[i].Power > maxPower)
                    {
                        mostPowerfulCard = GreekSiege.Cards[i];
                        maxPower = GreekSiege.Cards[i].Power;
                    }
                }    
            }
            if(mostPowerfulCard != null)
            {
                if(GreekMelee.Cards.Contains(mostPowerfulCard)) 
                {
                    GreekMelee.Cards.Remove(mostPowerfulCard);
                    GreekMelee.UpdateList();
                }
                else if(GreekRange.Cards.Contains(mostPowerfulCard)) 
                {
                    GreekRange.Cards.Remove(mostPowerfulCard);
                    GreekRange.UpdateList();
                }
                else if(GreekSiege.Cards.Contains(mostPowerfulCard)) 
                {
                    GreekSiege.Cards.Remove(mostPowerfulCard);
                    GreekSiege.UpdateList();
                }
                GreekGraveyard.Cards.Add(mostPowerfulCard);
                GreekGraveyard.UpdateList();
            }

            return true;
        }

        if(estadoDeJuego.enemy == Player.Nordicos)
        {
            if(NordicMelee.Cards.Count > 0) FindMostPowerfulCardInListMelee();
            else if(NordicRange.Cards.Count >0) FindMostPowerfulCardInListRange();
            else if(NordicSiege.Cards.Count > 0) FindMostPowerfulCardInListSiege();
            else return false;
        
            void FindMostPowerfulCardInListMelee()
            {
                for (int i = 0; i < NordicMelee.Cards.Count; i++)
                {
            
                    if(NordicMelee.Cards[i].Power  > maxPower)
                    {
                        mostPowerfulCard = NordicMelee.Cards[i];
                        maxPower = NordicMelee.Cards[i].Power;
                    }
                }
            }
    
            void FindMostPowerfulCardInListRange()
            {
                for (int i = 0; i < NordicRange.Cards.Count; i++)
                {
            
                    if(NordicRange.Cards[i].Power > maxPower)
                    {
                        mostPowerfulCard = NordicRange.Cards[i];
                        maxPower = NordicRange.Cards[i].Power;
                    }
                }
            }

            void FindMostPowerfulCardInListSiege()
            {
                for (int i = 0; i < NordicSiege.Cards.Count; i++)
                {
                
                    if(NordicSiege.Cards[i].Power > maxPower)
                    {
                        mostPowerfulCard = NordicSiege.Cards[i];
                        maxPower = NordicSiege.Cards[i].Power;
                    }
                }    
            }
            if(mostPowerfulCard != null)
            {
                if(NordicMelee.Cards.Contains(mostPowerfulCard)) 
                {
                    NordicMelee.Cards.Remove(mostPowerfulCard);
                    NordicMelee.UpdateList();
                }
                else if(NordicRange.Cards.Contains(mostPowerfulCard)) 
                {
                    NordicRange.Cards.Remove(mostPowerfulCard);
                    NordicRange.UpdateList();
                }
                else if(NordicSiege.Cards.Contains(mostPowerfulCard)) 
                {
                    NordicSiege.Cards.Remove(mostPowerfulCard);
                    NordicSiege.UpdateList();
                }
                NordicGraveyard.Cards.Add(mostPowerfulCard);
                NordicGraveyard.UpdateList();
            }

            return true;
        }
        else return false;
        
    }

    public static bool CalculateAverage(EstadoDeJuego estadoDeJuego)
    {
        try{
            List<UnityUnitCard> listGreek = new List<UnityUnitCard>();
            List<UnityUnitCard> listNordic = new List<UnityUnitCard>();
            List<List<UnityBaseCard>> listaZonasGreek = new List<List<UnityBaseCard>>{GreekMelee.Cards, GreekRange.Cards, GreekSiege.Cards};
            List<List<UnityBaseCard>> listaZonasNordic = new List<List<UnityBaseCard>>{NordicMelee.Cards, NordicRange.Cards, NordicSiege.Cards};

            int TotalGreek = 0;
            int TotalNordic = 0;

            for (int i = 0; i < 3; i++)
            {
                Average(listaZonasGreek[i], listGreek, ref TotalGreek);
                Average(listaZonasNordic[i], listNordic, ref TotalNordic);
            }

            int averageGreek = listGreek.Count > 0 ? TotalGreek / listGreek.Count : 0;
            int averageNordic = listNordic.Count > 0 ? TotalNordic / listNordic.Count : 0;

            foreach (UnityUnitCard item in listGreek)
            {
                if (item.worth == Worth.Silver) item.Power = averageGreek;
            }

            foreach (UnityUnitCard item in listNordic)
            {
                if (item.worth == Worth.Silver) item.Power = averageNordic;
            }
                UpdateLists();
                return true;
        }
        catch
        {
            return false;
        }
        
    }

    static void Average(List<UnityBaseCard> listToCheck, List<UnityUnitCard> listToStore, ref int power)
    {
        foreach (UnityBaseCard item in listToCheck)
        {
            if (item is UnityUnitCard unit)
            {
                listToStore.Add(unit);
                power += unit.Power;
            }
        }
    }

    public static bool MultiplyPower(EstadoDeJuego estadoDeJuego)
    {
        List<List<UnityBaseCard>> listaZonasGreek = new List<List<UnityBaseCard>>{GreekMelee.Cards, GreekRange.Cards, GreekSiege.Cards};
        List<List<UnityBaseCard>> listaZonasNordic = new List<List<UnityBaseCard>>{NordicMelee.Cards, NordicRange.Cards, NordicSiege.Cards};

        if(estadoDeJuego.player == Player.Griegos)
        {
            try
            {
                int repetitions = 0; 
                List<UnityUnitCard> list = new List<UnityUnitCard>();

                for (int i = 0; i < listaZonasGreek.Count; i++)
                    FindMatchingCardsGreek(listaZonasGreek[i], list, ref repetitions);

                estadoDeJuego.card.Power *= repetitions;
                return true;
            }
            catch
            {
                return false;
            }
        }

        else if(estadoDeJuego.player == Player.Nordicos)
        {
            try
            {
                int repetitions = 0; 
                List<UnityUnitCard> list = new List<UnityUnitCard>();

                for (int i = 0; i < listaZonasGreek.Count; i++)
                    FindMatchingCardsNordic(listaZonasNordic[i], list, ref repetitions);

                estadoDeJuego.card.Power *= repetitions;
                return true;
            }
            catch
            {
                return false;
            }
        }
        return false;
        
    }

    static void FindMatchingCardsGreek(List<UnityBaseCard> list, List<UnityUnitCard> listToSave, ref int repetitions)
    {
        foreach (UnityBaseCard item in list)
        {
            if (item.Name == "Hefesto")
            {
                repetitions++;
                listToSave.Add((UnityUnitCard)item);
            }
        }
    }

    static void FindMatchingCardsNordic(List<UnityBaseCard> list, List<UnityUnitCard> listToSave, ref int repetitions)
    {
        foreach (UnityBaseCard item in list)
        {
            if (item.Name == "Skadi")
            {
                repetitions++;
                listToSave.Add((UnityUnitCard)item);
            }
        }
    }


    public static bool RemoveLeastPowerfulCard(EstadoDeJuego estadoDeJuego)
    {
        UnityBaseCard leastPowerfulCard = null;
        int minPower = int.MaxValue;

        if(estadoDeJuego.enemy == Player.Griegos)
        {
            if(GreekMelee.Cards.Count > 0) FindleastPowerfulCardInListMelee();
            else if(GreekRange.Cards.Count >0) FindleastPowerfulCardInListRange();
            else if(GreekSiege.Cards.Count > 0) FindleastPowerfulCardInListSiege();
            else return false; 
        
            void FindleastPowerfulCardInListMelee()
            {
                for (int i = 0; i < GreekMelee.Cards.Count; i++)
                {
            
                    if(GreekMelee.Cards[i].Power  < minPower)
                    {
                        leastPowerfulCard = GreekMelee.Cards[i];
                        minPower = GreekMelee.Cards[i].Power;
                    }
                }
            }
    
            void FindleastPowerfulCardInListRange()
            {
                for (int i = 0; i < GreekRange.Cards.Count; i++)
                {
            
                    if(GreekRange.Cards[i].Power < minPower)
                    {
                        leastPowerfulCard = GreekRange.Cards[i];
                        minPower = GreekRange.Cards[i].Power;
                    }
                }
            }

            void FindleastPowerfulCardInListSiege()
            {
                for (int i = 0; i < GreekSiege.Cards.Count; i++)
                {
                
                    if(GreekSiege.Cards[i].Power < minPower)
                    {
                        leastPowerfulCard = GreekSiege.Cards[i];
                        minPower = GreekSiege.Cards[i].Power;
                    }
                }    
            }
            if(leastPowerfulCard != null)
            {
                if(GreekMelee.Cards.Contains(leastPowerfulCard)) GreekMelee.Cards.Remove(leastPowerfulCard);
                else if(GreekRange.Cards.Contains(leastPowerfulCard)) GreekRange.Cards.Remove(leastPowerfulCard);
                else if(GreekSiege.Cards.Contains(leastPowerfulCard)) GreekSiege.Cards.Remove(leastPowerfulCard);
            }
            GreekGraveyard.Cards.Add(leastPowerfulCard);
            UpdateLists();
            return true;
        }

        if(estadoDeJuego.enemy == Player.Nordicos)
        {
            if(NordicMelee.Cards.Count > 0) FindleastPowerfulCardInListMelee();
            else if(NordicRange.Cards.Count >0) FindleastPowerfulCardInListRange();
            else if(NordicSiege.Cards.Count > 0) FindleastPowerfulCardInListSiege();
            else return false; 
        
            void FindleastPowerfulCardInListMelee()
            {
                for (int i = 0; i < NordicMelee.Cards.Count; i++)
                {
            
                    if(NordicMelee.Cards[i].Power  < minPower)
                    {
                        leastPowerfulCard = NordicMelee.Cards[i];
                        minPower = NordicMelee.Cards[i].Power;
                    }
                }
            }
    
            void FindleastPowerfulCardInListRange()
            {
                for (int i = 0; i < NordicRange.Cards.Count; i++)
                {
            
                    if(NordicRange.Cards[i].Power < minPower)
                    {
                        leastPowerfulCard = NordicRange.Cards[i];
                        minPower = NordicRange.Cards[i].Power;
                    }
                }
            }

            void FindleastPowerfulCardInListSiege()
            {
                for (int i = 0; i < NordicSiege.Cards.Count; i++)
                {
                
                    if(NordicSiege.Cards[i].Power < minPower)
                    {
                        leastPowerfulCard = NordicSiege.Cards[i];
                        minPower = NordicSiege.Cards[i].Power;
                    }
                }    
            }
            if(leastPowerfulCard != null)
            {
                if(NordicMelee.Cards.Contains(leastPowerfulCard)) NordicMelee.Cards.Remove(leastPowerfulCard);
                else if(NordicRange.Cards.Contains(leastPowerfulCard)) NordicRange.Cards.Remove(leastPowerfulCard);
                else if(NordicSiege.Cards.Contains(leastPowerfulCard)) NordicSiege.Cards.Remove(leastPowerfulCard);
            }
            NordicGraveyard.Cards.Add(leastPowerfulCard);
            UpdateLists();
            return true;
        }

        return false;
        
    }

    public static bool ClearRow(EstadoDeJuego estadoDeJuego)
    {
        List<List<UnityBaseCard>> rowsGreek = new List<List<UnityBaseCard>> {GreekMelee.Cards, GreekRange.Cards, GreekSiege.Cards};
        List<List<UnityBaseCard>> rowsNordic = new List<List<UnityBaseCard>> {NordicMelee.Cards, NordicRange.Cards, NordicSiege.Cards};


        List<UnityBaseCard> smallesNonEmptyRow = null;
        int minCount = int.MaxValue;

        if(estadoDeJuego.enemy == Player.Griegos)
        {
            for (int i = 0; i < rowsGreek.Count; i++)
            {
                if(rowsGreek[i].Count > 0 && rowsGreek[i].Count < minCount)
                {
                    smallesNonEmptyRow = rowsGreek[i];
                    minCount = rowsGreek[i].Count;
                }
            }
            if(smallesNonEmptyRow != null)
            { 
                GreekGraveyard.Cards.AddRange(smallesNonEmptyRow);
                smallesNonEmptyRow.Clear();
                UpdateLists();
                
            }
            return true;
        }

        if(estadoDeJuego.enemy == Player.Nordicos)
        {
            for (int i = 0; i < rowsNordic.Count; i++)
            {
                if(rowsNordic[i].Count > 0 && rowsNordic[i].Count < minCount)
                {
                    smallesNonEmptyRow = rowsNordic[i];
                    minCount = rowsNordic[i].Count;
                }
            }
            if(smallesNonEmptyRow != null)
            { 
                NordicGraveyard.Cards.AddRange(smallesNonEmptyRow);
                smallesNonEmptyRow.Clear();
                UpdateLists();
                
            }
            return true;
        }
        
        else return false;
    }

    public static bool AddIncrease(EstadoDeJuego estadoDeJuego)
    {
        if(estadoDeJuego.player == Player.Griegos)
        {
            try
            {
                if(estadoDeJuego.card.destinations[0] == Zonas.Melee) AddPowerMelee();
                if(estadoDeJuego.card.destinations[0] == Zonas.Range) AddPowerRange();
                if(estadoDeJuego.card.destinations[0] == Zonas.Siege) AddPowerSiege();
                
                void AddPowerMelee()
                {
                    if(GreekMelee.Cards.Count > 0)
                    {
                        for (int i = 0; i < GreekMelee.Cards.Count; i++)
                        {
                            if(GreekMelee.Cards[i] is UnityUnitCard card && !card.increaseActivated)
                            {
                                GreekMelee.Cards[i].Power += 1;
                                card.increaseActivated = true;
                            }
                            
                        }
                    }
                } 
                
                void AddPowerRange()
                {
                    if(GreekRange.Cards.Count > 0)
                    {
                        for (int i = 0; i < GreekRange.Cards.Count; i++)
                        {
                            if(GreekRange.Cards[i] is UnityUnitCard card && !card.increaseActivated)
                            {
                                GreekRange.Cards[i].Power += 1;
                                card.increaseActivated = true;
                            }
                           
                        }
                    }
                } 
                
                void AddPowerSiege()
                {
                    if(GreekSiege.Cards.Count > 0)
                    {
                        for (int i = 0; i < GreekSiege.Cards.Count; i++)
                        {
                            if(GreekSiege.Cards[i] is UnityUnitCard card && !card.increaseActivated)
                            {
                                GreekSiege.Cards[i].Power += 1;
                                card.increaseActivated = true;
                            }
                           
                        }
                    }
                }
                UpdateLists();
                return true;
            } 
            catch
            {
                return false;
            }
        }

        if(estadoDeJuego.player == Player.Nordicos)
        {
            try
            {
                if(estadoDeJuego.card.destinations[0] == Zonas.Melee) AddPowerMelee();
                if(estadoDeJuego.card.destinations[0] == Zonas.Range) AddPowerRange();
                if(estadoDeJuego.card.destinations[0] == Zonas.Siege) AddPowerSiege();
                
                void AddPowerMelee()
                {
                    if(NordicMelee.Cards.Count > 0)
                    {
                        for (int i = 0; i < NordicMelee.Cards.Count; i++)
                        {
                            if(NordicMelee.Cards[i] is UnityUnitCard card && !card.increaseActivated)
                            {
                                NordicMelee.Cards[i].Power += 1;
                                card.increaseActivated = true;
                            }
                        }
                    }
                } 
                
                void AddPowerRange()
                {
                    if(NordicRange.Cards.Count > 0)
                    {
                        for (int i = 0; i < NordicRange.Cards.Count; i++)
                        {
                            if(NordicRange.Cards[i] is UnityUnitCard card && !card.increaseActivated)
                            {
                                NordicRange.Cards[i].Power += 1;
                                card.increaseActivated = true;
                            }
                        }
                    }
                } 
                
                void AddPowerSiege()
                {
                    if(NordicSiege.Cards.Count > 0)
                    {
                        for (int i = 0; i < NordicSiege.Cards.Count; i++)
                        {
                            if(NordicSiege.Cards[i] is UnityUnitCard card && !card.increaseActivated)
                            {
                                NordicSiege.Cards[i].Power += 1;
                                card.increaseActivated = true;
                            }
                        }
                    }
                }
                UpdateLists();
                return true;
            } 
            catch
            {
                return false;
            }
        }return false;
    }

    public static bool SetWeatherPoseidón(EstadoDeJuego estadoDeJuego)
    {
        try{
            if(GreekSiege.Cards.Count > 0)
            {
                SubtractPowerGreek();
            }
            if(NordicSiege.Cards.Count > 0)
            {
                SubtractPowerNordic();
            }
            void SubtractPowerGreek()
            {
                for (int i = 0; i <GreekSiege.Cards.Count; i++)
                {
                GreekSiege.Cards[i].Power -= 2;
                }

            }
            void SubtractPowerNordic()
            {
                for (int i = 0; i < NordicSiege.Cards.Count; i++)
                {
                    NordicSiege.Cards[i].Power -= 2;
                }
            }
            UpdateLists();
            return true;
        }
        catch
        {
            return false;
        }
        
    }

    public static bool SetWeatherThor(EstadoDeJuego estadoDeJuego)
    {
        try{
            if(GreekRange.Cards.Count > 0)
            {
                SubtractPowerGreek();
            }
            if(NordicRange.Cards.Count > 0)
            {
                SubtractPowerNordic();
            }
            void SubtractPowerGreek()
            {
                for (int i = 0; i <GreekRange.Cards.Count; i++)
                {
                GreekRange.Cards[i].Power -= 2;
                }

            }
            void SubtractPowerNordic()
            {
                for (int i = 0; i < NordicRange.Cards.Count; i++)
                {
                    NordicRange.Cards[i].Power -= 2;
                }
            }
            UpdateLists();
            return true;
        }
        catch
        {
            return false;
        }
        
    }

    public static bool SetClimate(EstadoDeJuego estadoDeJuego)
    {
        if(estadoDeJuego.card.destinations[0] == Zonas.Melee)
        {
            SubtractPowerMelee();
            return true;
        }
        else if(estadoDeJuego.card.destinations[0] == Zonas.Range)
        {
            SubtractPowerRange();
            return true;
        }
        else if(estadoDeJuego.card.destinations[0] == Zonas.Siege)
        {
            SubtractPowerSiege();
            return true;
        }
        void SubtractPowerMelee()
        {
            if(GreekMelee.Cards.Count > 0)
            {
                foreach (var item in GreekMelee.Cards)
                {
                    if((item is UnityUnitCard card) && card.worth == Worth.Silver && !card.climateActivated)
                    {
                        item.Power -= 2; 
                        item.climateActivated = true;
                    }
                }
            }
            
            if(NordicMelee.Cards.Count > 0)
            {
                foreach (var item in NordicMelee.Cards)
                {
                    if((item is UnityUnitCard card) && card.worth == Worth.Silver && !card.climateActivated)
                    {
                        item.Power -= 2;
                        item.climateActivated = true;
                    }
                }

            }
            UpdateLists();
        }
         void SubtractPowerRange()
        {
            if(GreekRange.Cards.Count > 0)
            {
                foreach (var item in GreekRange.Cards)
                {
                    if((item is UnityUnitCard card) && card.worth == Worth.Silver && !card.climateActivated)
                    {
                        item.Power -= 2;
                        item.climateActivated = true;
                    }
                }
            }
            
            if(NordicRange.Cards.Count > 0)
            {
                foreach (var item in NordicRange.Cards)
                {
                    if((item is UnityUnitCard card) && card.worth == Worth.Silver && !card.climateActivated)
                    {
                        item.Power -= 2;
                        item.climateActivated = true;
                    }
                }

            }
            UpdateLists();
        }

        void SubtractPowerSiege()
        {
            if(GreekSiege.Cards.Count > 0)
            {
                foreach (var item in GreekSiege.Cards)
                {
                    if((item is UnityUnitCard card) && card.worth == Worth.Silver && !card.climateActivated)
                    {
                        item.Power -= 2;
                        item.climateActivated = true;
                    }
                }

            }
            
            if(NordicSiege.Cards.Count > 0)
            {
                foreach (var item in NordicSiege.Cards)
                {
                    if((item is UnityUnitCard card) && card.worth == Worth.Silver && !card.climateActivated)
                    {
                        item.Power -= 2;
                        item.climateActivated = true;
                    }
                }

            }
            UpdateLists();
        }
        return false;
       
    }

    public static bool Clearance(EstadoDeJuego estadoDeJuego)
    {
        if(estadoDeJuego.card.destinations[0] == Zonas.Melee)
        {
            AddPowerMelee();
            return true;
        }
        else if(estadoDeJuego.card.destinations[0] == Zonas.Range)
        {
            AddPowerRange();
            return true;
        }
        else if(estadoDeJuego.card.destinations[0] == Zonas.Siege)
        {
            AddPowerSiege();
            return true;
        }

        void AddPowerMelee()
        {
            if(GreekMelee.Cards.Count > 0)
            {
                for (int i = 0; i < GreekMelee.Cards.Count; i++)
                {
                    if((GreekMelee.Cards[i] is UnityUnitCard card) && card.worth == Worth.Silver && card.climateActivated)
                    {
                        GreekMelee.Cards[i].Power += 2;
                        GreekMelee.Cards[i].climateActivated = false;
                    }
                }
            }
            
            if(NordicMelee.Cards.Count > 0)
            {
                for (int i = 0; i < NordicMelee.Cards.Count; i++)
                {
                    if((NordicMelee.Cards[i] is UnityUnitCard card) && card.worth == Worth.Silver && card.climateActivated)
                    {
                        NordicMelee.Cards[i].Power += 2;
                        NordicMelee.Cards[i].climateActivated = false;
                    }
                }

            }

            int index = 0;
            while (index < Climate.Cards.Count)
            {
                if(Climate.Cards[index] != null && Climate.Cards[index] is UnityClimateCard card && card.destinations[0]==Zonas.Melee)
                {
                    if(Climate.Cards[index].Faction == Faction.Greek_Gods) GreekGraveyard.Cards.Add(Climate.Cards[index]);
                    else NordicGraveyard.Cards.Add(Climate.Cards[index]);
                    Climate.Cards.Remove(Climate.Cards[index]);
                    index ++;
                }
            }
            
            UpdateLists();
        }

        void AddPowerRange()
        {
            if(GreekRange.Cards.Count > 0)
            {
                for (int i = 0; i < GreekRange.Cards.Count; i++)
                {
                    if((GreekRange.Cards[i] is UnityUnitCard card) && card.worth == Worth.Silver && card.climateActivated)
                    {
                        GreekRange.Cards[i].Power += 2;
                        GreekRange.Cards[i].climateActivated = false;
                    }
                }

            }
            
            if(NordicRange.Cards.Count > 0)
            {
                for (int i = 0; i < NordicRange.Cards.Count; i++)
                {
                    if((NordicRange.Cards[i] is UnityUnitCard card) && card.worth == Worth.Silver && card.climateActivated)
                    {
                        NordicRange.Cards[i].Power += 2;
                        NordicRange.Cards[i].climateActivated = false;
                    }
                }

            }

             int index = 0;
            while (index < Climate.Cards.Count)
            {
                if(Climate.Cards[index] != null && Climate.Cards[index] is UnityClimateCard card && card.destinations[0]==Zonas.Melee)
                {
                    if(Climate.Cards[index].Faction == Faction.Greek_Gods) GreekGraveyard.Cards.Add(Climate.Cards[index]);
                    else NordicGraveyard.Cards.Add(Climate.Cards[index]);
                    Climate.Cards.Remove(Climate.Cards[index]);
                    index ++;
                }
            }
        
            UpdateLists();
        }

        void AddPowerSiege()
        {
            if(GreekSiege.Cards.Count > 0)
            {
                for (int i = 0; i < GreekSiege.Cards.Count; i++)
                {
                    if((GreekSiege.Cards[i] is UnityUnitCard card) && card.worth == Worth.Silver && card.climateActivated)
                    {
                        GreekSiege.Cards[i].Power += 2;
                        GreekSiege.Cards[i].climateActivated = false;
                    }
                }

            }
            
            if(NordicSiege.Cards.Count > 0)
            {
                for (int i = 0; i < NordicSiege.Cards.Count; i++)
                {
                    if((NordicSiege.Cards[i] is UnityUnitCard card) && card.worth == Worth.Silver && card.climateActivated)
                    {
                        NordicSiege.Cards[i].Power += 2;
                        NordicSiege.Cards[i].climateActivated = false;
                    }
                }

            }

            int index = 0;
            while (index < Climate.Cards.Count)
            {
                if(Climate.Cards[index] != null && Climate.Cards[index] is UnityClimateCard card && card.destinations[0]==Zonas.Melee)
                {
                    if(Climate.Cards[index].Faction == Faction.Greek_Gods) GreekGraveyard.Cards.Add(Climate.Cards[index]);
                    else NordicGraveyard.Cards.Add(Climate.Cards[index]);
                    Climate.Cards.Remove(Climate.Cards[index]);
                    index ++;
                }
            }
        
            UpdateLists();
        }
        return false; 
    }

    public static bool Increase(EstadoDeJuego estadoDeJuego)
    {
        if(estadoDeJuego.card.destinations[0] == Zonas.Melee)
        {
            AddPowerMelee();
            return true;
        }
        else if(estadoDeJuego.card.destinations[0] == Zonas.Range)
        {
            AddPowerRange();
            return true;
        }
        else if(estadoDeJuego.card.destinations[0] == Zonas.Siege)
        {
            AddPowerSiege();
            return true;
        }

        void AddPowerMelee()
        {
            if(GreekMelee.Cards.Count > 0)
            {
                for (int i = 0; i < GreekMelee.Cards.Count; i++)
                {
                    if((GreekMelee.Cards[i] is UnityUnitCard card) && card.worth == Worth.Silver && !card.increaseActivated)
                    {
                        GreekMelee.Cards[i].Power += 1;
                        card.increaseActivated = true;
                    }
                }
            }
            
            if(NordicMelee.Cards.Count > 0)
            {
                for (int i = 0; i < NordicMelee.Cards.Count; i++)
                {
                    if((NordicMelee.Cards[i] is UnityUnitCard card) && card.worth == Worth.Silver && !card.increaseActivated)
                    {
                        NordicMelee.Cards[i].Power += 1;
                        card.increaseActivated = true;
                    }
                }

            }
            
            UpdateLists();
        }

        void AddPowerRange()
        {
            if(GreekRange.Cards.Count > 0)
            {
                for (int i = 0; i < GreekRange.Cards.Count; i++)
                {
                    if((GreekRange.Cards[i] is UnityUnitCard card) && card.worth == Worth.Silver && !card.increaseActivated)
                    {
                        GreekRange.Cards[i].Power += 1;
                        card.increaseActivated = true;
                    }
                }

            }
            
            if(NordicRange.Cards.Count > 0)
            {
                for (int i = 0; i < NordicRange.Cards.Count; i++)
                {
                    if((NordicRange.Cards[i] is UnityUnitCard card) && card.worth == Worth.Silver && !card.increaseActivated)
                    {
                        NordicRange.Cards[i].Power += 1;
                        card.increaseActivated = true;
                    }
                }

            }
        
            UpdateLists();
        }

        void AddPowerSiege()
        {
            if(GreekSiege.Cards.Count > 0)
            {
                for (int i = 0; i < GreekSiege.Cards.Count; i++)
                {
                    if((GreekSiege.Cards[i] is UnityUnitCard card) && card.worth == Worth.Silver && !card.increaseActivated)
                    {
                        GreekSiege.Cards[i].Power += 1;
                        card.increaseActivated = true;
                    }
                }

            }
            
            if(NordicSiege.Cards.Count > 0)
            {
                for (int i = 0; i < NordicSiege.Cards.Count; i++)
                {
                    if((NordicSiege.Cards[i] is UnityUnitCard card) && card.worth == Worth.Silver && !card.increaseActivated)
                    {
                        NordicSiege.Cards[i].Power += 1;
                        card.increaseActivated = true;

                    }
                }

            }

        
            UpdateLists();
        }
        return false; 
    }

    public static bool LeaderZeus(EstadoDeJuego estadoDeJuego)
    {
        if(!estadoDeJuego.card.leader)
        {
            if(GreekMelee.Cards.Count > 0)
            {
                AddPower();
            }

            void AddPower()
            {
                for (int i = 0; i < GreekMelee.Cards.Count; i++)
                {
                    if(GreekMelee.Cards[i] is UnityUnitCard card && card.worth == Worth.Silver && !card.increaseActivated) 
                    {
                        GreekMelee.Cards[i].Power += 2;
                        card.increaseActivated = true;
                    }
                }
            } 
            estadoDeJuego.card.leader = true;
            UpdateLists();
            return true;
        }
        return false;
    }

    public static bool LeaderOdin(EstadoDeJuego estadoDeJuego)
    {
        bool odin = EliminateMostPowerfullCard(estadoDeJuego);
        estadoDeJuego.card.leader = false;
        return odin;
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
        {"Skadi" , MultiplyPower },

        {"Ares", RemoveLeastPowerfulCard },
        {"Tyr", RemoveLeastPowerfulCard },

        {"Apolo", ClearRow },
        {"Valquiria", ClearRow },

        {"Hera", AddIncrease },
        {"Balder", AddIncrease },
        
        {"Poseidón", SetWeatherPoseidón },
        {"Thor", SetWeatherThor },

        {"Climate Melee", SetClimate },
        {"Climate Range", SetClimate },
        {"Climate Siege", SetClimate },

        {"Clearance Melee", Clearance },
        {"Clearance Range", Clearance },
        {"Clearance Siege", Clearance },

        {"Increase Melee", Increase },
        {"Increase Range", Increase },
        {"Increase Siege", Increase },

        {"Odin", LeaderOdin },
        {"Zeus", LeaderZeus },
    };
}

public delegate bool EffectDelegate(EstadoDeJuego estadoDeJuego);