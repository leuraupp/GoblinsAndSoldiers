using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TileManager))]
public class TileManagerEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

       TileManager tileManager = (TileManager)target;

        EditorGUILayout.Space(30);
        EditorGUILayout.LabelField("Tiles");

        //if (tileManager.GetTiles().Count > 0) {
        //    foreach (GameObject tile in tileManager.GetTiles()) {
        //        EditorGUILayout.BeginHorizontal();
        //        EditorGUILayout.LabelField(tile.gameObject.name);
        //        EditorGUILayout.EndHorizontal();
        //    }
        //}
    }
}
