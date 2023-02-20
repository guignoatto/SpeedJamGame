using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private string highscoreFilePath;
    private HighScores highscore;
    private PlayerMovement _playerMovement;

    private ItemCollector _itemCollector;
    public float timer;

    private bool gameEnded = false;
    private LevelManagerView _levelManagerView;


    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _itemCollector = GameObject.FindObjectOfType<ItemCollector>();
        _levelManagerView = GetComponent<LevelManagerView>();
        highscoreFilePath = Application.dataPath + "/highscores.json";
        _levelManagerView.leaderBoard.SetActive(false);
        LoadHighScores();
    }

    public void EndGame()
    {
        gameEnded = true;
        ShowLeaderboard();
    }

    private void Update()
    {
        if (!gameEnded)
        {
            timer += Time.deltaTime;
            string minutes = Mathf.Floor(timer / 60).ToString("00");
            string seconds = (timer % 60).ToString("00");
            _levelManagerView.timer.text = minutes + ":" + seconds;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                _levelManagerView.pauseMenu.SetActive(false);
                _playerMovement.paused = false;
            }
            else
            {
                _levelManagerView.pauseMenu.SetActive(true);
                Time.timeScale = 0;
                _playerMovement.paused = true;
            }
        }
    }

    private void ShowLeaderboard()
    {
        SaveHighScore(timer);
        LoadHighScores();
        _levelManagerView.leaderBoard.SetActive(true);
        _levelManagerView.actualScore.text = Mathf.Floor(timer / 60).ToString("00") + ":" + (timer % 60).ToString("00");

        _levelManagerView.firstScore.text = Mathf.Floor(highscore.first / 60).ToString("00") + ":" +
                                            (highscore.first % 60).ToString("00");
        _levelManagerView.secondScore.text = Mathf.Floor(highscore.second / 60).ToString("00") + ":" +
                                             (highscore.second % 60).ToString("00");
        _levelManagerView.thirdScore.text = Mathf.Floor(highscore.third / 60).ToString("00") + ":" +
                                            (highscore.third % 60).ToString("00");
    }

    void LoadHighScores()
    {
        if (File.Exists(highscoreFilePath))
        {
            string json = File.ReadAllText(highscoreFilePath);
            highscore = JsonUtility.FromJson<HighScores>(json);
        }
        else
        {
            highscore = new HighScores();
        }

        SaveHighScores();
    }

    public void SaveHighScore(float score)
    {
        if (score < highscore.first)
        {
            highscore.third = highscore.second;
            highscore.second = highscore.first;
            highscore.first = score;
        }
        else if (score < highscore.second)
        {
            highscore.third = highscore.second;
            highscore.second = score;
        }
        else if (score < highscore.third)
        {
            highscore.third = score;
        }

        string json = JsonUtility.ToJson(highscore, true);
        File.WriteAllText(highscoreFilePath, json);
    }

    void SaveHighScores()
    {
        string json = JsonUtility.ToJson(highscore, true);
        File.WriteAllText(highscoreFilePath, json);
    }

    public HighScores GetHighscores()
    {
        return highscore;
    }
}

[Serializable]
public class HighScores
{
    public float first = 0;
    public float second = 0;
    public float third = 0;
}