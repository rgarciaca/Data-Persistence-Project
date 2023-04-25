using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string bestScorePlayerName;
    public int bestScore;

    public bool bestScoreExists;
    public string playerName;
    public int score;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        LoadScore();
    }

    private void Start()
    {
        score = 0;
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int points;

    }

    public void SaveScore()
    {
        if (bestScore < score)
        {
            SaveData data = new SaveData();
            data.playerName = playerName;
            data.points = score;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }

    public void LoadScore()
    {
        bestScoreExists = false;
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScorePlayerName = data.playerName;
            bestScore = data.points;

            bestScoreExists = true;
        }
    }
}
