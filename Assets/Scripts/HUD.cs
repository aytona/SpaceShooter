using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Text scoreText = null;
    public Text highScoreText = null;
    public Text restartText = null;
    public Text gameOverText = null;

    private bool gameOver;

    private static HUD instance = null;
    private GameObject player;

    // Make sure there is only one of this object in-game
    void Awake()
    {
        gameOver = false;
        restartText.text = "";
        gameOverText.text = "";
        player = GameObject.FindGameObjectWithTag("Player");

        if (instance == null)
        {
            GameObject.DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    void OnLevelWasLoaded()
    {
        gameOver = false;
        restartText.text = "";
        gameOverText.text = "";
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        this.scoreText.text = "Score: " + PlayerData.Instance.Score.ToString();
        this.highScoreText.text = "HighScore: " + PlayerData.Instance.HighScore.ToString();

        if (player == null)
        {
            GameOver();
        }

        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevelAsync(Application.loadedLevel);
            }
        }
    }

    void GameOver()
    {
        gameOverText.text = "GAME OVER!";
        restartText.text = "Press 'R' to Restart";
        gameOver = true;
    }
}
