using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulb : EletricalAppliance
{
    [SerializeField] private Light m_Light;
    [SerializeField] private Material m_Material;

    private void Start()
    {
        m_Light.enabled = m_IsOn;

        m_Material = GetComponent<Renderer>().material;
    }

    public override void SetState(bool state)
    {
        base.SetState(state);
        if (m_IsOn)
        {
            m_Light.enabled = true;
            m_Material.EnableKeyword("_EMISSION");
        }
        else
        {
            m_Light.enabled = false;
            m_Material.DisableKeyword("_EMISSION");
        }
    }
}
