using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject gameOvertext;
    public Text scoreText;
    public Text highScoreText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    private int score = 0;
    private int hScore = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Update()
    {
        hScore = PlayerPrefs.GetInt("high_score");
        highScoreText.text = "HighScore : " + hScore.ToString();
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }
        score++;
        scoreText.text = "Score : " + score.ToString();
    }
    public void BirdDied()
    {
        gameOvertext.SetActive(true);
        gameOver = true;
        if(PlayerPrefs.GetInt("high_score") < score)
            PlayerPrefs.SetInt("high_score", score);
    }
}