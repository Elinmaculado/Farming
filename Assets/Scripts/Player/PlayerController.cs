using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private UserInput playerInput;
    private InputAction move;
    private Vector2 moveInput;
    private CharacterController controller;
    public float speed;
    public float sprintSpeed;
    
    private void Awake()
    {
        playerInput = new UserInput();
        
    }

    private void Start()
    {
        playerInput.Control.Enable();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
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
}
