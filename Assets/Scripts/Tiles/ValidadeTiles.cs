using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NUnit.Framework.Constraints;

public class ValidadeTiles : MonoBehaviour {
    public GameObject[,] grid;
    private int rows = 5;
    private int columns = 5;

    public void ValidateTiles() {
        this.rows = GameManager.Instance.GetRows();
        this.columns = GameManager.Instance.GetColumns();

        InitializeGrid();
        List<GameObject> tilesToCheck = TileManager.Instance.GetTiles();

        bool validPlay = true;
        foreach (GameObject tile in tilesToCheck) {
            if (tile.GetComponentInChildren<Tiles>().GetTileName().Equals("Slime")) {
                Debug.Log("Slime found!");
                validPlay = validateSlimeTile(tile.name);
                if (!validPlay) {
                    break;
                }
            } else if (tile.GetComponentInChildren<Tiles>().GetTileName().Equals("Goblin")) {
                Debug.Log("Goblin found!");
                validPlay = ValidateGoblinTile(tile.name);
                if (!validPlay) {
                    break;
                }
            } else if (tile.GetComponentInChildren<Tiles>().GetTileName().Equals("Orc")) {
                Debug.Log("Orc found!");
                validPlay = ValidateOrcTiles(tile.name);
                if (!validPlay) {
                    break;
                }
            }
        }

        if (validPlay) {
            GameManager.Instance.ShowMessage("Ataque confirmado!");
            Invoke("NextLevel", 2f);
        } else {
            GameManager.Instance.ShowMessage("Ataque invalido!");
        }
    }

    private void NextLevel() {
        CameraManager.Instance.SetCameraLevel("level02");
    }

    void InitializeGrid() {
        grid = new GameObject[rows, columns];

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                string tileName = "Tile_" + i + "_" + j;
                grid[i, j] = GameObject.Find(tileName);
            }
        }
    }

    #region Validate Tiles
    private bool validateSlimeTile(string tileName) {
        List<GameObject> adjacentTiles = GetAdjacentTiles(rows, columns, tileName);

        bool validPlay = true;
        bool soldierFound = false;
        foreach (GameObject tile in adjacentTiles) {
            Debug.Log(tile.name);
            Debug.Log(tile.GetComponentInChildren<Tiles>().GetTileName());
            if (tile.GetComponentInChildren<Tiles>().GetTileName().Equals("Soldier")) {
                Debug.Log("Soldier found! " + soldierFound);
                if (!soldierFound) {
                    soldierFound = true;
                    List<GameObject> validadeSoldiers = GetAdjacentTiles(rows, columns, tile.name);
                    foreach (GameObject validadeSoldier in validadeSoldiers) {
                        Debug.Log("Soldier found! " + validadeSoldier.name);
                        Debug.Log("Soldier found! " + validadeSoldier.GetComponentInChildren<Tiles>().GetTileName());
                        if (validadeSoldier.GetComponentInChildren<Tiles>().GetTileName().Equals("Soldier")) {
                            Debug.Log("There is another soldier arround!");
                            validPlay = false;
                            break;
                        }
                    }
                }
            }
            if (soldierFound) {
                break;
            }
        }

        return validPlay && soldierFound;
    }

    private bool ValidateGoblinTile(string tileName) {
        List<GameObject> adjacentTiles = GetAdjacentTiles(rows, columns, tileName);

        bool validPlay = true;
        int soldierFound = 0;
        foreach (GameObject tile in adjacentTiles) {
            if (tile.GetComponentInChildren<Tiles>().GetTileName().Equals("Soldier")) {
                Debug.Log("Soldier found! " + soldierFound);
                if (soldierFound < 2) {
                    soldierFound++;
                    List<GameObject> validadeSoldiers = GetAdjacentTiles(rows, columns, tile.name);
                    foreach (GameObject validadeSoldier in validadeSoldiers) {
                        if (validadeSoldier.GetComponentInChildren<Tiles>().GetTileName().Equals("Soldier")) {
                            validPlay = false;
                            break;
                        }
                    }
                } else {
                    validPlay = false;
                    break;
                }
            }
            if (soldierFound >= 2) {
                break;
            }
        }

        return validPlay && soldierFound >= 2;
    }

    private bool ValidateOrcTiles(string tileName) {
        List<GameObject> adjacentTiles = GetAdjacentTiles(rows, columns, tileName);

        bool validPlay = true;
        int soldierFound = 0;
        foreach (GameObject tile in adjacentTiles) {
            if (tile.GetComponentInChildren<Tiles>().GetTileName().Equals("Soldier")) {
                Debug.Log("Soldier found! " + soldierFound);
                if (soldierFound < 3) {
                    soldierFound++;
                    List<GameObject> validadeSoldiers = GetAdjacentTiles(rows, columns, tile.name);
                    foreach (GameObject validadeSoldier in validadeSoldiers) {
                        if (validadeSoldier.GetComponentInChildren<Tiles>().GetTileName().Equals("Soldier")) {
                            validPlay = false;
                            break;
                        }
                    }
                } else {
                    validPlay = false;
                    break;
                }
            }
            if (soldierFound >= 3) {
                break;
            }
        }

        return validPlay && soldierFound >= 3;
    }
    #endregion

    private List<GameObject> GetAdjacentTiles(int rows, int columns, string tileName) {
        List<GameObject> adjacentTiles = new List<GameObject>();
        // Extrai as coordenadas da string do nome do tile
        string[] parts = tileName.Split('_');
        int row = int.Parse(parts[1]);
        int column = int.Parse(parts[2]);

        // Define as direções para verificar os tiles adjacentes (incluindo diagonais)
        int[,] directions = new int[,]
        {
            { -1, -1 }, { -1, 0 }, { -1, 1 },
            { 0, -1 },           { 0, 1 },
            { 1, -1 }, { 1, 0 }, { 1, 1 }
        };

        // Verifica cada direção
        for (int i = 0; i < directions.GetLength(0); i++) {
            int newRow = row + directions[i, 0];
            int newColumn = column + directions[i, 1];

            // Verifica se a nova posição está dentro dos limites do grid
            if (newRow >= 0 && newRow < rows && newColumn >= 0 && newColumn < columns) {
                adjacentTiles.Add(grid[newRow, newColumn]);
            }
        }

        return adjacentTiles;
    }
}
