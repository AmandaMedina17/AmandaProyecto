using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;


public class GameManager : MonoBehaviour
{
    public GameObject player1HandObject; // Referencia al GameObject de la mano del jugador 1
    public GameObject player2HandObject; // Referencia al GameObject de la mano del jugador 2
   
    public int roundNumber;
    public TextMeshProUGUI roundText;

    private ScriptZone GreekMelee;
    private ScriptZone NordicMelee;
    private ScriptZone GreekRange;
    private ScriptZone NordicRange;
    private ScriptZone GreekSiege;
    private ScriptZone NordicSiege;
    private ScriptZone GreekIncreaseMelee;
    private ScriptZone NordicIncreaseMelee;
    private ScriptZone GreekIncreaseRange;
    private ScriptZone NordicIncreaseRange;
    private ScriptZone GreekIncreaseSiege;
    private ScriptZone NordicIncreaseSiege;
    private ScriptZone Climate;
   
    public static int winner;

    private void Start()
    {
        
        roundNumber = 1;
        roundText.text = roundNumber.ToString();

        InitializeLists();
        StartRound();
        

       
       //inicializarPower();
    }

    private void Update()
    {
        if (ButtonPass.GreekPass && ButtonPass.NordicPass)
        {
            EndRound();
        }

        // if (enemyDeck.CardsInHand.Count == 0 || playerDeck.CardsInHand.Count == 0)
        // {
        //     roundNumber++;
        //     roundText.text = roundNumber.ToString();
        //     StartRound();
        // }
    }

    private void StartRound()
    {
        if(roundNumber != 1)
        {
            DealCards(DeckManager.player1Deck, player1HandObject);
            DealCards(DeckManager.player2Deck, player2HandObject);
        }
        

        ButtonPass.GreekPass = false;
        ButtonPass.NordicPass = false;
        TurnSystem.GreekTurn = true;
        Limpiar();
        UpdateLists();
    }

     private void EndRound()
    {
        Judge();
        roundNumber++;
        roundText.text = roundNumber.ToString();
        StartRound();
    }

    private void DealCards(List<UnityBaseCard> deck, GameObject handObject)
    {
        // Asegúrate de que el mazo tenga suficientes cartas
        if (deck.Count < 2)
        {
            Debug.LogError("No hay suficientes cartas en el mazo.");
            return;
        }

        // Baraja el mazo
        List<UnityBaseCard> shuffledDeck = deck.OrderBy(x => Random.value).ToList();

        // Obtén el script de la mano del GameObject
        ScriptZone hand = handObject.GetComponent<ScriptZone>();

        // Agrega las primeras 2 cartas a la lista de la mano
        for (int i = 0; i < 2; i++)
        {
            hand.Cards.Add(shuffledDeck[i]);
        }

        hand.UpdateList();

        // Elimina las cartas repartidas del mazo
        deck.RemoveRange(0, 2);
    }

    private void Limpiar()
    {
        GreekMelee.Cards.Clear();
        NordicMelee.Cards.Clear();
        GreekRange.Cards.Clear();
        NordicRange.Cards.Clear();
        GreekSiege.Cards.Clear();
        NordicSiege.Cards.Clear();
        GreekIncreaseMelee.Cards.Clear();
        NordicIncreaseMelee.Cards.Clear();
        GreekIncreaseRange.Cards.Clear();
        NordicIncreaseRange.Cards.Clear();
        GreekIncreaseSiege.Cards.Clear();
        NordicIncreaseSiege.Cards.Clear();
        Climate.Cards.Clear();
        
    }

    private void UpdateLists()
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

    }


    public void Judge()
    {
        if(Points.totalPowerPlayer1 < Points.totalPowerPlayer2)
        {
            winner = 2;
        }
        else if(Points.totalPowerPlayer1 > Points.totalPowerPlayer2)
        {
            winner = 1;
        }
        else if(Points.totalPowerPlayer1 == Points.totalPowerPlayer2)
        {
            winner = 0;
        }
       
    }

     private void InitializeLists()
    {
        
        GreekMelee= GameObject.Find("GreekMelee").GetComponent<ScriptZone>();
        NordicMelee = GameObject.Find("NordicMelee").GetComponent<ScriptZone>();
        GreekRange = GameObject.Find("GreekRange").GetComponent<ScriptZone>();
        NordicRange = GameObject.Find("NordicRange").GetComponent<ScriptZone>();
        GreekSiege = GameObject.Find("GreekSiege").GetComponent<ScriptZone>();
        NordicSiege = GameObject.Find("NordicSiege").GetComponent<ScriptZone>();
        Climate = GameObject.Find("Climate").GetComponent<ScriptZone>();
        GreekIncreaseMelee = GameObject.Find("GreekIncreaseMelee").GetComponent<ScriptZone>();
        GreekIncreaseRange = GameObject.Find("GreekIncreaseRange").GetComponent<ScriptZone>();
        GreekIncreaseSiege = GameObject.Find("GreekIncreaseSiege").GetComponent<ScriptZone>();
        NordicIncreaseMelee = GameObject.Find("NordicIncreaseMelee").GetComponent<ScriptZone>();
        NordicIncreaseRange = GameObject.Find("NordicIncreaseRange").GetComponent<ScriptZone>();
        NordicIncreaseSiege = GameObject.Find("NordicIncreaseSiege").GetComponent<ScriptZone>();
    }

    // private void inicializarPower()
    // {


    //     playerDeck = GameObject.Find("deck").GetComponent<Deck>();
    //     enemyDeck = GameObject.Find("enemyDeck").GetComponent<Deck>();

    //     for (int i = 0; i < playerDeck.cardList.Count; i++)
    //     {
    //         playerDeck.cardList[i].GetComponent<DisplayCard>().card.power = playerDeck.cardList[i].GetComponent<DisplayCard>().card.initialPower;
    //     }

    //     for (int i = 0; i < enemyDeck.cardList.Count; i++)
    //     {
    //         enemyDeck.cardList[i].GetComponent<DisplayCard>().card.power = enemyDeck.cardList[i].GetComponent<DisplayCard>().card.initialPower;
    //     }

    // }
}