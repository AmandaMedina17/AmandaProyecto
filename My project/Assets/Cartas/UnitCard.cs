using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics.Tracing;

public class UnitCard : BaseCard
{
    public Worth worth;
    public UnitCard(string Name, int InitialPower, Faction Faction, TipoDeCarta TipoDeCarta, List<Zonas> destinations, Worth Worth, EffectDelegate Effect = null) : base(Name, InitialPower, Faction, TipoDeCarta, destinations, Effect)
    {
    }
}