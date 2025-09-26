using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class QTEButton : MonoBehaviour, IPointerDownHandler
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        gameObject.SetActive(false);
    }
}
