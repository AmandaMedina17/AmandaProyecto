using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCards : MonoBehaviour
{

    public int changesGreek = 2;
    public int changesNordic = 2;


    public void ChangeGreek()
    {
        if(changesGreek > 0)
        {
            int randomIndex1 = Random.Range(0, GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Count);
            Destroy(GameObject.Find("deck").GetComponent<Deck>().CardsInHand[randomIndex1]);
            GameObject.Find("deck").GetComponent<Deck>().CardsInHand.Remove(GameObject.Find("deck").GetComponent<Deck>().CardsInHand[randomIndex1]); 
            
            int randomIndex2 = Random.Range(0, Effects.playerDeck.cardList.Count);
            GameObject drawCard2 = Instantiate(Effects.playerDeck.cardList[randomIndex2], new Vector3(0, 0, 0), Quaternion.identity);
            drawCard2.transform.SetParent(Effects.playerDeck.Hand.transform, false);
            Effects.playerDeck.CardsInHand.Add(drawCard2);
            Effects.playerDeck.cardList.RemoveAt(randomIndex2);

            changesGreek--;
        }
        else 
        {
            Debug.Log("no hay mas cambios");
        } 
    }
        

    public void ChangeNordic()
    {

        if(changesNordic > 0)
        {
            int randomIndex1 = Random.Range(0, GameObject.Find("enemyDeck").GetComponent<Deck>().CardsInHand.Count);
            Destroy(GameObject.Find("enemyDeck").GetComponent<Deck>().CardsInHand[randomIndex1]);
            GameObject.Find("enemyDeck").GetComponent<Deck>().CardsInHand.Remove(GameObject.Find("enemyDeck").GetComponent<Deck>().CardsInHand[randomIndex1]); 
            
            int randomIndex2 = Random.Range(0, Effects.enemyDeck.cardList.Count);
            GameObject drawCard1 = Instantiate(Effects.enemyDeck.cardList[randomIndex2], new Vector3(0, 0, 0), Quaternion.identity);
            drawCard1.transform.SetParent(Effects.enemyDeck.Hand.transform, false);
            Effects.enemyDeck.CardsInHand.Add(drawCard1);
            Effects.enemyDeck.cardList.RemoveAt(randomIndex2);

            changesNordic--;
        }
        else 
        {
            Debug.Log("no hay mas cambios");
        } 
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
