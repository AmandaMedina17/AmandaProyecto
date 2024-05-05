using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
   
    private Deck enemyDeck;
    private Deck playerDeck;

    // Start is called before the first frame update
    void Start()
    {
        enemyDeck = GameObject.Find("enemyDeck").GetComponent<Deck>();
        playerDeck = GameObject.Find("deck").GetComponent<Deck>();
    }

    // Update is called once per frame
    public void OnClick()
    {
        if(this.gameObject.GetComponent<DisplayCard>().card.id == 4)
        {
            if(this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Griegos")
            {
                DrawACardGreek();
                this.gameObject.GetComponent<DisplayCard>().card.id = 0;
            }
            else if(this.gameObject.GetComponent<DisplayCard>().card.faction == "Dioses Nórdicos")
            {
                DrawACardNordic();
                this.gameObject.GetComponent<DisplayCard>().card.id = 0;
            }
            
        }
    }


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
}
