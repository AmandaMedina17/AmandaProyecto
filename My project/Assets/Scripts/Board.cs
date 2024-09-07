using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Tablero tablero;
    public Dictionary<string , GameObject> ListaDeLasZonas;
    public GameObject Climate;
    public Players Griegos;
    public Players Nordicos;
     public Dictionary<string, Players> GetPlayerByName;
    public Dictionary<Player, Players> GetPlayer;
    public bool JugandoGriegos = true;


    // Start is called before the first frame update
    void Start()
    {
        ListaDeLasZonas = new Dictionary<string, GameObject>();
        foreach(string item in NombresZonas)
        {
            ListaDeLasZonas.Add(item, GameObject.Find(item));
        }
        Climate = ListaDeLasZonas["Climate"];
        tablero = Tablero.tablero;

        GetPlayerByName = new Dictionary<string, Players>() { { "Greek_Gods", Griegos }, { "Nordic_Gods", Nordicos } };
        GetPlayer = new Dictionary<Player, Players>() { { Player.Griegos, Griegos }, { Player.Nordicos, Nordicos } };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static string[] NombresZonas = {"Climate", "Melee Greek", "Range Greek", "Siege Greek", "Increase Melee Greek", "Increase Range Greek", "Increase Siege Greek", "Melee Nordic", "Range Nordic", "Siege Nordic", "Increase Melee Nordic", "Increase Range Nordic", "Increase Siege Nordic" };

    
}