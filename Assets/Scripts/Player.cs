using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float playerSpeed = 5;
    [SerializeField]private float jumpForce = 5;
    private float playerInputHorizontal;
    //private float playerInputVertical;

    private Rigidbody2D rBody2D; 

    // Start is called before the first frame update
    void Start()
    {
        rBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       PlayerMovement();

       if(Input.GetButtonDown("Jump"))
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
        /*playerInput2 = Input.GetAxis("Vertical");
        
        transform.Translate(new Vector2(playerInput, playerInput2) * playerSpeed * Time.deltaTime);*/
    }

    void Jump()
    {
         rBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
