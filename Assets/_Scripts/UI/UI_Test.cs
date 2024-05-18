using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Test : MonoBehaviour
{
    private void OnEnable()
    {
        ResourceManager.OnBudgetExhausted += OnBudgetExhausted;
        ResourceManager.OnWaterExhausted += OnWaterExhausted;
        ResourceManager.OnGasExhausted += OnGasExhausted;
    }

    private void OnDisable()
    {
        ResourceManager.OnBudgetExhausted -= OnBudgetExhausted;
        ResourceManager.OnWaterExhausted -= OnWaterExhausted;
        ResourceManager.OnGasExhausted -= OnGasExhausted;
    }

    private void OnBudgetExhausted()
    {
        Debug.Log("Budget exhausted");
    }

    private void OnWaterExhausted()
    {
        Debug.Log("Water exhausted");
    }

    private void OnGasExhausted()
    {
        Debug.Log("Gas exhausted");
    }
}
