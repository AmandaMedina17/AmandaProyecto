using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoDeJuego
{
    public Player player;
    public Player enemy;
    public Tablero tablero;
    public UnityBaseCard card;
    public List<BaseCard> lista;


    public EstadoDeJuego(Player player, Player enemy, UnityBaseCard card = null)
    {
        this.player = player;
        this.enemy = enemy;
        this.card = card;
    }

    public EstadoDeJuego UpdatePlayerInstance(List<BaseCard> position, UnityBaseCard card)
    {
        lista = position;
        this.card = card;

        return this;
    }

}