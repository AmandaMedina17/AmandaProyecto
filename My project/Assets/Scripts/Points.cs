using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Points : MonoBehaviour
{
    public TMP_Text pointsText1;
    public TMP_Text pointsText2;
    public static int totalPowerPlayer1;
    public int uno;
    public static int totalPowerPlayer2;
    public int dos;

    private static List<UnityBaseCard> GreekMelee;
    private static List<UnityBaseCard> NordicMelee;
    private static List<UnityBaseCard> GreekRange;
    private static List<UnityBaseCard> NordicRange;
    private static List<UnityBaseCard> GreekSiege;
    private static List<UnityBaseCard> NordicSiege;

    
    void Start()
    {


        GreekMelee = GameObject.Find("GreekMelee").GetComponent<ScriptZone>().Cards;
        NordicMelee = GameObject.Find("NordicMelee").GetComponent<ScriptZone>().Cards;
        GreekRange = GameObject.Find("GreekRange").GetComponent<ScriptZone>().Cards;
        NordicRange = GameObject.Find("NordicRange").GetComponent<ScriptZone>().Cards;
        GreekSiege = GameObject.Find("GreekSiege").GetComponent<ScriptZone>().Cards;
        NordicSiege = GameObject.Find("NordicSiege").GetComponent<ScriptZone>().Cards;

      
    }

    // Update is called once per frame
    void Update()
    { 
        uno=0;
        dos=0;
        totalPowerPlayer1=0;
        totalPowerPlayer2=0;

        for (int i = 0; i < GreekMelee.Count; i++)
        {
            uno += GreekMelee[i].Power;    
        }
        for (int i = 0; i < GreekRange.Count; i++)
        {
            uno += GreekRange[i].Power;          
        }
        for (int i = 0; i < GreekSiege.Count; i++)
        {
           uno += GreekSiege[i].Power;
        }
        
        for (int i = 0; i < NordicMelee.Count; i++)
        {
            dos += NordicMelee[i].Power;  
        }
        for (int i = 0; i < NordicRange.Count; i++)
        {
            dos += NordicRange[i].Power;            
        }
        for (int i = 0; i < NordicSiege.Count; i++)
        {
            dos += NordicSiege[i].Power;   
        }

        totalPowerPlayer2 = dos;
        totalPowerPlayer1 = uno;


        pointsText1.text = totalPowerPlayer1.ToString();
        pointsText2.text = totalPowerPlayer2.ToString();

    }
}
