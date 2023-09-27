using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    [Tooltip("Controla la velocidad de movimiento del personaje.")]
    [SerializeField]private float playerSpeed = 5;
    [Tooltip("Controla la fuerza de salto del personaje.")]
    [SerializeField]private float jumpForce = 5;
    private float playerInputHorizontal;
    //private float playerInputVertical;

    private Rigidbody2D rBody2D; 
    private GroundSensor sensor;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rBody2D = GetComponent<Rigidbody2D>();
        sensor = GetComponentInChildren<GroundSensor>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       PlayerMovement();

       if(Input.GetButtonDown("Jump") && sensor.isGrounded)
       {
            Jump();
       }
    }

    void FixedUpdate()
    {
        //rBody2D.AddForce(new Vector2(playerInputHorizontal * playerSpeed, 0), ForceMode2D.Impulse);

        rBody2D.velocity = new Vector2(playerInputHorizontal * playerSpeed, rBody2D.velocity.y);
    }

    void PlayerMovement()
    {
        playerInputHorizontal= Input.GetAxis("Horizontal");

        if(playerInputHorizontal != 0)
        {
            animator.SetBool("IsRunning", true);
        }

        if(playerInputHorizontal == 0)
        {
            animator.SetBool("IsRunning", false);
        }
        /*playerInput2 = Input.GetAxis("Vertical");
        
        transform.Translate(new Vector2(playerInput, playerInput2) * playerSpeed * Time.deltaTime);*/
    }

    void Jump()
    {
         rBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
