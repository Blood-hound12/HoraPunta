using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PassengerBehavior : MonoBehaviour
{
    [SerializeField] private GameObject Target;
    private float TimerForStop;

    bool isMoving = true;

    private Rigidbody2D rb;
    private Collider2D collider;

    private DifficultyManager difficultyManager;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        difficultyManager = FindObjectOfType<DifficultyManager>();
        difficultyManager.AddCatToCounter();

    }

    private void Start()
    {
        Movement();
    }

    public void Movement()
    {
        TimerForStop = Random.Range(1f, 1.1f);

        if (isMoving)
        {
            Vector2 direction = (Target.transform.position - transform.position).normalized;
            rb.velocity = direction * 6f;
            StartCoroutine(Stop());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "GameZone")
        {
            collider.enabled = true;
        }
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(TimerForStop);
        collider.enabled = true;
        isMoving = false;
        rb.velocity = Vector2.zero;
    }
}
