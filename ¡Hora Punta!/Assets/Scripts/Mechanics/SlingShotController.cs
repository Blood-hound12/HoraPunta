using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShotController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 startPos;
    private bool isSwiping = false;
    public bool canEntry = false;

    public GameObject arrow;

    public float swipeForce = 10f;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

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
                arrow.SetActive(true);
                animator.SetBool("isThrowing?", true);
            }
        }

        if (isSwiping)
        {
            Vector2 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            UpdateArrow(currentPos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isSwiping)
            {
                Vector2 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 swipeDirection = (endPos - startPos).normalized;
                rb.AddForce(swipeDirection * -swipeForce, ForceMode2D.Impulse);
                isSwiping = false;
                arrow.SetActive(false);
                animator.SetBool("isThrowing?", false);
                canEntry = true;
                StartCoroutine(deactivateBool());
            }
        }
    }

    IEnumerator deactivateBool()
    {
        yield return new WaitForSeconds(2f);
        canEntry = false;
    }

    private void UpdateArrow(Vector2 currentPos)
    {
        Vector2 direction = startPos - currentPos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrow.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}

