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

    //private
    private List<GameObject> tiles;

    #region Actions
    public void Init() {
        
    }
    #endregion

    #region Getters and Setters
    public GameObject GetTile(string tileName) {

        if (tileName.Equals("empty")) {
            return emptyTile;
        } else if (tileName.Equals("soldier")) {
            return soldierTile;
        } else if (tileName.Equals("grass")) {
            return grassTile;
        } else if (tileName.Equals("slime")) {
            return slimeTile;
        }

        return null;
    }

    public List<Tiles> GetTiles() {
        //return tiles;
        return null;
    }
    #endregion
    #region Actions
    public void ChangeTile(GameObject tileToChange, string tileName) {

        //GameObject newTile = GetTile(tileName);

        Vector3 currentPosition = tileToChange.transform.position;
        Vector3 currentScale = tileToChange.transform.localScale;

        Destroy(tileToChange);
        GameObject newTile = Instantiate(GetTile(tileName), currentPosition, Quaternion.identity);
        newTile.transform.localScale = currentScale;

        //GameObject gameObject = GetTile(tileName);
        //if (gameObject != null) {
        //    Vector3 currentScale = tileToChange.transform.localScale;
        //    GameObject newTile = Instantiate(gameObject, tileToChange.transform.position, Quaternion.identity);
        //    newTile.transform.localScale = currentScale;
        //    newTile.transform.SetParent(tileToChange.transform.parent);
        //    Destroy(tileToChange);
        //}
    }
    #endregion
}
