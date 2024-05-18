using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{
    [SerializeField] private bool m_IsOn;
    [SerializeField] private EletricalAppliance m_Appliance;

    private void Start()
    {
        m_IsOn = m_Appliance.GetState();
    }

    public void Interact()
    {
        m_IsOn = !m_IsOn;
        m_Appliance.SetState(m_IsOn);
    }
    
}
