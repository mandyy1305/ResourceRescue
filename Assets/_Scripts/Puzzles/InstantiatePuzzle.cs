using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InstantiatePuzzle : MonoBehaviour
{
    public GameObject puzzle;
    public Camera puzzleCam;

    private void Start()
    {
        puzzleCam = GameObject.FindGameObjectWithTag("PuzzleCamera").GetComponent<Camera>();
    }
    public void InstantiatePuzzleType()
    {
        Instantiate(puzzle, new Vector3(-50f, 0f, 4f), Quaternion.identity, null);   
        ChangeCameraSettings();
        
    }

    void ChangeCameraSettings()
    {
        Camera.main.gameObject.GetComponent<Camera>().enabled = false;
        puzzleCam.gameObject.GetComponent<Camera>().enabled = true;
        return;
    }
}
