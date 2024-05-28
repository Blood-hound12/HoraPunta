using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoplifterBehavior : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ActivateCollider());
    }

    IEnumerator ActivateCollider()
    {
        yield return new WaitForSeconds(8f);
        //this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            Vector2 direction = collision.transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction.normalized * 10f, ForceMode2D.Impulse);
    }
}
