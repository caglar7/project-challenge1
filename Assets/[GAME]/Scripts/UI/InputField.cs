using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// need access on rebuild click
/// </summary>

[RequireComponent(typeof(TMP_InputField))]
public class InputField : MonoBehaviour
{
    public static InputField instance;
    public TMP_InputField field;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            field = GetComponent<TMP_InputField>();
        }
    }

}
