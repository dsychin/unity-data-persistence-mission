using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public static string PlayerName;
    public static ScoreRecord HighScore = new ScoreRecord { };

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        LoadHighScore();
        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    public static void UpdateHighScore(int points)
    {
        HighScore = new ScoreRecord
        {
            PlayerName = PlayerName,
            Points = points
        };
        SaveHighScore();
    }

    [Serializable]
    public class ScoreRecord
    {
        public string PlayerName;
        public int Points;
    }

    public class SaveData
    {
        public ScoreRecord HighScore;
    }

    static void SaveHighScore()
    {
        var saveData = new SaveData
        {
            HighScore = HighScore
        };
        var json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/saveData.json", json);
    }

    static void LoadHighScore()
    {
        if (!File.Exists(Application.persistentDataPath + "/saveData.json"))
        {
            return;
        }
        var json = File.ReadAllText(Application.persistentDataPath + "/saveData.json");
        var saveData = JsonUtility.FromJson<SaveData>(json);
        HighScore = saveData.HighScore;
    }
}
