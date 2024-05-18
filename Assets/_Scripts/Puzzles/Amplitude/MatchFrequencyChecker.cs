using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchFrequencyChecker : MonoBehaviour
{
    public GameObject baseSine;
    public GameObject randomSine;
    
    public GameObject resourceCanvas;
    public GameObject interactableCanvas;
    public Camera puzzleCam;
    public Camera main;

    private float amBase, frBase, spBase, amRandom, frRandom, spRandom;

    public float totalTime = 1f;
    public float remainingTime;
    public bool isCountingDown = false;

    private void Start()
    {
        resourceCanvas = FindAnyObjectByType<ResourceManager>().gameObject;
        interactableCanvas = GameObject.FindGameObjectWithTag("Interact");
        puzzleCam = GameObject.FindGameObjectWithTag("PuzzleCamera").GetComponent<Camera>();
        main = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

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
            bool am = Mathf.Abs(amBase - amRandom) < 0.6f;
            bool fr = Mathf.Abs(frBase - frRandom) < 0.6f;
            bool sp = Mathf.Abs(spBase - spRandom) < 0.6f;

            if(!am || !fr || !sp)
            {
                isCountingDown = false;
            }
            

            if (remainingTime < 0)
            {
                remainingTime = 0;
                isCountingDown = false;

                //Success
                Success();
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
        main.enabled = true;
        puzzleCam.gameObject.GetComponent<Camera>().enabled = false;
        resourceCanvas.GetComponent<Canvas>().enabled = true;
        //interactableCanvas.GetComponent<Canvas>().enabled = true;
        ACRemote.isFixed = true;
        Destroy(gameObject);
        return;       
    }

}
