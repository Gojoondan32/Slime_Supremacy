using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    

    public WalkingScript playerScript;
    public GameManager scoreScript;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        playerScript.extraJumps = 1;
        Destroy(gameObject);
        scoreScript.score = scoreScript.score + 50;
    }
    /**
    public void FixedUpdate()
    {
        LayerMask playerMask = LayerMask.GetMask("Player");
        if (Physics2D.Raycast(transform.position, Vector2.up, 1f, playerMask))
        {
            playerScript.extraJumpValue = 2;
        }
    }
    **/
}
