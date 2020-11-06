using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text scoreText;
    public Text scoreText2;
    public int score;
    public Text highScore;
    //private int highscore;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Time.timeScale = 1;
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore.text = score.ToString();
        }
    }

    public void IncreaseScore()
    {
        score++;
        //text
        scoreText.text = score.ToString("00");
        scoreText2.text = score.ToString("00");
    }
}
