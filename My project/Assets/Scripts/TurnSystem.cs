using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class TurnSystem : MonoBehaviour
{
    public static bool GreekTurn;
    public TextMeshProUGUI turnText;

    public int player1Points;
    public int player2Points;



    // Start is called before the first frame update
    void Start()
    {
        GreekTurn = true;
        player1Points = 0;
        player2Points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTurnText();
        CheckForWinner();

        
        // if((CardControler.GriegosPlayedACard == true) && (ButtonPass.NordicPass == false))
        // {
        //    EndGreekTurn();
        //    CardControler.GriegosPlayedACard = false;
        // }
        // else if((CardControler.NordicosPlayedACard == true) && (ButtonPass.GreekPass == false))
        // {
        //     EndNordicTurn();
        //     CardControler.NordicosPlayedACard = false;
        // }

        // if(GameManager.winner == 1)
        // {
        //     GreekTurn = true;
        // }
        // else if(GameManager.winner == 2)
        // {
        //     GreekTurn = false;
        // }

        /*if(LeaderZeus.leaderZeus == true && ButtonPass.player2Pass == false)
        {
            EndGreekTurn();
            LeaderZeus.leaderZeus = false;
        }
        else if(LeaderOdín.leaderOdin == true && ButtonPass.player1Pass == false)
        {
            EndPlayer2Turn();
            LeaderOdín.leaderOdin = false;
        }*/

    }

    void UpdateTurnText()
    {
        if (ButtonPass.GreekPass && !ButtonPass.NordicPass)
        {
            turnText.text = "Turno de los dioses nórdicos (Griegos pasaron)";
        }
        else if (ButtonPass.NordicPass && !ButtonPass.GreekPass)
        {
            turnText.text = "Turno de los dioses griegos (Nórdicos pasaron)";
        }
        else
        {
            turnText.text = GreekTurn ? "Turno de los dioses griegos" : "Turno de los dioses nórdicos";
        }
    }

    void CheckForWinner()
    {
        if (GameManager.winner == 1)
        {
            GreekTurn = true;
        }
        else if (GameManager.winner == 2)
        {
            GreekTurn = false;
        }
    }

    
       
    
}