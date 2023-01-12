using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action<GridPiece> CheckMatch; 
    
    public static void CheckMatchEvent(GridPiece g)
    {
        CheckMatch?.Invoke(g);
    }
}
