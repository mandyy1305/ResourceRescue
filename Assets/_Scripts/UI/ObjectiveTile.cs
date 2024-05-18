using UnityEngine;

public class ObjectiveTile : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI m_ObjectiveText;
    [SerializeField] private UnityEngine.UI.Image m_StatusImage;

    public void SetObjective(Objective objective)
    {
        m_ObjectiveText.text = objective.objectiveName;
        m_StatusImage.sprite = objective.emptyCircleImage;
    }

    public void CompleteObjective(Objective objective)
    {
        m_StatusImage.sprite = objective.filledCircleImage;
    }
}
