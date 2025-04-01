using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData : MonoBehaviour
{
    [SerializeField] public bool isWalkable;
    [SerializeField] public bool isHill;
    [SerializeField] private Vector2Int coordinates; //saving this as xy for stuff like game events. ex: SpawnTowerAt(x, y) then inside function find the transform of those coords

    public void SetCoordinates(Vector2Int coords)
    {
        coordinates = coords;
    }
}