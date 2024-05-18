using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderEventListener : MonoBehaviour
{
    public static event Action<float, float, float> OnNewValueSet;
    private void Start()
    {
        float amplitudeValue = UnityEngine.Random.Range(0.4f, 1.8f);
        float frequencyValue = UnityEngine.Random.Range(0.4f, 5f);
        float speedValue = UnityEngine.Random.Range(5f, 15f);

        GetComponent<SineCurve>().amplitude = amplitudeValue;
        GetComponent<SineCurve>().frequency = frequencyValue;
        GetComponent<SineCurve>().speed = speedValue;

        Debug.Log(amplitudeValue + "-->" + frequencyValue + "-->" + speedValue);

        OnNewValueSet?.Invoke(amplitudeValue, frequencyValue, speedValue);
    }

    private void OnEnable()
    {
        SliderHandle.OnSliderChange += SliderHandle_OnSliderChange;
    }

    private void SliderHandle_OnSliderChange(SliderHandle.Properties arg1, float arg2)
    {
        switch (arg1.ToString())
        {
            case "amplitude": GetComponent<SineCurve>().amplitude = arg2;
                break;

            case "frequency": GetComponent<SineCurve>().frequency = arg2;
                break;

            case "speed": GetComponent<SineCurve>().speed = arg2;
                break;

            default: break;
        }
        
    }

    private void OnDisable()
    {
        SliderHandle.OnSliderChange -= SliderHandle_OnSliderChange;
    }
}
