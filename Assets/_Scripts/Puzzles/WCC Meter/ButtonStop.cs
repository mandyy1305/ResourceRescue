using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStop : MonoBehaviour
{
    public static event Action OnClickButton;

    private void OnMouseDown()
    {
        Debug.Log("Yeha");
        OnClickButton?.Invoke();
    }
}
