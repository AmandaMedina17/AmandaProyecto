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

    private void Start()
    {
        roundNumber = 1;
        enemyDeck = GameObject.Find("enemyDeck").GetComponent<Deck>();
        playerDeck = GameObject.Find("deck").GetComponent<Deck>();
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
        ClearZones();
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

    /*private void ClearZones();
    {
        ScriptZone.Melee.Clear();
        ScriptZone.MeleeEnemy.Clear();
        ScriptZone.Siege.Clear();
        ScriptZone.SiegeEnemy.Clear();
        ScriptZone.Range.Clear();
        ScriptZone.RangeEnemy.Clear();
        ScriptZone.Climate.Clear();
        ScriptZone.IncreaseMelee.Clear();
        ScriptZone.IncreaseMeleeEnemy.Clear();
        ScriptZone.IncreaseSiege.Clear();
        ScriptZone.IncreaseSiegeEnemy.Clear();
        ScriptZone.IncreaseRange.Clear();
        ScriptZone.IncreaseRangeEnemy.Clear();
    }*/
}