using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnSystem : MonoBehaviour
{
    public static bool player1Turn;
    public TextMeshProUGUI turnText;

    public int player1Points;
    public int player2Points;

    public bool pass;


    // Start is called before the first frame update
    void Start()
    {
        player1Turn = true;
        player1Points = 0;
        player2Points = 0;
        pass = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player1Turn == true)
        {
            turnText.text = "Turno del jugador 1";
        }
        else
        {
            turnText.text = "Turno del jugador 2";
        }
        

        if((TeletransportationCard.player1PlayedACard == true) && (ButtonPass.player2Pass == false))
        {
           EndPlayer1Turn();
           TeletransportationCard.player1PlayedACard = false;
        }
        else if((TeletransportationCard.player2PlayedACard == true) && (ButtonPass.player1Pass == false))
        {
            EndPlayer2Turn();
            TeletransportationCard.player2PlayedACard = false;
        }

        if(GameManager.winner == 1)
        {
            player1Turn = true;
        }
        else if(GameManager.winner == 2)
        {
            player1Turn = false;
        }

    }

    public void EndPlayer1Turn()
    {
        player1Turn = false;
    }

    public void EndPlayer2Turn()
    {
        player1Turn = true;
    }


    
       
    
}
