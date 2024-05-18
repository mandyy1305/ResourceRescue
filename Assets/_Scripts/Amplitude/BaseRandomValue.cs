using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRandomValue : MonoBehaviour
{
    public float amplitudeValue;
    public float frequencyValue;
    public float speedValue;
    void Start()
    {
        amplitudeValue = UnityEngine.Random.Range(0.4f, 1.8f);
        frequencyValue = UnityEngine.Random.Range(0.4f, 5f);
        speedValue = UnityEngine.Random.Range(5f, 15f);

        GetComponent<SineCurve>().amplitude = amplitudeValue;
        GetComponent<SineCurve>().frequency = frequencyValue;
        GetComponent<SineCurve>().speed = speedValue;
    }

}
