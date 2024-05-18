using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ButtonClick : MonoBehaviour
{
    //disable button once clicked on, otherwise user can click on it multiple times
    public GameObject pivot;
    public GameObject callibrator;
    public float rotationSpeed = -300f;
    private bool stopRotating = false;
    public static int stopped = 0;


    public GameObject resourceCanvas;
    public Camera puzzleCam;
    public Camera main;

    private void Start()
    {
        pivot.transform.eulerAngles = Vector3.zero;
        stopped = 0;

        resourceCanvas = FindAnyObjectByType<ResourceManager>().gameObject;
        puzzleCam = GameObject.FindGameObjectWithTag("PuzzleCamera").GetComponent<Camera>();
        main = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    private void Update()
    {
        if (!stopRotating)
        {
            pivot.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        if(stopped == 3)
        {
            // puzzle solved
            Debug.Log("Puzzle Solved");
            StartCoroutine(Success());
        }
    }

    private void OnMouseDown()
    {
        if (pivot.transform.eulerAngles.z >= 170f && pivot.transform.eulerAngles.z <= 190f)
        {
            stopRotating = true;
            stopped++;
        }
        else
        {
            // destory and reinstantiate;
            Instantiate(callibrator, null);
            Destroy(gameObject.transform.parent.parent.gameObject);
        }
    }

    private IEnumerator Success()
    {
        yield return new WaitForSeconds(0.6f);
        main.enabled = true;
        puzzleCam.gameObject.GetComponent<Camera>().enabled = false;
        resourceCanvas.GetComponent<Canvas>().enabled = true;
        Cylinder.isFixed = true;
        Destroy(transform.parent.parent.gameObject);
    }
}

