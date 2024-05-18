using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private bool m_CanInteract;

    private Switch m_InteractionSwitch;

    

    private void Interact()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 2f))
        {
            if (hit.collider.TryGetComponent<IInteractable>(out var interactable))
            {
                interactable.Interact();
            }
        }
    }

    public void SetCanInteract(bool canInteract)
    {
        m_CanInteract = canInteract;
    }
}
