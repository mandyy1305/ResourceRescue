using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EletricalAppliance : MonoBehaviour
{
    [Tooltip("Cost per second to operate")]
    [SerializeField] protected float m_CostPerSecond;

    [SerializeField] protected bool m_IsOn;

    public virtual void SetState(bool state)
    {
        m_IsOn = state;
    }

    public bool GetState()
    {
        return m_IsOn;
    }

    public float GetCostPerSecond()
    {
        return m_CostPerSecond;
    }

    protected virtual void Update()
    {
        if (m_IsOn)
        {
            ResourceManager.Instance.DecreaseBudget(m_CostPerSecond * Time.deltaTime);
        }
    }
}


