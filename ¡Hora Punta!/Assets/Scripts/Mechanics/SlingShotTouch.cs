using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShotTouch : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 startPos;
    private bool isSwiping = false;
    public bool canEntry = false;
    bool NOTREPEAT = false;

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
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>().OverlapPoint(touchPos))
                    {
                        startPos = touchPos;
                        isSwiping = true;
                        arrow.SetActive(true);
                        animator.SetBool("isThrowing?", true);
                    }
                    break;

                case TouchPhase.Moved:
                    if (isSwiping)
                    {
                        UpdateArrow(touchPos);
                    }
                    break;

                case TouchPhase.Ended:
                    if (isSwiping)
                    {
                        Vector2 endPos = touchPos;
                        Vector2 swipeDirection = (endPos - startPos).normalized;
                        rb.AddForce(swipeDirection * -swipeForce, ForceMode2D.Impulse);
                        isSwiping = false;
                        arrow.SetActive(false);
                        animator.SetBool("isThrowing?", false);
                        canEntry = true;
                        if (!NOTREPEAT)
                        {
                            StartCoroutine(deactivateBool());
                        }
                    }
                    break;
            }
        }
    }

    public IEnumerator deactivateBool()
    {
        NOTREPEAT = true;
        yield return new WaitForSeconds(2.2f);
        NOTREPEAT = false;
        canEntry = false;
    }

    private void UpdateArrow(Vector2 currentPos)
    {
        Vector2 direction = startPos - currentPos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrow.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SlingShotTouch slingShotTouch = collision.gameObject.GetComponent<SlingShotTouch>();
        if (canEntry && !NOTREPEAT)
        {
            animator.SetTrigger("Collision");
            slingShotTouch.canEntry = true;
            slingShotTouch.StartCoroutine(slingShotTouch.deactivateBool());
        }
        else if (canEntry && NOTREPEAT)
        {
            animator.SetTrigger("Collision");
            slingShotTouch.canEntry = true;
        }
    }
}
