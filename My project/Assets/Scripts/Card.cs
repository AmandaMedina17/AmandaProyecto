using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Card 
{
    public int id;
    public string cardName;
    public int power;
    public string cardDescription;
    public Sprite spriteImage;
    public string color;


    public Card()
    {

    }


    public Card(int Id, string CardName, int Power, string CardDescription, Sprite SpriteImage, string Color)
    {
        id = Id;
        cardName = CardName;
        power = Power;
        cardDescription = CardDescription;
        spriteImage = SpriteImage;
        color = Color;
    }
}
