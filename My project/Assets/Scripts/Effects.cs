using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
   
    public static Deck enemyDeck;
    public static Deck playerDeck;

    private ScriptZone melee;
    private ScriptZone meleeEnemy;
    private ScriptZone range;
    private ScriptZone rangeEnemy;
    private ScriptZone siege;
    private ScriptZone siegeEnemy;
    private ScriptZone climate;
    private ScriptZone increaseMelee;
    private ScriptZone increaseRange;
    private ScriptZone increaseSiege;
    private ScriptZone increaseMeleeEnemy;
    private ScriptZone increaseRangeEnemy;
    private ScriptZone increaseSiegeEnemy;

    // Start is called before the first frame update
    void Start()
    {
        enemyDeck = GameObject.Find("enemyDeck").GetComponent<Deck>();
        playerDeck = GameObject.Find("deck").GetComponent<Deck>();

        melee = GameObject.Find("ZoneMelee").GetComponent<ScriptZone>();
        meleeEnemy = GameObject.Find("ZoneMeleeEnemy").GetComponent<ScriptZone>();
        range = GameObject.Find("ZoneRange").GetComponent<ScriptZone>();
        rangeEnemy = GameObject.Find("ZoneRangeEnemy").GetComponent<ScriptZone>();
        siege = GameObject.Find("ZoneSiege").GetComponent<ScriptZone>();
        siegeEnemy = GameObject.Find("ZoneSiegeEnemy").GetComponent<ScriptZone>();
        climate = GameObject.Find("ZoneClimate").GetComponent<ScriptZone>();
        increaseMelee = GameObject.Find("ZoneIncreaseMelee").GetComponent<ScriptZone>();
        increaseRange = GameObject.Find("ZoneIncreaseRange").GetComponent<ScriptZone>();
        increaseSiege = GameObject.Find("ZoneIncreaseSiege").GetComponent<ScriptZone>();
        increaseMeleeEnemy = GameObject.Find("ZoneIncreaseMeleeEnemy").GetComponent<ScriptZone>();
        increaseRangeEnemy = GameObject.Find("ZoneIncreaseRangeEnemy").GetComponent<ScriptZone>();
        increaseSiegeEnemy = GameObject.Find("ZoneIncreaseSiegeEnemy").GetComponent<ScriptZone>();
    }

    // Update is called once per frame
    public void Click()
    {
        //if(this.gameObject.GetComponent<DisplayCard>().card.tele == false && this.gameObject.GetComponent<DisplayCard>().card.effect==true)
        //{
            if(this.gameObject.GetComponent<DisplayCard>().card.id == 4)
            {
                if(this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Griegos")
                {
                    DrawACardGreek();
                }
                else if(this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Nórdicos")
                {
                    DrawACardNordic();
                }
                
            }

            if(this.gameObject.GetComponent<DisplayCard>().card.id == 1)
            {
                if(this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Griegos")
                {
                    EliminateMostPowerfullCardNordic();
                }
                else if(this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Nórdicos")
                {
                    EliminateMostPowerfullCardGreek();
                }
                
            }

             if(this.gameObject.GetComponent<DisplayCard>().card.id == 6)
            {
                if(this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Griegos")
                {
                    AverageNordic();
                }
                else if(this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Nórdicos")
                {
                    AverageGreek();
                }
                
            }

            if(this.gameObject.GetComponent<DisplayCard>().card.id == 8)
            {
                if(this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Griegos")
                {
                    MultiplyPowerGreek();
                }
                else if(this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Nórdicos")
                {
                    MultiplyPowerNordic();
                }
                
            }

            if(this.gameObject.GetComponent<DisplayCard>().card.id == 7)
            {
                if(this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Griegos")
                {
                    RemoveLeastPowerfulCardNordic();
                }
                else if(this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Nórdicos")
                {
                    RemoveLeastPowerfulCardGreek();
                }
                
            }

            if(this.gameObject.GetComponent<DisplayCard>().card.id == 5)
            {
                if(this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Griegos")
                {
                    ClearRowNordic();
                }
                else if(this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Nórdicos")
                {
                    ClearRowGreek();
                }
                
            }

             if(this.gameObject.GetComponent<DisplayCard>().card.id == 12)
            {
                Climate1();
                
            }

             if(this.gameObject.GetComponent<DisplayCard>().card.id == 13)
            {
                Climate2();
                
            }

             if(this.gameObject.GetComponent<DisplayCard>().card.id == 14)
            {
                Climate3();
                
            }

            if(this.gameObject.GetComponent<DisplayCard>().card.id == 9)
            {
                if(this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Griegos")
                {
                    Increase1Greek();
                }
                else if(this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Nórdicos")
                {
                   Increase1Nordic();
                }
                
            }

            if(this.gameObject.GetComponent<DisplayCard>().card.id == 10)
            {
                if(this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Griegos")
                {
                    Increase2Greek();
                }
                else if(this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Nórdicos")
                {
                    Increase2Nordic();
                }
                
            }

            if(this.gameObject.GetComponent<DisplayCard>().card.id == 11)
            {
                if(this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Griegos")
                {
                    Increase3Greek();
                }
                else if(this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Nórdicos")
                {
                    Increase3Nordic();
                }
                
            }

            if(this.gameObject.GetComponent<DisplayCard>().card.id == 15)
            {
                Clearance1();
                
            }

            if(this.gameObject.GetComponent<DisplayCard>().card.id == 16)
            {
               Clearance2();
                
            }

            if(this.gameObject.GetComponent<DisplayCard>().card.id == 17)
            {
                Clearance3();
            }

             if(this.gameObject.GetComponent<DisplayCard>().card.id == 2)
            {
                if(this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Griegos")
                {
                    SetWeatherPoseidón();
                }
                else if(this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Nórdicos")
                {
                    SetWeatherThor();
                }
                
            }

             if(this.gameObject.GetComponent<DisplayCard>().card.id == 3)
            {
                if(this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Griegos")
                {
                    AddIncreaseGreek();
                }
                else if(this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Nórdicos")
                {
                    AddIncreaseNordic();
                }
                
            }

            if(this.gameObject.GetComponent<DisplayCard>().card.id == 18)
            {
                if(this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Griegos")
                {
                    baitGreek();
                }
                else if(this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Nórdicos")
                {
                    baitNordic();
                }
                
            }

           
        //this.gameObject.GetComponent<DisplayCard>().card.effect = false;
        //}
    }

    //Efecto robar una carta
    public void DrawACardGreek()  
    {
        int randomIndex2 = Random.Range(0, playerDeck.cardList.Count);
        GameObject drawCard2 = Instantiate(playerDeck.cardList[randomIndex2], new Vector3(0, 0, 0), Quaternion.identity);
        drawCard2.transform.SetParent(playerDeck.Hand.transform, false);
        playerDeck.CardsInHand.Add(drawCard2);
        playerDeck.cardList.RemoveAt(randomIndex2);
     
    }
    public void DrawACardNordic()
    {
        int randomIndex1 = Random.Range(0, enemyDeck.cardList.Count);
        GameObject drawCard1 = Instantiate(enemyDeck.cardList[randomIndex1], new Vector3(0, 0, 0), Quaternion.identity);
        drawCard1.transform.SetParent(enemyDeck.Hand.transform, false);
        enemyDeck.CardsInHand.Add(drawCard1);
        enemyDeck.cardList.RemoveAt(randomIndex1);
  
    }


    //Efecto eliminar la carta con mas poder del rival campo
    public void EliminateMostPowerfullCardGreek()        //metodo para la faccion griega
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

    

        
    }

    public void EliminateMostPowerfullCardNordic()        //metodo para la faccion griega
    {
        GameObject mostPowerfulCard = null;

        int maxPower = int.MinValue;

            if(meleeEnemy.MeleeEnemy.Count > 0)
            {
                FindMostPowerfulCardInListMeleeenemy();
            }
            
            else if(rangeEnemy.RangeEnemy.Count > 0)
            {
                FindMostPowerfulCardInListRangeenemy();
            }
            
            else if(siegeEnemy.SiegeEnemy.Count > 0)
            {
                FindMostPowerfulCardInListSiegeenemy();
            }
            else
            {
                Debug.LogWarning("no hay cartas en el campo");

            }
        void FindMostPowerfulCardInListMeleeenemy()
        {
            for (int i = 0; i < meleeEnemy.MeleeEnemy.Count; i++)
            {
                if(meleeEnemy.MeleeEnemy[i].GetComponent<DisplayCard>().card.power > maxPower)
                {
                    mostPowerfulCard = meleeEnemy.MeleeEnemy[i];
                    maxPower = meleeEnemy.MeleeEnemy[i].GetComponent<DisplayCard>().card.power;
                }
            }
        }

        void FindMostPowerfulCardInListRangeenemy()
        {
            for (int i = 0; i < rangeEnemy.RangeEnemy.Count; i++)
            {
            
                if(rangeEnemy.RangeEnemy[i].GetComponent<DisplayCard>().card.power > maxPower)
                {
                    mostPowerfulCard = rangeEnemy.RangeEnemy[i];
                    maxPower = rangeEnemy.RangeEnemy[i].GetComponent<DisplayCard>().card.power;
                }
            }   

        }

        void FindMostPowerfulCardInListSiegeenemy()
        {
            for (int i = 0; i < siegeEnemy.SiegeEnemy.Count; i++)
            {
            
                if(siegeEnemy.SiegeEnemy[i].GetComponent<DisplayCard>().card.power > maxPower)
                {
                    mostPowerfulCard = siegeEnemy.SiegeEnemy[i];
                    maxPower = siegeEnemy.SiegeEnemy[i].GetComponent<DisplayCard>().card.power;
                }
            }
        }

        if(mostPowerfulCard != null)
        {
            Destroy(mostPowerfulCard);
            if(meleeEnemy.MeleeEnemy.Contains(mostPowerfulCard))
            {
                meleeEnemy.MeleeEnemy.Remove(mostPowerfulCard);
            }
            else if(rangeEnemy.RangeEnemy.Contains(mostPowerfulCard))
            {
                rangeEnemy.RangeEnemy.Remove(mostPowerfulCard);
            }
            else if(siegeEnemy.SiegeEnemy.Contains(mostPowerfulCard))
            {
                siegeEnemy.SiegeEnemy.Remove(mostPowerfulCard);
            }
        }


    }


     //Efecto del promedio
    public void AverageGreek()
    {
        int totalPower = 0;
        int totalCards = 0;
        int averagePower = 0;

        CalculateTotalPowerAndCArdsMelee();
        CalculateTotalPowerAndCArdsSiege();
        CalculateTotalPowerAndCArdsRange();

        if(totalCards > 0)
        {
            averagePower = totalPower / totalCards;

            EqualizeCardListPowerMelee();
            EqualizeCardListPowerRange();
            EqualizeCardListPowerSiege();
        }
        else
        {
            Debug.LogWarning("no hay cartas en el campo");

        }

        void CalculateTotalPowerAndCArdsMelee()
        {
            for (int i = 0; i < melee.Melee.Count; i++)
            {
                totalPower += melee.Melee[i].GetComponent<DisplayCard>().card.power;
                totalCards++;
            }
        }
        void CalculateTotalPowerAndCArdsRange()
        {
            for (int i = 0; i < range.Range.Count; i++)
            {
                totalPower += range.Range[i].GetComponent<DisplayCard>().card.power;
                totalCards++;
            }
        }
        void CalculateTotalPowerAndCArdsSiege()
        {
            for (int i = 0; i < siege.Siege.Count; i++)
            {
                totalPower += siege.Siege[i].GetComponent<DisplayCard>().card.power;
                totalCards++;
            }
        }

        void EqualizeCardListPowerMelee()
        {
            for (int i = 0; i < melee.Melee.Count; i++)
            {
                melee.Melee[i].GetComponent<DisplayCard>().card.power = averagePower;
            }
        }
        void EqualizeCardListPowerRange()
        {
            for (int i = 0; i < range.Range.Count; i++)
            {
                range.Range[i].GetComponent<DisplayCard>().card.power = averagePower;
            }
        }
        void EqualizeCardListPowerSiege()
        {
            for (int i = 0; i < siege.Siege.Count; i++)
            {
                siege.Siege[i].GetComponent<DisplayCard>().card.power = averagePower;
            }
        }

    }

     public void AverageNordic()
    {
        int totalPower = 0;
        int totalCards = 0;
        int averagePower = 0;

        CalculateTotalPowerAndCArdsMelee();
        CalculateTotalPowerAndCArdsSiege();
        CalculateTotalPowerAndCArdsRange();

        if(totalCards > 0)
        {
            averagePower = totalPower / totalCards;

            EqualizeCardListPowerMelee();
            EqualizeCardListPowerRange();
            EqualizeCardListPowerSiege();
        }
        else
        {
            Debug.LogWarning("no hay cartas en el campo");

        }

        void CalculateTotalPowerAndCArdsMelee()
        {
            for (int i = 0; i < meleeEnemy.MeleeEnemy.Count; i++)
            {
                totalPower += meleeEnemy.MeleeEnemy[i].GetComponent<DisplayCard>().card.power;
                totalCards++;
            }
        }
        void CalculateTotalPowerAndCArdsRange()
        {
            for (int i = 0; i < rangeEnemy.RangeEnemy.Count; i++)
            {
                totalPower += rangeEnemy.RangeEnemy[i].GetComponent<DisplayCard>().card.power;
                totalCards++;
            }
        }
        void CalculateTotalPowerAndCArdsSiege()
        {
            for (int i = 0; i < siegeEnemy.SiegeEnemy.Count; i++)
            {
                totalPower += siegeEnemy.SiegeEnemy[i].GetComponent<DisplayCard>().card.power;
                totalCards++;
            }
        }

        void EqualizeCardListPowerMelee()
        {
            for (int i = 0; i < meleeEnemy.MeleeEnemy.Count; i++)
            {
                meleeEnemy.MeleeEnemy[i].GetComponent<DisplayCard>().card.power = averagePower;
            }
        }
        void EqualizeCardListPowerRange()
        {
            for (int i = 0; i < rangeEnemy.RangeEnemy.Count; i++)
            {
                rangeEnemy.RangeEnemy[i].GetComponent<DisplayCard>().card.power = averagePower;
            }
        }
        void EqualizeCardListPowerSiege()
        {
            for (int i = 0; i < siegeEnemy.SiegeEnemy.Count; i++)
            {
                siegeEnemy.SiegeEnemy[i].GetComponent<DisplayCard>().card.power = averagePower;
            }
        }

    }


    //Efecto multiplicar por n su ataque
    public void MultiplyPowerGreek()
    {
        if(melee.Melee.Contains(this.gameObject))
        {
            MultiplyCardPowerMelee();
        }
        else if(range.Range.Contains(this.gameObject))
        {
            MultiplyCardPowerRange();
        }
        else if(siege.Siege.Contains(this.gameObject))
        {
            MultiplyCardPowerSiege();
        }

        void MultiplyCardPowerMelee()
        {
            int count = 1;
            for (int i = 0; i < melee.Melee.Count; i++)
            {
                if(melee.Melee[i].GetComponent<DisplayCard>().card.name == this.gameObject.GetComponent<DisplayCard>().card.name)
                {
                    count++;
                }
            }
            this.gameObject.GetComponent<DisplayCard>().card.power *= count;
        }

        void MultiplyCardPowerSiege()
        {
            int count = 1;
            for (int i = 0; i < siege.Siege.Count; i++)
            {
                if(siege.Siege[i].GetComponent<DisplayCard>().card.name == this.gameObject.GetComponent<DisplayCard>().card.name)
                {
                    count++;
                }
            }
            this.gameObject.GetComponent<DisplayCard>().card.power *= count;
        }

        void MultiplyCardPowerRange()
        {
            int count = 1;
            for (int i = 0; i < range.Range.Count; i++)
            {
                if(range.Range[i].GetComponent<DisplayCard>().card.name == this.gameObject.GetComponent<DisplayCard>().card.name)
                {
                    count++;
                }
            }
            this.gameObject.GetComponent<DisplayCard>().card.power *= count;
        }
        
        
    }

     public void MultiplyPowerNordic()
    {
        if(meleeEnemy.MeleeEnemy.Contains(this.gameObject))
        {
            MultiplyCardPowerMelee();
        }
        else if(rangeEnemy.RangeEnemy.Contains(this.gameObject))
        {
            MultiplyCardPowerRange();
        }
        else if(siegeEnemy.SiegeEnemy.Contains(this.gameObject))
        {
            MultiplyCardPowerSiege();
        }

        void MultiplyCardPowerMelee()
        {
            int count = 1;
            for (int i = 0; i < meleeEnemy.MeleeEnemy.Count; i++)
            {
                if(meleeEnemy.MeleeEnemy[i].GetComponent<DisplayCard>().card.name == this.gameObject.GetComponent<DisplayCard>().card.name)
                {
                    count++;
                }
            }
            this.gameObject.GetComponent<DisplayCard>().card.power *= count;
        }

        void MultiplyCardPowerSiege()
        {
            int count = 1;
            for (int i = 0; i < siegeEnemy.SiegeEnemy.Count; i++)
            {
                if(siegeEnemy.SiegeEnemy[i].GetComponent<DisplayCard>().card.name == this.gameObject.GetComponent<DisplayCard>().card.name)
                {
                    count++;
                }
            }
            this.gameObject.GetComponent<DisplayCard>().card.power *= count;
        }

        void MultiplyCardPowerRange()
        {
            int count = 1;
            for (int i = 0; i < rangeEnemy.RangeEnemy.Count; i++)
            {
                if(rangeEnemy.RangeEnemy[i].GetComponent<DisplayCard>().card.name == this.gameObject.GetComponent<DisplayCard>().card.name)
                {
                    count++;
                }
            }
            this.gameObject.GetComponent<DisplayCard>().card.power *= count;
        }
        
        
    }


    //Efecto eliminar la carta con menos poder del rival
    public void RemoveLeastPowerfulCardGreek()        //metodo para la faccion griega
    {

        GameObject leastPowerfulCard = null;
        int minPower = int.MaxValue;

        if(melee.Melee.Count >0)
        {
            FindLeastPowerfulCardInListMelee();
        }
        
        if(range.Range.Count >0)
        {
            FindLeastPowerfulCardInListRange();
        }
        
        if(siege.Siege.Count >0)
        {
            FindLeastPowerfulCardInListSiege();
        }

        void FindLeastPowerfulCardInListMelee()
        {
            for (int i = 0; i < melee.Melee.Count; i++)
            {
           
                if(melee.Melee[i].GetComponent<DisplayCard>().card.power  < minPower)
                {
                    leastPowerfulCard = melee.Melee[i];
                    minPower = melee.Melee[i].GetComponent<DisplayCard>().card.power;
                }
            }
        }
 
        void FindLeastPowerfulCardInListRange()
        {
            for (int i = 0; i < range.Range.Count; i++)
            {
          
                if(range.Range[i].GetComponent<DisplayCard>().card.power < minPower)
                {
                    leastPowerfulCard = range.Range[i];
                    minPower = range.Range[i].GetComponent<DisplayCard>().card.power;
                }
            }
        }

        void FindLeastPowerfulCardInListSiege()
        {
            for (int i = 0; i < siege.Siege.Count; i++)
            {
            
                if(siege.Siege[i].GetComponent<DisplayCard>().card.power < minPower)
                {
                    leastPowerfulCard = siege.Siege[i];
                    minPower = siege.Siege[i].GetComponent<DisplayCard>().card.power;
                }
            }    
        }
        if(leastPowerfulCard != null)
        {
            Destroy(leastPowerfulCard);
            if(melee.Melee.Contains(leastPowerfulCard))
            {
                melee.Melee.Remove(leastPowerfulCard);
            }
                else if(range.Range.Contains(leastPowerfulCard))
            {
                range.Range.Remove(leastPowerfulCard);
            }
            else if(siege.Siege.Contains(leastPowerfulCard))
            {
                siege.Siege.Remove(leastPowerfulCard);
            }
        }



        
    }

    public void RemoveLeastPowerfulCardNordic()        //metodo para la faccion nordica
    {
        GameObject leastPowerfulCard = null;
        int minPower = int.MaxValue;

            if(meleeEnemy.MeleeEnemy.Count > 0)
            {
                FindLeastPowerfulCardInListMeleeenemy();
            }
            
            if(rangeEnemy.RangeEnemy.Count > 0)
            {
                FindLeastPowerfulCardInListRangeenemy();
            }
            
            if(siegeEnemy.SiegeEnemy.Count > 0)
            {
                FindLeastPowerfulCardInListSiegeenemy();
            }

        void FindLeastPowerfulCardInListMeleeenemy()
        {
            for (int i = 0; i < meleeEnemy.MeleeEnemy.Count; i++)
            {
                if(meleeEnemy.MeleeEnemy[i].GetComponent<DisplayCard>().card.power < minPower)
                {
                    leastPowerfulCard = meleeEnemy.MeleeEnemy[i];
                    minPower = meleeEnemy.MeleeEnemy[i].GetComponent<DisplayCard>().card.power;
                }
            }
        }

        void FindLeastPowerfulCardInListRangeenemy()
        {
            for (int i = 0; i < rangeEnemy.RangeEnemy.Count; i++)
            {
            
                if(rangeEnemy.RangeEnemy[i].GetComponent<DisplayCard>().card.power < minPower)
                {
                    leastPowerfulCard = rangeEnemy.RangeEnemy[i];
                    minPower = rangeEnemy.RangeEnemy[i].GetComponent<DisplayCard>().card.power;
                }
            }   

        }

        void FindLeastPowerfulCardInListSiegeenemy()
        {
            for (int i = 0; i < siegeEnemy.SiegeEnemy.Count; i++)
            {
            
                if(siegeEnemy.SiegeEnemy[i].GetComponent<DisplayCard>().card.power < minPower)
                {
                    leastPowerfulCard = siegeEnemy.SiegeEnemy[i];
                    minPower = siegeEnemy.SiegeEnemy[i].GetComponent<DisplayCard>().card.power;
                }
            }
        }

        if(leastPowerfulCard != null)
        {
            Destroy(leastPowerfulCard);
            if(meleeEnemy.MeleeEnemy.Contains(leastPowerfulCard))
            {
                meleeEnemy.MeleeEnemy.Remove(leastPowerfulCard);
            }
                else if(rangeEnemy.RangeEnemy.Contains(leastPowerfulCard))
            {
                rangeEnemy.RangeEnemy.Remove(leastPowerfulCard);
            }
            else if(siegeEnemy.SiegeEnemy.Contains(leastPowerfulCard))
            {
                siegeEnemy.SiegeEnemy.Remove(leastPowerfulCard);
            }
        }

    }


    //Efecto de limpiar la fila con menos unidades
    public void ClearRowGreek()
    {
        List<List<GameObject>> rows = new List<List<GameObject>> {melee.Melee, range.Range, siege.Siege};

        List<GameObject> smallesNonEmptyRow = null;
        int minCount = int.MaxValue;

        for (int i = 0; i < rows.Count; i++)
        {
            if(rows[i].Count > 0 && rows[i].Count < minCount)
            {
                smallesNonEmptyRow = rows[i];
                minCount = rows[i].Count;
            }
        }
        if(smallesNonEmptyRow != null)
        {
           
            for (int i = 0; i < smallesNonEmptyRow.Count; i++)
            {
                Destroy(smallesNonEmptyRow[i]);
            } 
            smallesNonEmptyRow.Clear();
        }
    }

    public void ClearRowNordic()
    {
        List<List<GameObject>> rows = new List<List<GameObject>> {meleeEnemy.MeleeEnemy, rangeEnemy.RangeEnemy, siegeEnemy.SiegeEnemy};

        List<GameObject> smallesNonEmptyRow = null;
        int minCount = int.MaxValue;

        for (int i = 0; i < rows.Count; i++)
        {
            if(rows[i].Count > 0 && rows[i].Count < minCount)
            {
                smallesNonEmptyRow = rows[i];
                minCount = rows[i].Count;
            }
        }
        if(smallesNonEmptyRow != null)
        {
            
            for (int i = 0; i < smallesNonEmptyRow.Count; i++)
            {
                Destroy(smallesNonEmptyRow[i]);
            }
            smallesNonEmptyRow.Clear();
        }
    }


    //Efectos de climas
    public void Climate1()
    {
        if(melee.Melee.Count > 0)
        {
            SubtractPowerGreek();
        }
        if(meleeEnemy.MeleeEnemy.Count > 0)
        {
            SubtractPowerNordic();
        }
        void SubtractPowerGreek()
        {
            for (int i = 0; i < melee.Melee.Count; i++)
            {
                melee.Melee[i].GetComponent<DisplayCard>().card.power -= 2;
            }

            ScriptZone.climateMelee = true;
        }
        void SubtractPowerNordic()
        {
            for (int i = 0; i < meleeEnemy.MeleeEnemy.Count; i++)
            {
                meleeEnemy.MeleeEnemy[i].GetComponent<DisplayCard>().card.power -= 2;
            }
            ScriptZone.climateMeleeEnemy = true;
        }
    }


    public void Climate2()
    {
        if(range.Range.Count > 0)
        {
            SubtractPowerGreek();
        }
        if(rangeEnemy.RangeEnemy.Count > 0)
        {
            SubtractPowerNordic();
        }

        void SubtractPowerGreek()
        {
            for (int i = 0; i < range.Range.Count; i++)
            {
                range.Range[i].GetComponent<DisplayCard>().card.power = range.Range[i].GetComponent<DisplayCard>().card.power - 2;
            }
            ScriptZone.climateRange = true;
        }
        void SubtractPowerNordic()
        {
            for (int i = 0; i < rangeEnemy.RangeEnemy.Count; i++)
            {
                rangeEnemy.RangeEnemy[i].GetComponent<DisplayCard>().card.power = rangeEnemy.RangeEnemy[i].GetComponent<DisplayCard>().card.power - 2;
            }
            ScriptZone.climateRangeEnemy = true;
        }
    }


    public void Climate3()
    {
        if(siege.Siege.Count > 0)
        {
            SubtractPowerGreek();
        }
        if(siegeEnemy.SiegeEnemy.Count > 0)
        {
            SubtractPowerNordic();
        }
        void SubtractPowerGreek()
        {
            for (int i = 0; i < siege.Siege.Count; i++)
            {
                siege.Siege[i].GetComponent<DisplayCard>().card.power -= 2;
            }
             ScriptZone.climateSiege = true;
        }
        void SubtractPowerNordic()
        {
            for (int i = 0; i < siegeEnemy.SiegeEnemy.Count; i++)
            {
                siegeEnemy.SiegeEnemy[i].GetComponent<DisplayCard>().card.power -= 2;
            }
            ScriptZone.climateSiegeEnemy = true;
        }
    }

    //Efectos de aumento
    public void Increase1Greek()
    {
       if(melee.Melee.Count > 0)
        {
            AddPower();
        }

        void AddPower()
        {
            for (int i = 0; i < melee.Melee.Count; i++)
            {
                melee.Melee[i].GetComponent<DisplayCard>().card.power += 2;
            }
        } 
    }

    public void Increase1Nordic()
    {
       if(meleeEnemy.MeleeEnemy.Count > 0)
        {
            AddPower();
        }

        void AddPower()
        {
            for (int i = 0; i < meleeEnemy.MeleeEnemy.Count; i++)
            {
                meleeEnemy.MeleeEnemy[i].GetComponent<DisplayCard>().card.power += 2;
            }
        } 
    }

    public void Increase2Greek()
    {
       if(range.Range.Count > 0)
        {
            AddPower();
        }

        void AddPower()
        {
            for (int i = 0; i < range.Range.Count; i++)
            {
                range.Range[i].GetComponent<DisplayCard>().card.power += 2;
            }
        } 
    }

    public void Increase2Nordic()
    {
       if(rangeEnemy.RangeEnemy.Count > 0)
        {
            AddPower();
        }

        void AddPower()
        {
            for (int i = 0; i < rangeEnemy.RangeEnemy.Count; i++)
            {
                rangeEnemy.RangeEnemy[i].GetComponent<DisplayCard>().card.power += 2;
            }
        } 
    }

    public void Increase3Greek()
    {
       if(siege.Siege.Count > 0)
        {
            AddPower();
        }

        void AddPower()
        {
            for (int i = 0; i < siege.Siege.Count; i++)
            {
                siege.Siege[i].GetComponent<DisplayCard>().card.power += 2;
            }
        } 
    }

    public void Increase3Nordic()
    {
       if(siegeEnemy.SiegeEnemy.Count > 0)
        {
            AddPower();
        }

        void AddPower()
        {
            for (int i = 0; i < siegeEnemy.SiegeEnemy.Count; i++)
            {
                siegeEnemy.SiegeEnemy[i].GetComponent<DisplayCard>().card.power += 2;
            }
        } 
    }

    //Efectos de despeje
    public void Clearance1()
    {
       if(melee.Melee.Count > 0 && ScriptZone.climateMelee == true)
        {
            AddPowerGreek();
        }

        void AddPowerGreek()
        {
            for (int i = 0; i < melee.Melee.Count; i++)
            {
                melee.Melee[i].GetComponent<DisplayCard>().card.power += 2;
            }
        }
         
        if(meleeEnemy.MeleeEnemy.Count > 0  && ScriptZone.climateMeleeEnemy == true)
        {
            AddPowerNordic();
        }

        void AddPowerNordic()
        {
            for (int i = 0; i < meleeEnemy.MeleeEnemy.Count; i++)
            {
                meleeEnemy.MeleeEnemy[i].GetComponent<DisplayCard>().card.power += 2;
            }
        }

        
       
       bool found = false;
        int index = 0;
        while (index < climate.Climate.Count && !found)
        {
            if(climate.Climate[index] != null && climate.Climate[index].gameObject.GetComponent<DisplayCard>().card.id == 12)
            {
                found = true; 
                Destroy(climate.Climate[index]);
                climate.Climate.Remove(climate.Climate[index]);
               
            }
            else 
            {
                Debug.LogWarning("No hay clima correspondiente");
                index++;
            }
        }
        
        Destroy(this.gameObject);
        if(GameObject.Find("enemyDeck").GetComponent<Deck>().CardsInHand.Contains(this.gameObject))
        {
            GameObject.Find("enemyDeck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
        }
        else if(GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Contains(this.gameObject))
        {
            GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
        }
        
    }


    public void Clearance2()
    {
       if(range.Range.Count > 0  && ScriptZone.climateRange == true)
        {
            AddPowerGreek();
        }

        void AddPowerGreek()
        {
            for (int i = 0; i < range.Range.Count; i++)
            {
                range.Range[i].GetComponent<DisplayCard>().card.power += 2;
            }
        } 
        
        if(rangeEnemy.RangeEnemy.Count > 0  && ScriptZone.climateRangeEnemy == true)
        {
            AddPowerNordic();
        }

        void AddPowerNordic()
        {
            for (int i = 0; i < rangeEnemy.RangeEnemy.Count; i++)
            {
                rangeEnemy.RangeEnemy[i].GetComponent<DisplayCard>().card.power += 2;
            }
        } 

        
       

        bool found = false;
        int index = 0;
        while (index < climate.Climate.Count && !found)
        {
            if(climate.Climate[index] && climate.Climate[index].gameObject.GetComponent<DisplayCard>().card.id == 13)
            {
                found = true;
                Destroy(climate.Climate[index]);
                climate.Climate.Remove(climate.Climate[index]);
                
            }
            else 
            {
                Debug.LogWarning("No hay clima correspondiente");
                index++;
            }
        }
         Destroy(this.gameObject);
        if(GameObject.Find("enemyDeck").GetComponent<Deck>().CardsInHand.Contains(this.gameObject))
        {
            GameObject.Find("enemyDeck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
        }
        else if(GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Contains(this.gameObject))
        {
            GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
        }
       
            
        
    }


    public void Clearance3()
    {
       if(siege.Siege.Count > 0  && ScriptZone.climateSiege == true)
        {
            AddPowerGreek();
        }

        void AddPowerGreek()
        {
            for (int i = 0; i < siege.Siege.Count; i++)
            {
                siege.Siege[i].GetComponent<DisplayCard>().card.power += 2;
            }
        } 
        
        if(siegeEnemy.SiegeEnemy.Count > 0  && ScriptZone.climateSiegeEnemy == true)
        {
            AddPowerNordic();
        }

        void AddPowerNordic()
        {
            for (int i = 0; i < siegeEnemy.SiegeEnemy.Count; i++)
            {
                siegeEnemy.SiegeEnemy[i].GetComponent<DisplayCard>().card.power += 2;
            }
        } 

      
            
        
        bool found = false;
        int index = 0;
        while (index < climate.Climate.Count && !found)
        {
            if(climate.Climate[index] && climate.Climate[index].gameObject.GetComponent<DisplayCard>().card.id == 14)
            {
                found = true;
                Destroy(climate.Climate[index]);
                climate.Climate.Remove(climate.Climate[index]);
                
            }
            else 
            {
                Debug.LogWarning("No hay clima correspondiente");
                index++;
            }
        }
         Destroy(this.gameObject);
         if(GameObject.Find("enemyDeck").GetComponent<Deck>().CardsInHand.Contains(this.gameObject))
        {
            GameObject.Find("enemyDeck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
        }
        else if(GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Contains(this.gameObject))
        {
            GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
        }
        
    }


    //Efectos de colocar un clima
     public void SetWeatherPoseidón()
    {
        if(melee.Melee.Count > 0)
        {
            SubtractPowerGreek();
        }
        if(meleeEnemy.MeleeEnemy.Count > 0)
        {
            SubtractPowerNordic();
        }
        void SubtractPowerGreek()
        {
            for (int i = 0; i < melee.Melee.Count; i++)
            {
                melee.Melee[i].GetComponent<DisplayCard>().card.power -= 2;
            }

            ScriptZone.climateMelee = true;
        }
        void SubtractPowerNordic()
        {
            for (int i = 0; i < meleeEnemy.MeleeEnemy.Count; i++)
            {
                meleeEnemy.MeleeEnemy[i].GetComponent<DisplayCard>().card.power -= 2;
            }
            ScriptZone.climateMeleeEnemy = true;
        }
    }

    public void SetWeatherThor()
    {
        if(range.Range.Count > 0)
        {
            SubtractPowerGreek();
        }
        if(rangeEnemy.RangeEnemy.Count > 0)
        {
            SubtractPowerNordic();
        }

        void SubtractPowerGreek()
        {
            for (int i = 0; i < range.Range.Count; i++)
            {
                range.Range[i].GetComponent<DisplayCard>().card.power -= 2;
            }
            ScriptZone.climateRange = true;
        }
        void SubtractPowerNordic()
        {
            for (int i = 0; i < rangeEnemy.RangeEnemy.Count; i++)
            {
                rangeEnemy.RangeEnemy[i].GetComponent<DisplayCard>().card.power -= 2;
            }
            ScriptZone.climateRangeEnemy = true;
        }
    }


     public void AddIncreaseGreek()
    {
       if(range.Range.Count > 0)
        {
            AddPower();
        }

        void AddPower()
        {
            for (int i = 0; i < range.Range.Count; i++)
            {
                range.Range[i].GetComponent<DisplayCard>().card.power += 1;
            }
        } 
    }

    public void AddIncreaseNordic()
    {
       if(meleeEnemy.MeleeEnemy.Count > 0)
        {
            AddPower();
        }

        void AddPower()
        {
            for (int i = 0; i < meleeEnemy.MeleeEnemy.Count; i++)
            {
                meleeEnemy.MeleeEnemy[i].GetComponent<DisplayCard>().card.power += 1;
            }
        } 
    }


    //efecto señuelo
    public void baitGreek()
    {
        GameObject mostPowerfulCard2 = null;
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
                    mostPowerfulCard2 = melee.Melee[i];
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
                    mostPowerfulCard2 = range.Range[i];
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
                    mostPowerfulCard2 = siege.Siege[i];
                    maxPower = siege.Siege[i].GetComponent<DisplayCard>().card.power;
                }
            }    
        }
        if(mostPowerfulCard2 != null)
        {
            mostPowerfulCard2.transform.SetParent(GameObject.Find("deck").GetComponent<Deck>().Hand.transform, false);
            GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Add(mostPowerfulCard2);
            if(melee.Melee.Contains(mostPowerfulCard2))
            {
                this.gameObject.transform.SetParent(GameObject.Find("ZoneMelee").transform, false);
                GameObject.Find("ZoneMelee").GetComponent<ScriptZone>().Melee.Add(this.gameObject);
                GameObject.Find("ZoneMelee").GetComponent<ScriptZone>().Melee.Remove(mostPowerfulCard2);
                GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                melee.Melee.Remove(mostPowerfulCard2);
            }
            else if(range.Range.Contains(mostPowerfulCard2))
            {
                this.gameObject.transform.SetParent(GameObject.Find("ZoneRange").transform, false);
                GameObject.Find("ZoneRange").GetComponent<ScriptZone>().Range.Add(this.gameObject);
                GameObject.Find("ZoneRange").GetComponent<ScriptZone>().Range.Remove(mostPowerfulCard2);
                GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                range.Range.Remove(mostPowerfulCard2);
            }
            else if(siege.Siege.Contains(mostPowerfulCard2))
            {
                this.gameObject.transform.SetParent(GameObject.Find("ZoneSiege").transform, false);
                GameObject.Find("ZoneSiege").GetComponent<ScriptZone>().Siege.Add(this.gameObject);
                GameObject.Find("ZoneSiege").GetComponent<ScriptZone>().Siege.Remove(mostPowerfulCard2);
                GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                siege.Siege.Remove(mostPowerfulCard2);
            }
        }
    }

    public void baitNordic()
    {
         GameObject mostPowerfulCard3 = null;

        int maxPower = int.MinValue;

            if(meleeEnemy.MeleeEnemy.Count > 0)
            {
                FindMostPowerfulCardInListMeleeenemy();
            }
            
            else if(rangeEnemy.RangeEnemy.Count > 0)
            {
                FindMostPowerfulCardInListRangeenemy();
            }
            
            else if(siegeEnemy.SiegeEnemy.Count > 0)
            {
                FindMostPowerfulCardInListSiegeenemy();
            }
            else
            {
                Debug.LogWarning("no hay cartas en el campo");

            }
        void FindMostPowerfulCardInListMeleeenemy()
        {
            for (int i = 0; i < meleeEnemy.MeleeEnemy.Count; i++)
            {
                if(meleeEnemy.MeleeEnemy[i].GetComponent<DisplayCard>().card.power > maxPower)
                {
                    mostPowerfulCard3 = meleeEnemy.MeleeEnemy[i];
                    maxPower = meleeEnemy.MeleeEnemy[i].GetComponent<DisplayCard>().card.power;
                }
            }
        }

        void FindMostPowerfulCardInListRangeenemy()
        {
            for (int i = 0; i < rangeEnemy.RangeEnemy.Count; i++)
            {
            
                if(rangeEnemy.RangeEnemy[i].GetComponent<DisplayCard>().card.power > maxPower)
                {
                    mostPowerfulCard3 = rangeEnemy.RangeEnemy[i];
                    maxPower = rangeEnemy.RangeEnemy[i].GetComponent<DisplayCard>().card.power;
                }
            }   

        }

        void FindMostPowerfulCardInListSiegeenemy()
        {
            for (int i = 0; i < siegeEnemy.SiegeEnemy.Count; i++)
            {
            
                if(siegeEnemy.SiegeEnemy[i].GetComponent<DisplayCard>().card.power > maxPower)
                {
                    mostPowerfulCard3 = siegeEnemy.SiegeEnemy[i];
                    maxPower = siegeEnemy.SiegeEnemy[i].GetComponent<DisplayCard>().card.power;
                }
            }
        }

         if(mostPowerfulCard3 != null)
        {
            mostPowerfulCard3.transform.SetParent(GameObject.Find("enemyDeck").GetComponent<Deck>().Hand.transform, false);
            GameObject.Find("enemyDeck").GetComponent<Deck>().CardsInHand.Add(mostPowerfulCard3);
            if(meleeEnemy.MeleeEnemy.Contains(mostPowerfulCard3))
            {
                this.gameObject.transform.SetParent(GameObject.Find("ZoneMeleeEnemy").transform, false);
                GameObject.Find("ZoneMeleeEnemy").GetComponent<ScriptZone>().MeleeEnemy.Add(this.gameObject);
                GameObject.Find("ZoneMeleeEnemy").GetComponent<ScriptZone>().MeleeEnemy.Remove(mostPowerfulCard3);
                GameObject.Find("enemyDeck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                meleeEnemy.MeleeEnemy.Remove(mostPowerfulCard3);
            }
            else if(rangeEnemy.RangeEnemy.Contains(mostPowerfulCard3))
            {
                this.gameObject.transform.SetParent(GameObject.Find("ZoneRangeEnemy").transform, false);
                GameObject.Find("ZoneRangeEnemy").GetComponent<ScriptZone>().RangeEnemy.Add(this.gameObject);
                GameObject.Find("ZoneRangeEnemy").GetComponent<ScriptZone>().RangeEnemy.Remove(mostPowerfulCard3);
                GameObject.Find("enemyDeck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                rangeEnemy.RangeEnemy.Remove(mostPowerfulCard3);
            }
            else if(siegeEnemy.SiegeEnemy.Contains(mostPowerfulCard3))
            {
                this.gameObject.transform.SetParent(GameObject.Find("ZoneSiegeEnemy").transform, false);
                GameObject.Find("ZoneSiegeEnemy").GetComponent<ScriptZone>().SiegeEnemy.Add(this.gameObject);
                GameObject.Find("ZoneSiegeEnemy").GetComponent<ScriptZone>().SiegeEnemy.Remove(mostPowerfulCard3);
                GameObject.Find("enemyDeck").GetComponent<Deck>().CardsInHand.Remove(this.gameObject);
                siegeEnemy.SiegeEnemy.Remove(mostPowerfulCard3);
            }
        }

    }
}


   

/*if(meleeEnemy.MeleeEnemy != null && meleeEnemy.MeleeEnemy.Count != 0)
        {
            GameObject mostPowerfulCardMeleeEnemy = meleeEnemy.MeleeEnemy[0];
            for (int i = 0; i < meleeEnemy.MeleeEnemy.Count; i++)
            {
                if(meleeEnemy.MeleeEnemy[i].power > mostPowerfulCardMeleeEnemy.power)
                {
                    mostPowerfulCardMeleeEnemy = meleeEnemy.MeleeEnemy[i];
                }
            }
        }
        if(rangeEnemy.RangeEnemy != null && rangeEnemy.RangeEnemy.Count != 0)
        {
            GameObject mostPowerfulCardrangeEnemy = rangeEnemy.RangeEnemy[0];
            for (int i = 0; i < rangeEnemy.RangeEnemy.Count; i++)
            {
            
                if(rangeEnemy.RangeEnemy[i].power > mostPowerfulCardrangeEnemy.power)
                {
                    mostPowerfulCardrangeEnemy = rangeEnemy.RangeEnemy[i];
                }
            } 
        }

        if(siegeEnemy.SiegeEnemy != null && siegeEnemy.SiegeEnemy.Count != 0)
        { 
            GameObject mostPowerfulCardsiegeEnemy = siegeEnemy.SiegeEnemy[0];
            for (int i = 0; i < siegeEnemy.SiegeEnemy.Count; i++)
            {
            
                if(siegeEnemy.SiegeEnemy[i].power > mostPowerfulCardsiegeEnemy.power)
                {
                    mostPowerfulCardsiegeEnemy = siegeEnemy.SiegeEnemy[i];
                }
            }

        }

        GameObject mostPowerful;

        if(mostPowerfulCardMeleeEnemy.power < mostPowerfulCardrangeEnemy.power)
        {
            mostPowerful = mostPowerfulCardrangeEnemy;
        }
        else if(mostPowerfulCardrangeEnemy.power < mostPowerfulCardsiegeEnemy.power)
        {
            mostPowerful = mostPowerfulCardsiegeEnemy;
        }
        else
        {
            mostPowerful = mostPowerfulCardMeleeEnemy;
        }

        Destroy(mostPowerful);*/

        /*if(melee.Melee != null && melee.Melee.Count != 0)
        {
            GameObject mostPowerfulCardsiege = melee.Melee[0];
            for (int i = 0; i < melee.Melee.Count; i++)
            {
           
                if(melee.Melee[i].power > mostPowerfulCardMelee.power)
                {
                    mostPowerfulCardMelee = melee.Melee[i];
                }
            }
        }

        if(range.Range != null && rang.Range.Count != 0)
        {
            
            GameObject mostPowerfulCardrange = range.Range[0];
            for (int i = 0; i < range.Range.Count; i++)
            {
          
                if(range.Range[i].power > mostPowerfulCardrange.power)
                {
                    mostPowerfulCardrange = range.Range[i];
                }
            }
        }
        
        if(siege.Siege != null && siege.Siege.Count != 0)
        {
            
            GameObject mostPowerfulCardMelee = siege.Siege[0];
            for (int i = 0; i < siege.Siege.Count; i++)
            {
            
                if(siege.Siege[i].power > mostPowerfulCardsiege.power)
                {
                    mostPowerfulCardsiege = siege.Siege[i];
                }
            } 
        }

        GameObject mostPowerful;

        if(mostPowerfulCardMelee.power < mostPowerfulCardrange.power)
        {
            mostPowerful = mostPowerfulCardrange;
        }
        else if(mostPowerfulCardrange.power < mostPowerfulCardsiege.power)
        {
            mostPowerful = mostPowerfulCardsiege;
        }
        else
        {
            mostPowerful = mostPowerfulCardMelee;
        }

        Destroy(mostPowerful);*/
