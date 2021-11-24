using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using TMPro;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    //Current Game

    public string _currentPlayerName;
    public string _currentPlayerScore;

    //Saved Strings.

    public string _nhsPlayerName;
    public string _nhsPlayerScore;

    //Saved when loaded.
    
    public string _hsPlayerName;
    public string _hsPlayerScore;
    
    

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
        Debug.Log(Application.persistentDataPath);
    }

    [System.Serializable]
    class SaveData
    {
        public string _playerName;
        public string _score;
    }

    public void Save()
    {
        string path = "/Savefile.json";
        SaveData data = new SaveData();
        data._playerName = _hsPlayerName;
        data._score = _hsPlayerScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + path, json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            _hsPlayerName = data._playerName;
            _hsPlayerScore = data._score;
        }
        else
        {
            Debug.Log("No file is saved");
        }
    }
}