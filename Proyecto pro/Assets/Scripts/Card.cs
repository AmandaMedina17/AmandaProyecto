using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Card : MonoBehaviour
{
   public int id;
   public string cardName;
   public int power;
   public string cardDescription;

   public Card()
   {

   }

   public Card(int Id, string CardName,  int Power, string CardDescription)
   {
    id = Id;
    cardName = CardName;
    power = Power;
    cardDescription = CardDescription;
   }
}
