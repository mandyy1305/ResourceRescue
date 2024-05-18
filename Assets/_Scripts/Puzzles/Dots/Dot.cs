using UnityEngine;
using System.Collections.Generic;

public class Dot : MonoBehaviour
{
    public List<Dot> connectedDots = new List<Dot>();
    public Dictionary<Dot, bool> visitedConnections = new Dictionary<Dot, bool>();

    void Start()
    {
        // Initialize the dictionary with all connected dots set to false (not visited)
        foreach (var dot in connectedDots)
        {
            visitedConnections[dot] = false;
        }
    }

    void OnMouseDown()
    {
        PuzzleManager.Instance.OnDotSelected(this);
    }

    // Mark a connection as visited
    public void VisitConnection(Dot dot)
    {
        if (visitedConnections.ContainsKey(dot))
        {
            visitedConnections[dot] = true;
            dot.visitedConnections[this] = true; // Ensure the reverse connection is also marked
        }
    }

    // Check if a connection has been visited
    public bool IsConnectionVisited(Dot dot)
    {
        return visitedConnections.ContainsKey(dot) && visitedConnections[dot];
    }
}
