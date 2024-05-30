using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCatBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float knockbackForce = 2.2f;
    [SerializeField] private float movementSpeed = 1.5f;

    bool Ready = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        rb.AddForce(Vector2.up * movementSpeed, ForceMode2D.Impulse);
        StartCoroutine(StopMovement());
        StartCoroutine(RetireMusicCat());
    }

    private void Update()
    {
        if (Ready)
        {
            rb.isKinematic = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RedPassenger") || collision.gameObject.CompareTag("GreenPassenger"))
        {
            Rigidbody2D PassengerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 difference = (transform.position - collision.transform.position).normalized;
            Vector2 force = difference * -knockbackForce;
            PassengerRb.AddForce(force, ForceMode2D.Impulse);
        }
    }

    IEnumerator RetireMusicCat()
    {
        float spawnTime = Random.Range(15, 20);
        float velocity = Random.Range(-5f, 5f);
        yield return new WaitForSeconds(spawnTime);
        rb.isKinematic = false;
        rb.velocity = new Vector2(velocity, rb.velocity.y);
    }

    IEnumerator StopMovement()
    {
        yield return new WaitForSeconds(1.6f);
        rb.velocity = Vector2.zero;
        Ready = true;
    }
}
