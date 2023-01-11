using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// generatinng a grid with piece game objects
/// </summary>

public class Grid : MonoBehaviour
{
    [Header("Grid Settings")]
    [Range(1, 10)] [SerializeField] int n = 1;
    //[Tooltip("distance to edges")] [SerializeField] float margin = .1f;

    Vector3 upperLeft;
    float gridSize;
    GridPiece[,] gridPieces;

    private void Start()
    {
        GenerateGrid(n);
    }

    /// <summary>
    /// generating based on n value and margin
    /// 
    /// square grid needed, screen width can be used 
    /// width is taken as the edge of the square play area
    /// 
    /// </summary>
    private void GenerateGrid(int n)
    {
        Init();
        ClearGrid();
        float cellSize = gridSize / n;
        transform.position = Vector3.zero;
        gridPieces = new GridPiece[n, n];
        upperLeft += new Vector3(cellSize / 2f, -cellSize / 2f, 0f);

        for (int x = 0; x < n; x++)
        {
            for (int y = 0; y < n; y++)
            {
                GameObject clone = PoolManager.Instance.gridPiecePool.PullObjFromPool();
                clone.transform.position = upperLeft + new Vector3(x * cellSize, -y * cellSize, 0f);
                clone.transform.SetParent(transform);

                gridPieces[x, y] = clone.GetComponent<GridPiece>();
            }
        }
    }

    /// <summary>
    /// finding grid width in world place
    /// </summary>
    private void Init()
    {
        Transform camTransform = Camera.main.transform;
        Vector3 screenUpperLeft = new Vector3(0f, Screen.height, 0f - camTransform.position.z);
        upperLeft = Camera.main.ScreenToWorldPoint(screenUpperLeft);
        gridSize = 2 * Mathf.Abs(upperLeft.x);
    }

    /// <summary>
    /// clear just before generating
    /// </summary>
    private void ClearGrid()
    {
        if (gridPieces == null) return;

        for (int x = 0; x < gridPieces.GetLength(0); x++)
        {
            for (int y = 0; y < gridPieces.GetLength(1); y++)
            {
                PoolManager.Instance.gridPiecePool.AddObjToPool(gridPieces[x, y].gameObject);
            }
        }
    }
}
