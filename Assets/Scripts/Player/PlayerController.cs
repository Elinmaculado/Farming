using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Input system")]
    private UserInput playerInput;
    private InputAction move;
    private Vector2 moveInput;
    private CharacterController controller;
    
    [Header("Movement")]
    public float speed;
    public float sprintSpeed;
    
    [Header("Interaction")]
    GroundInteractor groundInteractor;
    
    private void Awake()
    {
        playerInput = new UserInput();
        
    }

    private void Start()
    {
        playerInput.Control.Enable();
        controller = GetComponent<CharacterController>();
        groundInteractor = GetComponentInChildren<GroundInteractor>();
    }

    private void Update()
    {
        Move();
        
        Interact();
    }

    void Move()
    {
        moveInput = playerInput.Control.Movement.ReadValue<Vector2>();
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y);
        
        if(movement.magnitude > 0)
            transform.rotation = Quaternion.LookRotation(movement);
        

        if (playerInput.Control.Sprint.IsPressed())
        {
            controller.Move(movement * Time.deltaTime * sprintSpeed);
        }
        else
        {
            controller.Move(movement * Time.deltaTime * speed);
        }
    }

    public void Interact()
    {
        if (playerInput.Control.Interact.WasPressedThisFrame())
        {
            groundInteractor.GroundInteraction();
        }
    }
}
