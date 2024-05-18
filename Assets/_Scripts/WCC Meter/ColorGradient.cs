using System;
using UnityEngine;

public class ColorGradient : MonoBehaviour
{
    public int width = 100; // Width of the sprite
    public int height = 100; // Height of the sprite
    public Color darkestColor = Color.red; // Darkest color point
    public Color intensityColor = new Color(1, 0, 0, 0); // Color to fade to (e.g., fully transparent red)

    private Texture2D texture;

    void Start()
    {
        texture = new Texture2D(width, height);
        GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f));
        CreateGradient();
    }

    void CreateGradient()
    {
        int darkestPoint = UnityEngine.Random.Range(0, width);
        for (int x = 0; x < width; x++)
        {
            float distance = Mathf.Abs(darkestPoint - x);
            float t = distance / (width / 2);
            Color color = Color.Lerp(darkestColor, intensityColor, t);
            for (int y = 0; y < height; y++)
            {
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
    }
}
