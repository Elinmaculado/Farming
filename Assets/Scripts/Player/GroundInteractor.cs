using UnityEngine;

public class GroundInteractor : MonoBehaviour
{
    Land selectedLand = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down, Color.red);
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1))
        {
            OnInteractableHit(hit);
        }
    }

    void OnInteractableHit(RaycastHit hit)
    {
        Collider other = hit.collider;
        if (other.tag == "Land")
        {
            Land land = other.gameObject.GetComponent<Land>();
            SelectLand(land);
            return;
        }

        if (selectedLand != null)
        {
            selectedLand.isSelected = false;
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
        selectedLand.Interaction();
    }
}
