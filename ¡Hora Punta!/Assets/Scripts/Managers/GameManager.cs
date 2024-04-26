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

    // Update is called once per frame
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
