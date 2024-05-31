using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VagonBehavior : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RetireVagon());
    }

    IEnumerator RetireVagon()
    {
        float lifeTime = Random.Range(25, 35);
        yield return new WaitForSeconds(lifeTime);
        animator.SetBool("escaping", true);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
