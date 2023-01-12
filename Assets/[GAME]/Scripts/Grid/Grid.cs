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

    [Header("Parameters")]
    Vector3 upperLeft;
    float gridSize;
    GridPiece[,] gridPieces;
    List<GridPiece> listCross = new List<GridPiece>();

    private void Start()
    {
        GenerateGrid(n);
        EventManager.CheckMatch += CheckMatch;
    }

    /// <summary>
    /// generating based on n value and margin
    /// 
    /// square grid needed, screen width can be used 
    /// width is taken as the edge of the square play area
    /// 
    /// </summary>
    private void GenerateGrid(int _n)
    {
        Init();
        ClearGrid();
        n = _n;
        gridPieces = new GridPiece[n, n];
        listCross.Clear();

        float cellSize = gridSize / n;
        transform.position = Vector3.zero;
        upperLeft += new Vector3(cellSize / 2f, -cellSize / 2f, 0f);

        for (int x = 0; x < n; x++)
        {
            for (int y = 0; y < n; y++)
            {
                GameObject clone = PoolManager.Instance.gridPiecePool.PullObjFromPool();
                clone.transform.position = upperLeft + new Vector3(x * cellSize, -y * cellSize, 0f);
                clone.transform.SetParent(transform);
                clone.transform.name = x.ToString() + y.ToString();

                GridPiece g = clone.GetComponent<GridPiece>();
                g.Init(x, y);
                gridPieces[x, y] = g;
            }
        }
    }

    /// <summary>
    /// finding grid width in world space
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

    /// <summary>
    /// add neighbors to grid pieces if there is any
    /// </summary>
    private void CheckMatch(GridPiece piece)
    {
        listCross.Add(piece);
        AssignNeighbors(piece);
        RemoveMatching();
    }

    /// <summary>
    /// checking right, left, up and down position
    /// if there is a cross,
    /// clamping values so there won't be any -1 or out of index
    /// </summary>
    /// <param name="refPiece"></param>
    private void AssignNeighbors(GridPiece refPiece)
    {
        List<GridPiece> possibleNeighbors = new List<GridPiece>();
        possibleNeighbors.Add(gridPieces[ refPiece.x, Mathf.Clamp(refPiece.y - 1, 0, n-1)] );
        possibleNeighbors.Add(gridPieces[ refPiece.x, Mathf.Clamp(refPiece.y + 1, 0, n-1)] );
        possibleNeighbors.Add(gridPieces[ Mathf.Clamp(refPiece.x - 1, 0, n-1) , refPiece.y]);
        possibleNeighbors.Add(gridPieces[ Mathf.Clamp(refPiece.x + 1, 0, n-1) , refPiece.y]);

        foreach(GridPiece g in possibleNeighbors)
        {
            if (g != refPiece && g.GetState() == PieceState.cross)
            {
                refPiece.AddNeighbor(g);
                g.AddNeighbor(refPiece);
            }
        }
    }

    /// <summary>
    /// scan through the cross list and check for items
    /// that have 2 or more neighbors, add these in a collection
    /// remove the cross in collection items
    /// </summary>
    private void RemoveMatching()
    {
        List<GridPiece> listMatching = new List<GridPiece>();

        foreach(GridPiece cross in listCross)
        {
            if(cross.GetNeighbors().Count >= 2)
            {
                if (!listMatching.Contains(cross)) listMatching.Add(cross);
                foreach (GridPiece neighbor in cross.GetNeighbors())
                {
                    if (!listMatching.Contains(neighbor)) listMatching.Add(neighbor);
                }
            }
        }

        foreach(GridPiece match in listMatching)
        {
            match.RemoveCross();
            listCross.Remove(match);
        }
    }
}
