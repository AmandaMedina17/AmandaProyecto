using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Climate Card", menuName = "Climate Card")]
public class UnityClimateCard : UnityBaseCard
{
  public UnityClimateCard(string name, int power, Faction faction, TipoDeCarta tipoDeCarta, List<Zonas> Destinations, Sprite SpriteImage, string CardDescription, EffectDelegate Effect = null) : base(name, power, faction, tipoDeCarta, Destinations, SpriteImage, CardDescription, Effect)
    {

    }
}