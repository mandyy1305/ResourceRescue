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

    public int totalACs;
    public int activeACs;

    public int totalGeysers;
    public int activeGeysers;

    [Header("UI")]
    [SerializeField] private TMPro.TextMeshProUGUI m_TotalBulbsText;
    [SerializeField] private TMPro.TextMeshProUGUI m_ActiveBulbsText;

    [SerializeField] private TMPro.TextMeshProUGUI m_TotalACsText;
    [SerializeField] private TMPro.TextMeshProUGUI m_ActiveACsText;

    [SerializeField] private TMPro.TextMeshProUGUI m_TotalGeysersText;
    [SerializeField] private TMPro.TextMeshProUGUI m_ActiveGeysersText;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        totalACs = activeACs = 1;
        totalGeysers = activeGeysers = 1;

        RefreshSummary();
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

        m_TotalACsText.text = totalACs.ToString();
        m_ActiveACsText.text = activeACs.ToString();

        m_TotalGeysersText.text = totalGeysers.ToString();
        m_ActiveGeysersText.text = activeGeysers.ToString();

    }
}
