using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Points : MonoBehaviour
{
    public TMP_Text pointsText1;
    public TMP_Text pointsText2;
   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointsText1.text = TeletransportationCard.player1Points.ToString();
        pointsText2.text = TeletransportationCard.player2Points.ToString();
    }
}
