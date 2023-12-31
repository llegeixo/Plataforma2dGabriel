using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

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
    //private GroundSensor sensor;
    [SerializeField] private Animator animator;
    SpriteRenderer sRenderer;
    [SerializeField] private PlayableDirector _director;

    [SerializeField]AudioSource sfxAudioSource;

    [SerializeField]private AudioClip jumpSound;

    MenuManager _menuManager;

    // Start is called before the first frame update
    void Start()
    {
        rBody2D = GetComponent<Rigidbody2D>();
        //sensor = GetComponentInChildren<GroundSensor>();
        sRenderer = GetComponent<SpriteRenderer>();
        
        Debug.Log(GameManager.instance.vidas);

        sfxAudioSource = GetComponent<AudioSource>();

        _menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
    }

    // Update is called once per frame
    void Update()
    {
       PlayerMovement();

       if(Input.GetButtonDown("Jump") && GroundSensor.isGrounded)
       {
            Jump();
            animator.SetBool("IsJumping", true);
       }

       if(Input.GetButtonDown("Fire2"))
       {
        _director.Play();
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


        if(playerInputHorizontal < 0)
            {
                
                transform.rotation = Quaternion.Euler(0, 180, 0);
                animator.SetBool("IsRunning", true);
            }
            else if(playerInputHorizontal > 0)
            {
                //spriteRenderer.flipX = false;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                animator.SetBool("IsRunning", true);
            }
            else
            {
                animator.SetBool("IsRunning", false);

            }

        
        /*playerInput2 = Input.GetAxis("Vertical");
        
        transform.Translate(new Vector2(playerInput, playerInput2) * playerSpeed * Time.deltaTime);*/
    }

    void Jump()
    {
        rBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        sfxAudioSource.PlayOneShot(jumpSound);
    }

    public void SignalTest()
    {
        Debug.Log("Señal recibida");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("DeathZone"))
        {    
            SoundManager.instance.DeathSound();
            _menuManager.Lose();
        }
        
    }
}
