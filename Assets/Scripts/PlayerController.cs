using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float forwardSpeed;
    private int desiredLane = 1; // 0 zuun tal, 1 goloor, 2 baruun
    public float laneDistance = 3f; // lane hoorondiin zai
    public float laneChangeSpeed = 10f; // How fast the player moves between lanes
    public float jumpForce;
    public float gravity = -20;
    Vector3 moveVector = Vector3.zero;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Handle lane switching input
        if (controller.isGrounded)
        {
            moveVector.y = -1;
            if (Keyboard.current.upArrowKey.wasPressedThisFrame)
            {
                Jump();
            }
        }else
        {
            moveVector.y += gravity * Time.deltaTime;
        }
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            desiredLane++;
            if (desiredLane > 2) desiredLane = 2;
        }
        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            desiredLane--;
            if (desiredLane < 0) desiredLane = 0;
        }

        // Calculate target X position based on desired lane
        float targetX = (desiredLane - 1) * laneDistance; // -2.5, 0, 2.5

        // Smoothly move towards target lane
        
        moveVector.x = (targetX - transform.position.x) * laneChangeSpeed;
        moveVector.z = forwardSpeed;

        controller.Move(moveVector * Time.deltaTime);
    }

    private void Jump()
    {
        moveVector.y = jumpForce;
    }
}