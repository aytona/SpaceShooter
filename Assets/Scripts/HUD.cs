using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Text score = null;
    public Text highScore = null;

    private static HUD instance = null;

    // Make sure there is only one of this object in-game
    void Awake()
    {
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

    void Update()
    {
        this.score.text = "Score: " + PlayerData.Instance.Score.ToString();
        this.highScore.text = "HighScore: " + PlayerData.Instance.HighScore.ToString();
    }
}
