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

        float delayOffset = 0.01f;

        List<string> mosntersList = LevelManager.Instance.SetLevel(levelName);
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                bool isMonster = false;

                float posX = boardCollider.bounds.min.x + margin + j * (cellSize + actualPaddingX) + cellSize / 2;
                float posY = boardCollider.bounds.min.y + margin + i * (cellSize + actualPaddingY) + cellSize / 2;
                Vector3 position = new Vector3(posX, posY, 0);

                mosntersList.ForEach(monster => {
                    if (monster.Split(',')[1].Equals(i.ToString()) && monster.Split(',')[2].Equals(j.ToString())) {
                        TileManager.Instance.CreateTile(TileManager.Instance.GetTileType(monster.Split(',')[0]), position, cellSize, "Tile_" + i + "_" + j, delayOffset);
                        isMonster = true;
                    }
                });
                if (!isMonster) {
                    TileManager.Instance.CreateTile(emptyTile, position, cellSize, "Tile_"+i+"_"+j, delayOffset);
                }
                delayOffset += 0.01f;
            }
        }
    }

    public void SetMonsterOnGrid(string gridMap) {
        var monsterType = gridMap.Split(',')[0];
        var row = gridMap.Split(',')[1];
        var column = gridMap.Split(',')[2];

        Debug.Log("monsterType: " + monsterType);
        Debug.Log("row: " + row + " column: " + column);

        GameObject tileToChange = GameObject.Find("Tile_" + row + "_" + column);
        TileManager.Instance.ChangeTile(tileToChange, monsterType, "Tile_" + row + "_" + column, true);
    }

}
