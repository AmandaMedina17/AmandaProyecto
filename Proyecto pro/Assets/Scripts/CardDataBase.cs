using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
   public static List<Card> cardList = new List<Card> ();

   void Awake ()
   {
    cardList.Add(new Card (0, "Zeus", 0, "Mantiene una carta aleatoria en el campo entre cada ronda"));
    cardList.Add(new Card (1, "Afrodita", 4, "Roba una carta"));
    cardList.Add(new Card (2, "Apolo", 3, "Limpia la fila del campo (no vacía) con menos unidades (propia o del rival)"  ));
    cardList.Add(new Card (3, "Ares", 2, "Elimina la carta con menos poder del rival"));
    cardList.Add(new Card (4, "Artemisa", 3, "nise"));
    cardList.Add(new Card (5, "Atenea", 3, "Calcula el promedio de poder entre todas las cartas del campo e iguala el poder de todas las cartas a ese promedio (propio o del rival)"));
    cardList.Add(new Card (6, "Hades", 6, "Elimina la carta con más poder del campo(propio o del rival)"));
    cardList.Add(new Card (7, "Hefesto", 3, "Multiplica por n su ataque (siendo n la cantidad de cartas iguales a ella en el campo)"));
    cardList.Add(new Card (8, "Hera", 4, "Coloca un aumento en una fila propia"));
    cardList.Add(new Card (9, "Poseidón", 5, "Inunda la fila Melee"));
   }
}
