using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils.Core.Singleton;

public class LevelManager : Singleton<LevelManager> {

    public int levelIndex = 0;
    public string levelName = "";

    private int soldiersCount = 0;

    public void Load(int i) {
        SceneManager.LoadScene(i);
        levelIndex = i;
        levelName = GetLevelNameByIndex(i);
    }

    public void Load(string s) {
        SceneManager.LoadScene(s);
        levelName = s;
        levelIndex = GetLevelIndexByName(s);
    }

    public List<string> SetLevel(string levelName) {
        List<string> monstersMap = new List<string>();

        Debug.Log("levelName: " + levelName);

        if (levelName.Equals("map01-easy")) {
            monstersMap.Add("slime,0,0");
            monstersMap.Add("slime,2,3");
            monstersMap.Add("slime,2,1");
            monstersMap.Add("slime,4,3");
            monstersMap.Add("slime,4,0");
            soldiersCount = 5;
        } else if (levelName.Equals("map02-easy")) {
            monstersMap.Add("goblin,1,0");
            monstersMap.Add("goblin,1,4");
            monstersMap.Add("goblin,3,2");
            soldiersCount = 6;
        } else if (levelName.Equals("map03-easy")) {
            monstersMap.Add("orc,4,1");
            monstersMap.Add("orc,2,4");
            soldiersCount = 6;
        } else if (levelName.Equals("map04-easy")) {
            monstersMap.Add("slime,0,3");
            monstersMap.Add("slime,5,2");
            monstersMap.Add("goblin,1,4");
            monstersMap.Add("goblin,2,1");
            monstersMap.Add("orc,4,4");
            soldiersCount = 9;
        }
        levelIndex = GetLevelIndexByName(levelName);
        this.levelName = levelName;
        GameManager.Instance.SetSoldiersCount(soldiersCount);

        return monstersMap;

        //foreach (var gridMap in monstersMap) {
        //    GridManager.Instance.SetMonsterOnGrid(gridMap);
        //}
    }

    private int GetLevelIndexByName(string levelName) {
        switch (levelName) {
            case "map01-easy":
            return 1;
            case "map02-easy":
            return 2;
            case "map03-easy":
            return 3;
            case "map04-easy":
            return 4;
            default:
            return 0;
        }
    }
    private string GetLevelNameByIndex(int levelIndex) {
        switch (levelIndex) {
            case 1:
            return "map01-easy";
            case 2:
            return "map02-easy";
            case 3:
            return "map03-easy";
            case 4:
            return "map04-easy";
            default:
            return "";
        }
    }
    public int GetLevelIndex() {
        return levelIndex;
    }
    public string GetLevelName() {
        return levelName;
    }

    public void NextLevel() {
        levelIndex++;
        Debug.Log("levelIndex: " + levelIndex);
        Load(levelIndex);
    }
}
