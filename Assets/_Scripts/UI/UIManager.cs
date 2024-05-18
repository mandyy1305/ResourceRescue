using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject m_InteractUI;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        m_InteractUI.SetActive(false);
    }

    public void ShowInteractUI(bool value)
    {
        m_InteractUI.SetActive(value);
    }
    
}
