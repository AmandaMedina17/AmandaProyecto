using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderZeus : MonoBehaviour
{ 
    private ScriptZone melee;
    public int cantidadDeVeces;
    public static bool leaderZeus;

    void Start()
    {
        melee = GameObject.Find("ZoneMelee").GetComponent<ScriptZone>();
        cantidadDeVeces = 2;
    }

    public void OnClick()
    {
        if(cantidadDeVeces != 0)
        {
            if(melee.Melee.Count > 0)
            {
                AddPower();
            }

            void AddPower()
            {
                for (int i = 0; i < melee.Melee.Count; i++)
                {
                    melee.Melee[i].GetComponent<DisplayCard>().card.power += 3;
                }
            } 
            cantidadDeVeces--;
            leaderZeus = true;
        }
       
    }
    
        
}