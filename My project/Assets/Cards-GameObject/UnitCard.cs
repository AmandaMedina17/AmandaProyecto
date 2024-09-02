using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics.Tracing;

[CreateAssetMenu(fileName = "Unit Card", menuName = "Unit Card")]
public class UnityUnitCard : UnityBaseCard
{
    public Worth worth;
    public UnityUnitCard(string name, int power, Faction faction, TipoDeCarta tipoDeCarta, List<Zonas> Destinations, Sprite SpriteImage, string CardDescription, Worth worth, EffectDelegate Effect = null) : base(name, power, faction, tipoDeCarta, Destinations, SpriteImage, CardDescription, Effect)
    {
        this.worth = worth;
    }
}