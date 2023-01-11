using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// generation a grid with piece game objects
/// </summary>

public class Grid : MonoBehaviour
{
    [Header("Grid Settings")]
    [Range(1, 10)] [SerializeField] int n = 1;
    [Tooltip("distance to edges")] [SerializeField] float margin = .1f;

    

    private void Start()
    {
        GenerateGrid();
    }


    /// <summary>
    /// generating based on n value and margin
    /// 
    /// square grid needed, screen width can be used 
    /// width is taken as the edge of the square play area
    /// 
    /// </summary>
    private void GenerateGrid()
    {
        float gridEdgeSize = Screen.width;
        float cellSize = gridEdgeSize =
    }
}
