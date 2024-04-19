using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DisplayCard : MonoBehaviour
{
    public List<Card> displayCard = new List<Card>();
    public int displayId;

    public int id;
    public string cardName;
    public int power;
    public string cardDescription;
    public Sprite spriteImage;


    public TextMeshProUGUI nameText;
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI descriptionText;
    public Image artImage;
    public Image frame;

    public bool cardBack;
    public static bool staticCardBack;

    public GameObject Hand;
    public int numberOfCardsInDeck;

    // Start is called before the first frame update
    void Start()
    {
        numberOfCardsInDeck = PlayerDeck.deckSize;

        displayCard[0] = CardDataBase.cardList[displayId];
        id = displayCard[0].id;
        cardName = displayCard[0].cardName;
        power = displayCard[0].power;
        cardDescription = displayCard[0].cardDescription;
        spriteImage = displayCard[0].spriteImage;
        
        nameText.text = " " + cardName;
        powerText.text = " " + power;
        descriptionText.text = " " + cardDescription;
        artImage.sprite = spriteImage;

        if(displayCard[0].color == "Sky Blue")
        {
            frame.GetComponent<Image>().color = new Color32(135, 206, 235, 255);
        }
        if(displayCard[0].color == "Golden")
        {
            frame.GetComponent<Image>().color = new Color32(234, 150, 63, 255);
        }
        if(displayCard[0].color == "Silver")
        {
            frame.GetComponent<Image>().color = new Color32(192, 192, 192, 255);
        }
        if(displayCard[0].color == "Bronze")
        {
            frame.GetComponent<Image>().color = new Color32(205, 127, 50, 255);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Hand = GameObject.Find("Hand");
        if(this.transform.parent == Hand.transform.parent)
        {
            cardBack=false;
        }

       staticCardBack = cardBack;


        if (this.tag == "Clone")
        {
            displayCard[0] = PlayerDeck.staticDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -= 1;
            PlayerDeck.deckSize -= 1;
            cardBack= false;
            this.tag = "Untagged";
        }
    }
}
