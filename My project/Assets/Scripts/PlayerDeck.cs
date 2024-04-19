using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> container = new List<Card>();
    public int x;
    public static int deckSize;
    public static List<Card> staticDeck = new List<Card>();


    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;

    public GameObject CardToHand;
    public GameObject[] Clones;
    public GameObject Hand;

    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        deckSize = 27;

        for (int i = 0; i < 27; i++)
        {
            x = Random.Range(0, 13);
            deck[i] = CardDataBase.cardList[x];

        }

        StartCoroutine(StartGame());
    }



    // Update is called once per frame
    void Update()
    {
        staticDeck = deck;

        if(deckSize < 20)
        {
            cardInDeck1.SetActive(false);
        }
        if(deckSize < 10)
        {
            cardInDeck2.SetActive(false);
        }
        if(deckSize < 1)
        {
            cardInDeck3.SetActive(false);
        }
    }

    IEnumerator StartGame()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(1);
                
                Instantiate(CardToHand, transform.position, transform.rotation);
            }
        }

    public void Suffle()
    {
        for (int i = 0; i < deckSize; i++)
        {
            container[0] = deck[i];
            int randomIndex = Random.Range(i, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];
        }
    }
}
