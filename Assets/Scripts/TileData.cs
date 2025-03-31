using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData : MonoBehaviour
{
    [SerializeField] private bool isWalkable;
    [SerializeField] private Vector2Int coordinates;

    public void SetCoordinates(Vector2Int coords)
    {
        coordinates = coords;
    }
}