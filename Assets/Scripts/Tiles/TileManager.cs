using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Core.Singleton;
using DG.Tweening;

public class TileManager : Singleton<TileManager>
{
    public GameObject emptyTile;
    public GameObject soldierTile;
    public GameObject grassTile;
    public GameObject slimeTile;
    public GameObject goblinTile;
    public GameObject orcTile;

    //private
    private List<GameObject> tiles;
    Vector3 finalScale = new Vector3(0, 0, 1);

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
        } else if (tileName.Equals("orc")) {
            return orcTile;
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
    public void CreateTile(GameObject tile, Vector3 position, float cellSize, string tileName, float delay) {
        GameObject square = Instantiate(tile, position, Quaternion.identity, transform);
        finalScale = new Vector3(cellSize, cellSize, 1);
        square.transform.localScale = new Vector3(0, 0, 1);
        square.transform.DOScale(finalScale, 0.2f).SetDelay(delay);
        square.name = tileName;
        SetTile(square);
    }
    public void ChangeTile(GameObject tileToChange, string tileType, string tileName, bool isMonster) {
        Vector3 currentPosition = tileToChange.transform.position;

        GetTiles().Remove(tileToChange);
        Destroy(tileToChange);
        GameObject newTile = Instantiate(GetTileType(tileType), currentPosition, Quaternion.identity, transform);
        newTile.transform.localScale = new Vector3(0, 0, 1);
        newTile.transform.DOScale(finalScale, 0.2f);
        newTile.name = tileName;
        SetTile(newTile);
        if (isMonster) {
            newTile.GetComponentInChildren<BoxCollider2D>().enabled = false;
        }
    }
    #endregion
}
