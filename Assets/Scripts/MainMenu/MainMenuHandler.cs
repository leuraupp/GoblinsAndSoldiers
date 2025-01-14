using UnityEngine;
using UnityEditor;

public class MainMenuHandler : MonoBehaviour
{
    public void OnStartGame() {
        LevelManager.Instance.Load("map01-easy(Test)");
    }

    public void OnExitGame() {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void OnOptions() {
        
    }
}
