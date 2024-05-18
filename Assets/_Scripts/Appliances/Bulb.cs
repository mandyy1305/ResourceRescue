using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    protected override void Update()
    {
        base.Update();
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

            if (AreAllLightsOff())
            {
                ObjectiveManager.Instance.CompleteObjective(ObjectiveType.TurnOffLights);
            }
        }
    }

    public bool AreAllLightsOff()
    {
        List<Bulb> bulbs = FindObjectsOfType<Bulb>().ToList();

        foreach (Bulb b in bulbs)
        {
            if (b.m_IsOn)
                return false;
        }

        return true;
    }
}
