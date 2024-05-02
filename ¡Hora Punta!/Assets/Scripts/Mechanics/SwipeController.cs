using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 startPos;
    private bool isSwiping = false;

    public float swipeForce = 10f;
    public float knockbackForce = 2.4f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<Collider2D>().OverlapPoint(touchPos))
            {
                startPos = touchPos;
                isSwiping = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isSwiping)
            {
                Vector2 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 swipeDirection = (endPos - startPos).normalized;
                rb.AddForce(swipeDirection * swipeForce, ForceMode2D.Impulse);
                isSwiping = false;
                StartCoroutine(MovementCooldown());
            }
        }
    }

    private IEnumerator MovementCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        rb.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("GreenPassenger") || collision.transform.CompareTag("RedPassenger"))
        {
            Vector2 difference = (transform.position - collision.transform.position).normalized;
            Vector2 force = difference * -knockbackForce;
            rb.AddForce(force, ForceMode2D.Impulse);
            StartCoroutine(MovementCooldown());
        }
        if(collision.transform.CompareTag("Obstacle"))
        {
            StartCoroutine(MovementCooldown());
        }
    }
}
