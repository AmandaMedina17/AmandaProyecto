using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Bait Card", menuName = "Bait Card")]
public class UnityBaitCard : UnityBaseCard
{
   public UnityBaitCard(string name, int power, Faction faction, TipoDeCarta tipoDeCarta, List<Zonas> Destinations, Sprite SpriteImage, string CardDescription, EffectDelegate Effect = null) : base(name, power, faction, tipoDeCarta, Destinations, SpriteImage, CardDescription, Effect)
    {

    }
}