using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPass : MonoBehaviour
{
    public static bool player1Pass;   // true cuando el jugador 1 pasa
    public static bool player2Pass;   // true cuando el jugador 2 pasa

    public void BottonPass()
    {
        if(TurnSystem.player1Turn == true)
        {
            TurnSystem.player1Turn = false;
            player1Pass = true;
        }
        else
        {
            TurnSystem.player1Turn = true;
            player2Pass = true;
        }

        //pass = true;
        //PassTurn();
    }

    // Start is called before the first frame update
    void Start()
    {
        player1Pass = false;
        player2Pass = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
