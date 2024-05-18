using UnityEngine;
using UnityEngine.EventSystems;

public class OnHoverActivate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject m_ObjectToActivate;

    private void Start()
    {
        m_ObjectToActivate.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_ObjectToActivate.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_ObjectToActivate.SetActive(false);
    }
}
