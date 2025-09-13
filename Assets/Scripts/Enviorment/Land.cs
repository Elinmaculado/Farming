using System;
using UnityEngine;

public class Land : MonoBehaviour
{
    public GameObject topPart;
    public bool isSelected = false;

    private void Start()
    {
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
}
