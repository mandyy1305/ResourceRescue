using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SliderHandle : MonoBehaviour
{
    public Transform sliderTrack; // Reference to the slider track
    public float minValue = 0f; // Minimum slider value
    public float maxValue = 1f; // Maximum slider value
    public static bool isSelected = false;

    private bool isDragging = false;
    private float trackStartX;
    private float trackEndX;


    public enum Properties
    {
        amplitude, frequency, speed
    };
    public Properties property;

    public static event Action<Properties, float> OnSliderChange;
    public static event Action OnSliderUp;

    private void OnEnable()
    {
        SliderEventListener.OnNewValueSet += SliderEventListener_OnNewValueSet;
    }

    private void OnDisable()
    {
        SliderEventListener.OnNewValueSet -= SliderEventListener_OnNewValueSet;
    }

    private void SliderEventListener_OnNewValueSet(float amplitude, float frequency, float speed)
    {
        float trackWidth = sliderTrack.GetComponent<SpriteRenderer>().bounds.size.x;
        trackStartX = sliderTrack.position.x - trackWidth / 2;
        trackEndX = sliderTrack.position.x + trackWidth / 2;

        switch (property)
        {
            case Properties.amplitude:
                transform.position = new Vector3(CalculateHandlePosition(amplitude), sliderTrack.position.y, 0);
                break;

            case Properties.frequency:
                transform.position = new Vector3(CalculateHandlePosition(frequency), sliderTrack.position.y, 0);
                break;

            case Properties.speed:
                transform.position = new Vector3(CalculateHandlePosition(speed), sliderTrack.position.y, 0);
                break;
        }
    }

    void Start()
    {
        if (sliderTrack == null)
        {
            Debug.LogError("Slider Track is not assigned.");
            return;
        }

        // Calculate the start and end positions of the track in local coordinates
        float trackWidth = sliderTrack.GetComponent<SpriteRenderer>().bounds.size.x;
        trackStartX = sliderTrack.position.x - trackWidth / 2;
        trackEndX = sliderTrack.position.x + trackWidth / 2;

    }

    void Update()
    {
        if (isDragging)
        {
            DragSlider();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnMouseDown()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        if (GetComponent<Collider2D>().OverlapPoint(mousePos))
        {
            isDragging = true;
            isSelected = true;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        isSelected = false;
        OnSliderUp?.Invoke();
    }

    void DragSlider()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        float clampedX = Mathf.Clamp(mousePosition.x, trackStartX, trackEndX);
        transform.position = new Vector3(clampedX, sliderTrack.position.y, 0);

        // Calculate the slider value based on handle position
        float sliderValue = CalculateSliderValue(clampedX);
        //sliderValue = Mathf.Round(sliderValue);
        Debug.Log("Slider Value: " + sliderValue);

        OnSliderChange?.Invoke(property, sliderValue);
    }

    float CalculateSliderValue(float handleX)
    {
        float trackLength = trackEndX - trackStartX;
        float value = (handleX - trackStartX) / trackLength;
        return Mathf.Lerp(minValue, maxValue, value);
    }

    float CalculateHandlePosition(float sliderValue)
    {
        float normalizedValue = Mathf.InverseLerp(minValue, maxValue, sliderValue);
        return Mathf.Lerp(trackStartX, trackEndX, normalizedValue);
    }
}
