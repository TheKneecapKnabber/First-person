using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool _isHighlighted = false;
    
    public TMP_Text nameDisplay;
    public string displayText;

    private void Awake()
    {
        nameDisplay.text = "";
    }

    public void ShowItemInteractable() //distingguish between non-iteratable items 
    {
        if (!_isHighlighted)
        {
            _isHighlighted = true;
            this.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            nameDisplay.text = displayText;
        }
    }

    public void HideItemInteractable() 
    {
        _isHighlighted = false;
        this.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        nameDisplay.text = "";
    }
}
