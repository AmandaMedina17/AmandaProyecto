using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Leader Card", menuName = "Leader Card")]
public class UnityLeaderCard : UnityBaseCard
{
    public UnityLeaderCard(string name, int power, Faction faction, TipoDeCarta tipoDeCarta, List<Zonas> Destinations, Sprite SpriteImage, string CardDescription) : base(name, power, faction, tipoDeCarta, Destinations, SpriteImage, CardDescription)
    {

    }
}