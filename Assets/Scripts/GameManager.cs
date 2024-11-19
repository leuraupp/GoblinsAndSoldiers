using UnityEngine;
using Utils.Core.Singleton;

public class GameManager : Singleton<GameManager> {

    private void Start() {
        TileManager.Instance.Init();
        GridManager.Instance.GenerateGrid(5, 5);
    }

}
