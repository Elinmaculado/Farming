using UnityEngine;

public class GroundInteractor : MonoBehaviour
{
    Land selectedLand = null;

    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1))
        {
            OnInteractableHit(hit);
        }
        else
        {
            if (selectedLand != null)
            {
                selectedLand.isSelected = false;
                selectedLand = null;
            }
        }
    }

    void OnInteractableHit(RaycastHit hit)
    {
        Collider other = hit.collider;
        Debug.Log(other.tag);

        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            Land land = interactable as Land;
            if (land != null)
            {
                SelectLand(land);
                return;
            }

            if (selectedLand != null)
            {
                selectedLand.isSelected = false;
                selectedLand = null;
            }
        }
        else
        {
            if (selectedLand != null)
            {
                selectedLand.isSelected = false;
                selectedLand = null;
            }
        }
    }

    void SelectLand(Land land)
    {
        if (selectedLand != null)
        {
            selectedLand.isSelected = false;
        }
        selectedLand = land;
        land.isSelected = true;
    }

    public void GroundInteraction()
    {
        if (selectedLand != null)
        {
            selectedLand.Interact();
            return;
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
}