using UnityEngine;
using UnityEngine.EventSystems;

public class Tiles : MonoBehaviour {
    public string tileName;

    private void OnMouseOver() {
        Debug.Log("Mouse is over GameObject.");
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Left click");
            ChangeTile("soldier");
        } else if (Input.GetMouseButtonDown(1)) {
            Debug.Log("Right click");
            ChangeTile("grass");
        }
    }

    private void ChangeTile(string type) {
        TileManager.Instance.ChangeTile(gameObject, type);
    }
}
