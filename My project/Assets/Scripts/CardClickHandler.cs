using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardClickHandler : MonoBehaviour
{
    public UnityBaseCard card;

    private void OnMouseDown()
    {
        if(card != null)
        {
            EffectDelegate effect = SavedEffects.ObtenerEfecto(card.Name);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
