using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// component for each grid piece
/// </summary>

public enum PieceState
{
    empty,
    cross,
}

public class GridPiece : MonoBehaviour
{
    private PieceState state;

    public void Init()
    {
        // empty sprite remove cross
        // init any data there is
    }

    public PieceState GetState()
    {
        return state;
    }
}
