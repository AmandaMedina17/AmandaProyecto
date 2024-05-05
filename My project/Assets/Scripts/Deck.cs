using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<GameObject> cardList;
    public List<GameObject> CardsInHand;
    
    /*public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;
    public GameObject Card4;
    public GameObject Card5;
    public GameObject Card6;
    public GameObject Card7;
    public GameObject Card8;
    public GameObject Card9;
    public GameObject Card10;
    public GameObject Card11;
    public GameObject Card12;
    public GameObject Card13;
    public GameObject Card14;
    public GameObject Card15;
    public GameObject Card16;
    public GameObject Card17;
    public GameObject Card18;
    public GameObject Card19;
    public GameObject Card20;
    public GameObject Card21;
    public GameObject Card22;
    public GameObject Card23;
    public GameObject Card24;
    public GameObject Card25;
    public GameObject Card26;
    public GameObject Card27;*/
    public GameObject Hand;


    void Start()
    {
        for( int i = 0; i<10; i++)
        {
            OnClick();
        }
    }

    public void OnClick()
    {
        DrawCard();
    }

    // Update is called once per frame
    public void DrawCard()
    {
        int randomIndex = Random.Range(0, cardList.Count);
        GameObject drawCard = Instantiate(cardList[randomIndex], new Vector3(0, 0, 0), Quaternion.identity);
        drawCard.transform.SetParent(Hand.transform, false);
        CardsInHand.Add(drawCard);
        cardList.RemoveAt(randomIndex);
    }

   /* void Awake(){
        cardList.Add(Card1);
        cardList.Add(Card2);
        cardList.Add(Card3);
        cardList.Add(Card4);
        cardList.Add(Card5);
        cardList.Add(Card6);
        cardList.Add(Card7);
        cardList.Add(Card8);
        cardList.Add(Card9);
        cardList.Add(Card10);
        cardList.Add(Card11);
        cardList.Add(Card12);
        cardList.Add(Card13);
        cardList.Add(Card14);
        cardList.Add(Card15);
        cardList.Add(Card16);
        cardList.Add(Card17);
        cardList.Add(Card18);
        cardList.Add(Card19);
        cardList.Add(Card20);
        cardList.Add(Card21);
        cardList.Add(Card22);
        cardList.Add(Card23);
        cardList.Add(Card24);
        cardList.Add(Card25);
        cardList.Add(Card26);
        cardList.Add(Card27);
    }*/
}
