using UnityEngine;

public class PoolManager : MonoBehaviour
{
    #region Singleton
    public static PoolManager Instance = null;

    private void Awake()
    {
        if (Instance == null) Instance = this;

        StartCreation();
    }
    #endregion

    [Header("Objects For Pooling")]
    public GameObject gridPiece;

    [Header("Pools")]
    [HideInInspector] public PoolingPattern gridPiecePool;


    void StartCreation()
    {
        gridPiecePool = new PoolingPattern(gridPiece);
        gridPiecePool.FillPool(100);

    }
}
