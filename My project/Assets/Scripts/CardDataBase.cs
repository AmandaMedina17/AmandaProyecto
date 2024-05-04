using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
   /*public static List<Card> cardList = new List<Card>();
   public static List<Card> CardsInHand = new List<Card>();
   //public static List<Card> CardsInDeck = new List<Card>();

    void Awake(){
        cardList.Add(Card1);
        cardList.Add(Card2);
        cardList.Add(Card3);
        cardList.Add(Card4);
        cardList.Add(Card5);
        cardList.Add(Card6);
        cardList.Add(Card7);
        cardList.Add(Card8);
        cardList.Add(Card9);
        cardList.Add(Card10);
        cardList.Add(Card11);
        cardList.Add(Card12);
        cardList.Add(Card13);
        cardList.Add(Card14);
        cardList.Add(Card15);
        cardList.Add(Card16);
        cardList.Add(Card17);
        cardList.Add(Card18);
        cardList.Add(Card19);
        cardList.Add(Card20);
        cardList.Add(Card21);
        cardList.Add(Card22);
        cardList.Add(Card23);
        cardList.Add(Card24);
        cardList.Add(Card25);
        cardList.Add(Card26);
        cardList.Add(Card27);
    }

    /*void Awake()
    {
        cardList.Add(new Card(0, "Zeus", "Dioses Griegos", 0, "Mantiene una carta aleatoria en el campo entre cada ronda", Resources.Load<Sprite>("Zeus"), "Sky Blue", 0, " ", "Leader"));

        cardList.Add(new Card(1, "Poseidón", "Dioses Griegos", 5, "Inunda la fila Melee", Resources.Load<Sprite>("Poseidon"), "Golden", 0, "R", "Gold"));
        cardList.Add(new Card(2, "Hades", "Dioses Griegos", 6,  "Elimina la carta con más poder del campo (propio o del rival)", Resources.Load<Sprite>("Hades"), "Golden", 0, "S", "Gold"));

        cardList.Add(new Card(3, "Afrodita", "Dioses Griegos", 4, "Roba una carta", Resources.Load<Sprite>("Afrodita"), "Silver", 0, "M", "Silver"));
        cardList.Add(new Card(4, "Afrodita", "Dioses Griegos", 4, "Roba una carta", Resources.Load<Sprite>("Afrodita"), "Silver", 0, "M", "Silver"));
        cardList.Add(new Card(5, "Afrodita", "Dioses Griegos", 4, "Roba una carta", Resources.Load<Sprite>("Afrodita"), "Silver", 0, "M", "Silver"));

        cardList.Add(new Card(6, "Apolo", "Dioses Griegos", 3, "Limpia la fila en el campo (no vacía) con menos unidades (propia o del rival)", Resources.Load<Sprite>("Apolo"), "Silver", 0, "R", "Silver"));
        cardList.Add(new Card(7, "Apolo", "Dioses Griegos", 3, "Limpia la fila en el campo (no vacía) con menos unidades (propia o del rival)", Resources.Load<Sprite>("Apolo"), "Silver", 0, "R", "Silver"));
        cardList.Add(new Card(8, "Apolo", "Dioses Griegos", 3, "Limpia la fila en el campo (no vacía) con menos unidades (propia o del rival)", Resources.Load<Sprite>("Apolo"), "Silver", 0, "R", "Silver"));

        cardList.Add(new Card(9, "Ares", "Dioses Griegos", 4, "Elimina la carta con menos poder del rival", Resources.Load<Sprite>("Ares"), "Silver", 0, "M", "Silver"));
        cardList.Add(new Card(10, "Ares", "Dioses Griegos", 4, "Elimina la carta con menos poder del rival", Resources.Load<Sprite>("Ares"), "Silver", 0, "M", "Silver"));
        cardList.Add(new Card(11, "Ares", "Dioses Griegos", 4, "Elimina la carta con menos poder del rival", Resources.Load<Sprite>("Ares"), "Silver", 0, "M", "Silver"));

        cardList.Add(new Card(12, "Artemisa", "Dioses Griegos", 3, "Roba una carta", Resources.Load<Sprite>("Artemisa"), "Silver", 0, "M", "Silver"));
        cardList.Add(new Card(13, "Artemisa", "Dioses Griegos", 3, "Roba una carta", Resources.Load<Sprite>("Artemisa"), "Silver", 0, "M", "Silver"));
        cardList.Add(new Card(14, "Artemisa", "Dioses Griegos", 3, "Roba una carta", Resources.Load<Sprite>("Artemisa"), "Silver", 0, "M", "Silver"));

        cardList.Add(new Card(15, "Atenea", "Dioses Griegos", 3, "Calcula el promedio de poder entre todas las cartas del campo e iguala el poder de todas las cartas a ese promedio (propio o del rival)", Resources.Load<Sprite>("Atenas"), "Silver", 0, "S", "Silver"));
        cardList.Add(new Card(16, "Atenea", "Dioses Griegos", 3, "Calcula el promedio de poder entre todas las cartas del campo e iguala el poder de todas las cartas a ese promedio (propio o del rival)", Resources.Load<Sprite>("Atenas"), "Silver", 0, "S", "Silver"));
        cardList.Add(new Card(17, "Atenea", "Dioses Griegos", 3, "Calcula el promedio de poder entre todas las cartas del campo e iguala el poder de todas las cartas a ese promedio (propio o del rival)", Resources.Load<Sprite>("Atenas"), "Silver", 0, "S", "Silver"));

        cardList.Add(new Card(18, "Hefesto", "Dioses Griegos", 3, "Multilplica por n su ataque (siendo n la cantidad de cartas iguales a ella en el campo)", Resources.Load<Sprite>("Hefesto"), "Silver", 0, "R", "Silver"));
        cardList.Add(new Card(19, "Hefesto", "Dioses Griegos", 3, "Multilplica por n su ataque (siendo n la cantidad de cartas iguales a ella en el campo)", Resources.Load<Sprite>("Hefesto"), "Silver", 0, "R", "Silver"));
        cardList.Add(new Card(20, "Hefesto", "Dioses Griegos", 3, "Multilplica por n su ataque (siendo n la cantidad de cartas iguales a ella en el campo)", Resources.Load<Sprite>("Hefesto"), "Silver", 0, "R", "Silver"));

        cardList.Add(new Card(21, "Hera", "Dioses Griegos", 4, "Coloca un aumento en una fila propia", Resources.Load<Sprite>("Hera"), "Silver", 0, "R", "Silver"));
        cardList.Add(new Card(22, "Hera", "Dioses Griegos", 4, "Coloca un aumento en una fila propia", Resources.Load<Sprite>("Hera"), "Silver", 0, "R", "Silver"));
        cardList.Add(new Card(23, "Hera", "Dioses Griegos", 4, "Coloca un aumento en una fila propia", Resources.Load<Sprite>("Hera"), "Silver", 0, "R", "Silver"));

        cardList.Add(new Card(24, "Clima", "Dioses Griegos", 0, "No permite colocar cartas en la fila Siege mientras está activa", Resources.Load<Sprite>("Clima"), "Bronze", 0, "Cl", "Special"));
        cardList.Add(new Card(25, "Despeje", "Dioses Griegos", 0, "Despeja el clima eliminando una carta de tipo clima", Resources.Load<Sprite>("Despeje"), "Bronze", 0, "Cl", "Special"));
        cardList.Add(new Card(26, "Señuelo", "Dioses Griegos", 0, "Coloca esta carta en el lugar de una carta del campo para regresar esta a la mano", Resources.Load<Sprite>("Señuelo"), "Bronze", 0, "Sñ", "Special"));
        cardList.Add(new Card(27, "Aumento", "Dioses Griegos", 0, "Bonificación de 1 punto al ataque de las unidades de una fila", Resources.Load<Sprite>("Aumento"), "Bronze", 0, "Au", "Special"));


    }*/
}
