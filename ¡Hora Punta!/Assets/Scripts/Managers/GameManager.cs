using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float SuccessScore = 0;

    public float FailScore = 0;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;

    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    public static GameManager current;

    private void Awake()
    {
        updateHighScore();
        
        if(current == null)
        {
            current = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        ScoreText.text = "Score: " + SuccessScore;
        if(FailScore >=3)
        {
            SceneManager.LoadScene("Test");
        }
    }

    public void AddScore()
    {
        SuccessScore += 1;
        HighScore();
    }

    void HighScore()
    {
        if(SuccessScore > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", SuccessScore);
            updateHighScore();
        }
    }

    void updateHighScore()
    {
        HighScoreText.text = "High Score: " + PlayerPrefs.GetFloat("HighScore", 0);
    }

    public void AddFailScore()
    {
        FailScore += 1;

        if (life3.gameObject.activeSelf == true)
        {
            life3.gameObject.SetActive(false);
        }
        else if (life2.gameObject.activeSelf == true)
        {
            life2.gameObject.SetActive(false);
        }
        else if (life1.gameObject.activeSelf == true)
        {
            life1.gameObject.SetActive(false);
        }
    }
}
