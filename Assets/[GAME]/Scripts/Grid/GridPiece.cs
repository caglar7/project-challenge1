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
    [SerializeField] private GameObject cross;
    [HideInInspector] public int x, y;
    private PieceState state;
    private List<GridPiece> listNeighbors = new List<GridPiece>();

    /// <summary>
    /// init method on generation
    /// </summary>
    /// <param name="_x"></param>
    /// <param name="_y"></param>
    public void Init(int _x, int _y)
    {
        x = _x;
        y = _y;
        cross.SetActive(false);
        state = PieceState.empty;
        listNeighbors.Clear();
    }

    /// <summary>
    /// show cross and trigger check event
    /// </summary>
    public void ShowCross()
    {
        if (state == PieceState.cross) return;
        
        cross.SetActive(true);
        state = PieceState.cross;

        EventManager.CheckMatchEvent(this);        
    }

    public void RemoveCross()
    {
        Init(x, y);
    }

    public void AddNeighbor(GridPiece value)
    {
        if (!listNeighbors.Contains(value)) listNeighbors.Add(value);
    }

    public List<GridPiece> GetNeighbors()
    {
        return listNeighbors;
    }

    public PieceState GetState()
    {
        return state;
    }
}
