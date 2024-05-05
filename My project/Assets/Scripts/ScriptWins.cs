using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScriptWins : MonoBehaviour
{
    public TMP_Text winsPlayer1;
    public TMP_Text winsPlayer2;

    public TMP_Text WinnText;
    public string Winn;

    public int numberWinsPlayer1;
    public int numberWinsPlayer2;

    // Start is called before the first frame update
    void Start()
    {
        numberWinsPlayer1=0;
        numberWinsPlayer2=0;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.winner == 1)
        {
            numberWinsPlayer1++;
            winsPlayer1.text = numberWinsPlayer1.ToString();
            GameManager.winner = 0;
        }
        else if(GameManager.winner == 2)
        {
            numberWinsPlayer2++;
            winsPlayer2.text = numberWinsPlayer2.ToString();
            GameManager.winner = 0;
        }

        if(numberWinsPlayer1 == 2)
        {
            Winn = "Ganador Jugador 1";
            WinnText.text = Winn;
        }
        else if(numberWinsPlayer2 == 2)
        {
            Winn = "Ganador Jugador 2";
            WinnText.text = Winn;
        }
    }
}
