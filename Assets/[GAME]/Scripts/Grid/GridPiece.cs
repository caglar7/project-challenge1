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
    public GameObject cross;
    private PieceState state;

    private void Start()
    {
        RemoveCross();
    }
    public void ShowCross()
    {
        cross.SetActive(true);
        state = PieceState.cross;
    }

    public void RemoveCross()
    {
        cross.SetActive(false);
        state = PieceState.empty;
    }

    public PieceState GetState()
    {
        return state;
    }
}
