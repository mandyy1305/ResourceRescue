using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulb : EletricalAppliance
{
    [SerializeField] private Light m_Light;

    private void Start()
    {
        m_Light.enabled = m_IsOn;
    }

    public override void SetState(bool state)
    {
        base.SetState(state);
        if (m_IsOn)
        {
            m_Light.enabled = true;
        }
        else
        {
            m_Light.enabled = false;
        }
    }
}
