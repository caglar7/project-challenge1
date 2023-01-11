using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// on mouse down, show cross
/// </summary>

public class InputHandle : MonoBehaviour
{
    GridPiece gridPiece;

    private void Awake()
    {
        gridPiece = GetComponent<GridPiece>();
    }

    private void OnMouseDown()
    {
        if (gridPiece) gridPiece.ShowCross();
    }

}
