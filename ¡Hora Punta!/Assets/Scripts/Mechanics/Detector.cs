using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    private GameManager gameManager;
    private DifficultyManager difficultyManager;
    public string detectorType; // "Green" or "Red"

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        difficultyManager = GameObject.Find("GameManager").GetComponent<DifficultyManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GreenPassenger")
        {
            HandleGreenPassenger();
            Destroy(collision.gameObject);
            difficultyManager.RemoveCatFromCounter();
        }
        else if (collision.gameObject.tag == "RedPassenger")
        {
            HandleRedPassenger();
            Destroy(collision.gameObject);
            difficultyManager.RemoveCatFromCounter();
        }
    }

    private void HandleGreenPassenger()
    {
        if (detectorType == "Green")
        {
            gameManager.AddScore();
        }
        else if (detectorType == "Red")
        {
            StartCoroutine(WaitAndAddFailScore());
        }
    }

    private void HandleRedPassenger()
    {
        if (detectorType == "Red")
        {
            gameManager.AddScore();
        }
        else if (detectorType == "Green")
        {
            StartCoroutine(WaitAndAddFailScore());
        }
    }

    IEnumerator WaitAndAddFailScore()
    {
        yield return new WaitForSeconds(0.35f);
        gameManager.AddFailScore();
    }
}
