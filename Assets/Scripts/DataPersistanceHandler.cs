using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataPersistanceHandler : MonoBehaviour
{
    public static DataPersistanceHandler Instance;
    public string playerName;
    public string hiScoreName;
    public int bestScore;

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHiScore();
    }
    
    [System.Serializable]

    class SaveData
    {
        public string playerName;
        public int bestScore;
    }

    public void SaveHiScore()
    {
        SaveData data = new SaveData();
        data.playerName = hiScoreName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHiScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            hiScoreName = data.playerName;
            bestScore = data.bestScore;
        }
    }
}
