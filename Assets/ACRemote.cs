using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACRemote : MonoBehaviour
{
    private bool m_CanInteract;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && m_CanInteract)
        {
            //m_Puzzle.SetActive(true);
        }
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
