using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorGreen : MonoBehaviour
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
            gameManager.AddScore();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "RedPassenger")
        {
            Destroy(collision.gameObject);
            Particles.SetActive(true);
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.35F);
        gameManager.AddFailScore();
        Particles.SetActive(false);
    }
}
