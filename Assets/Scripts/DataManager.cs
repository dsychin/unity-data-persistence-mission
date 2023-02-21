using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public static string PlayerName;
    public static ScoreRecord HighScore = new ScoreRecord{};

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
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
    }

    public class ScoreRecord
    {
        public string PlayerName;
        public int Points;
    }
}
