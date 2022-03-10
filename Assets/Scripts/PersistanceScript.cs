using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PersistanceScript : MonoBehaviour
{
    public static PersistanceScript Instance;
    public string highScore;
    public int maxScore = 0;
    private static string playerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }

    public void SetName(string name)
    {
        playerName = name;
    }
    public void SetHighscore(int score)
    {
        if(score > maxScore)
        {
            highScore = playerName + ": " + score;
            maxScore = score;
            SaveHighScore();
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string highScore;
        public int maxScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.maxScore = maxScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            maxScore = data.maxScore;
        }
    }
}
