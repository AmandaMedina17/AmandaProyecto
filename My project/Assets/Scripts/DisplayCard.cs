using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DisplayCard : MonoBehaviour
{
    public Card card;
    
    public TMP_Text cardDescriptionText;
    public Image Image;
    public TMP_Text Power;
    public TextMeshProUGUI nameText;
    
  
    public TMP_Text Zone;
    
    void Start()
    {

        nameText.text = card.name;
     
        Image.sprite = card.spriteImage;
        cardDescriptionText.text = card.cardDescription;
        Zone.text = card.zone;
        Power.text = card.power.ToString();

    }
}