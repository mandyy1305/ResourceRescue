using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;
    public GameObject linePrefab;
    private Dot currentDot;
    private Dictionary<string, Line> lineDictionary = new Dictionary<string, Line>();

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // Draw all initial lines
        DrawInitialLines();
    }

    void DrawInitialLines()
    {
        foreach (var dot in FindObjectsOfType<Dot>())
        {
            foreach (var connectedDot in dot.connectedDots)
            {
                if (!IsLineDrawn(dot, connectedDot))
                {
                    CreateLine(dot.transform.position, connectedDot.transform.position, dot, connectedDot);
                }
            }
        }
    }

    bool IsLineDrawn(Dot dot1, Dot dot2)
    {
        return lineDictionary.ContainsKey(GetLineKey(dot1, dot2)) || lineDictionary.ContainsKey(GetLineKey(dot2, dot1));
    }

    string GetLineKey(Dot dot1, Dot dot2)
    {
        return dot1.name + "_" + dot2.name;
    }

    public void OnDotSelected(Dot dot)
    {
        if (currentDot == null)
        {
            currentDot = dot;
        }
        else if (currentDot.connectedDots.Contains(dot) && !currentDot.IsConnectionVisited(dot))
        {
            RemoveLine(currentDot, dot);
            currentDot.VisitConnection(dot);
            currentDot = dot;

            if (CheckWinCondition())
            {
                Debug.Log("You Win!");
            }
            else if (CheckLossCondition(currentDot))
            {
                Debug.Log("You Lost!");
            }
        }
        else
        {
            // Invalid move: connection is already visited or dots are not directly connected
            // You can add feedback here for the player
        }
    }

    void CreateLine(Vector3 start, Vector3 end, Dot dot1, Dot dot2)
    {
        GameObject lineObject = Instantiate(linePrefab);
        Line line = lineObject.GetComponent<Line>();
        line.SetPositions(start, end);
        lineDictionary[GetLineKey(dot1, dot2)] = line;
    }

    void RemoveLine(Dot dot1, Dot dot2)
    {
        string key = GetLineKey(dot1, dot2);
        if (lineDictionary.ContainsKey(key))
        {
            Destroy(lineDictionary[key].gameObject);
            lineDictionary.Remove(key);
        }
        else
        {
            key = GetLineKey(dot2, dot1);
            if (lineDictionary.ContainsKey(key))
            {
                Destroy(lineDictionary[key].gameObject);
                lineDictionary.Remove(key);
            }
        }
    }

    private bool CheckLossCondition(Dot dot)
    {
        // Check if the current dot has any unvisited connections
        foreach (var connectedDot in dot.connectedDots)
        {
            if (!dot.IsConnectionVisited(connectedDot))
            {
                return false;
            }
        }
        return true;
    }

    private bool CheckWinCondition()
    {
        // Check if all connections have been traced
        return lineDictionary.Count == 0;
    }
}
