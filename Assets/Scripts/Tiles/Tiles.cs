using UnityEngine;
using UnityEngine.EventSystems;

public class Tiles : MonoBehaviour {
    public string tileName;

    public string GetTileName() {
        return tileName;
    }

    private void OnMouseOver() {
        Debug.Log("Mouse is over GameObject.");
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Left click");
            if (GameManager.Instance.GetSoldiersCount() > 0) {
                ChangeTile("soldier");
                GameManager.Instance.RemoveSoldier();
            } else {
                GameManager.Instance.ShowMessage("Soldados insuficientes!");
            }
        } else if (Input.GetMouseButtonDown(1)) {
            Debug.Log("Right click");
            ChangeTile("grass");
            if (tileName.Equals("Soldier")) {
                GameManager.Instance.AddSoldier();
            }
        }
    }

    private void ChangeTile(string type) {
        TileManager.Instance.ChangeTile(gameObject, type, gameObject.name, false);
    }
}
