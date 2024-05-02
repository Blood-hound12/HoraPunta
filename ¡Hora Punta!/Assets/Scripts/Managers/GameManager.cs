using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float SuccessScore = 0;

    public float FailScore = 0;

    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI HighScoreText;

    public GameObject[] lives;
    [SerializeField] private GameObject LoseAnim;
    [SerializeField] private GameObject PanelLose;

    public GameObject BaseObstacle;
    public Transform[] ObstacleOrigins;

    public static GameManager current;
    [SerializeField] private GameObject deactivables;

    private void Awake()
    {
        Time.timeScale = 1;

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

        if (lives[0].activeSelf == true)
        {
            lives[0].SetActive(false);
            Instantiate(BaseObstacle, ObstacleOrigins[0].position, Quaternion.identity);
        }
        else if (lives[1].activeSelf == true)
        {
            lives[1].SetActive(false);
            Instantiate(BaseObstacle, ObstacleOrigins[1].position, Quaternion.identity);
            Instantiate(BaseObstacle, ObstacleOrigins[2].position, Quaternion.identity);
        }
        else if (lives[2].activeSelf == true)
        {
            lives[2].SetActive(false);
            LoseAnim.SetActive(true);
            deactivables.SetActive(false);
            StartCoroutine(RestartGame());
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(2);
        PanelLose.SetActive(true);
        Time.timeScale = 0;
    }
}
