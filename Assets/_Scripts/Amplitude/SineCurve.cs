using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class SineCurve : MonoBehaviour
{
    public int pointsCount = 100; // Number of points in the curve
    public float amplitude = 1.0f; // Amplitude of the sine wave
    public float frequency = 1.0f; // Frequency of the sine wave
    public float length = 10.0f; // Length of the sine curve
    public float speed = 1.0f; // Speed of the wave animation

    private LineRenderer lineRenderer;
    private float offset = 0.0f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = pointsCount;
    }

    void Update()
    {
        offset += speed * Time.deltaTime;
        RenderSineWave();
    }

    void RenderSineWave()
    {
        Vector3[] points = new Vector3[pointsCount];
        Vector3 parentPosition = transform.position;

        for (int i = 0; i < pointsCount; i++)
        {
            float x = (i / (float)(pointsCount - 1)) * length;
            float y = Mathf.Sin(x * frequency + offset) * amplitude;
            points[i] = new Vector3(x, y, 0) + parentPosition;
        }

        lineRenderer.SetPositions(points);
    }
}
