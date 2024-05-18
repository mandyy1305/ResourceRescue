using UnityEngine;
using System.Collections.Generic;

public class ShapeTracer : MonoBehaviour
{
    private Dot initialDot;
    private Dot currentDot;
    private HashSet<(Dot, Dot)> visitedConnections = new HashSet<(Dot, Dot)>();
    private LineRenderer tracingLineRenderer;
    public bool IsTracing { get; private set; } = false;
    private int totalConnections;
    private Vector3 initialMousePos;
    private bool hasStartedTracing = false;
    public float dragThreshold = 0.1f; // Minimum distance to start tracing

    void Start()
    {
        tracingLineRenderer = gameObject.AddComponent<LineRenderer>();
        tracingLineRenderer.positionCount = 0;
        tracingLineRenderer.startWidth = 0.1f;
        tracingLineRenderer.endWidth = 0.1f;
        tracingLineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        tracingLineRenderer.startColor = Color.red;
        tracingLineRenderer.endColor = Color.red;

        CalculateTotalConnections();
    }

    void Update()
    {
        if (IsTracing)
        {
            TrackMouse();
        }

        if (Input.GetMouseButtonUp(0) && IsTracing)
        {
            EndTracing();
        }
    }

    public void StartTracing(Dot startDot)
    {
        initialDot = startDot;
        currentDot = null;
        IsTracing = true;
        hasStartedTracing = false;
        visitedConnections.Clear();

        initialMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        initialMousePos.z = 0;

        tracingLineRenderer.positionCount = 1;
        tracingLineRenderer.SetPosition(0, initialDot.transform.position);
    }

    private void TrackMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        if (!hasStartedTracing)
        {
            if (Vector3.Distance(mousePos, initialMousePos) < dragThreshold)
            {
                return; // Do not start tracing if the mouse hasn't moved far enough
            }
            else
            {
                hasStartedTracing = true;
            }
        }

        foreach (var dot in initialDot.connectedDots)
        {
            if (dot == null)
            {
                continue; // Skip null entries in connectedDots
            }

            if (Vector3.Distance(mousePos, dot.transform.position) < 0.2f) // Adjust threshold as needed
            {
                var connection = (initialDot, dot);
                var reverseConnection = (dot, initialDot);
                if (!visitedConnections.Contains(connection) && !visitedConnections.Contains(reverseConnection))
                {
                    visitedConnections.Add(connection);
                    visitedConnections.Add(reverseConnection);
                    currentDot = dot;

                    tracingLineRenderer.positionCount++;
                    tracingLineRenderer.SetPosition(tracingLineRenderer.positionCount - 1, currentDot.transform.position);

                    RemoveInitialLine(connection);
                    initialDot = currentDot; // Update initialDot to currentDot for the next segment of the line
                }
                break;
            }
        }
    }

    private void EndTracing()
    {
        IsTracing = false;
        ValidateTracing();
    }

    private void ValidateTracing()
    {
        if (visitedConnections.Count == totalConnections)
        {
            Debug.Log("Success! All connections were traced.");
            // Add success handling here (e.g., show a message, load next level, etc.)
        }
        else
        {
            Debug.Log("Failed to trace all connections.");
            // Add failure handling here (e.g., reset game, show a message, etc.)
        }
    }

    private void RemoveInitialLine((Dot, Dot) connection)
    {
        var (dot1, dot2) = connection;
        if (dot1.connectionLines.ContainsKey(dot2))
        {
            dot1.connectionLines[dot2].enabled = false;
        }
        if (dot2.connectionLines.ContainsKey(dot1))
        {
            dot2.connectionLines[dot1].enabled = false;
        }
    }

    private void CalculateTotalConnections()
    {
        totalConnections = 0;
        Dot[] allDots = FindObjectsOfType<Dot>();

        foreach (Dot dot in allDots)
        {
            totalConnections += dot.connectedDots.Length;
        }
    }
}
