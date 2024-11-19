using UnityEngine;
using Utils.Core.Singleton;

public class GridManager : Singleton<GridManager> {

    public float spacing = 1.1f;

    public void GenerateGrid(int rows, int columns) {
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                Vector3 position = new Vector3(j * spacing, i * spacing, 0);
                Instantiate(TileManager.Instance.GetTiles().GetRandomItem(), position, Quaternion.identity, transform);
            }
        }
    }

}
