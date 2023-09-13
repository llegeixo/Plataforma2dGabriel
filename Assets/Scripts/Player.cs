using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float playerSpeed = 5;
    private float playerInput;
    private float playerInput2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       PlayerMovement();
    }

    void PlayerMovement()
    {
        playerInput = Input.GetAxis("Horizontal");
        playerInput2 = Input.GetAxis("Vertical");
        
        transform.Translate(new Vector2(playerInput, playerInput2) * playerSpeed * Time.deltaTime);
    }
}
