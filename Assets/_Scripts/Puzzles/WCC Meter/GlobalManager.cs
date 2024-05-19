using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GlobalManager : MonoBehaviour
{
    public static float score;

    public GameObject resourceCanvas;
    public Camera puzzleCam;
    public Camera main;
    private void Start()
    {
        score = 0f;
        resourceCanvas = FindAnyObjectByType<ResourceManager>().gameObject;
        puzzleCam = GameObject.FindGameObjectWithTag("PuzzleCamera").GetComponent<Camera>();
        main = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        if(score > 25f)
        {
            // success
            StartCoroutine(Success());
        }
    }

    private IEnumerator Success()
    {
        yield return new WaitForSeconds(0.6f); 
        main.enabled = true;
        puzzleCam.gameObject.GetComponent<Camera>().enabled = false;
        resourceCanvas.GetComponent<Canvas>().enabled = true;
        ObjectiveManager.Instance.CompleteObjective(ObjectiveType.PreventWaterLeak);
        ResourceManager.Instance.isWaterFixed = true;
        Faucet.isFixed = true;
        Destroy(transform.parent.gameObject);
    }
}
