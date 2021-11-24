using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _highScoreNumber;
    [SerializeField] private float _highScoreFlashSpeed = 0.5f;
    [SerializeField] private TMP_Text _inputPlaceholderText;
    [SerializeField] private TMP_Text _nameEntry;
    [SerializeField] private GameObject _nameWarning;
    [SerializeField] private GameObject _startInterface;
    [SerializeField] private GameObject _nameInputInterface;


    //Unity Monobehaviour Methods. 

    //Private Methods

    private void Start()
    {
        StartCoroutine(HighScoreFlash(true));
        _inputPlaceholderText.text = ". . .";
        if (DataManager.Instance._hsPlayerScore == "")
        {
            _highScoreNumber.text = "000"; ;
        }
        else
        {
            _highScoreNumber.text = DataManager.Instance._hsPlayerScore;
        }
        

    }

    public IEnumerator HighScoreFlash(bool stop)
    {
        while (stop)
        {
            _highScoreNumber.gameObject.SetActive(false);
            yield return new WaitForSeconds(_highScoreFlashSpeed);
            _highScoreNumber.gameObject.SetActive(true);
            yield return new WaitForSeconds(_highScoreFlashSpeed);
        }
    }

    //Public Methods

    public void StartButtonClick()
    {
        _startInterface.SetActive(false);
        _nameInputInterface.SetActive(true);
        StopCoroutine(HighScoreFlash(false));
    }

    public void ClearInputBoxOnSelect()
    {
        if (_inputPlaceholderText.text == ". . .")
        {
            _inputPlaceholderText.text = "";
        }
    }

    public void SubmitName()
    {
        if (_nameEntry.text.Length <= 1)
        {
            _nameWarning.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(1);
            DataManager.Instance._currentPlayerName = _nameEntry.text;
        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        application.quit();
#endif
    }
}