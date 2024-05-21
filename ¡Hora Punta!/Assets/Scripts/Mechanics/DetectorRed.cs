using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorRed : MonoBehaviour
{
    private GameManager gameManager;
    private DifficultyManager difficultyManager;
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        difficultyManager = GameObject.Find("DifficultyManager").GetComponent<DifficultyManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GreenPassenger")
        {
            Destroy(collision.gameObject);
            StartCoroutine(Wait());
            difficultyManager.RemoveCatFromCounter();
        }
        if (collision.gameObject.tag == "RedPassenger")
        {
            gameManager.AddScore();
            Destroy(collision.gameObject);
            difficultyManager.RemoveCatFromCounter();
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.35f);
        gameManager.AddFailScore();
    }
}
