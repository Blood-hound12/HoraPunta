using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragnnDropController : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 offset;
    private bool isDragging = false;

    private Rigidbody2D rb;

    [SerializeField] private float knockbackForce = 2.4f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        initialPosition = transform.position;
        offset = initialPosition - GetMouseWorldPos();
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false; // Dejar de rastrear el arrastre del mouse
        Vector3 swipeDirection = initialPosition - transform.position;
        if (rb != null)
        {
            rb.velocity = swipeDirection * -2f;
            StartCoroutine(MovementCooldown());
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }

    private IEnumerator MovementCooldown()
    {
        yield return new WaitForSeconds(0.45f);
        rb.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("GreenPassenger") || collision.transform.CompareTag("RedPassenger"))
        {
            Vector2 difference = (transform.position - collision.transform.position).normalized;
            Vector2 force = difference * -knockbackForce;
            rb.AddForce(force, ForceMode2D.Impulse);
            StartCoroutine(MovementCooldown());
        }
    }
}
