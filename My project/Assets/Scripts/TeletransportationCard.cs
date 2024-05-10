using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeletransportationCard : MonoBehaviour
{
    public Card card;
    //public static int player1Points;
    //public static int player2Points;
    public static bool player1PlayedACard;
    public static bool player2PlayedACard;
    //public static bool tele;
    //public static bool effect;



    //gameObject.transform.localScale = new Vector3(1, 1, 1);

    void Start()
    {
        //player1Points = 0;
        //player2Points = 0;
       
       
    }

    public void OnClick()
    {
        //if(this.gameObject.GetComponent<DisplayCard>().card.tele == true && this.gameObject.GetComponent<DisplayCard>().card.effect==false)
        //{
            if(TurnSystem.player1Turn == true)
            {
                if (this.gameObject.GetComponent<DisplayCard>().card.zone == "M" && this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Griegos")
                {
                    this.gameObject.transform.SetParent(GameObject.Find("ZoneMelee").transform, false);
                    GameObject.Find("ZoneMelee").GetComponent<ScriptZone>().Melee.Add(this.gameObject);
                    GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                    player1PlayedACard = true;
                    //this.gameObject.GetComponent<DisplayCard>().card.tele = false;
                    //this.gameObject.GetComponent<DisplayCard>().card.effect = true;
                    //player1Points = player1Points + this.gameObject.GetComponent<DisplayCard>().card.power;
                }

                else if (this.gameObject.GetComponent<DisplayCard>().card.zone == "S" && this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Griegos")
                {
                    this.gameObject.transform.SetParent(GameObject.Find("ZoneSiege").transform, false);
                    GameObject.Find("ZoneSiege").GetComponent<ScriptZone>().Siege.Add(this.gameObject);
                    GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                    player1PlayedACard = true;
                    //this.gameObject.GetComponent<DisplayCard>().card.tele = false;
                    //this.gameObject.GetComponent<DisplayCard>().card.effect = true;
                    //player1Points = player1Points + this.gameObject.GetComponent<DisplayCard>().card.power;
                }

            else if (this.gameObject.GetComponent<DisplayCard>().card.zone == "R" && this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Griegos")
                {
                    this.gameObject.transform.SetParent(GameObject.Find("ZoneRange").transform, false);
                    GameObject.Find("ZoneRange").GetComponent<ScriptZone>().Range.Add(this.gameObject);
                    GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                    player1PlayedACard = true;
                    //this.gameObject.GetComponent<DisplayCard>().card.tele = false;
                    //this.gameObject.GetComponent<DisplayCard>().card.effect = true;
                    //player1Points = player1Points + this.gameObject.GetComponent<DisplayCard>().card.power;
                }

                else if (this.gameObject.GetComponent<DisplayCard>().card.zone == "Cl" && this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Griegos")
                {
                    this.gameObject.transform.SetParent(GameObject.Find("ZoneClimate").transform, false);
                    GameObject.Find("ZoneClimate").GetComponent<ScriptZone>().Climate.Add(this.gameObject);
                    GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                    player1PlayedACard = true;
                    //this.gameObject.GetComponent<DisplayCard>().card.tele = false;
                    //this.gameObject.GetComponent<DisplayCard>().card.effect = true;
                    //player1Points = player1Points + this.gameObject.GetComponent<DisplayCard>().card.power;

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
                    GameObject.Find("ZoneIncreaseMelee").GetComponent<ScriptZone>().IncreaseMelee.Add(this.gameObject);
                    GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                    player1PlayedACard = true;
                    //this.gameObject.GetComponent<DisplayCard>().card.tele = false;
                    //this.gameObject.GetComponent<DisplayCard>().card.effect = true;
                    //player1Points = player1Points + this.gameObject.GetComponent<DisplayCard>().card.power;
                }

                else if (this.gameObject.GetComponent<DisplayCard>().card.zone == "AuR" && this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Griegos")
                {   
                    this.gameObject.transform.SetParent(GameObject.Find("ZoneIncreaseRange").transform, false);
                    GameObject.Find("ZoneIncreaseRange").GetComponent<ScriptZone>().IncreaseRange.Add(this.gameObject);
                    GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                    player1PlayedACard = true;
                    //this.gameObject.GetComponent<DisplayCard>().card.tele = false;
                    //this.gameObject.GetComponent<DisplayCard>().card.effect = true;
                    //player1Points = player1Points + this.gameObject.GetComponent<DisplayCard>().card.power;
                }

                else if (this.gameObject.GetComponent<DisplayCard>().card.zone == "AuS" && this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Griegos")
                {
                    this.gameObject.transform.SetParent(GameObject.Find("ZoneIncreaseSiege").transform, false);
                    GameObject.Find("ZoneIncreaseSiege").GetComponent<ScriptZone>().IncreaseSiege.Add(this.gameObject);
                    GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                    player1PlayedACard = true;
                    //this.gameObject.GetComponent<DisplayCard>().card.tele = false;
                    //this.gameObject.GetComponent<DisplayCard>().card.effect = true;
                    ///player1Points = player1Points + this.gameObject.GetComponent<DisplayCard>().card.power;
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
                    //this.gameObject.GetComponent<DisplayCard>().card.tele = false;
                    //this.gameObject.GetComponent<DisplayCard>().card.effect = true;
                    //player2Points = player2Points + this.gameObject.GetComponent<DisplayCard>().card.power;
                }

                else if (this.gameObject.GetComponent<DisplayCard>().card.zone == "S" && this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Nórdicos")
                {
                    this.gameObject.transform.SetParent(GameObject.Find("ZoneSiegeEnemy").transform, false);
                    GameObject.Find("ZoneSiegeEnemy").GetComponent<ScriptZone>().SiegeEnemy.Add(this.gameObject);
                    GameObject.Find("enemyDeck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                    player2PlayedACard = true;
                    //this.gameObject.GetComponent<DisplayCard>().card.tele = false;
                    //this.gameObject.GetComponent<DisplayCard>().card.effect = true;
                    //player2Points = player2Points + this.gameObject.GetComponent<DisplayCard>().card.power;
                }

                else if (this.gameObject.GetComponent<DisplayCard>().card.zone == "R" && this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Nórdicos")
                {
                    this.gameObject.transform.SetParent(GameObject.Find("ZoneRangeEnemy").transform, false);
                    GameObject.Find("ZoneRangeEnemy").GetComponent<ScriptZone>().RangeEnemy.Add(this.gameObject);
                    GameObject.Find("enemyDeck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                    player2PlayedACard = true;
                    //this.gameObject.GetComponent<DisplayCard>().card.tele = false;
                    //this.gameObject.GetComponent<DisplayCard>().card.effect = true;
                    //player2Points = player2Points + this.gameObject.GetComponent<DisplayCard>().card.power;
                }

                else if (this.gameObject.GetComponent<DisplayCard>().card.zone == "Cl" && this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Nórdicos")
                {
                    this.gameObject.transform.SetParent(GameObject.Find("ZoneClimate").transform, false);
                    GameObject.Find("ZoneClimate").GetComponent<ScriptZone>().Climate.Add(this.gameObject);
                    GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                    player2PlayedACard = true;
                    //this.gameObject.GetComponent<DisplayCard>().card.tele = false;
                    //this.gameObject.GetComponent<DisplayCard>().card.effect = true;
                    //player2Points = player2Points + this.gameObject.GetComponent<DisplayCard>().card.power;

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
                    GameObject.Find("ZoneIncreaseMeleeEnemy").GetComponent<ScriptZone>().IncreaseMeleeEnemy.Add(this.gameObject);
                    GameObject.Find("enemyDeck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                    player2PlayedACard = true;
                    //this.gameObject.GetComponent<DisplayCard>().card.tele = false;
                    //this.gameObject.GetComponent<DisplayCard>().card.effect = true;
                    //player2Points = player2Points + this.gameObject.GetComponent<DisplayCard>().card.power;
                }

                else if (this.gameObject.GetComponent<DisplayCard>().card.zone == "AuR" && this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Nórdicos")
                {   
                    this.gameObject.transform.SetParent(GameObject.Find("ZoneIncreaseRangeEnemy").transform, false);
                    GameObject.Find("ZoneIncreaseRangeEnemy").GetComponent<ScriptZone>().IncreaseRangeEnemy.Add(this.gameObject);
                    GameObject.Find("enemyDeck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                    player2PlayedACard = true;
                    //this.gameObject.GetComponent<DisplayCard>().card.tele = false;
                    //this.gameObject.GetComponent<DisplayCard>().card.effect = true;
                    //player2Points = player2Points + this.gameObject.GetComponent<DisplayCard>().card.power;
                }

                else if (this.gameObject.GetComponent<DisplayCard>().card.zone == "AuS" && this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Nórdicos")
                {
                    this.gameObject.transform.SetParent(GameObject.Find("ZoneIncreaseSiegeEnemy").transform, false);
                    GameObject.Find("ZoneIncreaseSiegeEnemy").GetComponent<ScriptZone>().IncreaseSiegeEnemy.Add(this.gameObject);
                    GameObject.Find("enemyDeck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                    player2PlayedACard = true;
                    //this.gameObject.GetComponent<DisplayCard>().card.tele = false;
                    //this.gameObject.GetComponent<DisplayCard>().card.effect = true;
                    //player2Points = player2Points + this.gameObject.GetComponent<DisplayCard>().card.power;
                }

            }

            
        //}
    }

    void Update()
    {
        
    }

}
