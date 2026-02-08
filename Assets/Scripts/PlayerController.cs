using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float forwardSpeed;
    public float maxSpeed;
    private bool isSliding = false;
    private int desiredLane = 1; // 0 zuun tal, 1 goloor, 2 baruun
    public float laneDistance = 3f; // lane hoorondiin zai
    public float laneChangeSpeed = 10f; // How fast the player moves between lanes
    public float jumpForce;
    public float gravity = -20;
    Vector3 moveVector = Vector3.zero;
    public Animator animator;
    public GameObject nextLevelPanel;

    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(!PlayerManager.isGameStarted)
            return;
        animator.SetBool("isGameStarted", true);
        // Handle lane switching input
        animator.SetBool("isGrounded", controller.isGrounded);
        if (controller.isGrounded)
        {
            moveVector.y = -1;
            if (SwipeManager.swipeUp)
            {
                Jump();
                animator.SetBool("isSliding", false);
                isSliding = false;
            }

            if (SwipeManager.swipeDown && !isSliding)
            {
                StartCoroutine(Slide());
            }
        }else
        {
            moveVector.y += gravity * Time.deltaTime;
            if (SwipeManager.swipeDown && !isSliding)
            {
                moveVector.y = gravity * 2f; // strong downward force
                StartCoroutine(Slide());
            }
        }
        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane > 2) desiredLane = 2;
        }
        else if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane < 0) desiredLane = 0;
        }

        // Calculate target X position based on desired lane
        float targetX = (desiredLane - 1) * laneDistance; // -2.5, 0, 2.5

        if(forwardSpeed < maxSpeed)
            forwardSpeed += 0.1f * Time.deltaTime;
        // Smoothly move towards target lane
        
        moveVector.x = (targetX - transform.position.x) * laneChangeSpeed;
        moveVector.z = forwardSpeed;

        controller.Move(moveVector * Time.deltaTime);
    }

    private void Jump()
    {
        moveVector.y = jumpForce;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            PlayerManager.gameOver = true;
            AudioManager.Instance.StopAllSounds();
            AudioManager.Instance.PlaySound("GameOver");
        }
        
        if(hit.transform.tag == "Finish")
        {
            Time.timeScale = 0;
            AudioManager.Instance.StopAllSounds();
            nextLevelPanel.SetActive(true);
        }
    }

    private IEnumerator Slide()
    {
        isSliding = true;
        animator.SetBool("isSliding", true);

        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1;

        yield return new WaitForSeconds(1.0f);

        controller.center = Vector3.zero;
        controller.height = 2;

        animator.SetBool("isSliding", false);
        isSliding = false;
    }
}