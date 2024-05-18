using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Dot : MonoBehaviour
{
    public Dot[] connectedDots; // Array of dots that can be connected to this dot
    public Dictionary<Dot, LineRenderer> connectionLines = new Dictionary<Dot, LineRenderer>();

    void Start()
    {
        foreach (Dot dot in connectedDots)
        {
            LineRenderer lineRenderer = CreateLineRenderer();
            connectionLines[dot] = lineRenderer;
            DrawLine(lineRenderer, dot);
        }
    }

    private LineRenderer CreateLineRenderer()
    {
        GameObject lineObj = new GameObject("ConnectionLine");
        LineRenderer lr = lineObj.AddComponent<LineRenderer>();
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = Color.white;
        lr.endColor = Color.white;
        lr.useWorldSpace = true;
        return lr;
    }

    private void DrawLine(LineRenderer lr, Dot targetDot)
    {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, targetDot.transform.position);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(Input.GetMouseButton(0))
        {
            if (FindObjectOfType<ShapeTracer>().IsTracing == false)
            {
                FindObjectOfType<ShapeTracer>().StartTracing(this);
            }
        }
    }
}
