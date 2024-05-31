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

    [SerializeField] float passengerVelocity = 7f;

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
        TimerForStop = Random.Range(0.6f, 0.8f);

        if (isMoving)
        {
            Vector2 direction = (Target.transform.position - transform.position).normalized;
            rb.velocity = direction * passengerVelocity;
            StartCoroutine(ActivateCollider());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "GameZone")
        {
            isMoving = false;
            rb.velocity = Vector2.zero;
        }
    }

    IEnumerator ActivateCollider()
    {
        yield return new WaitForSeconds(TimerForStop);
        collider.enabled = true;
    }
}
