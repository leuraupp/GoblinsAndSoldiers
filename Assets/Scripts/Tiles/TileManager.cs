using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Core.Singleton;

public class TileManager : Singleton<TileManager>
{
    public GameObject emptyTile;
    public GameObject soldierTile;
    public GameObject grassTile;
    public GameObject slimeTile;
    public GameObject goblinTile;

    //private
    private List<GameObject> tiles;

    #region Actions
    public void Init() {
        tiles = new List<GameObject>();
    }
    #endregion

    #region Getters and Setters
    public GameObject GetTileType(string tileName) {

        if (tileName.Equals("empty")) {
            return emptyTile;
        } else if (tileName.Equals("soldier")) {
            return soldierTile;
        } else if (tileName.Equals("grass")) {
            return grassTile;
        } else if (tileName.Equals("slime")) {
            return slimeTile;
        } else if (tileName.Equals("goblin")) {
            return goblinTile;
        }

        return null;
    }

    public void SetTile(GameObject tile) {
        tiles.Add(tile);
    }

    public GameObject GetTile(string tileName) {
        foreach (GameObject tile in tiles) {
            if (tile.name.Equals(tileName)) {
                return tile;
            }
        }
        return null;
    }

    public List<GameObject> GetTiles() {
        return tiles;
    }
    #endregion
    #region Actions
    public void CreateTile(GameObject tile, Vector3 position, float cellSize, string tileName) {
        GameObject square = Instantiate(tile, position, Quaternion.identity, transform);
        square.transform.localScale = new Vector3(cellSize, cellSize, 1);
        square.name = tileName;
        SetTile(square);
    }
    public void ChangeTile(GameObject tileToChange, string tileType, string tileName) {
        Vector3 currentPosition = tileToChange.transform.position;
        Vector3 currentScale = tileToChange.transform.localScale;

        GetTiles().Remove(tileToChange);
        Destroy(tileToChange);
        GameObject newTile = Instantiate(GetTileType(tileType), currentPosition, Quaternion.identity, transform);
        newTile.transform.localScale = currentScale;
        newTile.name = tileName;
        SetTile(newTile);
    }
    #endregion
}
