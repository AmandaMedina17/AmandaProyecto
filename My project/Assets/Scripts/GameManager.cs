using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int roundNumber;
    public TextMeshProUGUI roundText;

    private Deck enemyDeck;
    private Deck playerDeck;
    

    private ScriptZone melee;
    private ScriptZone meleeEnemy;
    private ScriptZone range;
    private ScriptZone rangeEnemy;
    private ScriptZone siege;
    private ScriptZone siegeEnemy;
    private ScriptZone climate;
    private ScriptZone increaseMelee;
    private ScriptZone increaseRange;
    private ScriptZone increaseSiege;
    private ScriptZone increaseMeleeEnemy;
    private ScriptZone increaseRangeEnemy;
    private ScriptZone increaseSiegeEnemy;

    public static int winner;

    private void Start()
    {
        roundNumber = 1;
        enemyDeck = GameObject.Find("enemyDeck").GetComponent<Deck>();
        playerDeck = GameObject.Find("deck").GetComponent<Deck>();

        melee = GameObject.Find("ZoneMelee").GetComponent<ScriptZone>();
        meleeEnemy = GameObject.Find("ZoneMeleeEnemy").GetComponent<ScriptZone>();
        range = GameObject.Find("ZoneRange").GetComponent<ScriptZone>();
        rangeEnemy = GameObject.Find("ZoneRangeEnemy").GetComponent<ScriptZone>();
        siege = GameObject.Find("ZoneSiege").GetComponent<ScriptZone>();
        siegeEnemy = GameObject.Find("ZoneSiegeEnemy").GetComponent<ScriptZone>();
        climate = GameObject.Find("ZoneClimate").GetComponent<ScriptZone>();
        increaseMelee = GameObject.Find("ZoneIncreaseMelee").GetComponent<ScriptZone>();
        increaseRange = GameObject.Find("ZoneIncreaseRange").GetComponent<ScriptZone>();
        increaseSiege = GameObject.Find("ZoneIncreaseSiege").GetComponent<ScriptZone>();
        increaseMeleeEnemy = GameObject.Find("ZoneIncreaseMeleeEnemy").GetComponent<ScriptZone>();
        increaseRangeEnemy = GameObject.Find("ZoneIncreaseRangeEnemy").GetComponent<ScriptZone>();
        increaseSiegeEnemy = GameObject.Find("ZoneIncreaseSiegeEnemy").GetComponent<ScriptZone>();
       
    }

    private void Update()
    {
        if (ButtonPass.player1Pass == true && ButtonPass.player2Pass == true)
        {
            roundNumber++;
            roundText.text = roundNumber.ToString();

            StartRound();
        }

        if (enemyDeck.CardsInHand.Count == 0 || playerDeck.CardsInHand.Count == 0)
        {
            roundNumber++;
            roundText.text = roundNumber.ToString();
            StartRound();
        }
    }

    private void StartRound()
    {
        for (int i = 0; i < 2; i++)
        {
            DrawCard();  
        }
        ButtonPass.player1Pass = false;
        ButtonPass.player2Pass = false;
        Limpiar();
        Judge();
        
    }

    private void DrawCard()
    {
        int randomIndex1 = Random.Range(0, enemyDeck.cardList.Count);
        GameObject drawCard1 = Instantiate(enemyDeck.cardList[randomIndex1], new Vector3(0, 0, 0), Quaternion.identity);
        drawCard1.transform.SetParent(enemyDeck.Hand.transform, false);
        enemyDeck.CardsInHand.Add(drawCard1);
        enemyDeck.cardList.RemoveAt(randomIndex1);

        int randomIndex2 = Random.Range(0, playerDeck.cardList.Count);
        GameObject drawCard2 = Instantiate(playerDeck.cardList[randomIndex2], new Vector3(0, 0, 0), Quaternion.identity);
        drawCard2.transform.SetParent(playerDeck.Hand.transform, false);
        playerDeck.CardsInHand.Add(drawCard2);
        playerDeck.cardList.RemoveAt(randomIndex2);
    }

    private void Limpiar()
    {
        //scriptZone.ClearZones();
        melee.ClearZones();
        meleeEnemy.ClearZones();
        range.ClearZones();
        rangeEnemy.ClearZones();
        siege.ClearZones();
        siegeEnemy.ClearZones();
        climate.ClearZones();
        increaseMelee.ClearZones();
        increaseRange.ClearZones();
        increaseSiege.ClearZones();
        increaseMeleeEnemy.ClearZones();
        increaseRangeEnemy.ClearZones();
        increaseSiegeEnemy.ClearZones();
    }

   /* private void ClearZones()
    {
        melee.Melee.Clear();
        meleeEnemy.MeleeEnemy.Clear();
        siege.Siege.Clear();
        siegeEnemy.SiegeEnemy.Clear();
        range.Range.Clear();
        rangeEnemy.RangeEnemy.Clear();
        climate.Climate.Clear();
        increaseMelee.IncreaseMelee.Clear();
        increaseMeleeEnemy.IncreaseMeleeEnemy.Clear();
        increaseSiege.IncreaseSiege.Clear();
        increaseSiegeEnemy.IncreaseSiegeEnemy.Clear();
        increaseRange.IncreaseRange.Clear();
        increaseRangeEnemy.IncreaseRangeEnemy.Clear();
    }*/

    public void Judge()
    {
        if(TeletransportationCard.player1Points < TeletransportationCard.player2Points)
        {
            winner = 2;
        }
        else if(TeletransportationCard.player1Points > TeletransportationCard.player2Points)
        {
            winner = 1;
        }
        else if(TeletransportationCard.player1Points == TeletransportationCard.player2Points)
        {
            winner = 0;
        }
       
    }
}