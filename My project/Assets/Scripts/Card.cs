using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public int id;
    public new string name;
    public string faction;
    public string cardDescription;
    public Sprite spriteImage;
    public string color;
    public int power;
    public int initialPower;
    public string zone;
    public string cardType;
    public bool point;
   
   

    public void Print()
    {
        Debug.Log(name + ": " + cardDescription + "El poder de la carta: " + power);
    }


    
/* public Card(int Id, string CardName, string Faction, int InitialPower, string CardDescription, Sprite SpriteImage, string Color, int Power, string Zone, string CardType)
    {
        id = Id;
        cardName = CardName;
        faction = Faction;
        initialPower = InitialPower;
        cardDescription = CardDescription;
        spriteImage = SpriteImage;
        color = Color;
        power = Power; 
        zone = Zone;
        cardType = CardType;
    }*/
}
