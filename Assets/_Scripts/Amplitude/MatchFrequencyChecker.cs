using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchFrequencyChecker : MonoBehaviour
{
    public GameObject baseSine;
    public GameObject randomSine;

    private float amBase, frBase, spBase, amRandom, frRandom, spRandom;

    public float totalTime = 1f;
    public float remainingTime;
    public bool isCountingDown = false;

    private void OnEnable()
    {
        SliderHandle.OnSliderUp += SliderHandle_OnSliderUp;
    }

    private void OnDisable()
    {
        SliderHandle.OnSliderUp -= SliderHandle_OnSliderUp;
    }

    private void SliderHandle_OnSliderUp()
    {
        remainingTime = totalTime;
        amBase = baseSine.GetComponent<SineCurve>().amplitude;
        frBase = baseSine.GetComponent<SineCurve>().frequency;
        spBase = baseSine.GetComponent<SineCurve>().speed;

        amRandom = randomSine.GetComponent<SineCurve>().amplitude;
        frRandom = randomSine.GetComponent<SineCurve>().frequency;
        spRandom = randomSine.GetComponent<SineCurve>().speed;

        isCountingDown = true;
    }

    void Update()
    {
        if (!SliderHandle.isSelected && isCountingDown)
        {
            remainingTime -= Time.deltaTime;

            //match the values
            bool am = Mathf.Abs(amBase - amRandom) < 0.2f;
            bool fr = Mathf.Abs(frBase - frRandom) < 0.2f;
            bool sp = Mathf.Abs(spBase - spRandom) < 0.2f;

            if(!am || !fr || !sp)
            {
                isCountingDown = false;
            }
            

            if (remainingTime < 0)
            {
                remainingTime = 0;
                isCountingDown = false;

                //Success
                Debug.Log("Sines Matched");
            }
        }

        else
        {
            isCountingDown = false;
        }

    }

    private void Success()
    {
        return;       
    }

}
