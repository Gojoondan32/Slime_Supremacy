using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
    public float speed;
    public float distance;
    //public Transform groundDetection;
    public bool movingLeft = true;
    public bool movingRight = false;
    public GameObject player;
    public Rigidbody2D rb;
    public Rigidbody2D playerRigidbody;

    public GameManager scoreScript;

    public Transform slime;
    public WalkingScript respawn;
    [SerializeField] private GameObject cloudParticles;

    public Animator anim;

    public Transform groundDetection;
    // Start is called before the first frame update
    void Start()
    {
        
        

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        playerRigidbody = GameObject.Find("Slime").GetComponent<Rigidbody2D>();
    }
    
    public void FixedUpdate()
    {
        
        LayerMask mask = LayerMask.GetMask("Player");
        //If the player collides with the enemy above it, destroy the enemy
        if (Physics2D.Raycast(transform.position, transform.up, 1f, mask))
        {
            playerRigidbody.velocity = Vector2.up * 10f;
            Debug.Log("Works");
            Instantiate(cloudParticles, transform.position - Vector3.forward, Quaternion.identity);
            Destroy(gameObject);
            scoreScript.score = scoreScript.score + 100;
        }
        //If the player collides with the enemy from left or right, move the player to the last respawn
        else if(Physics2D.Raycast(transform.position, -Vector2.right, 1f, mask) || Physics2D.Raycast(transform.position, Vector2.right, 1f, mask))
        {

            slime.transform.position = respawn.respawnPoint;
            
        }
        
        
    }
    
   
    private void Update()
    {
        //Move enemy
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        anim.SetBool("isRunning", true);
        

        LayerMask waterMask = LayerMask.GetMask("Water");
        //If it collides with water, turn around
        if (Physics2D.Raycast(groundDetection.position, -Vector2.up, 1f, waterMask) && movingLeft == true)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = true;
            movingLeft = false;

        }
        else if (Physics2D.Raycast(groundDetection.position, -Vector2.up, 1f, waterMask) && movingRight == true)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingLeft = true;
            movingRight = false;
        }
    }

}
