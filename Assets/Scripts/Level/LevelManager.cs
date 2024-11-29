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

    public void SetLevel(string levelName) {
        List<string> monstersMap = new List<string>();

        Debug.Log("levelName: " + levelName);

        if (levelName.Equals("map01-easy")) {
            monstersMap.Add("slime,0,0");
            monstersMap.Add("slime,2,3");
            monstersMap.Add("slime,2,1");
            monstersMap.Add("slime,4,3");
            monstersMap.Add("slime,4,0");
        } else if (levelName.Equals("map02-easy")) {
            monstersMap.Add("goblin,1,0");
            monstersMap.Add("goblin,1,4");
            monstersMap.Add("goblin,3,2");
        }

        foreach (var gridMap in monstersMap) {
            GridManager.Instance.SetMonsterOnGrid(gridMap);
        }
    }
}
