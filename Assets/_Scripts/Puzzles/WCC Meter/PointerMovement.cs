using UnityEngine;
using UnityEngine.SceneManagement;

public class PointerMovement : MonoBehaviour
{
    public float speed = 4.0f; // Speed of the pendulum movement
    public float distance = 5.4f; // Maximum distance from the starting position
    public GameObject targetObject; // The gradient object
    public float offset;
    public GameObject fill;

    private Vector3 startPosition;
    private float phase = 0.0f; // Phase of the oscillation
    private bool isMoving = true; // To track if the pendulum should move
    private Texture2D gradientTexture;



    private void OnEnable()
    {
        ButtonStop.OnClickButton += ButtonStop_OnClickButton;
    }
    private void OnDisable()
    {
        ButtonStop.OnClickButton -= ButtonStop_OnClickButton;
    }

    private void ButtonStop_OnClickButton()
    {
        Vector2 localPos = targetObject.transform.InverseTransformPoint(transform.position);
        int textureX = (int)((localPos.x + 0.5f) * gradientTexture.width);
        textureX = Mathf.Clamp(textureX, 0, gradientTexture.width - 1);

        // Get the color at the current x position
        Color color = gradientTexture.GetPixel(textureX, 0);
        float score = color.r; // The red component represents the intensity

        score = Mathf.Round(score * 40);

        GlobalManager.score += score;
        float yScale = Mathf.Clamp(GlobalManager.score / 27.0f, 0f, 1f);
        fill.transform.localScale = new Vector3(1, yScale, 1);
        Debug.Log("Score: " + GlobalManager.score);
        isMoving = false;
    }

    void Start()
    {
        startPosition = new Vector3(0f, 0f, -1f);
        gradientTexture = targetObject.GetComponent<SpriteRenderer>().sprite.texture;
        offset = transform.parent.parent.position.x;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (isMoving)
        {
            phase += speed * Time.deltaTime;
            float newX = startPosition.x + Mathf.Sin(phase) * distance + offset;
            transform.position = new Vector3(newX, startPosition.y, startPosition.z);
        }
    }
}
