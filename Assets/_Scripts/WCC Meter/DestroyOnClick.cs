using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour
{
    public GameObject meter;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(DelayInstantiate());
        }
    }

    IEnumerator DelayInstantiate()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(meter);
        Destroy(gameObject);
    }
}
