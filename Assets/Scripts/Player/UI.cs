using System;
using UnityEngine;

public class UI : MonoBehaviour
{
    [Header("quick time events")] 
    public int steps;
    public QTEButton[] buttons;

    private void Awake()
    {
        buttons = GetComponentsInChildren<QTEButton>();
        
    }
    

    public void BeginQTE()
    {
        foreach (QTEButton button in buttons)
        {
            button.gameObject.SetActive(true);
            
            float randomX = UnityEngine.Random.Range(400, 1600);
            float randomY = UnityEngine.Random.Range(300, 900);
            button.transform.position = new Vector3(randomX, randomY);
        }
    }
}
