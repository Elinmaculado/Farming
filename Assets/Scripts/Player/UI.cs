using System;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI instance;
    public Land activeLand;
    public PlayerController controller;

    [Header("quick time events")] 
    public int steps;
    public QTEButton[] buttons;

    private void Awake()
    {
        instance = this;

    }

    private void Start()
    {
        controller = FindFirstObjectByType<PlayerController>();
        buttons = GetComponentsInChildren<QTEButton>(true);
        foreach (QTEButton button in buttons)
        {
            button.gameObject.SetActive(false);
        }
    }

    public void BeginQTE(Land land)
    {
        controller.enabled = false;
        activeLand = land;
        foreach (QTEButton button in buttons)
        {
            button.gameObject.SetActive(true);

            float randomX = UnityEngine.Random.Range(600, 1600);
            float randomY = UnityEngine.Random.Range(300, 700);
            button.transform.position = new Vector3(randomX, randomY);
        }
        steps = buttons.Length;
    }
}