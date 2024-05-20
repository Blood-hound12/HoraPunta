using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 startPos;
    private bool isSwiping = false;

    public float swipeForce = 10f;

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
            }
        }
    }

    //private Rigidbody2D rb;
    //private Vector2 startPos;
    //private bool isSwiping = false;

    //public float swipeForce = 10f;

    //private void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //}

    //private void Update()
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        Touch touch = Input.GetTouch(0);

    //        if (touch.phase == TouchPhase.Began)
    //        {
    //            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
    //            if (GetComponent<Collider2D>().OverlapPoint(touchPos))
    //            {
    //                startPos = touchPos;
    //                isSwiping = true;
    //            }
    //        }
    //        else if (touch.phase == TouchPhase.Ended && isSwiping)
    //        {
    //            Vector2 endPos = Camera.main.ScreenToWorldPoint(touch.position);
    //            Vector2 swipeDirection = (endPos - startPos).normalized;
    //            rb.AddForce(swipeDirection * swipeForce, ForceMode2D.Impulse);
    //            isSwiping = false;
    //        }
    //    }
    //}
}
