using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Score variables
    public int score;
    public Text scoreTxt;

    
    

    //Time variables
    public float startingTime = 120f;
    public float currentTime = 0f;
    [SerializeField] Text countdownTxt;

    //Extra jumps reference
    public WalkingScript Jumps;
    [SerializeField] Text extraJumpsTxt;
    public int textJumpVariable;

    public PauseMenu gameOver;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        Jumps.extraJumps = textJumpVariable;
    }

    // Update is called once per frame
    void Update()
    {
        //Start the countdown
        currentTime -= 1 * Time.deltaTime;
        //Convert current time to a string variable
        countdownTxt.text = "Time: " + currentTime.ToString("0");

        //When timer reaches 0, load the main menu
        if (currentTime <= 0)
        {
            currentTime = 0;
            Debug.Log("Lose");
            SceneManager.LoadScene("Main Menu");
        }


        
        //Convert extra jumps to a string variable 
        
        extraJumpsTxt.text = "Extra Jumps: " + Jumps.extraJumps.ToString("0");
        
        //Convert score to string variable
        scoreTxt.text = score.ToString("Score: ") + score;

        

    }
    
}
