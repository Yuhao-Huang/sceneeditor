using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputFieldController : MonoBehaviour
{

    public TMP_InputField inputField;
    private void Awake()
    {
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void ParseInputValue(string inputString)
    {
        int inputValue;
        int.TryParse(inputString, out inputValue);
        Debug.Log("Input value: " + inputValue);
    }
}
