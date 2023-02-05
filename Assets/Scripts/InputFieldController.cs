using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputFieldController : MonoBehaviour
{

    public TMP_InputField inputField;
    private string inputValue = "";
    private void Awake()
    {
        Hide();
    }
    public void ParseInputValue(string inputString)
    {
        inputValue = inputString;
        Debug.Log(inputValue);
    }
        public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
