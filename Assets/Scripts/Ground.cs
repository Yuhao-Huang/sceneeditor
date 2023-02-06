using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private Color _color;

    private void Awake()
    {
    }
    void Start()
    {
        EventCenter.pickerClickedAction += SetColor;
    }
        
    public void SetColor(Color color)
    {
        _color = GetComponent<SpriteRenderer>().color = color;
    }
}
