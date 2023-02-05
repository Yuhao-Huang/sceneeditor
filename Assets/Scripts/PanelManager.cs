using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public KeyCode showKey = KeyCode.S;
    public KeyCode hideKey = KeyCode.H;
    public GameObject[] targetUI;

    private void Update()
    {
        if (Input.GetKeyDown(showKey))
        {
            for (int i = 0; i < targetUI.Length; i++)
            {
                targetUI[i].SetActive(true);

            }
        }
        else if (Input.GetKeyDown(hideKey))
        {

            for (int i = 0; i < targetUI.Length; i++)
            {
                targetUI[i].SetActive(false);

            }
        }
    }
}
