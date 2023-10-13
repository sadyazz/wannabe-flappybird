using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class logicScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject mainMenuScreen;
    public GameObject game;

    public TextMeshProUGUI highScoreText;

    public bool gameStarted = false;

    public Button startButton;

    public GameObject bird;
    public birdScript birds;

    public pipeMoveSCript pipeMover;
    private int previousScore = 0;

    private void Awake()
    {
        Time.timeScale = 0f;
    }

    private void OnEnable()
    {
        startButton.onClick.AddListener(startGame);
    }

    private void OnDisable()
    {
        startButton.onClick.RemoveListener(startGame);
    }

    private void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("highScoreText", 0).ToString();
        game.SetActive(false);
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();

        if(playerScore> PlayerPrefs.GetInt("highScoreText", 0))
        {
            PlayerPrefs.SetInt("highScoreText", playerScore);
            highScoreText.text = playerScore.ToString();
        }

        //if (playerScore % 5 == 0)
        //{
        //    birds.DoSomethingAfterEvery30Points();
        //}
        if (playerScore > previousScore)
        {
            // Increase the speed.
            pipeMover.PipePassed();
            previousScore = playerScore;
        }
    }

    //private void flip()
    //{
    //    Debug.Log("FLIP!");
    //    if (bird != null)
    //    {
    //        SpriteRenderer birdSpriteRenderer = bird.GetComponent<SpriteRenderer>();
    //        if (birdSpriteRenderer != null)
    //        {
    //            birdSpriteRenderer.flipY = true;
    //        }
    //    }
    //}

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void startGame()
    {
        Time.timeScale = 1f;

        gameStarted = true;
        mainMenuScreen.SetActive(false);
        game.SetActive(true);
    }
}
