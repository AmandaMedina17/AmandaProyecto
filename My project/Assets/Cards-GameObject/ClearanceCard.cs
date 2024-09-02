using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Clearance Card", menuName = "Clearance Card")]
public class UnityClearanceCard : UnityBaseCard
{
  public UnityClearanceCard(string name, int power, Faction faction, TipoDeCarta tipoDeCarta, List<Zonas> Destinations, Sprite SpriteImage, string CardDescription, EffectDelegate Effect = null) : base(name, power, faction, tipoDeCarta, Destinations, SpriteImage, CardDescription, Effect)
    {

    }
}