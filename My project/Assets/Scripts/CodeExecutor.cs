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
    
    public void Awake()
    {
        
    }

    void Start()
    {
        inicio = new Inicio();
        executeButton.onClick.AddListener(ExecuteCode);
        ClearButton.onClick.AddListener(ClearAllText);

    }

    // Update is called once per frame
    void ExecuteCode()
    {
        string code = codeInput.text;
        Debug.Log(code);
        inicio.Evaluate(code);
        
    }

    void ClearAllText()
    {
        codeInput.text = "";
    }
}
