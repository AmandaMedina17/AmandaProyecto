using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptZone : MonoBehaviour
{
    public List<GameObject> Melee;
    public List<GameObject> MeleeEnemy;
    public List<GameObject> Siege;
    public List<GameObject> SiegeEnemy;
    public List<GameObject> Range;
    public List<GameObject> RangeEnemy;
    public List<GameObject> Climate;
    public List<GameObject> IncreaseMelee;
    public List<GameObject> IncreaseMeleeEnemy;
    public List<GameObject> IncreaseSiege;
    public List<GameObject> IncreaseSiegeEnemy;
    public List<GameObject> IncreaseRange;
    public List<GameObject> IncreaseRangeEnemy;


    public static bool climateMelee;
    public static bool climateMeleeEnemy;
    public static bool climateSiege;
    public static bool climateSiegeEnemy;
    public static bool climateRange;
    public static bool climateRangeEnemy;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearZones()
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
         Melee = new List<GameObject>;*/

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
    }
}
