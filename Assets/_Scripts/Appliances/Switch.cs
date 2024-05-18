using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{
    [SerializeField] private bool m_IsOn;
    [SerializeField] private EletricalAppliance m_Appliance;

    [SerializeField] private bool m_CanInteract;

    private void Start()
    {
        m_IsOn = m_Appliance.GetState();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && m_CanInteract)
        {
            Interact();
        }
    }

    public void Interact()
    {
        m_IsOn = !m_IsOn;
        m_Appliance.SetState(m_IsOn);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            UIManager.Instance.ShowInteractUI(true);
            m_CanInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            UIManager.Instance.ShowInteractUI(false);
            m_CanInteract = false;
        }
    }

}
