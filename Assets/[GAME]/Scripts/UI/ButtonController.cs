using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// sometimes onClick references are lost on editor
/// writing custom button onClick listener
/// </summary>

[RequireComponent(typeof(Button))]
public class ButtonController : MonoBehaviour
{
    [SerializeField] ButtonType buttonType;
    Button button;
    
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ButtonMethod);
    }

    private void ButtonMethod()
    {
        switch(buttonType)
        {
            case ButtonType.RebuildGrid:
                EventManager.RebuildGridEvent();
                break;
        }
    }
}

public enum ButtonType
{
    RebuildGrid,

}