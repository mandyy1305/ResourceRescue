using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float m_Speed;
    [SerializeField] private float m_NormalSpeed = 5f;
    [SerializeField] private float m_SprintSpeed = 10f;

    [SerializeField] private CharacterController m_CharacterController;

    private Vector3 m_Input;

    // Start is called before the first frame update
    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        TakeInput();
        CheckForSprint();
        Move();
    }

    private void TakeInput()
    {
        m_Input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        
    }

    private void CheckForSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_Speed = m_SprintSpeed;
        }
        else
        {
            m_Speed = m_NormalSpeed;
        }
    }

    private void Move()
    {
        Vector3 move = transform.right * m_Input.x + transform.forward * m_Input.z;
        m_CharacterController.Move(m_Speed * Time.deltaTime * move);
    }
}
