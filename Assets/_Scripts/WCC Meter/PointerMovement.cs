using UnityEngine;
using UnityEngine.SceneManagement;

public class PointerMovement : MonoBehaviour
{
    public float speed = 4.0f; // Speed of the pendulum movement
    public float distance = 5.4f; // Maximum distance from the starting position
    public GameObject targetObject; // The gradient object

    private Vector3 startPosition;
    private float phase = 0.0f; // Phase of the oscillation
    private bool isMoving = true; // To track if the pendulum should move
    private Texture2D gradientTexture;

    void Start()
    {
        // Store the starting position of the sprite
        startPosition = new Vector3(0f, 0f, -1f);

        // Get the texture from the target object
        gradientTexture = targetObject.GetComponent<SpriteRenderer>().sprite.texture;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (isMoving)
        {
            // Update the phase based on speed and deltaTime
            phase += speed * Time.deltaTime;

            // Calculate the new position using a sine wave
            float newX = startPosition.x + Mathf.Sin(phase) * distance;

            // Update the sprite's position
            transform.position = new Vector3(newX, startPosition.y, startPosition.z);
        }

        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseClick();
        }
    }

    void HandleMouseClick()
    {
        Vector2 localPos = targetObject.transform.InverseTransformPoint(transform.position);
        int textureX = (int)((localPos.x + 0.5f) * gradientTexture.width);
        textureX = Mathf.Clamp(textureX, 0, gradientTexture.width - 1);

        // Get the color at the current x position
        Color color = gradientTexture.GetPixel(textureX, 0);
        float score = color.r; // The red component represents the intensity

        score =  Mathf.Round(score * 10);

        GlobalManager.score += score;
        Debug.Log("Score: " + GlobalManager.score);
        isMoving = false;
    }
}
