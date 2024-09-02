using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Increase Card", menuName = "Increase Card")]
public class UnityIncreaseCard : UnityBaseCard
{
    public int Incremento;
    public UnityIncreaseCard(string name,  int power, Faction faction, TipoDeCarta tipoDeCarta, List<Zonas> Destinations, Sprite SpriteImage, string CardDescription, int Incremento, EffectDelegate Effect = null) : base(name, power, faction, tipoDeCarta, Destinations, SpriteImage, CardDescription, Effect)
    {
        this.Incremento = Incremento;
    }
}
