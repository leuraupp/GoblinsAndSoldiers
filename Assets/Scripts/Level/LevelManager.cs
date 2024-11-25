using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils.Core.Singleton;

public class LevelManager : Singleton<LevelManager> {

    public void Load(int i) {
        SceneManager.LoadScene(i);
    }

    public void Load(string s) {
        SceneManager.LoadScene(s);
    }
}
