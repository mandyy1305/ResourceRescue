using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_TutorialUI;

    public static TutorialUI Instance;

    private float m_Timer = 0;
    private float m_Time = 0;

    private bool m_IsTextSet;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (m_IsTextSet)
        {
            m_Timer += Time.deltaTime;

            if (m_Timer >= m_Time)
            {
                m_TutorialUI.text = "";
                m_Timer = 0;
                m_IsTextSet = false;
            }
        }
    }

    private void Start()
    {
        m_TutorialUI.text = "";
    }

    public void SetTutorialText(string text, float time)
    {
        m_TutorialUI.text = text;
        m_Time = time;

        m_IsTextSet = true;
    }
}
