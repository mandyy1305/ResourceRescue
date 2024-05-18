using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float m_MouseSensitivity = 100f;
    [SerializeField] private Transform m_PlayerBody;
    [SerializeField] float m_SmoothTime = 0.1f; // Adjust this value for smoothness

    private float m_XRotation = 0f;
    private Vector2 m_MouseInput;
    private Vector2 m_CurrentMouseInput;
    private Vector2 m_MouseInputVelocity;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        TakeMouseInput();
    }

    private void TakeMouseInput()
    {
        m_MouseInput.x = Input.GetAxis("Mouse X") * m_MouseSensitivity * Time.deltaTime;
        m_MouseInput.y = Input.GetAxis("Mouse Y") * m_MouseSensitivity * Time.deltaTime;

        // Smooth the mouse input
        m_CurrentMouseInput.x = Mathf.SmoothDamp(m_CurrentMouseInput.x, m_MouseInput.x, ref m_MouseInputVelocity.x, m_SmoothTime);
        m_CurrentMouseInput.y = Mathf.SmoothDamp(m_CurrentMouseInput.y, m_MouseInput.y, ref m_MouseInputVelocity.y, m_SmoothTime);

        m_XRotation -= m_CurrentMouseInput.y;
        m_XRotation = Mathf.Clamp(m_XRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(m_XRotation, 0f, 0f);
        m_PlayerBody.Rotate(Vector3.up * m_CurrentMouseInput.x);
    }
}
