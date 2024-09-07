using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    public string Name;
    public Board board;
    public ZonasTablero zonasTablero;
    public GameObject Hand;
    public GameObject Points;
    public Player player;
    public static List<BaseCard> Deck;
    // Start is called before the first frame update
    void Start()
    {
  
        
    }

    void Awake()
    {
        Name = this.gameObject.name;
        if(Name == "GreekGods")
        {
            player = Player.Griegos;
        }
        else 
        {
            player = Player.Nordicos;
        }
    }
}
