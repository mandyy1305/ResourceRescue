using UnityEngine;

public class PuzzleManagerClearance : MonoBehaviour
{
    public static PuzzleManagerClearance Instance;
    public GameObject puzzleManagerPrefab; // Reference to the PuzzleManager prefab

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnPuzzleManagerDestroy()
    {
        // Instantiate the new PuzzleManager
        puzzleManagerPrefab.GetComponent<InstantiatePuzzle>().InstantiatePuzzleType(-50f);
    }
}
