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
        this.gameObject.SetActive(false);
    }
}
