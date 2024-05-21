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

    private DifficultyManager difficultyManager;

    private void Awake()
    {
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
        TimerForStop = Random.Range(3.5f, 5f);

        if (isMoving)
        {
            Vector2 direction = (Target.transform.position - transform.position).normalized;
            rb.velocity = direction * 4.5f;
        }
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(TimerForStop);
        isMoving = false;
        rb.velocity = Vector2.zero;
    }
}
