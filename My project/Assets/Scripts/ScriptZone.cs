using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ScriptZone : MonoBehaviour
{
    public List<UnityBaseCard> Cards;
    
    public void UpdateList()
    {
        GridLayoutGroup gridLayoutGroup = GetComponent<GridLayoutGroup>();
        GameObject[] hijos = CogerLosHijos(gridLayoutGroup);

        foreach(GameObject hijo in hijos)
        {
            Destroy(hijo);
        }

        foreach(UnityBaseCard card in Cards)
        {
            InstanciarCarta(card, gridLayoutGroup);
        }
    }

    private GameObject[] CogerLosHijos(GridLayoutGroup gridLayoutGroup)
    {
        GameObject[] hijos = new GameObject[gridLayoutGroup.transform.childCount];

        for (int i = 0; i < gridLayoutGroup.transform.childCount; i++)
        {
            hijos[i] = gridLayoutGroup.transform.GetChild(i).gameObject;
        }
        return hijos;
    }

    private void InstanciarCarta(UnityBaseCard card, GridLayoutGroup gridLayoutGroup)
    {
        GameObject cardPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/CardPrefab.prefab");
        GameObject cardCopy = GameObject.Instantiate(cardPrefab);
        CardControler cardControler = cardCopy.GetComponent<CardControler>();
        cardControler.card = card; 
        cardCopy.GetComponent<Display>().card = (UnityBaseCard)card;
        string name = cardCopy.GetComponent<Display>().card.Name;
        cardCopy.transform.SetParent(gridLayoutGroup.transform, false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

   /* public void ClearZones()
    {
        for (int i = 0; i < Melee.Count; i++)
        {
            Destroy(Melee[i]);
        }
       
        
        for (int i = 0; i < MeleeEnemy.Count; i++)
        {
            Destroy(MeleeEnemy[i]);
        }

        for (int i = 0; i < Range.Count; i++)
        {
            Destroy(Range[i]);
        }
        
        for (int i = 0; i < RangeEnemy.Count; i++)
        {
            Destroy(RangeEnemy[i]);
        }
        
        for (int i = 0; i < Siege.Count; i++)
        {
            Destroy(Siege[i]);
        }
        
        for (int i = 0; i < SiegeEnemy.Count; i++)
        {
            Destroy(SiegeEnemy[i]);
        }
        
        for (int i = 0; i < Climate.Count; i++)
        {
            Destroy(Climate[i]);
        }
        
        for (int i = 0; i < IncreaseMelee.Count; i++)
        {
            Destroy(IncreaseMelee[i]);
        }

        for (int i = 0; i < IncreaseMeleeEnemy.Count; i++)
        {
            Destroy(IncreaseMeleeEnemy[i]);
        }

        for (int i = 0; i < IncreaseRange.Count; i++)
        {
            Destroy(IncreaseRange[i]);
        }

        for (int i = 0; i < IncreaseRangeEnemy.Count; i++)
        {
            Destroy(IncreaseRangeEnemy[i]);
        }

        for (int i = 0; i < IncreaseSiege.Count; i++)
        {
            Destroy(IncreaseSiege[i]);
        }

        for (int i = 0; i < IncreaseSiegeEnemy.Count; i++)
        {
            Destroy(IncreaseSiegeEnemy[i]);
        }


      
        /* Melee = new List<GameObject>;
         Melee = new List<GameObject>;
         Melee = new List<GameObject>;
         Melee = new List<GameObject>;
         Melee = new List<GameObject>;
         Melee = new List<GameObject>;
         Melee = new List<GameObject>;
         Melee = new List<GameObject>;
         Melee = new List<GameObject>;

        Melee.Clear();
        MeleeEnemy.Clear();
        Siege.Clear();
        SiegeEnemy.Clear();
        Range.Clear();
        RangeEnemy.Clear();
        Climate.Clear();
        IncreaseMelee.Clear();
        IncreaseMeleeEnemy.Clear();
        IncreaseSiege.Clear();
        IncreaseSiegeEnemy.Clear();
        IncreaseRange.Clear();
        IncreaseRangeEnemy.Clear();
    }*/
}
