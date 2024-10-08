using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCard : MonoBehaviour
{
    public GameObject canvas;
    private GameObject zoomCard;
    private Vector2 zoomScale = new Vector2(4,4);

    public void Awake()
    {
        canvas = GameObject.Find("Zoom");
    }

    public void OnCardAreaEnter()
    {
        zoomCard = Instantiate(gameObject, new Vector2(150,150), Quaternion.identity);

        zoomCard.transform.SetParent(canvas.transform, false);

        zoomCard.transform.localScale = zoomScale;
    }

    public void OnCardAreaExit()
    {
        Destroy(zoomCard);
    }
    
}
