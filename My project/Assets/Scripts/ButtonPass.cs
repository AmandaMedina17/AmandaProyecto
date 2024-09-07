using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPass : MonoBehaviour
{
    public static bool GreekPass;   // true cuando el jugador 1 pasa
    public static bool NordicPass;   // true cuando el jugador 2 pasa

    public void BottonPass()
    {
        if(TurnSystem.GreekTurn == true)
        {
            TurnSystem.GreekTurn = false;
            GreekPass = true;
        }
        else
        {
            TurnSystem.GreekTurn = true;
            NordicPass = true;
        }

        //pass = true;
        //PassTurn();
    }

    // Start is called before the first frame update
    void Start()
    {
        GreekPass = false;
        NordicPass = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
