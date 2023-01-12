using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class EventManager : MonoBehaviour
{
    public static event Action<GridPiece> CheckMatch;
    public static event Action MatchFound;
    public static event Action RebuildGrid;


    /// <summary>
    /// check matching pieces
    /// </summary>
    /// <param name="g"></param>
    public static void CheckMatchEvent(GridPiece g)
    {
        CheckMatch?.Invoke(g);
    }

    /// <summary>
    /// when a match happens
    /// </summary>
    public static void MatchFoundEvent()
    {
        MatchFound?.Invoke();
    }

    /// <summary>
    /// triggered on rebuild button click
    /// </summary>
    public static void RebuildGridEvent()
    {
        RebuildGrid?.Invoke();
    }
}
