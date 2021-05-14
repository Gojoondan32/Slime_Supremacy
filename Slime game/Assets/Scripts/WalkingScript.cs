using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WalkingScript : MonoBehaviour
{
    [Range (1, 20)]
    public int walkSpeed;
    public Rigidbody2D rb;

    [Range (1, 20)]
    public float jumpForce = 7;
    
    private float MoveInputH;
    private Animator anim;
    

    public Transform groundDetection;
    public LayerMask groundLayer;
    public float checkRadius;
    private bool isGrounded;

    

    public int extraJumps;

    public Vector3 respawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {

        respawnPoint = transform.position;
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        

        //Gives the player an extra jump
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            if(rb.velocity.y > 0 || rb.velocity.y < 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                extraJumps--;
            }
                
        }
        
        //Player jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;

        }

        //Does the player touch water
        if (touchingWater() == true)
        {
            transform.position = respawnPoint;
        }

        //Animator section
        if (rb.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }
        if(rb.velocity.y > 0)
        {
            anim.speed = 1;
            anim.SetBool("isJumping", true);
            
        }
        if(rb.velocity.y < 0)
        {
            anim.speed = 1;
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }
        if(isGrounded == true)
        {
            anim.SetBool("isLanding", true);
            
        }

        anim.SetBool("isLanding", false);
    }

    public bool isBounced;

    IEnumerator stopBounce()
    {
        yield return new WaitForSeconds(1f);
        isBounced = false;
    }
    public void startBounce()
    {
        isBounced = true;
        StartCoroutine("stopBounce");
    }
    public void FixedUpdate()
    {
        //Check if the player is grounded 
        isGrounded = Physics2D.OverlapCircle(groundDetection.position, checkRadius, groundLayer);


        //Player movement
        MoveInputH = Input.GetAxisRaw("Horizontal");
        if (!isBounced)
        {
            rb.velocity = new Vector2(MoveInputH * walkSpeed, rb.velocity.y);
        }
        

        if (MoveInputH > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (MoveInputH < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }
    private bool touchingWater()
    {
        if (GetComponent<BoxCollider2D>().IsTouchingLayers(LayerMask.GetMask("Water")))
        {
            
            return true;
            
        }
        return false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Set respawn point to the last checkpoint
        if(other.tag == "Checkpoint")
        {
            respawnPoint = other.transform.position;
        }
    }
}
