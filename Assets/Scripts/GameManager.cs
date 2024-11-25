using UnityEngine;
using Utils.Core.Singleton;

public class GameManager : Singleton<GameManager> {

    public int rows = 5;
    public int columns = 5;

    private void Start() {
        TileManager.Instance.Init();
        GridManager.Instance.GenerateGrid(rows, columns, "map01-easy");
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            LevelManager.Instance.Load("map01-easy");
        }
    }

}
