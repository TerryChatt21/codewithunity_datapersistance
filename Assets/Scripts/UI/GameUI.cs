using System;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentPlayerName;
    [SerializeField] private TMP_Text _currentPlayerScore;
    [SerializeField] private TMP_Text _hsPlayerName;
    [SerializeField] private TMP_Text _hsPlayerScore;


    private void Awake()
    {
        UpdateHighScores();
        UpdateCurrentPlayerName();
    }

    private void UpdateHighScores()
    {
        if (DataManager.Instance._hsPlayerScore == "" && DataManager.Instance._hsPlayerScore == "")
        {
            _hsPlayerName.text = "NO SCORE SET";
            _hsPlayerScore.text = "0";
        }
        else
        {
            _hsPlayerName.text = DataManager.Instance._hsPlayerName.ToUpper();
            _hsPlayerScore.text = DataManager.Instance._hsPlayerScore;
        }
        
    }

    private void UpdateCurrentPlayerName()
    {
        _currentPlayerName.text = DataManager.Instance._currentPlayerName.ToUpper();
    }

    public void ScoreSubmitOnFinish()
    {

        int currentScore = int.Parse(_currentPlayerScore.text);
        int highScore = int.Parse(DataManager.Instance._hsPlayerScore);
        if (DataManager.Instance._hsPlayerScore == "")
        {
            highScore = 0;
        }
        if (currentScore > highScore)
        {
            DataManager.Instance._hsPlayerName = _currentPlayerName.text;
            DataManager.Instance._hsPlayerScore = _currentPlayerScore.text;
            DataManager.Instance.Save();
        }
    }

}