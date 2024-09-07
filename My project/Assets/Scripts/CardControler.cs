using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardControler : MonoBehaviour
{
    public UnityBaseCard card; // Referencia a la carta asociada

    public static bool GriegosPlayedACard= false;
    public static bool NordicosPlayedACard= false;

    public void OnCardClicked()
    {
        if ((card.Faction == Faction.Greek_Gods && ButtonPass.GreekPass) ||
            (card.Faction == Faction.Nordic_Gods && ButtonPass.NordicPass))
        {
            Debug.Log("Esta facción ya pasó. No puede jugar más cartas.");
            return;
        }

        if ((card.Faction == Faction.Greek_Gods && !TurnSystem.GreekTurn) ||
            (card.Faction == Faction.Nordic_Gods && TurnSystem.GreekTurn))
        {
            Debug.Log("No es el turno de esta facción.");
            return;
        }

        if(card.TipoDeCarta == TipoDeCarta.Increase)
        {
            HandleIncreaseCard();
        }
        else if(card.TipoDeCarta == TipoDeCarta.Clearance)
        {
            HandleClearanceCard();
        }
        else if (card.TipoDeCarta == TipoDeCarta.Climate) 
        {
            HandleClimateCard();
        }
        else if(card.TipoDeCarta == TipoDeCarta.Bait)
        {
            HandleBaitCard();
        }
        else if(card.TipoDeCarta == TipoDeCarta.Unit)
        {
            HandleNormalCard();
        }

        ExecuteCardEffect();

        UpdatePlayedCardStatus();
        ChangeTurn();
    }

    private void ExecuteCardEffect()
    {
        // Crear un objeto EstadoDeJuego con la información necesaria
        EstadoDeJuego estadoDeJuego = new EstadoDeJuego(GetCurrentPlayer(), GetEnemyPlayer(), card);


        // Obtener y ejecutar el efecto de la carta
        EffectDelegate effect = SavedEffects.ObtenerEfecto(card.Name);
        bool effectSuccess = effect(estadoDeJuego);

        if (effectSuccess)
        {
            Debug.Log($"Efecto de {card.Name} ejecutado con éxito.");
        }
        else
        {
            Debug.Log($"No se pudo ejecutar el efecto de {card.Name}.");
        }
    }

    private Player GetCurrentPlayer()
    {
        return TurnSystem.GreekTurn ? Player.Griegos: Player.Nordicos;
    }

    private Player GetEnemyPlayer()
    {
        return TurnSystem.GreekTurn ? Player.Nordicos : Player.Griegos;
    }


    private void HandleIncreaseCard()
    {
        if (card.destinations[0] == Zonas.Melee)
        {
            if(card.Faction == Faction.Greek_Gods && TurnSystem.GreekTurn)
            {
                MoveCardToIncreaseMeleeGreek();
            }
            else if(!TurnSystem.GreekTurn) 
            {
                MoveCardToIncreaseMeleeNordic();
            }
        }
        else if (card.destinations[0] == Zonas.Range)
        {
            if(card.Faction == Faction.Greek_Gods && TurnSystem.GreekTurn)
            {
                MoveCardToIncreaseRangeGreek();
            }
            else if(!TurnSystem.GreekTurn) 
            {
                MoveCardToIncreaseRangeNordic();
            }
        }
        else if (card.destinations[0] == Zonas.Siege)
        {
            if(card.Faction == Faction.Greek_Gods && TurnSystem.GreekTurn)
            {
                MoveCardToIncreaseSiegeGreek();
            }
            else if(!TurnSystem.GreekTurn) 
            {
                MoveCardToIncreaseSiegeNordic();
            }
        }
    }

    private void HandleClearanceCard()
    {
        if(card.Faction == Faction.Greek_Gods && TurnSystem.GreekTurn)
        {
            MoveCardToGraveyardGreek("GreekHand");
        }
        else if(!TurnSystem.GreekTurn) 
        {
            MoveCardToGraveyardNordic("NordicHand");
        }
    }

    private void HandleClimateCard()
    {
        if(card.Faction == Faction.Greek_Gods && TurnSystem.GreekTurn)
        {
            MoveCardToClimateGreek();
        }
        else if(!TurnSystem.GreekTurn) 
        {
            MoveCardToClimateNordic();
        }
    }

    private void HandleBaitCard()
    {
        if(card.Faction == Faction.Greek_Gods && TurnSystem.GreekTurn)
        {
            baitGreek();
        }
        else if(!TurnSystem.GreekTurn)
        {
            baitNordic();
        }
    }

    private void HandleNormalCard()
    {
        if (card.destinations[0] == Zonas.Melee)
        {
            if(card.Faction == Faction.Greek_Gods && TurnSystem.GreekTurn)
            {
                MoveCardToMeleeGreek();
            }
            else if(!TurnSystem.GreekTurn) 
            {
                MoveCardToMeleeNordic();
            }
        }
        else if (card.destinations[0] == Zonas.Range)
        {
            if(card.Faction == Faction.Greek_Gods && TurnSystem.GreekTurn)
            {
                MoveCardToRangeGreek();
            }
            else if(!TurnSystem.GreekTurn) 
            {
                MoveCardToRangeNordic();
            }
        }
        else if (card.destinations[0] == Zonas.Siege)
        {
            if(card.Faction == Faction.Greek_Gods && TurnSystem.GreekTurn)
            {
                MoveCardToSiegeGreek();
            }
            else if(!TurnSystem.GreekTurn) 
            {
                MoveCardToSiegeNordic();
            }
        }
    }

    private void UpdatePlayedCardStatus()
    {
        if (card.Faction == Faction.Greek_Gods)
        {
            GriegosPlayedACard = true;
        }
        else
        {
            NordicosPlayedACard = true;
        }
    }

    private void ChangeTurn()
    {
        if (card.Faction == Faction.Greek_Gods && !ButtonPass.NordicPass)
        {
            TurnSystem.GreekTurn = false;
        }
        else if (card.Faction == Faction.Nordic_Gods && !ButtonPass.GreekPass)
        {
            TurnSystem.GreekTurn = true;
        }
    }

    private void MoveCardToIncreaseMeleeGreek()
    {
        // Busca el GameObject "Melee" y obtén el script ScriptZone
        GameObject meleeObject = GameObject.Find("GreekIncreaseMelee");
        ScriptZone meleeScript = meleeObject.GetComponent<ScriptZone>();

        GameObject hand = GameObject.Find("GreekHand");
        ScriptZone handscript = hand.GetComponent<ScriptZone>();

        // Elimina la carta de la lista actual
        handscript.Cards.Remove(card);

        // Agrega la carta a la lista de Melee
        meleeScript.Cards.Add(card);

        handscript.UpdateList();
        meleeScript.UpdateList();

    }
    
        private void MoveCardToIncreaseMeleeNordic()
    {
        // Busca el GameObject "Melee" y obtén el script ScriptZone
        GameObject meleeObject = GameObject.Find("NordicIncreaseMelee");
        ScriptZone meleeScript = meleeObject.GetComponent<ScriptZone>();

        GameObject hand = GameObject.Find("NordicHand");
        ScriptZone handscript = hand.GetComponent<ScriptZone>();

        // Elimina la carta de la lista actual
        handscript.Cards.Remove(card);

        // Agrega la carta a la lista de Melee
        meleeScript.Cards.Add(card);

         handscript.UpdateList();
        meleeScript.UpdateList();

    }
        private void MoveCardToIncreaseRangeGreek()
    {
        // Busca el GameObject "Melee" y obtén el script ScriptZone
        GameObject rangeObject = GameObject.Find("GreekIncreaseRange");
        ScriptZone rangeScript = rangeObject.GetComponent<ScriptZone>();

        GameObject hand = GameObject.Find("GreekHand");
        ScriptZone handscript = hand.GetComponent<ScriptZone>();

        // Elimina la carta de la lista actual
        handscript.Cards.Remove(card);

        // Agrega la carta a la lista de Melee
        rangeScript.Cards.Add(card);

         handscript.UpdateList();
        rangeScript.UpdateList();

    }
        private void MoveCardToIncreaseRangeNordic()
    {
        // Busca el GameObject "Melee" y obtén el script ScriptZone
        GameObject rangeObject = GameObject.Find("NordicIncreaseRange");
        ScriptZone rangeScript = rangeObject.GetComponent<ScriptZone>();

        GameObject hand = GameObject.Find("NordicHand");
        ScriptZone handscript = hand.GetComponent<ScriptZone>();

        // Elimina la carta de la lista actual
        handscript.Cards.Remove(card);

        // Agrega la carta a la lista de Melee
        rangeScript.Cards.Add(card);

         handscript.UpdateList();
        rangeScript.UpdateList();

    }
        private void MoveCardToIncreaseSiegeGreek()
    {
        // Busca el GameObject "Melee" y obtén el script ScriptZone
        GameObject siegeObject = GameObject.Find("GreekIncreaseSiege");
        ScriptZone siegeScript = siegeObject.GetComponent<ScriptZone>();

        GameObject hand = GameObject.Find("GreekHand");
        ScriptZone handscript = hand.GetComponent<ScriptZone>();

        // Elimina la carta de la lista actual
        handscript.Cards.Remove(card);

        // Agrega la carta a la lista de Melee
        siegeScript.Cards.Add(card);

         handscript.UpdateList();
        siegeScript.UpdateList();

    }
        private void MoveCardToIncreaseSiegeNordic()
    {
        // Busca el GameObject "Melee" y obtén el script ScriptZone
        GameObject siegeObject = GameObject.Find("NordicIncreaseSiege");
        ScriptZone siegeScript = siegeObject.GetComponent<ScriptZone>();

        GameObject hand = GameObject.Find("NordicHand");
        ScriptZone handscript = hand.GetComponent<ScriptZone>();

        // Elimina la carta de la lista actual
        handscript.Cards.Remove(card);

        // Agrega la carta a la lista de Melee
        siegeScript.Cards.Add(card);

         handscript.UpdateList();
        siegeScript.UpdateList();

    }
     
    private void MoveCardToClimateGreek()
    {
        GameObject climsteObject = GameObject.Find("Climate");
        ScriptZone climateScript = climsteObject.GetComponent<ScriptZone>();

        GameObject hand = GameObject.Find("GreekHand");
        ScriptZone handscript = hand.GetComponent<ScriptZone>();

        // Elimina la carta de la lista actual
        handscript.Cards.Remove(card);

        // Agrega la carta a la lista de Melee
        climateScript.Cards.Add(card);

        handscript.UpdateList();
        climateScript.UpdateList();
    }

     private void MoveCardToClimateNordic()
    {
        GameObject climsteObject = GameObject.Find("Climate");
        ScriptZone climateScript = climsteObject.GetComponent<ScriptZone>();

        GameObject hand = GameObject.Find("NordicHand");
        ScriptZone handscript = hand.GetComponent<ScriptZone>();

        // Elimina la carta de la lista actual
        handscript.Cards.Remove(card);

        // Agrega la carta a la lista de Melee
        climateScript.Cards.Add(card);

        handscript.UpdateList();
        climateScript.UpdateList();
    }

    private void MoveCardToMeleeGreek()
    {
        // Busca el GameObject "Melee" y obtén el script ScriptZone
        GameObject meleeObject = GameObject.Find("GreekMelee");
        ScriptZone meleeScript = meleeObject.GetComponent<ScriptZone>();

        GameObject hand = GameObject.Find("GreekHand");
        ScriptZone handscript = hand.GetComponent<ScriptZone>();

        // Elimina la carta de la lista actual
        handscript.Cards.Remove(card);

        // Agrega la carta a la lista de Melee
        meleeScript.Cards.Add(card);

        handscript.UpdateList();
        meleeScript.UpdateList();

    }
    
        private void MoveCardToMeleeNordic()
    {
        // Busca el GameObject "Melee" y obtén el script ScriptZone
        GameObject meleeObject = GameObject.Find("NordicMelee");
        ScriptZone meleeScript = meleeObject.GetComponent<ScriptZone>();

        GameObject hand = GameObject.Find("NordicHand");
        ScriptZone handscript = hand.GetComponent<ScriptZone>();

        // Elimina la carta de la lista actual
        handscript.Cards.Remove(card);

        // Agrega la carta a la lista de Melee
        meleeScript.Cards.Add(card);

         handscript.UpdateList();
        meleeScript.UpdateList();

    }
        private void MoveCardToRangeGreek()
    {
        // Busca el GameObject "Melee" y obtén el script ScriptZone
        GameObject rangeObject = GameObject.Find("GreekRange");
        ScriptZone rangeScript = rangeObject.GetComponent<ScriptZone>();

        GameObject hand = GameObject.Find("GreekHand");
        ScriptZone handscript = hand.GetComponent<ScriptZone>();

        // Elimina la carta de la lista actual
        handscript.Cards.Remove(card);

        // Agrega la carta a la lista de Melee
        rangeScript.Cards.Add(card);

         handscript.UpdateList();
        rangeScript.UpdateList();

    }
        private void MoveCardToRangeNordic()
    {
        // Busca el GameObject "Melee" y obtén el script ScriptZone
        GameObject rangeObject = GameObject.Find("NordicRange");
        ScriptZone rangeScript = rangeObject.GetComponent<ScriptZone>();

        GameObject hand = GameObject.Find("NordicHand");
        ScriptZone handscript = hand.GetComponent<ScriptZone>();

        // Elimina la carta de la lista actual
        handscript.Cards.Remove(card);

        // Agrega la carta a la lista de Melee
        rangeScript.Cards.Add(card);

         handscript.UpdateList();
        rangeScript.UpdateList();

    }
        private void MoveCardToSiegeGreek()
    {
        // Busca el GameObject "Melee" y obtén el script ScriptZone
        GameObject siegeObject = GameObject.Find("GreekSiege");
        ScriptZone siegeScript = siegeObject.GetComponent<ScriptZone>();

        GameObject hand = GameObject.Find("GreekHand");
        ScriptZone handscript = hand.GetComponent<ScriptZone>();

        // Elimina la carta de la lista actual
        handscript.Cards.Remove(card);

        // Agrega la carta a la lista de Melee
        siegeScript.Cards.Add(card);

         handscript.UpdateList();
        siegeScript.UpdateList();

    }
        private void MoveCardToSiegeNordic()
    {
        // Busca el GameObject "Melee" y obtén el script ScriptZone
        GameObject siegeObject = GameObject.Find("NordicSiege");
        ScriptZone siegeScript = siegeObject.GetComponent<ScriptZone>();

        GameObject hand = GameObject.Find("NordicHand");
        ScriptZone handscript = hand.GetComponent<ScriptZone>();

        // Elimina la carta de la lista actual
        handscript.Cards.Remove(card);

        // Agrega la carta a la lista de Melee
        siegeScript.Cards.Add(card);

         handscript.UpdateList();
        siegeScript.UpdateList();

    }

    public void MoveCardToGraveyardGreek(string position)
    {
        GameObject graveyardObject = GameObject.Find("GreekGraveyard");
        ScriptZone graveyardScript = graveyardObject.GetComponent<ScriptZone>();

        GameObject zone = GameObject.Find(position);
        ScriptZone zoneScript = zone.GetComponent<ScriptZone>();

        // Elimina la carta de la lista actual
        zoneScript.Cards.Remove(card);

        // Agrega la carta a la lista de Melee
        graveyardScript.Cards.Add(card);

         zoneScript.UpdateList();
        graveyardScript.UpdateList();
    }

    public void MoveCardToGraveyardNordic(string position)
    {
         GameObject graveyardObject = GameObject.Find("NordicGraveyard");
        ScriptZone graveyardScript = graveyardObject.GetComponent<ScriptZone>();

        GameObject zone = GameObject.Find(position);
        ScriptZone zoneScript = zone.GetComponent<ScriptZone>();

        // Elimina la carta de la lista actual
        zoneScript.Cards.Remove(card);

        // Agrega la carta a la lista de Melee
        graveyardScript.Cards.Add(card);

         zoneScript.UpdateList();
        graveyardScript.UpdateList();
    }

    public void baitGreek()
    {
        UnityBaseCard mostPowerfulCard = null;
        int maxPower = int.MinValue;
        GameObject MeleeObject = GameObject.Find("GreekMelee");
        GameObject RangeObject = GameObject.Find("GreekRange");
        GameObject SiegeObject = GameObject.Find("GreekSiege");
        GameObject hand = GameObject.Find("GreekHand");
        ScriptZone handscript = hand.GetComponent<ScriptZone>();
        
        List<UnityBaseCard> Melee = MeleeObject.GetComponent<ScriptZone>().Cards;
        List<UnityBaseCard> Range = RangeObject.GetComponent<ScriptZone>().Cards;
        List<UnityBaseCard> Siege = SiegeObject.GetComponent<ScriptZone>().Cards;


        if(Melee.Count >0)
        {
            FindMostPowerfulCardInListMelee();
        }
        else if(Range.Count >0)
        {
            FindMostPowerfulCardInListRange();
        }
        
        else if(Siege.Count >0)
        {
            FindMostPowerfulCardInListSiege();
        }
        else 
        {
            Debug.LogWarning("no hay cartas en el campo");

        }
        void FindMostPowerfulCardInListMelee()
        {
            for (int i = 0; i < Melee.Count; i++)
            {
           
                if(Melee[i].Power > maxPower)
                {
                    mostPowerfulCard = Melee[i];
                    maxPower = Melee[i].Power;
                }
            }
        }
 
        void FindMostPowerfulCardInListRange()
        {
            for (int i = 0; i < Range.Count; i++)
            {
          
                if(Range[i].Power > maxPower)
                {
                    mostPowerfulCard = Range[i];
                    maxPower = Range[i].Power;
                }
            }
        }

        void FindMostPowerfulCardInListSiege()
        {
            for (int i = 0; i < Siege.Count; i++)
            {
            
                if(Siege[i].Power > maxPower)
                {
                    mostPowerfulCard = Siege[i];
                    maxPower = Siege[i].Power;
                }
            }    
        }
        if(mostPowerfulCard != null)
        {
            handscript.Cards.Add(mostPowerfulCard);
            if(Melee.Contains(mostPowerfulCard))
            {
                Melee.Add(card);
                Melee.Remove(mostPowerfulCard);
                handscript.Cards.Remove(card);
                MeleeObject.GetComponent<ScriptZone>().UpdateList();
            }
            else if(Range.Contains(mostPowerfulCard))
            {
                Range.Add(card);
                Range.Remove(mostPowerfulCard);
                handscript.Cards.Remove(card);
                RangeObject.GetComponent<ScriptZone>().UpdateList();
            }
            else if(Siege.Contains(mostPowerfulCard))
            {
                Siege.Add(card);
                Siege.Remove(mostPowerfulCard);
                handscript.Cards.Remove(card);
                SiegeObject.GetComponent<ScriptZone>().UpdateList();
            }
            handscript.UpdateList();
        }
    }

    public void baitNordic()
    {
        UnityBaseCard mostPowerfulCard = null;
        int maxPower = int.MinValue;
        GameObject MeleeObject = GameObject.Find("NordicMelee");
        GameObject RangeObject = GameObject.Find("NordicRange");
        GameObject SiegeObject = GameObject.Find("NordicSiege");
        GameObject hand = GameObject.Find("NordicHand");
        ScriptZone handscript = hand.GetComponent<ScriptZone>();
        
        List<UnityBaseCard> Melee = MeleeObject.GetComponent<ScriptZone>().Cards;
        List<UnityBaseCard> Range = RangeObject.GetComponent<ScriptZone>().Cards;
        List<UnityBaseCard> Siege = SiegeObject.GetComponent<ScriptZone>().Cards;


        if(Melee.Count >0)
        {
            FindMostPowerfulCardInListMelee();
        }
        else if(Range.Count >0)
        {
            FindMostPowerfulCardInListRange();
        }
        
        else if(Siege.Count >0)
        {
            FindMostPowerfulCardInListSiege();
        }
        else 
        {
            Debug.LogWarning("no hay cartas en el campo");

        }
        void FindMostPowerfulCardInListMelee()
        {
            for (int i = 0; i < Melee.Count; i++)
            {
           
                if(Melee[i].Power > maxPower)
                {
                    mostPowerfulCard = Melee[i];
                    maxPower = Melee[i].Power;
                }
            }
        }
 
        void FindMostPowerfulCardInListRange()
        {
            for (int i = 0; i < Range.Count; i++)
            {
          
                if(Range[i].Power > maxPower)
                {
                    mostPowerfulCard = Range[i];
                    maxPower = Range[i].Power;
                }
            }
        }

        void FindMostPowerfulCardInListSiege()
        {
            for (int i = 0; i < Siege.Count; i++)
            {
            
                if(Siege[i].Power > maxPower)
                {
                    mostPowerfulCard = Siege[i];
                    maxPower = Siege[i].Power;
                }
            }    
        }
        if(mostPowerfulCard != null)
        {
            handscript.Cards.Add(mostPowerfulCard);
            if(Melee.Contains(mostPowerfulCard))
            {
                Melee.Add(card);
                Melee.Remove(mostPowerfulCard);
                handscript.Cards.Remove(card);
                MeleeObject.GetComponent<ScriptZone>().UpdateList();
            }
            else if(Range.Contains(mostPowerfulCard))
            {
                Range.Add(card);
                Range.Remove(mostPowerfulCard);
                handscript.Cards.Remove(card);
                RangeObject.GetComponent<ScriptZone>().UpdateList();

            }
            else if(Siege.Contains(mostPowerfulCard))
            {
                Siege.Add(card);
                Siege.Remove(mostPowerfulCard);
                handscript.Cards.Remove(card);
                SiegeObject.GetComponent<ScriptZone>().UpdateList();

            }
            handscript.UpdateList();

        }
    }
     
}