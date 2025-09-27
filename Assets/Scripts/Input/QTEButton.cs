using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class QTEButton : MonoBehaviour, IPointerDownHandler
{

    public void OnPointerDown(PointerEventData eventData)
    {
        UI.instance.steps--;
        if (UI.instance.steps <= 0)
        {
            if (UI.instance.activeLand != null)
            {
                UI.instance.activeLand.spawnPlant();
                UI.instance.activeLand = null;
            }

        }
        gameObject.SetActive(false);
    }
}
