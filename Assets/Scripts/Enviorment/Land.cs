using System;
using UnityEngine;

public class Land : MonoBehaviour, IInteractable
{
    public GameObject topPart;
    public bool isSelected = false;
    public LandState state;
    private void Start()
    {
        state = LandState.Normal;
        topPart.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isSelected)
            topPart.SetActive(true);
        else
            topPart.SetActive(false);
    }

    public void Interaction()
    {
    }

    public void Interact()
    {
        Debug.Log($"Previous state: {state}");
        if (state == LandState.Normal)
        {
            Debug.Log("Seeds planted");
            state = LandState.Planted;
        }
        else if (state == LandState.Planted)
        {
            Debug.Log("Seeds watered");
            state = LandState.Watered;
        }
        else if (state == LandState.Watered)
        {
            Debug.Log("Now we wait");
        }
        Debug.Log($"Ner state: {state}");
        
        
    }
}

public enum LandState
{
    Normal,
    Planted,
    Watered
}