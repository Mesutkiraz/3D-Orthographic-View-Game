using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject loseUI;
    public GameObject winUI;
    public int score;
    public Text loseScoreText,winScoreText;
    public Text inGameScore;
    void Start()
    {
        
    }

    public void GameEnd()
    {
        loseUI.SetActive(true);
        loseScoreText.text = "Total Score: " + score.ToString();
        inGameScore.gameObject.SetActive(false);
    }
    public void WinLevel()
    {
        winUI.SetActive(true);
        winScoreText.text = "Total Score: " + score.ToString();
        inGameScore.gameObject.SetActive(false);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void AppReplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void AddScore(int pointValue)
    {
        score += pointValue;
        
        inGameScore.text = "Puan: " + score;

    }
    public void AppQuit()
    {
        Application.Quit();
    }
}
