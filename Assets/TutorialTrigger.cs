using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    [SerializeField] private string m_TutorialText;

    [SerializeField] private float m_Time;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TutorialUI.Instance.SetTutorialText(m_TutorialText, m_Time);
        }
    }
}
