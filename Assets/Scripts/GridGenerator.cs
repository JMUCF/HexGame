using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject[] hexPrefabs;
    public int gridWidth = 10;
    public int gridHeight = 10;
    private float hexSize = 1f; //Don't change this, based on tile model size
    public float noiseScale = 0.1f;

    public List<TileData> Tiles = new List<TileData>();

    void Start()
    {
        //Offsets perlin noise so each run is different
        float noiseOffsetX = Random.Range(0f, 1000f);
        float noiseOffsetY = Random.Range(0f, 1000f);
        GenerateGrid(noiseOffsetX, noiseOffsetY);
    }

    void GenerateGrid(float offsetX, float offsetY) //might need to re-write this to keep track of tile coordinates
    {
        GameObject gridParent = new GameObject("HexGrid");

        float xOffset = hexSize * 1.732f;
        float zOffset = hexSize * 1.5f;

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                float xPos = x * xOffset;
                if (y % 2 == 1) xPos += xOffset / 2;
                float zPos = y * zOffset;

                float noiseValue = Mathf.PerlinNoise((x * noiseScale) + offsetX, (y * noiseScale) + offsetY); //This section looks at noise to decide which tile to use, so things blend
                GameObject hexPrefab;
                if (noiseValue < 0.3f)
                    hexPrefab = hexPrefabs[Random.Range(0, 2)];
                else if (noiseValue < 0.6f)
                    hexPrefab = hexPrefabs[Random.Range(2, 5)];
                else
                    hexPrefab = hexPrefabs[Random.Range(5, 8)];

                GameObject tile = Instantiate(hexPrefab, new Vector3(xPos, 0, zPos), Quaternion.identity);
                tile.transform.parent = gridParent.transform;

                TileData tileData = tile.GetComponent<TileData>(); //Get the TileData and set the coordinates on the tile, then add to list to view on GameManager
                tileData.SetCoordinates(new Vector2Int(x, y));
                AddTileToList(tileData);
            }
        }
    }

    void AddTileToList(TileData tileData)
    {
        Tiles.Add(tileData);
    }
}