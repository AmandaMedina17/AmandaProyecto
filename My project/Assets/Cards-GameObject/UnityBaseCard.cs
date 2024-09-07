using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Base Card", menuName = "Cards")]
public class UnityBaseCard : ScriptableObject
{
    public string Name;
    public Faction Faction;
    public TipoDeCarta TipoDeCarta;
    public List<Zonas> destinations = new List<Zonas>();
    public List<BaseCard> PlaceRightNow;
    public Sprite spriteImage;
    public string cardDescription;
    public int Power;

    public bool climateActivated = false;
    public bool increaseActivated = false;
    public bool leader = false;
    


    public UnityBaseCard(string name, int power, Faction faction, TipoDeCarta tipoDeCarta, List<Zonas> Destinations, Sprite SpriteImage, string CardDescription, EffectDelegate Effect = null)
    {
        Name = name;
        Faction = faction;
        TipoDeCarta = tipoDeCarta;
        destinations = Destinations;
        spriteImage = SpriteImage;
        Power = power;
        cardDescription = CardDescription;
    }
}
