using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour
{
    public GameObject meter;
    private void OnEnable()
    {
        ButtonStop.OnClickButton += ButtonStop_OnClickButton;
    }
    private void OnDisable()
    {
        ButtonStop.OnClickButton -= ButtonStop_OnClickButton;
    }

    private void ButtonStop_OnClickButton()
    {
        StartCoroutine(DelayInstantiate());
    }

    IEnumerator DelayInstantiate()
    {
        yield return new WaitForSeconds(0.6f);
        Instantiate(meter, transform.parent);
        Destroy(gameObject);
    }
}
