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

    private static ScriptZone melee;
    private static ScriptZone meleeEnemy;
    private static ScriptZone range;
    private static ScriptZone rangeEnemy;
    private static ScriptZone siege;
    private static ScriptZone siegeEnemy;

    
    void Start()
    {


        melee = GameObject.Find("ZoneMelee").GetComponent<ScriptZone>();
        meleeEnemy = GameObject.Find("ZoneMeleeEnemy").GetComponent<ScriptZone>();
        range = GameObject.Find("ZoneRange").GetComponent<ScriptZone>();
        rangeEnemy = GameObject.Find("ZoneRangeEnemy").GetComponent<ScriptZone>();
        siege = GameObject.Find("ZoneSiege").GetComponent<ScriptZone>();
        siegeEnemy = GameObject.Find("ZoneSiegeEnemy").GetComponent<ScriptZone>();

      
    }

    // Update is called once per frame
    void Update()
    { 
        uno=0;
        dos=0;
        totalPowerPlayer1=0;
        totalPowerPlayer2=0;

        for (int i = 0; i < melee.Melee.Count; i++)
        {
            uno += melee.Melee[i].GetComponent<DisplayCard>().card.power;    
        }
        for (int i = 0; i < range.Range.Count; i++)
        {
            uno += range.Range[i].GetComponent<DisplayCard>().card.power;          
        }
        for (int i = 0; i < siege.Siege.Count; i++)
        {
           uno += siege.Siege[i].GetComponent<DisplayCard>().card.power;
        }
        
        for (int i = 0; i < meleeEnemy.MeleeEnemy.Count; i++)
        {
            dos += meleeEnemy.MeleeEnemy[i].GetComponent<DisplayCard>().card.power;  
        }
        for (int i = 0; i < rangeEnemy.RangeEnemy.Count; i++)
        {
            dos += rangeEnemy.RangeEnemy[i].GetComponent<DisplayCard>().card.power;            
        }
        for (int i = 0; i < siegeEnemy.SiegeEnemy.Count; i++)
        {
            dos += siegeEnemy.SiegeEnemy[i].GetComponent<DisplayCard>().card.power;   
        }

        totalPowerPlayer2 = dos;
        totalPowerPlayer1 = uno;


        pointsText1.text = totalPowerPlayer1.ToString();
        pointsText2.text = totalPowerPlayer2.ToString();

    }
}
