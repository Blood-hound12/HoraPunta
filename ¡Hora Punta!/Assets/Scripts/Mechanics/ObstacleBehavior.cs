using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float knockbackForce = 5f;
    [SerializeField] private float movementSpeed = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        rb.AddForce(Vector2.up * movementSpeed, ForceMode2D.Impulse);
        StartCoroutine(StopMovement());
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

    IEnumerator StopMovement()
    {
        yield return new WaitForSeconds(2.2f);
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
    }
}
