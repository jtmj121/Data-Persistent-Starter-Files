using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public string PlayerName;
    public string HighScoreName;
    public int HighScore;
        
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }
    class SaveData
    {
        public string HighScoreName;
        public int HighScore;
    }
    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.HighScoreName = HighScoreName;
        data.HighScore = HighScore;
        string json=JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);   
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            HighScoreName = data.HighScoreName;
            HighScore = data.HighScore;
        }
    }
}

