using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeletransportationCard : MonoBehaviour
{
    public static int player1Points;
    public static int player2Points;
    public static bool player1PlayedACard;
    public static bool player2PlayedACard;

    //gameObject.transform.localScale = new Vector3(1, 1, 1);

    void Start()
    {
        player1Points = 0;
        player2Points = 0;

    }

    public void OnClick()
    {
        if(TurnSystem.player1Turn == true)
        {
            if (this.gameObject.GetComponent<DisplayCard>().card.zone == "M" && this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Griegos")
            {
                this.gameObject.transform.SetParent(GameObject.Find("ZoneMelee").transform, false);
                GameObject.Find("ZoneMelee").GetComponent<ScriptZone>().Melee.Add(this.gameObject);
                GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                player1PlayedACard = true;

            }

            else if (this.gameObject.GetComponent<DisplayCard>().card.zone == "S" && this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Griegos")
            {
                this.gameObject.transform.SetParent(GameObject.Find("ZoneSiege").transform, false);
                GameObject.Find("ZoneSiege").GetComponent<ScriptZone>().Siege.Add(this.gameObject);
                GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                player1PlayedACard = true;
            }

           else if (this.gameObject.GetComponent<DisplayCard>().card.zone == "R" && this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Griegos")
            {
                this.gameObject.transform.SetParent(GameObject.Find("ZoneRange").transform, false);
                GameObject.Find("ZoneRange").GetComponent<ScriptZone>().Range.Add(this.gameObject);
                GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                player1PlayedACard = true;
            }

            else if (this.gameObject.GetComponent<DisplayCard>().card.zone == "Cl" && this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Griegos")
            {
                this.gameObject.transform.SetParent(GameObject.Find("ZoneClimate").transform, false);
                GameObject.Find("ZoneClimate").GetComponent<ScriptZone>().RangeEnemy.Add(this.gameObject);
                GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                player1PlayedACard = true;
                /*if(TurnSystem.player1Turn == true)
                {
                    player1PlayedACard = true;
                }
                else
                {
                    player2PlayedACard = true;
                }*/
            }

            else if (this.gameObject.GetComponent<DisplayCard>().card.zone == "AuM" && this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Griegos")
            {
                this.gameObject.transform.SetParent(GameObject.Find("ZoneIncreaseMelee").transform, false);
                GameObject.Find("ZoneIncreaseMelee").GetComponent<ScriptZone>().RangeEnemy.Add(this.gameObject);
                GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                player1PlayedACard = true;
            }

            else if (this.gameObject.GetComponent<DisplayCard>().card.zone == "AuR" && this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Griegos")
            {   
                this.gameObject.transform.SetParent(GameObject.Find("ZoneIncreaseRange").transform, false);
                GameObject.Find("ZoneIncreaseRange").GetComponent<ScriptZone>().RangeEnemy.Add(this.gameObject);
                GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                player1PlayedACard = true;
            }

            else if (this.gameObject.GetComponent<DisplayCard>().card.zone == "AuS" && this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Griegos")
            {
                this.gameObject.transform.SetParent(GameObject.Find("ZoneIncreaseSiege").transform, false);
                GameObject.Find("ZoneIncreaseSiege").GetComponent<ScriptZone>().RangeEnemy.Add(this.gameObject);
                GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                player1PlayedACard = true;
            }
        }


        if(TurnSystem.player1Turn == false)
        {
            if (this.gameObject.GetComponent<DisplayCard>().card.zone == "M" && this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Nórdicos")
            {
                this.gameObject.transform.SetParent(GameObject.Find("ZoneMeleeEnemy").transform, false);
                GameObject.Find("ZoneMeleeEnemy").GetComponent<ScriptZone>().MeleeEnemy.Add(this.gameObject);
                GameObject.Find("enemyDeck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                player2PlayedACard = true;
            }

            else if (this.gameObject.GetComponent<DisplayCard>().card.zone == "S" && this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Nórdicos")
            {
                this.gameObject.transform.SetParent(GameObject.Find("ZoneSiegeEnemy").transform, false);
                GameObject.Find("ZoneSiegeEnemy").GetComponent<ScriptZone>().SiegeEnemy.Add(this.gameObject);
                GameObject.Find("enemyDeck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                player2PlayedACard = true;
            }

            else if (this.gameObject.GetComponent<DisplayCard>().card.zone == "R" && this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Nórdicos")
            {
                this.gameObject.transform.SetParent(GameObject.Find("ZoneRangeEnemy").transform, false);
                GameObject.Find("ZoneRangeEnemy").GetComponent<ScriptZone>().RangeEnemy.Add(this.gameObject);
                GameObject.Find("enemyDeck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                player2PlayedACard = true;
            }

            else if (this.gameObject.GetComponent<DisplayCard>().card.zone == "Cl" && this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Nórdicos")
            {
                this.gameObject.transform.SetParent(GameObject.Find("ZoneClimate").transform, false);
                GameObject.Find("ZoneClimate").GetComponent<ScriptZone>().RangeEnemy.Add(this.gameObject);
                GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                player2PlayedACard = true;
                /*if(TurnSystem.player1Turn == true)
                {
                    player1PlayedACard = true;
                }
                else
                {
                    player2PlayedACard = true;
                }*/
            }
        
            else if (this.gameObject.GetComponent<DisplayCard>().card.zone == "AuM" && this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Nórdicos")
            {
                this.gameObject.transform.SetParent(GameObject.Find("ZoneIncreaseMeleeEnemy").transform, false);
                GameObject.Find("ZoneIncreaseMeleeEnemy").GetComponent<ScriptZone>().RangeEnemy.Add(this.gameObject);
                GameObject.Find("enemyDeck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                player2PlayedACard = true;
            }

            else if (this.gameObject.GetComponent<DisplayCard>().card.zone == "AuR" && this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Nórdicos")
            {   
                this.gameObject.transform.SetParent(GameObject.Find("ZoneIncreaseRangeEnemy").transform, false);
                GameObject.Find("ZoneIncreaseRangeEnemy").GetComponent<ScriptZone>().RangeEnemy.Add(this.gameObject);
                GameObject.Find("enemyDeck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                player2PlayedACard = true;
            }

            else if (this.gameObject.GetComponent<DisplayCard>().card.zone == "AuS" && this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Nórdicos")
            {
                this.gameObject.transform.SetParent(GameObject.Find("ZoneIncreaseSiegeEnemy").transform, false);
                GameObject.Find("ZoneIncreaseSiegeEnemy").GetComponent<ScriptZone>().RangeEnemy.Add(this.gameObject);
                GameObject.Find("enemyDeck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                player2PlayedACard = true;
            }

        }
    }

}
