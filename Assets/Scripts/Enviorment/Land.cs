using System;
using UnityEngine;

public class Land : MonoBehaviour, IInteractable
{
    public GameObject topPart;
    public bool isSelected = false;
    public LandState state;
    public Transform plantSpawnLocation;
    public GameObject plantPrefab;
    private Color startingColor;
    private MeshRenderer meshRenderer;
    
    
    public UI ui;
    private void Start()
    {
        ui = FindFirstObjectByType<UI>();
        state = LandState.Normal;
        topPart.SetActive(false);
        meshRenderer = GetComponent<MeshRenderer>();
        startingColor = meshRenderer.material.color;
    }

    void Update()
    {
        if(isSelected && state != LandState.Watered)
            topPart.SetActive(true);
        else
            topPart.SetActive(false);
    }

    public void Interact()
    {
        Debug.Log($"Previous state: {state}");
        if (state == LandState.Normal)
        {
            Debug.Log("Seeds planted");
            state = LandState.Planted;
            meshRenderer.material.color = Color.green;
        }
        else if (state == LandState.Planted)
        {
            Debug.Log("Seeds watered");
            state = LandState.Watered;
            ui.BeginQTE();
            meshRenderer.material.color = Color.blue;
            spawnPlant();
        }
        else if (state == LandState.Watered)
        {
            Debug.Log("Now we wait");
        }
        Debug.Log($"Ner state: {state}");
        
        
    }

    public void spawnPlant()
    {
        Instantiate(plantPrefab, plantSpawnLocation.position, plantSpawnLocation.rotation, this.transform);
    }

    public void ResetLand()
    {
        state = LandState.Normal;
        meshRenderer.material.color = startingColor;
    }
}


public enum LandState
{
    Normal,
    Planted,
    Watered
}