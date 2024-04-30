using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorRed : MonoBehaviour
{
    public GameObject Particles;
    private GameManager gameManager;
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Particles.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GreenPassenger")
        {
            Destroy(collision.gameObject);
            Particles.SetActive(true);
            StartCoroutine(Wait());
        }
        if (collision.gameObject.tag == "RedPassenger")
        {
            gameManager.AddScore();
            Destroy(collision.gameObject);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.35f);
        gameManager.AddFailScore();
        Particles.SetActive(false);
    }
}
