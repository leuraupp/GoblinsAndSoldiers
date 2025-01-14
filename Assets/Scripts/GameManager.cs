using UnityEngine;
using Utils.Core.Singleton;
using TMPro;

public class GameManager : Singleton<GameManager> {

    public int rows = 5;
    public int columns = 5;
    public GameObject msgObj;
    public GameObject soldierObj;
    public string levelName;

    //private
    public int soldiersCount = 0;

    public int GetRows() { return rows; }
    public int GetColumns() { return columns; }

    private void Start() {
        msgObj.SetActive(false);
        TileManager.Instance.Init();
        GridManager.Instance.GenerateGrid(rows, columns, levelName);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            LevelManager.Instance.Load("map01-easy");
        }
    }

    #region UI
    public void ShowMessage(string message) {
        msgObj.SetActive(true);
        msgObj.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = message;
        Invoke("HideMessage", 2f);
    }
    public void HideMessage() {
        msgObj.SetActive(false);
    }
    public void SetSoldiersCount(int soldiersCount) {
        soldierObj.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "X " + soldiersCount;
        this.soldiersCount = soldiersCount;
    }
    public void AddSoldier() {
        soldiersCount++;
        soldierObj.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "X " + soldiersCount;
    }
    public void RemoveSoldier() {
        soldiersCount--;
        soldierObj.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "X " + soldiersCount;
    }
    public int GetSoldiersCount() {
        Debug.Log("Soldiers count: " + soldiersCount);
        return soldiersCount;
    }
    #endregion

}
