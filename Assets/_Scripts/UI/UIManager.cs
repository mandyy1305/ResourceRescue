using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject m_InteractUI;
    [SerializeField] private GameObject m_ObjectivesAndSummaryUI;

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
        m_ObjectivesAndSummaryUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ShowObjectivesAndSummaryUI(!m_ObjectivesAndSummaryUI.activeInHierarchy);

            if (m_ObjectivesAndSummaryUI.activeInHierarchy)
            {
                SummaryManager.Instance.RefreshSummary();
            }
        }
    }

    public void ShowInteractUI(bool value)
    {
        m_InteractUI.SetActive(value);
    }

    public void ShowObjectivesAndSummaryUI(bool value)
    {
        m_ObjectivesAndSummaryUI.SetActive(value);
    }
    
}
