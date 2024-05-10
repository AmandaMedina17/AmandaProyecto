using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderOdín : MonoBehaviour
{

    private ScriptZone melee;
    private ScriptZone range;
    private ScriptZone siege;
    public int cantidadDeVeces;

    public static bool leaderOdin;

    // Start is called before the first frame update
    void Start()
    {
        melee = GameObject.Find("ZoneMelee").GetComponent<ScriptZone>();
        range = GameObject.Find("ZoneRange").GetComponent<ScriptZone>();
        siege = GameObject.Find("ZoneSiege").GetComponent<ScriptZone>();
        cantidadDeVeces = 2;

    }

    public void OnClick()        //metodo para la faccion griega
    {
        if(cantidadDeVeces >0)
        {
            GameObject mostPowerfulCard = null;
            int maxPower = int.MinValue;

            if(melee.Melee.Count >0)
            {
                FindMostPowerfulCardInListMelee();
            }
            else if(range.Range.Count >0)
            {
                FindMostPowerfulCardInListRange();
            }
            
            else if(siege.Siege.Count >0)
            {
                FindMostPowerfulCardInListSiege();
            }
            else 
            {
                Debug.LogWarning("no hay cartas en el campo");

            }
            void FindMostPowerfulCardInListMelee()
            {
                for (int i = 0; i < melee.Melee.Count; i++)
                {
            
                    if(melee.Melee[i].GetComponent<DisplayCard>().card.power  > maxPower)
                    {
                        mostPowerfulCard = melee.Melee[i];
                        maxPower = melee.Melee[i].GetComponent<DisplayCard>().card.power;
                    }
                }
            }
    
            void FindMostPowerfulCardInListRange()
            {
                for (int i = 0; i < range.Range.Count; i++)
                {
            
                    if(range.Range[i].GetComponent<DisplayCard>().card.power > maxPower)
                    {
                        mostPowerfulCard = range.Range[i];
                        maxPower = range.Range[i].GetComponent<DisplayCard>().card.power;
                    }
                }
            }

            void FindMostPowerfulCardInListSiege()
            {
                for (int i = 0; i < siege.Siege.Count; i++)
                {
                
                    if(siege.Siege[i].GetComponent<DisplayCard>().card.power > maxPower)
                    {
                        mostPowerfulCard = siege.Siege[i];
                        maxPower = siege.Siege[i].GetComponent<DisplayCard>().card.power;
                    }
                }    
            }
            if(mostPowerfulCard != null)
            {
                Destroy(mostPowerfulCard);
                if(melee.Melee.Contains(mostPowerfulCard))
                {
                    melee.Melee.Remove(mostPowerfulCard);
                }
                else if(range.Range.Contains(mostPowerfulCard))
                {
                    range.Range.Remove(mostPowerfulCard);
                }
                else if(siege.Siege.Contains(mostPowerfulCard))
                {
                    siege.Siege.Remove(mostPowerfulCard);
                }
            }
            cantidadDeVeces--;
            leaderOdin= true;
        }
    }
    
}
