using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static GameController instance;

    public bool gameOver = false;
    public float scrollSpeed = -3.5f;

    public Button startGameButton;
    public Button scoresButton;
    public Button startMenuButton;

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private int playerScore = 0;
    private PlayerProgress playerProgress;
    private int levelCount = 0;
 

    private void Awake()
    {
        //If we don't currently have a game control...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);
    }

    private void Start()
    {
        LoadPlayerProgress();
    }

    private void Update()
    {
        
        if (gameOver == false)
        {
            GroundScroll.instance.ScrollGround();

            if (levelCount == 5)
            {
                scrollSpeed--;
                levelCount = 0;
            }
            
        }
        
    }

    public void StartGame()
    {
        gameOver = false;
        Rocket.instance.inGame = true;
        Rocket.instance.UpdateRocketPosition();
        GroundScroll.instance.UpdateGroundPosition();
        scrollSpeed = -3.5f;

        scoreText.gameObject.SetActive(true);

        startGameButton.gameObject.SetActive(false);
        scoresButton.gameObject.SetActive(false);
        startMenuButton.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);

        playerScore = 0;
        scoreText.text = "Score: " + playerScore;
    }

    public void LoadScores()
    {
        startGameButton.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(true);

        scoreText.gameObject.SetActive(false);
        scoresButton.gameObject.SetActive(false);

        highScoreText.text = "Highest Score: " + playerProgress.highestScore;
    }

    public void EndGame()
    {
        gameOver = true;
        Rocket.instance.inGame = false;
        scrollSpeed = 0;

        startMenuButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(true);

        SubmitNewPlayerScore(playerScore);
        
    }

    public void StartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RocketScored()
    {
        if (gameOver)
        {
            return;
        }
        playerScore++;
        levelCount++;
        scoreText.text = "Score: " + playerScore;
    }

    private void SubmitNewPlayerScore(int newScore)
    {
        if(newScore > playerProgress.highestScore)
        {
            playerProgress.highestScore = newScore;
            SavePlayerProgress();
        }
    }

    private int GetHighestPLayerScore()
    {
        return playerProgress.highestScore;
    }

    private void LoadPlayerProgress()
    {
        playerProgress = new PlayerProgress();

        if (PlayerPrefs.HasKey("highestScore"))
        {
            playerProgress.highestScore = PlayerPrefs.GetInt("highestScore");
        }
    }

    private void SavePlayerProgress()
    {
        PlayerPrefs.SetInt("highestScore", playerProgress.highestScore);
    }
}
