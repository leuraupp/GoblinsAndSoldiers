using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using Utils.Core.Singleton;

public class GridManager : Singleton<GridManager> {

    public GameObject emptyTile;
    public GameObject board;
    public float padding = 0.1f;
    public float margin = 0.5f;
    public float minPadding = 0.1f;

    public void GenerateGrid(int rows, int columns, string levelName) {
        BoxCollider2D boardCollider = board.GetComponent<BoxCollider2D>();
        float boardWidth = boardCollider.bounds.size.x;
        float boardHeight = boardCollider.bounds.size.y;

        float availableWidth = boardWidth - (margin * 2);
        float availableHeight = boardHeight - (margin * 2);

        float maxCellWidth = (availableWidth - (minPadding * (columns - 1))) / columns;
        float maxCellHeight = (availableHeight - (minPadding * (rows - 1))) / rows;

        float cellSize = Mathf.Min(maxCellWidth, maxCellHeight);

        float actualPaddingX = (availableWidth - (columns * cellSize)) / (columns - 1);
        float actualPaddingY = (availableHeight - (rows * cellSize)) / (rows - 1);

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                float posX = boardCollider.bounds.min.x + margin + j * (cellSize + actualPaddingX) + cellSize / 2;
                float posY = boardCollider.bounds.min.y + margin + i * (cellSize + actualPaddingY) + cellSize / 2;
                Vector3 position = new Vector3(posX, posY, 0);

                GameObject square = Instantiate(emptyTile, position, Quaternion.identity, transform);
                square.transform.localScale = new Vector3(cellSize, cellSize, 1);
                square.name = "Tile_" + i + "_" + j;
            }
        }

        SetLevel(levelName);
    }

    private void SetLevel(string levelName) {
        List<string> monstersMap = new List<string>();

        Debug.Log("levelName: " + levelName);

        if (levelName.Equals("map01-easy")) {
            monstersMap.Add("slime,0,0");
            monstersMap.Add("slime,2,3");
            monstersMap.Add("slime,2,1");
            monstersMap.Add("slime,4,3");
            monstersMap.Add("slime,4,0");
        }

        foreach (var gridMap in monstersMap) {
            SetMonsterOnGrid(gridMap);
        }
    }

    public void SetMonsterOnGrid(string gridMap) {
        var monsterType = gridMap.Split(',')[0];
        var row = gridMap.Split(',')[1];
        var column = gridMap.Split(',')[2];

        Debug.Log("monsterType: " + monsterType);
        Debug.Log("row: " + row + " column: " + column);

        GameObject tileToChange = GameObject.Find("Tile_" + row + "_" + column);
        TileManager.Instance.ChangeTile(tileToChange, monsterType);
    }

}
