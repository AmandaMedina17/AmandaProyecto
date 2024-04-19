using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new Card(0, "Zeus", 0, "Mantiene una carta aleatoria en el campo entre cada ronda", Resources.Load<Sprite>("Zeus"), "Sky Blue"));
        cardList.Add(new Card(1, "Poseidón", 5, "Inunda la fila Melee", Resources.Load<Sprite>("Poseidon"), "Golden"));
        cardList.Add(new Card(2, "Hades", 6, "Elimina la carta con más poder del campo (propio o del rival)", Resources.Load<Sprite>("Hades"), "Golden"));
        cardList.Add(new Card(3, "Afrodita", 4, "Roba una carta", Resources.Load<Sprite>("Afrodita"), "Silver"));
        cardList.Add(new Card(4, "Apolo", 3, "Limpia la fila en el campo (no vacía) con menos unidades (propia o del rival)", Resources.Load<Sprite>("Apolo"), "Silver"));
        cardList.Add(new Card(5, "Ares", 4, "Elimina la carta con menos poder del rival", Resources.Load<Sprite>("Ares"), "Silver"));
        cardList.Add(new Card(6, "Artemisa", 3, "Roba una carta", Resources.Load<Sprite>("Artemisa"), "Silver"));
        cardList.Add(new Card(7, "Atenea", 3, "Calcula el promedio de poder entre todas las cartas del campo e iguala el poder de todas las cartas a ese promedio (propio o del rival)", Resources.Load<Sprite>("Atenas"), "Silver"));
        cardList.Add(new Card(8, "Hefesto", 3, "Multilplica por n su ataque (siendo n la cantidad de cartas iguales a ella en el campo)", Resources.Load<Sprite>("Hefesto"), "Silver"));
        cardList.Add(new Card(9, "Hera", 4, "Coloca un aumento en una fila propia", Resources.Load<Sprite>("Hera"), "Silver"));
        cardList.Add(new Card(10, "Clima", 0, "No permite colocar cartas en la fila Siege mientras está activa", Resources.Load<Sprite>("Clima"), "Bronze"));
        cardList.Add(new Card(11, "Despeje", 0, "Despeja el clima eliminando una carta de tipo clima", Resources.Load<Sprite>("Despeje"), "Bronze"));
        cardList.Add(new Card(12, "Señuelo", 0, "Coloca esta carta en el lugar de una carta del campo para regresar esta a la mano", Resources.Load<Sprite>("Señuelo"), "Bronze"));
        cardList.Add(new Card(13, "Aumento", 0, "Bonificación de 1 punto al ataque de las unidades de una fila", Resources.Load<Sprite>("Aumento"), "Bronze"));


    }
}
