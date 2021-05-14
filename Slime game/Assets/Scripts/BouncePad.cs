using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public Rigidbody2D player;
    [Range(0, 100)]
    public float jumpForce = 5f;

    
    public float velocity = 10f;

    public void Start()
    {
        player = GameObject.Find("Slime").GetComponent<Rigidbody2D>();
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks what layer the player is colliding with to apply the appropriate force
        if (player.IsTouchingLayers(LayerMask.GetMask("BouncePad1")))
        {
            player.velocity = Vector2.up * 25f;
        }
        else if (player.IsTouchingLayers(LayerMask.GetMask("BouncePad2")))
        {
            player.velocity = Vector2.up * 30f;
        }
        else if (player.IsTouchingLayers(LayerMask.GetMask("BouncePad3")))
        {
            player.velocity = Vector2.up * 20f;
        }
        else if (player.IsTouchingLayers(LayerMask.GetMask("BouncePad4")))
        {
            //Reference start bounce function
            player.GetComponent<WalkingScript>().startBounce();
            player.AddForce(new Vector2(25f, 25f), ForceMode2D.Impulse);
            
            Debug.Log("Thing " + player.velocity);

        }
        else if (player.IsTouchingLayers(LayerMask.GetMask("BouncePad5")))
        {
            player.velocity = Vector2.up * 30f;
        }
    }
    

    
}
