using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SummaryManager : MonoBehaviour
{
    public static SummaryManager Instance;

    [Header("Numbers")]
    [SerializeField] private int m_TotalBulbs;
    [SerializeField] private int m_ActiveBulbs;

    [Header("UI")]
    [SerializeField] private TMPro.TextMeshProUGUI m_TotalBulbsText;
    [SerializeField] private TMPro.TextMeshProUGUI m_ActiveBulbsText;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void RefreshSummary()
    {
        List<Bulb> bulbs = FindObjectsOfType<Bulb>().ToList();
        m_TotalBulbs = bulbs.Count;

        m_ActiveBulbs = 0;
        foreach (Bulb bulb in bulbs)
        {
            if (bulb.GetState() == true)
                m_ActiveBulbs++;
        }

        m_TotalBulbsText.text = m_TotalBulbs.ToString();
        m_ActiveBulbsText.text = m_ActiveBulbs.ToString();

    }
}
