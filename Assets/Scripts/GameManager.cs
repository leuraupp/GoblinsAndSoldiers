using UnityEngine;
using Utils.Core.Singleton;

public class GameManager : Singleton<GameManager> {

    public int rows = 5;
    public int columns = 5;
    public GameObject msgObj;

    public int GetRows() { return rows; }
    public int GetColumns() { return columns; }

    private void Start() {
        msgObj.SetActive(false);
        TileManager.Instance.Init();
        GridManager.Instance.GenerateGrid(rows, columns, "map02-easy");
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            LevelManager.Instance.Load("map01-easy");
        }
    }

    public void ShowMessage(string message) {
        msgObj.SetActive(true);
        msgObj.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = message;
        Invoke("HideMessage", 2f);
    }
    public void HideMessage() {
        msgObj.SetActive(false);
    }

}
