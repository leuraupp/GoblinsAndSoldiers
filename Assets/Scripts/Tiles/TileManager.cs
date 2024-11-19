using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Core.Singleton;

public class TileManager : Singleton<TileManager>
{
    public List<Tiles> tilesPrefabs;

    //private
    private List<GameObject> tiles;

    #region Actions
    public void Init() {
        foreach (Tiles tile in tilesPrefabs) {
            //GameObject tileToAdd = Instantiate(tile, transform);
            //tiles.Add(tileToAdd);
        }
    }
    #endregion

    #region Getters and Setters
    public Tiles GetTile(string tileName) {
        

        return null;
    }

    public List<Tiles> GetTiles() {
        //return tiles;
        return null;
    }
    #endregion
}
