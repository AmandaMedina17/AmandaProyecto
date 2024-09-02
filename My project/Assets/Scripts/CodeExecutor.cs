using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CodeExecutor : MonoBehaviour
{
    public TMP_InputField codeInput;
    public Button executeButton;
    public Button ClearButton;
    private Inicio inicio;

    /*private List<BaseCard> Cards;
    private List<string> AddedCards;
    private List<string> Pre_madeCards;
    private List<string> Pre_madeEffects;
    private bool PreviouslyCompiled;*/
    
    public void Awake()
    {
        /*Cards = new List<BaseCard>();
        AddedCards = new List<string>();
        Pre_madeCards = new List<string>();
        Pre_madeEffects = new List<string>();*/
    }

    void Start()
    {
        executeButton.onClick.AddListener(ExecuteCode);
        ClearButton.onClick.AddListener(ClearAllText);

    }

    // Update is called once per frame
    void ExecuteCode()
    {
        string code = codeInput.text;
        inicio.Evaluate(code);
    }

    void ClearAllText()
    {
        codeInput.text = "";
    }
}
