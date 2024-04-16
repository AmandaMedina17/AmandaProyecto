using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject CartaAfrodita;
    public GameObject CartaApolo;
    public GameObject CartaAres;
    public GameObject Hand1;

    List<GameObject> cartas = new List<GameObject>();


    void Start()
    {
        cartas.Add(CartaAfrodita);
        cartas.Add(CartaApolo);
        cartas.Add(CartaAres);
    }


    public void OnClick(){
        for(var i = 0; i < 10; i++){
    GameObject playerCard = Instantiate(cartas[Random.Range(0,cartas.Count)], new Vector3(0, 0, 0), Quaternion.identity);
    playerCard.transform.SetParent(Hand1.transform, false);
        }
    }
}
